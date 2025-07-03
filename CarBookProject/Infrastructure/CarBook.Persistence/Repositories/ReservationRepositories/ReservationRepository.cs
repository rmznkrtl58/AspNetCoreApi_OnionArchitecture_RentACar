using CarBook.Application.Interfaces.ReservationInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.ReservationRepositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarBookContext _context;
        public ReservationRepository(CarBookContext context)
        {
            _context = context;
        }
        public Reservation GetReservationByCarId(int id)
        {
            using (var ent = _context)
            {
                var values = ent.Reservations.Include(x => x.Car).ThenInclude(x => x.Brand).Where(x => x.Car.CarId == id).FirstOrDefault();
                return values;
            }
        }
    }
}