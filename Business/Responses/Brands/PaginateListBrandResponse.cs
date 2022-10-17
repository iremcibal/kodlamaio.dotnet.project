using Core.Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Brands
{
    public class PaginateListBrandResponse : PaginateListResponseBase
    {
        public IList<ListBrandResponse> Items { get; set; }

    }
}
