using RealEstateListingApi.Models;

using System.Reflection;

namespace RealEstateListingApi.Data
{
    public interface IListingRepository
    {
        string Add(Listing item);
        Listing Get(string id);
        IEnumerable<Listing> GetAll();
    }
    public class ListingRepository : IListingRepository
    {
        private readonly ApplicationDbContext _context;
        public ListingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Listing> GetAll()
        {
            return _context.Listings.ToList();
        }
        public Listing Get(string id)
        {
            return _context.Listings.FirstOrDefault(l => l.Id == id);
        }
        public string Add(Listing item)
        {
            _context.Listings.Add(item);
            _context.SaveChanges();
            return item.Id;
        }


    }
}
