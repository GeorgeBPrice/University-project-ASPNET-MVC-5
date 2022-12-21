using System.ComponentModel.DataAnnotations.Schema;
namespace AbodeBoutiqueStore.Models
{
    // this class is used to defined the product object
    // which is used to store products in the database, and called to
    // dynamically populate the catalog page, cart, and menu, with
    public class Product
    {
        // no required or regex used so far, as all data was seeded
        // however, it is expected admin user role could add products via a view/page,
        // and such control/validation techniques should be implemented
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { set; get; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        public string Image { set; get; }
    }
}