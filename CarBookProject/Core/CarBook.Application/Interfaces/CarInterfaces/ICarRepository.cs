using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarInterfaces
{   //Solide aykırı olmaması adına car sınıfıma özgü 
    //metodlarımın imzalarını taşıdığım yer
    public interface ICarRepository
    {
        List<Car> GetCarListWithBrands();
        List<Car> GetLast4CarListWithBrands();
        Car GetCarWithBrandByCarId(int id);
    }
}
