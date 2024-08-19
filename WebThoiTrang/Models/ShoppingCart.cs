using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThoiTrang.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> items { get; set; }
        public ShoppingCart()
        {
            this.items = new List<ShoppingCartItem>();
        }
        public void AddToCart(ShoppingCartItem item, int quantity)
        {
            var checkExist = items.FirstOrDefault(x => x.ProductId == item.ProductId);
            if (checkExist != null)
            {
                checkExist.Quantity += quantity;
                checkExist.TotalPrice = checkExist.Price * checkExist.Quantity;
            }
            else
            {
                items.Add(item);
            }
        }

        public void Remove(int id)
        {
            var checkExist = items.SingleOrDefault(x => x.ProductId == id);
            if (checkExist != null)
            {
                items.Remove(checkExist); 
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            var checkExist = items.SingleOrDefault(x => x.ProductId == id);
            if (checkExist != null)
            {
                checkExist.Quantity = quantity;
                checkExist.TotalPrice = checkExist.Price * checkExist.Quantity;
            }
        }

        public decimal GetTotalPrice()
        {
            return items.Sum(x => x.TotalPrice);
        }
        public int GetTotalQuantity()
        {
            return items.Sum(x => x.Quantity);
        }
        public void clearCart()
        {
            items.Clear();
        }
    }

    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string ProductImage { get; set; }
        public string Alias { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}