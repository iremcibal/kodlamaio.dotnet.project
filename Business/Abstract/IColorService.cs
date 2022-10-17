using Business.Requests.Colors;
using Business.Responses.Colors;
using Core.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        public void Add(CreateColorRequest request);
        public void Delete(DeleteColorRequest request);
        public void Update(UpdateColorRequest request);
        GetColorResponse GetById(int id);
        PaginateListColorResponse GetList(PageRequest request);

    }
}
