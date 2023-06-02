using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YemekSiparis.Entities;

namespace YemekSiparis.Models
{
    public class Cart
    {
        private List<CartItem> _cartLines = new List<CartItem>();

        public List<CartItem> CartLines { get {  return _cartLines; } }
        public void AddItem(Product product, int quantity) 
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.Id == product.Id);
            if (line == null) 
            {
                _cartLines.Add(new CartItem {  Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteItem(Product product) 
        {
            _cartLines.RemoveAll(i => i.Product.Id == product.Id);
        }

        public double Total()
        {
            return _cartLines.Sum(i => i.Product.Price * i.Quantity);
        }

        public void Clear()
        {
            _cartLines.Clear();
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}