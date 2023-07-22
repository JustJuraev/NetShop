using System.Collections.Generic;
using System.Linq;

namespace NetShop.Models
{
    public static class BasketList
    {
        private static Dictionary<string, List<BasketProduct>> Basket = new Dictionary<string, List<BasketProduct>>();
      
        public static List<BasketProduct> GetBasket(string sessionId)
        {
           
            if (!Basket.ContainsKey(sessionId))
            {
                return new List<BasketProduct>();
            }

            return Basket[sessionId];
        }

        public static void Add(string sessionId, BasketProduct product)
        {
         
            if (!Basket.ContainsKey(sessionId))
            {
                Basket.Add(sessionId, new List<BasketProduct>());
            }
            List<BasketProduct> cart = GetBasket(sessionId);
            BasketProduct productInBasket = cart.FirstOrDefault(pr => pr.Product.Id == product.Product.Id);
            if (productInBasket == null)
            {
                cart.Add(product);
                product.Count++;
            }
            else
            {
                productInBasket.Count++;
            }
            
        }

        public static void Clear(string sessionId) 
        {
            Basket[sessionId].Clear();
        }

        public static void Remove(string sessionId, BasketProduct product)
        {
            List<BasketProduct> cart = GetBasket(sessionId);
            BasketProduct productInBasket = cart.FirstOrDefault(pr => pr.Product.Id == product.Product.Id);
            if (productInBasket != null)
            {
                productInBasket.Count--;
                if (productInBasket.Count <= 0)
                {
                    cart.Remove(productInBasket);
                }
            }
        }

        public static int TotalSum(string sessionId)
        {
            int sum = 0;
            foreach(var item in GetBasket(sessionId))
            {
                for(int i = 0; i < item.Count; i++)
                {
                    sum += item.Product.PriceOutCome;
                }
            }

            return sum;
        }
    }
}
