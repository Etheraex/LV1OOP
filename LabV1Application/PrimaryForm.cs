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

        private void btnImportList_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            OrderList.SingleInstance.LoadFromFile(openFileDialog1.FileName);
            dgvOrderList.DataSource = OrderList.SingleInstance.Orders.ToList();
        }

        private void btnExportList_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            OrderList.SingleInstance.SaveToFile(openFileDialog1.FileName);
        }
    }
}
