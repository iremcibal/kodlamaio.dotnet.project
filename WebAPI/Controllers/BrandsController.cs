using Business.Abstract;
using Business.Requests.Brands;
using Business.Responses.Brands;
using Core.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public PaginateListBrandResponse GetList([FromQuery] PageRequest request)
        {
            PaginateListBrandResponse result = _brandService.GetList(request);
            return result;
        }

        [HttpGet("{id}")]
        public GetBrandResponse GetById(int id)
        {
            GetBrandResponse response = _brandService.GetById(id);
            return response;
        }

        [HttpPost]
        public void Add(CreateBrandRequest request)
        {
            _brandService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateBrandRequest request)
        {
            _brandService.Update(request);
        }


        [HttpDelete("{Id}")]
        public void Delete([FromRoute] DeleteBrandRequest request)
        {
            _brandService.Delete(request);
        }

    }
}
