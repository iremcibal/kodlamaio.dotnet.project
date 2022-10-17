using Business.Abstract;
using Business.Requests.CarStates;
using Business.Responses.CarStates;
using Core.Business.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarStatesController : ControllerBase
    {
        private readonly ICarStateService _carStateService;

        public CarStatesController(ICarStateService carStateService)
        {
            _carStateService = carStateService;
        }

        [HttpGet]
        public PaginateListCarStateResponse GetList([FromQuery] PageRequest request)
        {
            PaginateListCarStateResponse result = _carStateService.GetList(request);
            return result;
        }

        [HttpGet("{id}")]
        public GetCarStateResponse GetById(int id)
        {
            GetCarStateResponse response = _carStateService.GetById(id);
            return response;
        }

        [HttpPost]
        public void Add(CreateCarStateRequest request)
        {
            _carStateService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateCarStateRequest request)
        {
            _carStateService.Update(request);
        }


        [HttpDelete("{Id}")]
        public void Delete([FromRoute] DeleteCarStateRequest request)
        {
            _carStateService.Delete(request);
        }
    }
}
