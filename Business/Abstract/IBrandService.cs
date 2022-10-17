using Business.Requests.Brands;
using Business.Responses.Brands;
using Core.Business.Requests;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        GetBrandResponse GetById(int id);
        PaginateListBrandResponse GetList(PageRequest request);
        void Add(CreateBrandRequest request);
        void Delete(DeleteBrandRequest request);
        void Update(UpdateBrandRequest request);
    }
}
