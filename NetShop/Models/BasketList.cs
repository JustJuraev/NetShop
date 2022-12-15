using System.Collections.Generic;

namespace NetShop.Models
{
    public static class BasketList
    {
        private static Dictionary<string, List<Product>> Basket = new Dictionary<string, List<Product>>();

        public static List<Product> GetBasket(string sessionId)
        {
           
            if (!Basket.ContainsKey(sessionId))
            {
                return new List<Product>();
            }

            return Basket[sessionId];
        }

        public static void Add(string sessionId, Product product)
        {
            string test = sessionId;
            if (!Basket.ContainsKey(sessionId))
            {
                Basket.Add(sessionId, new List<Product>());
            }
            
            Basket[sessionId].Add(product);
        }


        public static void Remove(string sessionId, Product product)
        {
            Basket[sessionId].Remove(product);
        }
    }
}
