using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.RentACarInterfaces
{
    public interface IRentACarRepository
    {
        public Task <List<RentACar>> GetCarsByFilterAsync(Expression<Func<RentACar, bool>> filter);
    }
}
