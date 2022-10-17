using Business.Requests.Rentals;
using Business.Responses.Rentals;
using Core.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        GetRentalResponse GetById(GetRentalRequest request);
        PaginateListRentalResponse GetList(PageRequest request);
        void Add(CreateRentalRequest request);
        void Delete(DeleteRentalRequest request);
        void Update(UpdateRentalRequest request);
        //List<ListRentalResponse> GetRentDate(DateTime date);
        //List<ListRentalResponse> GetRentDateReturnDate(DateTime rentDate,DateTime returnDate);
    }
}
