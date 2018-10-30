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

namespace LabV1Application
{
    public partial class PrimaryForm : Form
    {
        #region Init

        public PrimaryForm()
        {
            InitializeComponent();
        }

        #endregion

        #region FilterPanel

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int idTmp = 1;
            DateTime dateFromTmp = new DateTime(2000, 01, 01);
            DateTime dateToTmp = DateTime.Now;
            try
            {
                // Ispitivanja validnosti unesenih parametara za pretragu 
                // i ispitivanje da li je nekom parametru ostavljena defaultna vrednost
                // u kom slucaju se prihvataju sve vrednosti za taj parametar
                if (txtBoxOrderID.Text != "OrderID" && !int.TryParse(txtBoxOrderID.Text, out idTmp))
                    throw new Exception("Pogresan format ID-a");
                if (txtBoxDateFrom.Text != "MM/DD/YYYY" && !DateTime.TryParse(txtBoxDateFrom.Text, out dateFromTmp))
                    throw new Exception("Pogresan format prvog datuma");
                if (txtBoxDateTo.Text != "MM/DD/YYYY" && !DateTime.TryParse(txtBoxDateTo.Text, out dateToTmp))
                    throw new Exception("Pogresan format drugog datuma");

                dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList().Where(x => x.IsEqual(idTmp, dateFromTmp, dateToTmp, cmbState.SelectedItem)).ToList();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Brisanje postavljenih vrednosti za filtere i vracanje prvobitne liste u DataGridView
        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            txtBoxOrderID.Text = "OrderID";
            txtBoxDateTo.Text = "MM/DD/YYYY";
            txtBoxDateFrom.Text = "MM/DD/YYYY";
            cmbState.SelectedItem = null;

            dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList();
        }

        #endregion

        #region OnItemPanel

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SecondaryForm blankForm = new SecondaryForm();
            blankForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvOrderList.SelectedRows.Count != 0)
            {
                SecondaryForm blankForm = new SecondaryForm();
                blankForm.Show();
            }
        }

        // Brisanje selektovanih redova u DataGrida
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // U listi su zapamceni svi indeksi selektovanih redova
            List<int> tmpIndexes= new List<int>();
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
            if (dgvOrderList.SelectedRows.Count != 0)
            {
                openFileDialog1.ShowDialog();
                string fileName = openFileDialog1.FileName;
                for (int i = 0; i < dgvOrderList.SelectedRows.Count; i++)
                    OrderList.SingleInstance.Orders[dgvOrderList.SelectedRows[i].Index].SaveOrderToFile(fileName);
            }
        }

        #endregion

        #region OnListPanel

        // Ucitavanje celog fajla u listu i prikaz u datagrid 
        private void btnImportList_Click(object sender, EventArgs e)
        {
            OrderList.SingleInstance.RemoveAllOrders();
            openFileDialog1.ShowDialog();
            OrderList.SingleInstance.LoadFromFile(openFileDialog1.FileName);
            dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList();
        }

        // Ispisivanje celog trenutnog datagrida u fajl
        private void btnExportList_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(openFileDialog1.FileName))
            {
                for (int i = 0; i < dgvOrderList.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvOrderList.ColumnCount; j++)
                        file.Write(dgvOrderList.Rows[i].Cells[j].Value.ToString() + " ");
                    file.WriteLine();
                }

            }
        }

        #endregion

        #region AdditionalMethodsEventHandlers

        // Funkcija za menjanje stanja selektovanih vrednosti u DataGrid-u
        private void StatusChange(string newValue)
        {
            // Resava promenu stanja ukoliko je selektovan ceo red za koji menjamo stanje
            if (dgvOrderList.SelectedRows.Count != 0)
                for (int i = 0; i < dgvOrderList.SelectedRows.Count; i++)
                    dgvOrderList.SelectedRows[i].Cells[5].Value = newValue;

            // Resava promenu ako je selektovana neka celija u redu, nezavisno od toga koja celija je selektovana 
            // u tom redu vrednost celije stanja ce se promeniti 
            if (dgvOrderList.SelectedCells.Count != 0)
                for (int i = 0; i < dgvOrderList.SelectedCells.Count; i++)
                    dgvOrderList.Rows[dgvOrderList.SelectedCells[i].RowIndex].Cells[5].Value = newValue;
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
