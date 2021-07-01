using BeerWebApi.Models;
using System.Collections.Generic;


namespace BeerWebApi.Services
{
    public interface IBeerService
    {
        public IEnumerable<Beer> GetAllBeers();
        public ResponseMessage AddBeer(BeerRequestDto beer);
        public IEnumerable<Beer> SearchBeer(string beerName);
        public ResponseMessage UpdateRating(UpdateRatingRequestDto request);
        public List<BeerRating> GetBeerRatings(int id);

    }
}
