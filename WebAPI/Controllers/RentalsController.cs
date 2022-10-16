using Business.Abstract;
using Business.Requests.Rentals;
using Business.Responses.Rentals;
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
        public List<ListRentalResponse> GetList()
        {
            List<ListRentalResponse> result = _rentalService.GetList();
            return result;
        }

        [HttpGet("{id}")]
        public GetRentalResponse GetById(int id)
        {
            GetRentalResponse response = _rentalService.GetById(id);
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
