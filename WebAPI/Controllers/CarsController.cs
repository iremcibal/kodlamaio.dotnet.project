using Business.Abstract;
using Business.Requests.Cars;
using Business.Responses.Cars;
using Core.Business.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public PaginateListCarResponse GetList([FromQuery] PageRequest request)
        {
            PaginateListCarResponse result = _carService.GetList(request);
            return result;
        }

        [HttpGet("{Id}")]
        public GetCarResponse GetById([FromRoute] GetCarRequest request)
        {
            GetCarResponse response = _carService.GetById(request);
            return response;
        }

        [HttpPost]
        public void Add(CreateCarRequest request)
        {
            _carService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateCarRequest request)
        {
            _carService.Update(request);
        }


        [HttpDelete("{Id}")]
        public void Delete([FromRoute] DeleteCarRequest request)
        {
            _carService.Delete(request);
        }

    }
}
