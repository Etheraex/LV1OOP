using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


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

        public void LoadFromFile(StreamReader file)
        {
            while (!file.EndOfStream)
            {
                Order orderTmp = Order.ReadOrderFromFile(file);
                int i = 0;
                for (; i < Orders.Count; i++)
                    if (Orders[i].CheckId(orderTmp.OrderId))
                        break;
                if (i == Orders.Count)
                    SingleInstance.AddOrder(orderTmp);
            }
        }

        public void SaveToFile(StreamWriter file)
        {
            foreach (Order o in _orderList)
                o.SaveOrderToFile(file);
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

        public void ReplaceItem(int i, Order o)
        {
            _orderList[i] = o;
        }

        #endregion
        }
    }
