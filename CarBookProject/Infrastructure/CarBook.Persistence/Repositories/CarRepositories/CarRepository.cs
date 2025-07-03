﻿using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;
        public CarRepository(CarBookContext context)
        {
            _context = context;
        }
        public List<Car> GetCarListWithBrands()
        {
            using (var ent=_context)
            {
                var carList = ent.Cars.Include(x => x.Brand).ToList();
                return carList;
            }
        }
        public Car GetCarWithBrandByCarId(int id)
        {
            using (var ent=_context)
            {
                var findCar = _context.Cars.Include(x => x.Brand).Where(x => x.CarId == id).FirstOrDefault();
                return findCar;
            }
        }
        public List<Car> GetLast4CarListWithBrands()
        {
            using (var ent=_context)
            {
                return ent.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarId).Take(4).ToList();
            }
        }
    }
}
