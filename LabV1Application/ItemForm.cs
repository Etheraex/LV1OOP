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

namespace LabV1Application
{
    public partial class ItemForm : Form
    {
        public ItemForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public String ItemName
        {
            get { return txtBoxName.Text.ToString(); }
        }

        public double ItemPrice
        {
            get { return double.Parse(txtBoxPrice.Text.ToString()); }
        }

        public int ItemQuantity
        {
            get { return int.Parse(txtBoxQuant.Text.ToString()); }
        }
    }
}
