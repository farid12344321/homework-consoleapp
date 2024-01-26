using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_consoleapp
{
    internal class Market : IMarket, IReporter
    {
        private Product[] _products = new Product[0];
        public Product[] Products => _products;
        public int AlcoholPercentLimit;

        private double _totalAmount;
        public double TotalAmount => _totalAmount;

        private double _alcoholProductLimit;
        public double AlcoholProductLimit => _alcoholProductLimit;

        double _drinkTotal;
        public double DrinkTotal => _drinkTotal;

        private double _alcoholDrinkTotal;
        public double AlcoholDrinkTotal => _alcoholDrinkTotal;

        private double _nonAlcoholdrinkTotal;
        public double NonAlcoholDrinkTotal => _nonAlcoholdrinkTotal;

        public void AddProduct(Product product)
        {
            if (product is DrinkProduct drink && drink.AlcoholPercent > this.AlcoholPercentLimit)
                return;
            Array.Resize(ref _products, _products.Length + 1);
            _products[_products.Length - 1] = product;
        }

        public Product FindByNo(int no)
        {
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].No == no)
                {
                    return _products[i];
                }
            }

            return null;
        }
        public int FindIndexByNo(int no)
        {
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].No == no)
                {
                    return i;
                }
            }
            return -1;
        }

        public double GetAlcoholProfit()
        {
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i] is DrinkProduct)
                {
                    if (((DrinkProduct)_products[i]).AlcoholPercent > 0)
                    {
                       _alcoholDrinkTotal += _products[i].SalePrice;
                    }
                }
            }
            return _alcoholDrinkTotal;
        }

        public double GetAllProfit()
        {
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i] is DrinkProduct)
                {
                    _drinkTotal += _products[i].SalePrice;
                }
            }
            return _drinkTotal;
        }

        public double GetNonAlcoholProfit()
        {
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i] is DrinkProduct)
                {
                    if (((DrinkProduct)_products[i]).AlcoholPercent == 0)
                    {
                        _nonAlcoholdrinkTotal += _products[i].SalePrice;
                    }
                }
            }
            return _nonAlcoholdrinkTotal;
        }

        public void RemoveProductByNo(int no)
        {
            var wantedProduct = FindByNo(no);
            if (wantedProduct == null) throw new ProductNotFoundException();

            if (wantedProduct.ExpireDate >= DateTime.Now.AddYears(1))
                throw new ProductExpireDateException();

            var wantedIndex = FindIndexByNo(no);
            for (int i = wantedIndex; i < _products.Length - 1; i++)
            {
                var temp = _products[i];
                _products[i] = _products[i + 1];
                _products[i + 1] = temp;
            }

            Array.Resize(ref _products, _products.Length - 1);
        }

        public void Sell(int no)
        {
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].No == no)
                {
                    _totalAmount += _products[i].SalePrice;
                }
            }
            Console.WriteLine("Umumi total amount: "+_totalAmount);
        }

        public DrinkProduct[] GetAlcoholDrinks()
        {
            DrinkProduct[] drinks = new DrinkProduct[0];

            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i] is DrinkProduct drink && drink.AlcoholPercent > 0)
                {
                    Array.Resize(ref drinks, drinks.Length + 1);
                    drinks[drinks.Length - 1] = drink;
                }
            }
            return drinks;
        }
        public DrinkProduct[] GetDrinks()
        {
            DrinkProduct[] drinks = new DrinkProduct[0];

            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i] is DrinkProduct drink)
                {
                    Array.Resize(ref drinks, drinks.Length + 1);
                    drinks[drinks.Length - 1] = drink;
                }
            }

            return drinks;
        }
        public DrinkProduct[] GetNonAlcoholDrinks()
        {
            DrinkProduct[] drinks = new DrinkProduct[0];

            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i] is DrinkProduct drink && drink.AlcoholPercent == 0)
                {
                    Array.Resize(ref drinks, drinks.Length + 1);
                    drinks[drinks.Length - 1] = drink;
                }
            }
            return drinks;
        }


    }
}
