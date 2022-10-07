using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Colors;
using Business.Responses.Colors;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        IMapper _mapper;
        ColorBusinessRules _businessRules;

        public ColorManager(IColorDal colorDal, IMapper mapper, ColorBusinessRules businessRules)
        {
            _colorDal = colorDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public void Add(CreateColorRequest request)
        {
            _businessRules.CheckIfColorNameExist(request.Name);
            Color color = _mapper.Map<Color>(request);
            _colorDal.Add(color);
        }

        public void Delete(DeleteColorRequest request)
        {
            _businessRules.CheckIfColorNotExist(request.Id);
            Color color = _mapper.Map<Color>(request);
            _colorDal.Delete(color);
        }

        public GetColorResponse GetById(int id)
        {
            Color color = _colorDal.Get(c=>c.Id == id);
            _businessRules.CheckIfColorNotExist(color);
            GetColorResponse response = _mapper.Map<GetColorResponse>(color);

            return response;

        }

        public List<ListColorResponse> GetList()
        {
            List<Color> colors = _colorDal.GetList();
            List<ListColorResponse> response = _mapper.Map<List<ListColorResponse>>(colors);

            return response;

        }

        public void Update(UpdateColorRequest request)
        {
            _businessRules.CheckIfColorNotExist(request.Id);
            Color color = _mapper.Map<Color>(request);
            _colorDal.Update(color);
        }
    }
}
