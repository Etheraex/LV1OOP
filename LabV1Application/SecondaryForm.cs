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

        // odredjuje mod u kome je forma upaljena
        // true - za add
        // false - za edit
        bool add_edit;
        public Order orderTmp;
        int index;

        public SecondaryForm()
        {
            InitializeComponent();
            add_edit = true;
            comboBox1.Items.Add("Pending");
            comboBox1.Items.Add("Processing");
            comboBox1.Items.Add("Complete");
            comboBox1.SelectedIndex = 0;
        }

        public SecondaryForm(int selectedData)
        {
            InitializeComponent();
            add_edit = false;

            comboBox1.Items.Add("Pending");
            comboBox1.Items.Add("Processing");
            comboBox1.Items.Add("Complete");
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
            index = selectedData;
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            int idTmp;
            DateTime orderDateTmp;
            DateTime requiredDateTmp;
            bool error = false;

            try
            {
                if (!int.TryParse(txtBoxOrderID.Text, out idTmp) || txtBoxOrderID.Text.Length != 8)
                {
                    txtBoxOrderID.ForeColor = Color.Red;
                    error = true;
                }
                if (!DateTime.TryParse(txtBoxOrderDate.Text, out orderDateTmp))
                {
                    txtBoxOrderDate.ForeColor = Color.Red;
                    error = true;
                }
                if (!DateTime.TryParse(txtBoxDateRequired.Text, out requiredDateTmp))
                {
                    txtBoxDateRequired.ForeColor = Color.Red;
                    error = true;
                }
                if (txtBoxShipVia.Text == "")
                {
                    txtBoxShipVia.BackColor = Color.Red;
                    error = true;
                }
                if (error)
                    throw new Exception("Pogresno popunjena forma!");
                else if (add_edit)
                {
                    String shipTmp = txtBoxShipVia.Text;
                    double frgtTmp = double.Parse(txtBoxFreightCharges.Text);
                    State stTmp = Order.ConvertStringToState(comboBox1.SelectedItem.ToString());
                    String cstName = rchTxtBoxCustomer.Lines[0];
                    String cstAddress = rchTxtBoxCustomer.Lines[1];
                    String cstCountry = rchTxtBoxCustomer.Lines[2];
                    Customer cstTmp = new Customer(cstName,cstAddress,cstCountry);
                    PackageList pckListTmp = new PackageList();
                    String itmName="";
                    double itmPrice = 1;
                    int itmCount = 1;
                    for (int i = 0; i < dgvPackageList.Rows.Count-1; i++)
                    {
                        itmName = dgvPackageList.Rows[i].Cells[0].Value.ToString();
                        itmPrice = double.Parse(dgvPackageList.Rows[i].Cells[1].Value.ToString());
                        itmCount = int.Parse(dgvPackageList.Rows[i].Cells[2].Value.ToString());
                        pckListTmp.AddPackage(new Package(itmName,itmCount, itmCount));
                    }

                    orderTmp = new Order(idTmp, orderDateTmp, requiredDateTmp, frgtTmp, stTmp, cstTmp, pckListTmp, shipTmp);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    String shipTmp = txtBoxShipVia.Text;
                    double frgtTmp = double.Parse(txtBoxFreightCharges.Text);
                    State stTmp = Order.ConvertStringToState(comboBox1.SelectedItem.ToString());
                    String cstName = rchTxtBoxCustomer.Lines[0];
                    String cstAddress = rchTxtBoxCustomer.Lines[1];
                    String cstCountry = rchTxtBoxCustomer.Lines[2];
                    Customer cstTmp = new Customer(cstName, cstAddress, cstCountry);
                    PackageList pckListTmp = new PackageList();
                    String itmName = "";
                    double itmPrice = 1;
                    int itmCount = 1;
                    for (int i = 0; i < dgvPackageList.Rows.Count - 1; i++)
                    {
                        itmName = dgvPackageList.Rows[i].Cells[0].Value.ToString();
                        itmPrice = double.Parse(dgvPackageList.Rows[i].Cells[1].Value.ToString());
                        itmCount = int.Parse(dgvPackageList.Rows[i].Cells[2].Value.ToString());
                        pckListTmp.AddPackage(new Package(itmName, itmCount, itmCount));
                    }

                    orderTmp = new Order(idTmp, orderDateTmp, requiredDateTmp, frgtTmp, stTmp, cstTmp, pckListTmp, shipTmp);
                    OrderList.SingleInstance.ReplaceItem(index, orderTmp);
                    this.Close();

                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
