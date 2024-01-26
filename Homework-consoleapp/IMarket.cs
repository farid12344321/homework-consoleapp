using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_consoleapp
{
    internal interface IMarket
    {
        Product[] Products { get;}
        void AddProduct(Product product);
        void RemoveProductByNo(int no);
        void Sell(int no);
        Product FindByNo(int no);
        int FindIndexByNo(int no);
    }
}
