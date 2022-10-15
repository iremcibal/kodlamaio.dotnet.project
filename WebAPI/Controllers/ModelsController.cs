using Business.Abstract;
using Business.Requests.Models;
using Business.Responses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        IModelService _modelService;
        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public List<ListModelResponse> GetList()
        {
            List<ListModelResponse> response = _modelService.GetList();
            return response;
        }

        [HttpPost]
        public void Add(CreateModelRequest request)
        {
            _modelService.Add(request);
        }

        [HttpGet("{id}")]
        public GetModelResponse Get(int id)
        {
            GetModelResponse response = _modelService.GetById(id);
            return response;
        }

        [HttpGet("/brandid")]
        public List<ListModelResponse> GetBrandId(int brandId)
        {
            List<ListModelResponse> response = _modelService.GetModelsByBrandId(brandId);
            return response;
        }

        [HttpGet("/fuelid")]
        public List<ListModelResponse> GetFuelId(int fuelId)
        {
            List<ListModelResponse> response = _modelService.GetModelsByFuelId(fuelId);
            return response;
        }

        [HttpGet("/cartypeid")]
        public List<ListModelResponse> GetCarTypeId(int carTypeId)
        {
            List<ListModelResponse> response = _modelService.GetModelsByCarTypeId(carTypeId);
            return response;
        }

        [HttpGet("/colorid")]
        public List<ListModelResponse> GetColorId(int colorId)
        {
            List<ListModelResponse> response = _modelService.GetModelsByColorId(colorId);
            return response;
        }

        [HttpPut]
        public void Update(UpdateModelRequest request)
        {
            _modelService.Update(request);
        }

        [HttpDelete("{Id}")]
        public void Delete([FromRoute] DeleteModelRequest request)
        {
            _modelService.Delete(request);
        }


    }
}
