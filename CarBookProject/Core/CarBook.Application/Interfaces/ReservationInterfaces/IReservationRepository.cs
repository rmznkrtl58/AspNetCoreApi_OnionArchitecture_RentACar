using CarBook.Application.Features.RepositoryPattern.IGenericRepositories;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.ReservationInterfaces
{
    public interface IReservationRepository
    {
        public Reservation GetReservationByCarId(int id);
    }
}
