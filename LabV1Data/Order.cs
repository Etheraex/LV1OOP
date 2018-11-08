using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace LabV1Data
{
    public enum State
    {
        Pending,
        Processing,
        Complete
    }
    
    public class Order : Object
    {
        #region Data

        private int _orderId;
        private DateTime _purchasedOn;
        private Customer _customerInfo;
        private PackageList _packages;
        private State _status;
        private DateTime _requiredBefore;
        private DateTime _shippedOn;
        private String _shippingCo;
        private double _freightCharges;


        #endregion

        #region Properties

        [DisplayName("Order#")]
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        [DisplayName("Purchased on")]
        public String PurchasedOn
        {
            get { return _purchasedOn.ToString("d.M.yyyy"); }
        }

        [DisplayName("Bill to name")]
        public String BillToName
        {
            get { return _customerInfo.Name; }
        }

        [DisplayName("Ship to name")]
        public String ShipToName
        {
            get { return _customerInfo.Name; }
        }

        [DisplayName("Income")]
        public String Income
        {
            get
            {
                return "$ "+_packages.Price.ToString();
            }
        }

        [DisplayName("Status")]
        public State Status
        {
            get { return _status; }
            set { _status = value; }
        }

        [Browsable(false)]
        public String CustomerInfo
        {
            get
            {
                return _customerInfo.ToString();
            }
        }

        [Browsable(false)]
        public String RequiredBefore
        {
            get { return _requiredBefore.ToString("d.M.yyyy"); }
        }

        [Browsable(false)]
        public String ShippingCo
        {
            get { return _shippingCo; }
            set { _shippingCo = value; }
        }

        [Browsable(false)]
        public double FreightCharges
        {
            get { return _freightCharges; }
            set { _freightCharges = value; }
        }

        [Browsable(false)]
        public PackageList PackageInfo
        {
            get { return _packages; }
        }

        [Browsable(false)]
        public String ShippedDate
        {
            get
            {
                if (_shippedOn == DateTime.MinValue)
                    return "";
                else
                    return _shippedOn.ToString("d.M.yyyy");
            }
        }

        #endregion 

        #region Constructors

        public Order()
        {

        }

        public Order(int id, DateTime orderDate, DateTime requiredDate, State stat, Customer cust, PackageList packages, String shipCo, double freightCharges, DateTime shippedOn)
        {
            _orderId = id;
            _purchasedOn = orderDate;
            _status = stat;
            _customerInfo = cust;
            _packages = packages;
            _requiredBefore = requiredDate;
            _freightCharges = freightCharges;
            _shippingCo = shipCo;
            _shippedOn = shippedOn;
        }

        #endregion

        #region Methods
        
        public override string ToString()
        {
            if(_freightCharges != 0 && _shippedOn != DateTime.MinValue)
                return _orderId + " " + _purchasedOn.ToString("d.M.yyyy") + " " + _requiredBefore.ToString("d.M.yyyy") + " " + _status + "\r\n"+ _shippedOn.ToString("d.M.yyyy") + "\r\n" + _shippingCo + "\r\n" + _freightCharges;
            else
                return _orderId + " " + _purchasedOn.ToString("d.M.yyyy") + " " + _requiredBefore.ToString("d.M.yyyy") + " " + _status + "\r\n" + "\r\n" + _shippingCo + "\r\n" ;
        }

        public bool IsInTimeFrame(DateTime dateFromTmp, DateTime dateToTmp)
        {
            return ( (_purchasedOn >= dateFromTmp) && (_purchasedOn <= dateToTmp) ) ? true : false;
        }
        
        public bool CheckId(int x)
        {
            return (_orderId == x) ? true : false;
        }

        // Jedna funkcija koja obuhvata sve provere prilikom filtriranja ordera
        // ukoliko je neki od prosledjenih parametara null za tu kategoriju propusta sve
        // postojece vrednosti tj ukoliko jedan od filtera nije postavljen
        public bool IsEqual(int idTmp,DateTime dateFromTmp,DateTime dateToTmp, Object statusObj)
        {
            bool condition1 = true;
            bool condition2 = true;

            if (statusObj != null) {
                State statusTmp = ConvertStringToState(statusObj.ToString());
                condition1 = (_status == statusTmp) ? true : false;
            }

            if ( idTmp != 1)
            {
                condition2 = CheckId(idTmp);
            }

            return condition1 && condition2 && IsInTimeFrame(dateFromTmp, dateToTmp);
        }

        public static State ConvertStringToState(string statusTmp)
        {
            State toReturn = State.Pending;
            switch (statusTmp)
            {
                case "Pending":
                    toReturn = State.Pending;
                    break;
                case "Processing":
                    toReturn = State.Processing;
                    break;
                case "Complete":
                    toReturn = State.Complete;
                    break;
                default:
                    throw new Exception("Nedefinisana vrednost za Status!");
            }
            return toReturn;
        }

        public void SaveOrderToFile(System.IO.StreamWriter file)
        {
            file.WriteLine("==========================================================================");
            file.WriteLine(this.ToString());
            _customerInfo.SaveToFile(file);
            _packages.SaveToFile(file);
        }

        public static Order ReadOrderFromFile(System.IO.StreamReader file)
        {
            try
            {
                String skip = file.ReadLine();                  // Linija sa znakovima jednakosti za razdvajanje pojedinacnih ordera
                String loadString = file.ReadLine();
                String[] splitStrings = loadString.Split(' ');

                int idTmp;
                int tmp = CheckId(splitStrings[0]);
                if (tmp == 0)
                    throw new Exception("Pogresna id vrednost");
                else
                    idTmp = tmp;

                DateTime dateTmp = DateTimeFromString(splitStrings[1]);
                DateTime dateReqTmp = DateTimeFromString(splitStrings[2]);

                if (dateTmp == DateTime.MinValue || dateReqTmp == DateTime.MinValue || dateReqTmp < dateTmp)
                    throw new Exception("Pogresna vrednost datuma");

                State statusTmp = Order.ConvertStringToState(splitStrings[3]);

                DateTime dateShipped;
                double freightCostTmp;

                if (!DateTime.TryParseExact(file.ReadLine(), "d.M.yyyy", null, DateTimeStyles.None, out dateShipped))
                    dateShipped = DateTime.MinValue;

                String shipCompanyTmp = file.ReadLine();
                if (!double.TryParse(file.ReadLine(), out freightCostTmp))
                    freightCostTmp = 0;

                Customer customerTmp = Customer.ReadFromFile(file);
                PackageList packagesTmp = PackageList.ReadFromFile(file);

                Order orderTmp = new Order(idTmp, dateTmp, dateReqTmp, statusTmp, customerTmp, packagesTmp, shipCompanyTmp, freightCostTmp, dateShipped);
                return orderTmp;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Greska pri izvrsenju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public static DateTime DateTimeFromString(String input)
        {
            DateTime output;
            if (!DateTime.TryParseExact(input, "d.M.yyyy", null, DateTimeStyles.None, out output))
                output = DateTime.MinValue;
            return output;
        }

        // Provera validnosti zadate vrednosti za ID
        // vraca ucitanu vrednost u int obliku ukoliko ima tacno 8 karaktera
        public static int CheckId(String input)
        {
            int output;
            if (input.Length != 8 || !int.TryParse(input, out output))
                output = 0;
            return output;
        }

        #endregion
    }
}
