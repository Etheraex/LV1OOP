using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            comboBox1.Items.Add("Pending");
            comboBox1.Items.Add("Processing");
            comboBox1.Items.Add("Complete");
            comboBox1.Visible = false;
            comboBox1.SelectedIndex = 0;
        }

        public SecondaryForm(int selectedData)
        {
            InitializeComponent();

            comboBox1.Items.Add("Pending");
            comboBox1.Items.Add("Processing");
            comboBox1.Items.Add("Complete");
            txtBoxOrderID.Text = OrderList.SingleInstance.Orders[selectedData].OrderId.ToString();
            txtBoxOrderDate.Text = OrderList.SingleInstance.Orders[selectedData].PurchasedOn;

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

            txtBoxDateRequired.Text = OrderList.SingleInstance.Orders[selectedData].RequiredBefore;
            txtBoxShipVia.Text = OrderList.SingleInstance.Orders[selectedData].ShippingCo;

            if(OrderList.SingleInstance.Orders[selectedData].FreightCharges != 0)
                txtBoxFreightCharges.Text = OrderList.SingleInstance.Orders[selectedData].FreightCharges.ToString();

            rchTxtBoxCustomer.Text = OrderList.SingleInstance.Orders[selectedData].CustomerInfo;
            dgvPackageList.DataSource = OrderList.SingleInstance.Orders[selectedData].PackageInfo.Packages;

            if (OrderList.SingleInstance.Orders[selectedData].ShippedDate != DateTime.MinValue.ToString("d.M.yyyy"))
                txtBoxDateShipped.Text = OrderList.SingleInstance.Orders[selectedData].ShippedDate;
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            int x = ReadData();
            if (x == 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (x == 1)
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int ReadData()
        {
            int idTmp;
            DateTime orderDateTmp;
            DateTime requiredDateTmp;
            bool error = false;
            int successful = 0;

            if (!int.TryParse(txtBoxOrderID.Text, out idTmp) || txtBoxOrderID.Text.Length != 8)
            {
                txtBoxOrderID.ForeColor = Color.Red;
                error = true;
            }
            if (!DateTime.TryParseExact(txtBoxOrderDate.Text, "d.M.yyyy", null, DateTimeStyles.None, out orderDateTmp))
            {
                txtBoxOrderDate.ForeColor = Color.Red;
                error = true;
            }
            if (!DateTime.TryParseExact(txtBoxDateRequired.Text, "d.M.yyyy", null, DateTimeStyles.None, out requiredDateTmp))
            {
                txtBoxDateRequired.ForeColor = Color.Red;
                error = true;
            }
            if (txtBoxShipVia.Text == "")
            {
                txtBoxShipVia.BackColor = Color.Red;
                error = true;
            }
            try
            {
                if (error)
                    throw new Exception("Pogresno popunjena forma!");

                String shipTmp = txtBoxShipVia.Text;
                double frgtTmp;
                if (!double.TryParse(txtBoxFreightCharges.Text, out frgtTmp))
                    frgtTmp = 0;
                State stTmp = Order.ConvertStringToState(comboBox1.SelectedItem.ToString());

                if (rchTxtBoxCustomer.Lines.Count() != 3)
                    throw new Exception("Pogresan format podataka o kupcu");

                String cstName = rchTxtBoxCustomer.Lines[0];
                String cstAddress = rchTxtBoxCustomer.Lines[1];
                String cstCountry = rchTxtBoxCustomer.Lines[2];

                Customer cstTmp = new Customer(cstName, cstAddress, cstCountry);
                DateTime dateShipped;
                if (!DateTime.TryParseExact(txtBoxDateShipped.Text, "d.M.yyyy", null, DateTimeStyles.None, out dateShipped))
                    dateShipped = DateTime.MinValue;
                PackageList pckListTmp = new PackageList();
                String itmName = "";
                double itmPrice = 1;
                int itmCount = 1;

                // Posto datagridview ima properti da korisnik moze da dodaje redove
                // uvek ce da postoji jedan prazan red visak
                // zato ako smo u add modu petlja mora da ide do Count - 1
                // posto taj red ne postoji u edit modu ide do Count
                int max = 0;
                if (comboBox1.Visible)                  // Ukoliko je comboBox1 vidljiv znaci da smo u edit modu
                    max = dgvPackageList.Rows.Count;
                else
                    max = dgvPackageList.Rows.Count - 1;

                if (max <= 0)
                    throw new Exception("Nije dodat nijedan Item u listu");

                for (int i = 0; i < max; i++)
                {
                    itmName = dgvPackageList.Rows[i].Cells[0].Value.ToString();
                    itmPrice = double.Parse(dgvPackageList.Rows[i].Cells[1].Value.ToString());
                    itmCount = int.Parse(dgvPackageList.Rows[i].Cells[2].Value.ToString());
                    pckListTmp.AddPackage(new Package(itmName, itmPrice, itmCount));
                }

                PrimaryForm.orderTmp = new Order(idTmp, orderDateTmp, requiredDateTmp, stTmp, cstTmp, pckListTmp, shipTmp, frgtTmp, dateShipped);
            }
            catch(Exception exc)
            {
                DialogResult dr = MessageBox.Show(exc.Message, "Greska pri izvrsenju", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Cancel)
                    successful = 1;
                else
                    successful = 2;
            }
            return successful;
        }
    }
}
