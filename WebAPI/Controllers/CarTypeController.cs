using Business.Abstract;
using Business.Requests.CarTypes;
using Business.Responses.Brands;
using Business.Responses.CarTypes;
using Core.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class CarTypeController : Controller
    {
        private readonly ICarTypeService _carTypeService;

        public CarTypeController(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }

        [HttpGet]
        public PaginateListCarTypeResponse GetList([FromQuery] PageRequest request)
        {
            PaginateListCarTypeResponse result = _carTypeService.GetList(request);
            return result;
        }

        [HttpGet("{id}")]
        public GetCarTypeResponse GetById(int id)
        {
            GetCarTypeResponse response = _carTypeService.GetById(id);
            return response;
        }

        [HttpPost]
        public void Add(CreateCarTypeRequest request)
        {
            _carTypeService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateCarTypeRequest request)
        {
            _carTypeService.Update(request);
        }


        [HttpDelete("{Id}")]
        public void Delete([FromRoute] DeleteCarTypeRequest request)
        {
            _carTypeService.Delete(request);
        }

    }
}
