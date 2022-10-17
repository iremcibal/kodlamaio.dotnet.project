using Business.Abstract;
using Business.Requests.Fuels;
using Business.Responses.Fuels;
using Core.Business.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
        IFuelService _fuelService;

        public FuelsController(IFuelService fuelService)
        {
            _fuelService = fuelService;
        }

        [HttpPost]
        public void Add(CreateFuelRequest request)
        {
            _fuelService.Add(request);
        }

        [HttpDelete("{Id}")]
        public void Delete([FromRoute]DeleteFuelRequest request)
        {
            _fuelService.Delete(request);
        }

        [HttpPut]
        public void Update(UpdateFuelRequest request)
        {
            _fuelService.Update(request);
        }

        [HttpGet("{id}")]
        public GetFuelResponse Get(int id)
        {
            GetFuelResponse response =_fuelService.GetById(id);
            return response;
        }

        [HttpGet]
        public PaginateListFuelResponse GetList([FromQuery] PageRequest request)
        {
            PaginateListFuelResponse result = _fuelService.GetList(request);
            return result;
        }


    }
}
