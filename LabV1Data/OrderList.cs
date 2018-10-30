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
                string ucitaj;
                string[] razdeli;

                int idTmp;
                DateTime kupljenoTmp;
                string kupacTmp;
                string primaocTmp;
                double zaradaTmp;
                State stanjeTmp = State.Pending;

                while (!file.EndOfStream)
                {
                    ucitaj = file.ReadLine();
                    razdeli = ucitaj.Split(' ');

                    idTmp = int.Parse(razdeli[0]);
                    kupljenoTmp = DateTime.ParseExact(razdeli[1] + " " + razdeli[2], "M/dd/yyyy H:mm:ss", null);
                    kupacTmp = razdeli[4] + " " + razdeli[5];
                    primaocTmp = razdeli[6] + " " + razdeli[7];
                    zaradaTmp = double.Parse(razdeli[8]);
                    stanjeTmp = Order.ConvertStringToState(razdeli[9]);

                    SingleInstance.AddOrder(new Order(idTmp, kupljenoTmp, kupacTmp, primaocTmp, zaradaTmp, stanjeTmp));
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
