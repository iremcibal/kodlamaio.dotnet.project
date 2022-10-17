using Business.Abstract;
using Business.Requests.Models;
using Business.Responses.Models;
using Core.Business.Requests;
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
        public PaginateListModelResponse GetList([FromQuery] PageRequest request)
        {
            PaginateListModelResponse response = _modelService.GetList(request);
            return response;
        }

        [HttpPost]
        public void Add(CreateModelRequest request)
        {
            _modelService.Add(request);
        }

        [HttpGet("{Id}")]
        public GetModelResponse Get([FromRoute] GetModelRequest request)
        {
            GetModelResponse response = _modelService.GetById(request);
            return response;
        }

        [HttpGet("/brandid")]
        public PaginateListModelResponse GetModelsByBrandId([FromQuery] PageRequest request,int brandId)
        {
            PaginateListModelResponse response = _modelService.GetModelsByBrandId(request,brandId);
            return response;
        }

        [HttpGet("/fuelid")]
        public PaginateListModelResponse GetModelsByFuelId([FromQuery] PageRequest request, int fuelId)
        {
            PaginateListModelResponse response = _modelService.GetModelsByFuelId(request, fuelId);
            return response;
        }

        [HttpGet("/cartypeid")]
        public PaginateListModelResponse GetModelsByCarTypeId([FromQuery] PageRequest request, int typeId)
        {
            PaginateListModelResponse response = _modelService.GetModelsByCarTypeId(request, typeId);
            return response;
        }

        [HttpGet("/colorid")]
        public PaginateListModelResponse GetModelsByColorId([FromQuery] PageRequest request, int colorId)
        {
            PaginateListModelResponse response = _modelService.GetModelsByColorId(request, colorId);
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
