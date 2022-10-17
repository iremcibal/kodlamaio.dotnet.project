using Business.Abstract;
using Business.Requests.Rentals;
using Business.Responses.Rentals;
using Core.Business.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public PaginateListRentalResponse GetList([FromQuery] PageRequest request)
        {
            PaginateListRentalResponse response = _rentalService.GetList(request);
            return response;
        }

        [HttpGet("{Id}")]
        public GetRentalResponse GetById([FromRoute]GetRentalRequest request)
        {
            GetRentalResponse response = _rentalService.GetById(request);
            return response;
        }

        [HttpPost]
        public void Add(CreateRentalRequest request)
        {
            _rentalService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateRentalRequest request)
        {
            _rentalService.Update(request);
        }


        [HttpDelete("{Id}")]
        public void Delete([FromRoute] DeleteRentalRequest request)
        {
            _rentalService.Delete(request);
        }
    }
}
