using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabV1Data
{
    public class Customer : Object
    {
        #region Data

        private String _name;
        private String _streetAddress;
        private String _cityCountry;

        #endregion

        #region Properties

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public String StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value; }
        }

        public String CityCountry
        {
            get { return _cityCountry; }
            set { _cityCountry = value; }
        }

        #endregion

        public Customer(String nameP, String addressP, String cityP)
        {
            _name = nameP;
            _streetAddress = addressP;
            _cityCountry = cityP;
        }

        public override string ToString()
        {
            return _name + "\r\n"+_streetAddress + "\r\n" + _cityCountry;
        }

        public static Customer ReadCustomerFromFile(System.IO.StreamReader file)
        {
            String nameTmp = file.ReadLine();
            String addressTmp = file.ReadLine();
            String countryTmp = file.ReadLine();

            return new Customer(nameTmp, addressTmp, countryTmp);
        }

    }
}
