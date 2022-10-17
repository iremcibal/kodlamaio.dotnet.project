using Core.Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.CarStates
{
    public class PaginateListCarStateResponse : PaginateListResponseBase
    {
        public IList<ListCarStateResponse> Items { get; set; }

    }
}
