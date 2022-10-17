using Business.Responses.Brands;
using Core.Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Colors
{
    public class PaginateListColorResponse : PaginateListResponseBase
    {
        public IList<ListColorResponse> Items { get; set; }

    }
}
