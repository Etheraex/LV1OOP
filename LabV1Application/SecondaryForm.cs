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
    public partial class SecondaryForm : Form
    {
        #region Init

        public SecondaryForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        public SecondaryForm(int selectedData)
        {
            InitializeComponent();
            txtBoxOrderID.Text = OrderList.SingleInstance.Orders[selectedData].OrderId.ToString();
            txtBoxOrderDate.Text = OrderList.SingleInstance.Orders[selectedData].PurchasedOn.ToString();
            switch (OrderList.SingleInstance.Orders[selectedData].Status.ToString())
            {
                case "Pending":
                    comboBox1.SelectedIndex = 0;
                    break;
                case "Processing":
                    comboBox1.SelectedIndex = 1;
                    break;
                case "Complete":
                    comboBox1.SelectedIndex = 2;
                    break;
            }
            txtBoxDateRequired.Text = OrderList.SingleInstance.Orders[selectedData].RequiredBefore.ToString();
            txtBoxShipVia.Text = OrderList.SingleInstance.Orders[selectedData].ShippingCo;
            txtBoxFreightCharges.Text = OrderList.SingleInstance.Orders[selectedData].FreightCharges.ToString();
            rchTxtBoxCustomer.Text = OrderList.SingleInstance.Orders[selectedData].CustomerInfo;
            dgvPackageList.DataSource = OrderList.SingleInstance.Orders[selectedData].PackageInfo;
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
