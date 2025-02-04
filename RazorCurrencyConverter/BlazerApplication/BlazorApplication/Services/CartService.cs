﻿using System;
using System.Linq;
using BlazorApplication.Models;

namespace BlazorApplication.Services
{
	public class CartService
	{
		public static List<ShoppingItem> SelectedItems { get; set; } = new List<ShoppingItem>();

        public static void RemoveFromCart(int productId)
        {
            SelectedItems.RemoveAll(x => x.Id == productId);
        }

        public void AddProductToCart(int productId)
		{
			if(ProductInCart(productId) is false)
			{
                var product = ProductService.Products.First(p => p.Id == productId);

                ShoppingItem item = new ShoppingItem();

                item.Product = product;
                item.PurchasePrice = product.Price;

                SelectedItems.Add(item);
			}
		}

        private bool ProductInCart(int productId)
        {
            foreach (ShoppingItem item in SelectedItems)
            {
                if (item.Product.Id == productId)
                {
                    item.Quantity++;
                    return true;
                }
            }
            return false;
        }
    }
}

