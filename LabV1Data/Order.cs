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
        #endregion Data

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

        #endregion Properies

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

        #endregion Constructors

        public override string ToString()
        {
            return _orderId + " " + _purchasedOn + " " + _billToName + " " + _shipToName + " " + _income + " " + _status;
        }
    }


}
