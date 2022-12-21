using System.Linq;

namespace AbodeBoutiqueStore.Models
{
    // this interface defines the data model that the IStoreRepository uses
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}