using System.Collections.Generic;
using System.Linq;

namespace AbodeBoutiqueStore.Models
{
    // the Cart class is responsible for adding cart lines (products) to the cart view
    // and populating the cart page with each added product's details, total, and productID 
    public class Cart
    {
        // Each new Item is added as it's own line in the cart (or += quantity of same line for multiples)
        // uses CartLine data object (end of this file)
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        // method to add item to cart
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = Lines
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        // removes an item line (each item line has a remove button, and product ID)
        public virtual void RemoveLine(Product product) =>
            Lines.RemoveAll(l => l.Product.ProductID == product.ProductID);

        // when an item is added to the cart, or removed, run this method to update the total
        public decimal ComputeTotalValue() =>
            Lines.Sum(e => e.Product.Price * e.Quantity);

        // does what it says!
        public virtual void Clear() => Lines.Clear();

    }

    // this class can be on it's own, left here for simplicity
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}