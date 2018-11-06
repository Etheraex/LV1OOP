using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace LabV1Data
{
    public class OrderList
    {
        #region Data

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

        #endregion

        #region Methods

        public void AddOrder(Order o)
        {
            try
            {
                if (o != null)
                    _orderList.Add(o);
                else
                    throw new Exception("Pokusaj dodavanja null objekta u OrderList");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Greska pri izvrsenju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            try
            {
                if (index < _orderList.Count)
                    _orderList.RemoveAt(index);
                else
                    throw new Exception("Pokusaj brisanja objekta sa nevalidnim indexom u OrderList");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Greska pri izvrsenju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public void ReplaceOrder(int i, Order o)
        {
            try
            {
                if (i < _orderList.Count && o != null)
                    _orderList[i] = o;
                else
                    throw new Exception("Greska pri izmeni Order-a u listi");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Greska pri izvrsenju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
