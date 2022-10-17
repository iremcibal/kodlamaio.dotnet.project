using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Brands;
using Business.Responses.Brands;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        BrandBusinessRules _brandBusinessRules;
        private IMapper _mapper;
        public BrandManager(IBrandDal brandDal, BrandBusinessRules brandBusinessRules, IMapper mapper)
        {
            this._brandDal = brandDal;
            this._brandBusinessRules = brandBusinessRules;
            this._mapper = mapper;
        }

        public void Add(CreateBrandRequest request)
        {
            _brandBusinessRules.CheckIfBrandNameExist(request.Name);
            
            Brand brand = _mapper.Map<Brand>(request);

            _brandDal.Add(brand);
        }

        public void Delete(DeleteBrandRequest request)
        {
            _brandBusinessRules.CheckIfBrandExist(request.Id);
            Brand brand = _mapper.Map<Brand>(request);

            _brandDal.Delete(brand);
        }

        public void Update(UpdateBrandRequest request)
        {
            _brandBusinessRules.CheckIfBrandExist(request.Id);
            Brand brand = _mapper.Map<Brand>(request);

            _brandDal.Update(brand);
        }
        public GetBrandResponse GetById(int id)
        {
            Brand brandToUpdate = _brandDal.Get(b=>b.Id==id);
            var response = _mapper.Map<GetBrandResponse>(brandToUpdate);

            return response;

        }

        public PaginateListBrandResponse GetList(PageRequest request)
        {
            IPaginate<Brand> brands = _brandDal.GetList(index: request.Index,
                                                            size: request.Size);

            PaginateListBrandResponse response = _mapper.Map<PaginateListBrandResponse>(brands);

            return response;
        }
    }
}
