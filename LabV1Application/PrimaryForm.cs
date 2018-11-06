using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabV1Data;
using System.IO;

namespace LabV1Application
{
    public partial class PrimaryForm : Form
    {
        #region Init

        public static Order orderTmp;

        public PrimaryForm()
        {
            InitializeComponent();
        }

        #endregion

        #region FilterPanel

        private void btnFilter_Click(object sender, EventArgs e)
        {
            
            // Pocetne vrednosti u slucaju da neki od filtera nije postavljen
            int idTmp = 1;
            DateTime dateFromTmp = DateTime.MinValue;
            DateTime dateToTmp = DateTime.MaxValue;

            if (dtpDateFrom.Checked)
                dateFromTmp = DateTime.Parse(dtpDateFrom.Value.ToString());
            if (dtpDateTo.Checked)
                dateToTmp = DateTime.Parse(dtpDateTo.Value.ToString());

            try
            {
                if (txtBoxOrderID.Text != "OrderID" && !int.TryParse(txtBoxOrderID.Text, out idTmp))
                    throw new Exception("Pogresan format ID-a");

                if (dateFromTmp > dateToTmp)
                    throw new Exception("Pocetni datum veci od krajnjeg");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Greska pri izvrsenju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Ponovno dodeljivanje datasource-a sa uslovom da podaci ispunjavaju ogranicenja 
            // postavljena filterima
            dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList().Where(x => x.IsEqual(idTmp, dateFromTmp, dateToTmp, cmbState.SelectedItem)).ToList();
        }

        // Brisanje postavljenih vrednosti za filtere i vracanje prvobitne liste u DataGridView
        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            txtBoxOrderID.Text = "OrderID";
            dtpDateFrom.Checked = false;
            dtpDateTo.Checked = false;
            cmbState.SelectedItem = null;

            dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList();
        }

        #endregion

        #region OnItemPanel

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SecondaryForm blankForm = new SecondaryForm();
            DialogResult dr = blankForm.ShowDialog();
            if ( dr == DialogResult.OK)
            {
                OrderList.SingleInstance.AddOrder(orderTmp);
                dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderList.SelectedRows.Count == 1)
                {
                    int i = 0;
                    for (; i < OrderList.SingleInstance.Orders.Count; i++)
                        if (int.Parse(dgvOrderList.SelectedRows[0].Cells[0].Value.ToString()) == OrderList.SingleInstance.Orders[i].OrderId)
                            break;

                    SecondaryForm blankForm = new SecondaryForm(i);
                    DialogResult dr = blankForm.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        OrderList.SingleInstance.ReplaceOrder(i, orderTmp);
                        dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList();
                    }
                }
                else if (dgvOrderList.SelectedRows.Count == 0)
                    throw new Exception("Nije selektovan nijedan red");
                else
                    throw new Exception("Selektovano previse redova");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,"Greska pri izvrsenju",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        // Brisanje selektovanih redova u DataGrida
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderList.SelectedRows.Count != 0)
                {
                    // U listi su zapamceni svi indeksi selektovanih redova
                    List<int> tmpIndexes = new List<int>();
                    for (int i = 0; i < dgvOrderList.SelectedRows.Count; i++)
                        tmpIndexes.Add(dgvOrderList.SelectedRows[i].Index);
                    // Sortiranje indeksa u opadajuci redosled kako bi brisanje
                    // krenulo od kraja liste kako ne bi poremetilo redosled
                    tmpIndexes.Sort((a, b) => -1 * a.CompareTo(b));
                    foreach (int i in tmpIndexes)
                        OrderList.SingleInstance.RemoveOrderAt(i);

                    // Ponovno dodeljivanje datasource-a kako bi se refresovali podaci u datagrid-u
                    dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList();
                }
                else
                    throw new Exception("Nije selektovan nijedan red za brisanje");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Greska pri izvrsenju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            StatusChange("Pending");
        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            StatusChange("Processing");
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            StatusChange("Complete");
        }

        // Exportovanje selektovanih redova u fajl
        private void btnExportItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderList.SelectedRows.Count != 0)
                {
                    DialogResult dr = openFileDialog1.ShowDialog();
                    if (dr == DialogResult.OK)
                        using (StreamWriter file = new StreamWriter(openFileDialog1.FileName))
                        {
                            for (int i = 0; i < dgvOrderList.SelectedRows.Count; i++)
                                OrderList.SingleInstance.Orders[dgvOrderList.SelectedRows[i].Index].SaveOrderToFile(file);
                        }
                }
                else
                    throw new Exception("Nije selektovan red za exportovanje");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Greska pri izvrsenju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region OnListPanel

        // Ucitavanje celog fajla u listu i prikaz u datagrid 
        private void btnImportList_Click(object sender, EventArgs e)
        {
            OrderList.SingleInstance.RemoveAllOrders();
            DialogResult dr = openFileDialog1.ShowDialog();
            if(dr == DialogResult.OK)
                using (StreamReader file = new StreamReader(openFileDialog1.FileName))
                {
                    OrderList.SingleInstance.LoadFromFile(file);
                    dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList();
                }
        }

        // Ispisivanje celog trenutnog datagrida u fajl
        private void btnExportList_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderList.Rows.Count == 0)
                    throw new Exception("Ne postoji nijedan red za exportovanje");
                else
                {
                    DialogResult dr = openFileDialog1.ShowDialog();
                    if (dr == DialogResult.OK)
                        using (StreamWriter file = new StreamWriter(openFileDialog1.FileName))
                        {
                            List<int> tmp = new List<int>();
                            for (int i = 0; i < dgvOrderList.RowCount; i++)
                                tmp.Add(int.Parse(dgvOrderList.Rows[i].Cells[0].Value.ToString()));
                            foreach (Order o in OrderList.SingleInstance.Orders)
                                if (tmp.Contains(o.OrderId))
                                    o.SaveOrderToFile(file);
                        }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Greska pri izvrsenju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        #endregion

        #region AdditionalMethodsEventHandlers

        // Funkcija za menjanje stanja selektovanih vrednosti u DataGrid-u
        private void StatusChange(string newValue)
        {
            try
            {
                // Resava promenu stanja ukoliko je selektovan ceo red za koji menjamo stanje
                if (dgvOrderList.SelectedRows.Count != 0)
                    for (int i = 0; i < dgvOrderList.SelectedRows.Count; i++)
                        dgvOrderList.SelectedRows[i].Cells[5].Value = newValue;

                // Resava promenu ako je selektovana neka celija u redu, nezavisno od toga koja celija je selektovana 
                // u tom redu vrednost celije stanja ce se promeniti 
                else if (dgvOrderList.SelectedCells.Count != 0)
                    for (int i = 0; i < dgvOrderList.SelectedCells.Count; i++)
                        dgvOrderList.Rows[dgvOrderList.SelectedCells[i].RowIndex].Cells[5].Value = newValue;
                else
                    throw new Exception("Nije selektovan nijedan red za promenu stanja");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Greska pri izvrsenju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nakon importovanja prva celija u prvom redu je po defaultu selektovana
        // ovim se brise ta selekcija
        private void dgvOrderList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvOrderList.ClearSelection();
        }

        #endregion
    }
}
