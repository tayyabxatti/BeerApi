using BeerWebApi.Models;
using BeerWebApi.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BeerWebApi.Services
{
    public class BeerService : IBeerService
    {
        private readonly BeerContext _beerContext;
        public BeerService(BeerContext beerContext)
        {
            _beerContext = beerContext;
        }

        public ResponseMessage AddBeer(BeerRequestDto beer)
        {
            ResponseMessage result = new ResponseMessage();
            var obj = _beerContext.Beers.FirstOrDefault(x =>  x.Name == beer.Name);
            if (obj == null)
            {
                //saving beer record.
                Beer resp = new Beer();
                resp.Name = beer.Name;
                if(beer.Type.ToLower()== "pale ale" || beer.Type.ToLower()== "stout")
                {
                    resp.Type = beer.Type;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Type can only be pale ali or stout";
                    return result;
                }
                resp.Rating = beer.Rating;
                _beerContext.Add(resp);
                _beerContext.SaveChanges();
                
                //saving beer ratings in a list to take average
                BeerRating beerRating = new BeerRating();
                beerRating.BeerId = resp.BeerId;
                beerRating.Rating = beer.Rating;
                _beerContext.BeerRatings.Add(beerRating);
                _beerContext.SaveChanges();

                result.Success = true;
                result.Message = "Beer saved successfully.";
                return result;
            }
            else
            {
                result.Success = false;
                result.Message = "Beer already exists.";
                return result;
            }
            
        }

        public IEnumerable<Beer> GetAllBeers()
        {
            return _beerContext.Beers.ToList();
        }

        public IEnumerable<Beer> SearchBeer(string beerName)
        {
            return _beerContext.Beers.Where(x => x.Name.Contains(beerName)).ToList();
        }

        public ResponseMessage UpdateRating(UpdateRatingRequestDto request)
        {
            ResponseMessage result = new ResponseMessage();
            var obj = _beerContext.Beers.FirstOrDefault(x => x.BeerId == request.BeerId);
            if (obj != null)
            {
                BeerRating beerRating = new BeerRating();
                beerRating.BeerId = request.BeerId;
                beerRating.Rating = request.Rating;
                _beerContext.BeerRatings.Add(beerRating);
                _beerContext.SaveChanges();

                var average = _beerContext.BeerRatings.Where(x => x.BeerId == request.BeerId).Select(x => x.Rating).ToList();
                obj.Rating = average.Average();
                _beerContext.Beers.Update(obj);
                _beerContext.SaveChanges();
                result.Success = true;
                result.Message = "Beer record updated successfully";
                return result;
            }
            else
            {
                result.Success = false;
                result.Message = "Beer record against id does not exist.";
                return result;
            }
        }

        public List<BeerRating> GetBeerRatings(int id)
        {
            return _beerContext.BeerRatings.Where(x => x.BeerId == id).ToList();
        }


    }
}
