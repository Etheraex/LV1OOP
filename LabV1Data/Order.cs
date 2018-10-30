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
        private String _billToName;
        private String _shipToName;
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
            get { return _billToName; }
            set { _billToName = value; }
        }

        public String ShipToName
        {
            get { return _shipToName; }
            set { _shipToName = value; }
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

        public Order(int id, DateTime orderDate, String billTo, String shipTo, double inc, State stat)
        {
            _orderId = id;
            _purchasedOn = orderDate;
            _billToName = billTo;
            _shipToName = shipTo;
            _income = inc;
            _status = stat;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return _orderId + " " + _purchasedOn + " " + _billToName + " " + _shipToName + " " + _income + " " + _status;
        }

        public bool IsInTimeFrame(DateTime dateFromTmp, DateTime dateToTmp)
        {
            return ( (_purchasedOn > dateFromTmp) && (_purchasedOn < dateToTmp) ) ? true : false;
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
                condition2 = (_orderId == idTmp) ? true : false;
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

        public void SaveOrderToFile(string filePath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
            {
                file.WriteLine(this.ToString());
            }
        }

        #endregion
    }


}
