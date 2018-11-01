using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Customer _customer;
        private double _income;
        private State _status;

        #endregion

        #region Properties

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        public DateTime PurchasedOn
        {
            get { return _purchasedOn; }
            set { _purchasedOn = value; }
        }

        public String BillToName
        {
            get { return _customer.Name; }
        }

        public String ShipToName
        {
            get { return _customer.Name; }
        }

        public double Income
        {
            get { return _income;}
            set { _income = value; }
        }

        public State Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion 

        #region Constructors

        public Order()
        {

        }

        public Order(int id, DateTime orderDate, double inc, State stat, Customer cust)
        {
            _orderId = id;
            _purchasedOn = orderDate;
            _income = inc;
            _status = stat;
            _customer = cust;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return _orderId + " " + _purchasedOn + " " + _income + " " + _status +  "\r\n" + _customer.ToString();
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
            file.WriteLine(this.ToString());
        }

        public static Order ReadOrderFromFile(System.IO.StreamReader file)
        {
            string loadString = file.ReadLine();
            string[] splitStrings;
            int idTmp;
            DateTime dateTmp;
            double incomeTmp;
            State statusTmp = State.Pending;

            splitStrings = loadString.Split(' ');

            idTmp = int.Parse(splitStrings[0]);
            dateTmp = DateTime.ParseExact(splitStrings[1] + " " + splitStrings[2], "M/dd/yyyy H:mm:ss", null);
            incomeTmp = double.Parse(splitStrings[4]);
            statusTmp = Order.ConvertStringToState(splitStrings[5]);

            Customer customerTmp = Customer.ReadCustomerFromFile(file);

            Order orderTmp = new Order(idTmp, dateTmp,incomeTmp,statusTmp, customerTmp);
            return orderTmp;
        }


        public String GetCustomerInfo()
        {
            return _customer.ToString();
        }

        #endregion
    }
}
