using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_consoleapp
{
    internal class DrinkProduct:Product
    {
        public double AlcoholPercent;

        public DrinkProduct(string name,double costPrice,double salePrice,DateTime expireDate,double alcoholPercent):base(name,costPrice,salePrice,expireDate)
        {
            AlcoholPercent = alcoholPercent;
        }

        public override string ToString()
        {
            return base.ToString() + " - AlcoholPercent: " + AlcoholPercent;
        }
    }
}
