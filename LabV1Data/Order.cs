using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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
        public DateTime PurchasedOn
        {
            get { return _purchasedOn; }
            set { _purchasedOn = value; }
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
        public DateTime RequiredBefore
        {
            get { return _requiredBefore; }
            set { _requiredBefore = value; }
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
        public List<Package> PackageInfo
        {
            get { return _packages.Packages; }
        }

        #endregion 

        #region Constructors

        public Order()
        {

        }

        public Order(int id, DateTime orderDate, DateTime requiredDate, double freightCharges, State stat, Customer cust, PackageList packages, String shipCo)
        {
            _orderId = id;
            _purchasedOn = orderDate;
            _status = stat;
            _customerInfo = cust;
            _packages = packages;
            _requiredBefore = requiredDate;
            _freightCharges = freightCharges;
            _shippingCo = shipCo;
        }

        #endregion

        #region Methods
        
        public override string ToString()
        {
            return _orderId + " " + _purchasedOn + " " + _requiredBefore + " " + _freightCharges + " " + _status + "\r\n" + _shippingCo;
        }

        public bool IsInTimeFrame(DateTime dateFromTmp, DateTime dateToTmp)
        {
            return ( (_purchasedOn >= dateFromTmp) && (_purchasedOn <= dateToTmp) ) ? true : false;
        }

        public bool CheckId(int x)
        {
            return (_orderId == x) ? true : false;
        }

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
                    break;
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
            String skip = file.ReadLine();
            String loadString = file.ReadLine();
            String shipCoTmp = file.ReadLine();
            String[] splitStrings;
            int idTmp;
            DateTime dateTmp;
            DateTime dateReqTmp;
            double freightTmp;
            State statusTmp = State.Pending;

            splitStrings = loadString.Split(' ');

            idTmp = int.Parse(splitStrings[0]);
            dateTmp = DateTime.ParseExact(splitStrings[1] + " " + splitStrings[2], "M/dd/yyyy H:mm:ss", null);
            dateReqTmp = DateTime.ParseExact(splitStrings[4] + " " + splitStrings[5], "M/dd/yyyy H:mm:ss", null);
            freightTmp = double.Parse(splitStrings[7]);
            statusTmp = Order.ConvertStringToState(splitStrings[8]);

            Customer customerTmp = Customer.ReadFromFile(file);
            PackageList packagesTmp = PackageList.ReadFromFile(file);

            Order orderTmp = new Order(idTmp, dateTmp,dateReqTmp ,freightTmp, statusTmp, customerTmp, packagesTmp, shipCoTmp);
            return orderTmp;
        }

        #endregion
    }
}
