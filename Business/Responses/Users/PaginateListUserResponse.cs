using Business.Responses.Brands;
using Core.Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Users
{
    public class PaginateListUserResponse : PaginateListResponseBase
    {
        public IList<ListUserResponse> Items { get; set; }

    }
}
