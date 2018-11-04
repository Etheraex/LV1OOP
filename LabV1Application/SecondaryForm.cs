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

        List<Package> temp = new List<Package>();

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
            txtBoxDateShipped.Text = OrderList.SingleInstance.Orders[selectedData].ShippedDate.ToString();
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            int idTmp;
            DateTime orderDateTmp;
            DateTime requiredDateTmp;



            if (!int.TryParse(txtBoxOrderID.Text, out idTmp) || txtBoxOrderID.Text.Length != 8)
                txtBoxOrderID.ForeColor = Color.Red;
            if (!DateTime.TryParse(txtBoxOrderDate.Text, out orderDateTmp))
                txtBoxOrderDate.ForeColor = Color.Red;
            if (!DateTime.TryParse(txtBoxDateRequired.Text, out requiredDateTmp))
                txtBoxDateRequired.ForeColor = Color.Red;
            if (txtBoxShipVia.Text == "")
                txtBoxShipVia.BackColor = Color.Red;


            //this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            using (ItemForm a = new ItemForm())
            {
                if (a.ShowDialog() == DialogResult.OK)
                {
                    String nameTmp = a.ItemName;
                    double priceTmp = a.ItemPrice;
                    int quantTmp = a.ItemQuantity;
                    Package packageTmp = new Package(new Item(nameTmp, priceTmp), quantTmp);
                    temp.Add(packageTmp);
                    dgvPackageList.DataSource = temp;
                }
            }
        }
    }
}
