using Business.Responses.Brands;
using Core.Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.CarTypes
{
    public class PaginateListCarTypeResponse : PaginateListResponseBase
    {
        public IList<ListCarTypeResponse> Items { get; set; }

    }
}
