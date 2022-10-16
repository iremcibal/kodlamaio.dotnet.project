using AutoMapper;
using Business.Abstract;
using Business.Requests.Rentals;
using Business.Responses.Rentals;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public GetRentalResponse GetById(int id)
        {
            Rental rental = _rentalDal.Get(b => b.Id == id);
            var response = _mapper.Map<GetRentalResponse>(rental);

            return response;
        }

        public List<ListRentalResponse> GetList()
        {
            List<Rental> rental = _rentalDal.GetList();
            List<ListRentalResponse> response = _mapper.Map<List<ListRentalResponse>>(rental);

            return response;
        }

        public void Update(UpdateRentalRequest request)
        {
            Rental rental = _mapper.Map<Rental>(request);

            _rentalDal.Update(rental);
        }
    }
}
