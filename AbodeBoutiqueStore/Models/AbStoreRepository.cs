using System.Linq;

namespace AbodeBoutiqueStore.Models

{
    // this class mediates between the Store's domain and the database layer
    // acting as in-memmory collection to leverage access to Product objects
    // anywhere the IStoreRepository is called

    public class AbStoreRepository : IStoreRepository
    {
        // declare
        private StoreDbContext context;

        // initialise
        public AbStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        // use
        public IQueryable<Product> Products => context.Products;
    }
}