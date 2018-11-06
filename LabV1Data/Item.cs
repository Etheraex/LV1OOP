using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LabV1Data
{
    public class Item
    {
        #region Data

        private String _name;
        private double _price;

        #endregion

        #region Properties

        public String ItemName
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        #endregion

        #region Constructors

        public Item(String name, double price)
        {
            _name = name;
            _price = price;
        }

        #endregion

        #region Methods

        public void SaveToFile(StreamWriter file)
        {
            file.WriteLine(_name);
            file.WriteLine(_price);
        }

        public static Item ReadFromFile(StreamReader file)
        {
            String nameTmp = file.ReadLine();
            double priceTmp = double.Parse(file.ReadLine());

            return new Item(nameTmp,priceTmp);
        }

        #endregion

    }
}
