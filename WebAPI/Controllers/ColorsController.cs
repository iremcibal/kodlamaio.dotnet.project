using Business.Abstract;
using Business.Requests.Colors;
using Business.Responses.Colors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public List<ListColorResponse> GetList()
        {
            List<ListColorResponse> response = _colorService.GetList();
            return response;
        }

        [HttpPost]
        public void Add(CreateColorRequest request)
        {
            _colorService.Add(request);
        }

        [HttpGet("{id}")]
        public GetColorResponse Get(int id)
        {
            GetColorResponse response = _colorService.GetById(id);
            return response;
        }

        [HttpPut]
        public void Update(UpdateColorRequest request)
        {
            _colorService.Update(request);
        }

        [HttpDelete("{Id}")]
        public void Delete([FromRoute] DeleteColorRequest request)
        {
            _colorService.Delete(request);
        }
    }
}
