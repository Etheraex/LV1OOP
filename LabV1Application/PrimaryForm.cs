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
        public PrimaryForm()
        {
            InitializeComponent();
        }

        // Ucitavanje celog fajla u listu i prikaz u datagrid 
        private void btnImportList_Click(object sender, EventArgs e)
        {
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int idTmp = 1;
            DateTime dateFromTmp = new DateTime(2000,01,01);
            DateTime dateToTmp = DateTime.Now;
            try
            {
                if (txtBoxOrderID.Text != "OrderID" && !int.TryParse(txtBoxOrderID.Text, out idTmp))
                    throw new Exception("Pogresan format ID-a");
                if (txtBoxDateFrom.Text != "MM/DD/YYYY" && !DateTime.TryParse(txtBoxDateFrom.Text, out dateFromTmp))
                    throw new Exception("Pogresan format prvog datuma");
                if (txtBoxDateTo.Text != "MM/DD/YYYY" && !DateTime.TryParse(txtBoxDateTo.Text, out dateToTmp))
                    throw new Exception("Pogresan format drugog datuma");

                dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList().Where(x => x.IsEqual( idTmp, dateFromTmp, dateToTmp, cmbState.SelectedItem) ).ToList();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            txtBoxOrderID.Text = "OrderID";
            txtBoxDateTo.Text = "MM/DD/YYYY";
            txtBoxDateFrom.Text = "MM/DD/YYYY";
            cmbState.SelectedItem = null;

            dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList();
        }
    }
}
