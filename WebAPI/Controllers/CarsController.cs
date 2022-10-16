using Business.Abstract;
using Business.Requests.Cars;
using Business.Responses.Cars;
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
        public List<ListCarResponse> GetList()
        {
            List<ListCarResponse> result = _carService.GetList();
            return result;
        }

        [HttpGet("{id}")]
        public GetCarResponse GetById(int id)
        {
            GetCarResponse response = _carService.GetById(id);
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
