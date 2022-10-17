using AutoMapper;
using Business.Abstract;
using Business.Requests.Rentals;
using Business.Responses.Rentals;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IMapper _mapper;

        public RentalManager(IRentalDal rentalDal, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }

        public void Add(CreateRentalRequest request)
        {
            Rental rental = _mapper.Map<Rental>(request);

            _rentalDal.Add(rental);
        }

        public void Delete(DeleteRentalRequest request)
        {
            Rental rental = _mapper.Map<Rental>(request);

            _rentalDal.Delete(rental);
        }

        public GetRentalResponse GetById(GetRentalRequest request)
        {
            Rental rental = _rentalDal.Get(b => b.Id == request.Id, r=>r.Include(ri=>ri.Customer).Include(ri=>ri.Car));
            var response = _mapper.Map<GetRentalResponse>(rental);

            return response;
        }

        public PaginateListRentalResponse GetList(PageRequest request)
        {
            IPaginate<Rental> brands = _rentalDal.GetList(index: request.Index,
                                                                   size: request.Size);

            PaginateListRentalResponse response = _mapper.Map<PaginateListRentalResponse>(brands);

            return response;
        }

        public void Update(UpdateRentalRequest request)
        {
            Rental rental = _mapper.Map<Rental>(request);

            _rentalDal.Update(rental);
        }
    }
}
