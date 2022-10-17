using Core.Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Cars
{
    public class PaginateListCarResponse : PaginateListResponseBase
    {
        public IList<ListCarResponse> Items { get; set; }

    }
}
