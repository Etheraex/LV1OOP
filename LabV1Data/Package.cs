using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace LabV1Data
{
    public class Package : Object
    {
        #region Data

        private Item _info;
        private int _quantity;

        #endregion

        #region Properties

        [DisplayName("Product name")]
        public String ItemName
        {
            get { return _info.ItemName; }
        }

        [DisplayName("Unit price")]
        public double ItemPrice
        {
            get { return _info.Price; }
        }

        [DisplayName("Quantity")]
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        [Browsable(false)]
        public double PackagePrice
        {
            get { return _info.Price * _quantity; }
        }

        #endregion

        #region Constructors

        public Package(Item itemInfo, int quantity)
        {
            _info = itemInfo;
            _quantity = quantity;
        }
        
        public Package(String name,double price,int count)
        {
            _info = new Item(name, price);
            _quantity = count;
        }

        #endregion

        #region Methods

        public void SaveToFile(StreamWriter file)
        {
            _info.SaveToFile(file);
            file.WriteLine(_quantity);
        }

        public static Package ReadFromFile(StreamReader file)
        {
            Item info = Item.ReadFromFile(file);
            int quant = int.Parse(file.ReadLine());

            return new Package(info, quant);
        }

        #endregion
    }
}
