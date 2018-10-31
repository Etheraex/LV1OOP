using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabV1Data
{
    public class OrderList
    {
        #region Date

        private List<Order> _orderList;

        #endregion

        #region Properies

        public List<Order> Orders
        {
            get { return _orderList; }
        }

        #endregion

        #region Constructors

        private OrderList()
        {
            _orderList = new List<Order>();
        }

        public void AddOrder(Order o)
        {
            _orderList.Add(o);
        }

        #endregion

        #region Methods

        public void LoadFromFile(String filePath)
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(filePath))
            {
                string loadString;
                string[] splitStrings;

                int idTmp;
                DateTime dateTmp;
                double incomeTmp;
                String nameTmp;
                String addressTmp;
                String countryTmp;
                State statusTmp = State.Pending;

                while (!file.EndOfStream)
                {
                    loadString = file.ReadLine();
                    nameTmp = file.ReadLine();
                    addressTmp = file.ReadLine();
                    countryTmp = file.ReadLine();
                    splitStrings = loadString.Split(' ');

                    idTmp = int.Parse(splitStrings[0]);
                    dateTmp = DateTime.ParseExact(splitStrings[1] + " " + splitStrings[2], "M/dd/yyyy H:mm:ss", null);
                    incomeTmp = double.Parse(splitStrings[4]);
                    statusTmp = Order.ConvertStringToState(splitStrings[5]);
                    int i = 0;
                    for (; i < Orders.Count; i++)
                        if (Orders[i].CheckId(idTmp))
                            break;
                    if(i == Orders.Count)
                        SingleInstance.AddOrder(new Order(idTmp, dateTmp, incomeTmp, statusTmp, nameTmp,addressTmp,countryTmp));
                }
            }
        }

        public void SaveToFile(String filePath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
            {
                foreach (Order o in _orderList)
                    file.WriteLine(o.ToString());
            }
        }

        public void RemoveOrderAt(int index)
        {
            _orderList.RemoveAt(index);
        }

        public void RemoveAllOrders()
        {
            _orderList.Clear();
        }

        private static OrderList _singleInstance = null;
        public static OrderList SingleInstance
        {
            get
            {
                if (_singleInstance == null)
                    _singleInstance = new OrderList();
                return _singleInstance;
            }
        }

        #endregion
    }
}
