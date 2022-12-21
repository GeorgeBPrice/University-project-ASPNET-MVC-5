using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AbodeBoutiqueStore.Infrastructure;

namespace AbodeBoutiqueStore.Models
{
    // In order to access the shopping cart once the user has left the page
    // a session is required to keep the cart data in state and scope
    public class SessionCart : Cart
    {
        // create a new Cart object, or retrieve existing one in session
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                               ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        // add items to Cart session
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }

        // remove
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }

        // or clear
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}