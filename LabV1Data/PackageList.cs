using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;


namespace LabV1Data
{
    public class PackageList
    {
        #region Data

        List<Package> _packageList;

        #endregion

        #region Properties

        [Browsable(false)]
        public double Price
        {
            get
            {
                double sum = 0;
                foreach (Package p in _packageList)
                    sum += p.PackagePrice;
                return sum;
            }
        }

        [Browsable(false)]
        public List<Package> Packages
        {
            get { return _packageList; }
        }

        #endregion

        #region Constructors

        public PackageList()
        {
            _packageList = new List<Package>();
        }

        public PackageList(List<Package> tmp)
        {
            _packageList = tmp;
        }

        #endregion
        
        #region Methods

        public void AddPackage(Package p)
        {
            _packageList.Add(p);
        }

        public void SaveToFile(StreamWriter file)
        {
            file.WriteLine(_packageList.Count);
            foreach (Package p in _packageList)
                p.SaveToFile(file);
        }

        public static PackageList ReadFromFile(StreamReader file)
        {
            int a = int.Parse(file.ReadLine());
            List<Package> packagesTmp = new List<Package>();
            for(int i = 0; i < a; i++)
            {
                packagesTmp.Add(Package.ReadFromFile(file));
            }
            return new PackageList(packagesTmp);
        }

        #endregion
    }
}
