using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ratingRepository
    {
        private readonly WebElectricStoreContext _WebElectricStoreContext;

        public ratingRepository(WebElectricStoreContext WebElectricStoreContext)
        {
            _WebElectricStoreContext = WebElectricStoreContext;
        }

        public async Task<Rating> addRating(Rating rating)
        {

            await _WebElectricStoreContext.Ratings.AddAsync(rating);
            await _WebElectricStoreContext.SaveChangesAsync();

            return rating;
        }
    }
}
