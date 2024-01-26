using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_consoleapp
{
    internal class Product
    {
        static int _no;
        public int No;
        public string Name;
        public double CostPrice;
        public double SalePrice;
        public DateTime ExpireDate;

        public Product()
        {
            _no++;
            No = _no;
        }

        public Product(string name,double costPrice, double salePrice,DateTime expireDate):this()
        {
            Name = name;
            CostPrice = costPrice;
            SalePrice = salePrice;
            ExpireDate = expireDate;
        }

        public override string ToString()
        {
            return $"No: {No} - Name: {Name} - Price: {SalePrice} - ExpireDate: {ExpireDate.ToString("dd.MM.yyyy")}";
        }

    }
}
