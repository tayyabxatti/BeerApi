using System;
using System.Collections.Generic;
using BeerWebApi.Models;
using BeerWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        /// <summary>
        /// gets list of all beers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllBeers")]
        public IEnumerable<Beer> GetAllBeers()
        {
            try
            {
                return _beerService.GetAllBeers();

            }catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// gets list of all beer ratings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllBeerRatings")]
        public IEnumerable<BeerRating> GetAllBeerRatings(int id)
        {
            try
            {
                return _beerService.GetBeerRatings(id);

            }catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// gets objects of beer and adds beer
        /// </summary>
        /// <param name="beer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddBeer")]

        public ResponseMessage AddBeer([FromBody]BeerRequestDto beer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return _beerService.AddBeer(beer);
                }
                else
                {
                    ResponseMessage result = new ResponseMessage();
                    result.Success = false;
                    result.Message = "Validation errors";
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Search beers
        /// </summary>
        /// <param name="beerName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchBeer")]
        public IEnumerable<Beer> SearchBeer(string beerName)
        {
            try
            {
                return _beerService.SearchBeer(beerName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// updates rating of beers
        /// </summary>
        /// <param name="beerName"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateRating")]
        public ResponseMessage UpdateRating(UpdateRatingRequestDto request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return _beerService.UpdateRating(request);
                }
                else
                {
                    ResponseMessage result = new ResponseMessage();
                    result.Success = false;
                    result.Message = "Validation errors";
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
