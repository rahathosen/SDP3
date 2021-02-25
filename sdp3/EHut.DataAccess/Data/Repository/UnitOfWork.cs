﻿using EHut.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EHut.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            FoodType = new FoodTypeRepository(_db);
        }

        public IFoodTypeRepository FoodType { get; private set; }
        public ICategoryRepository Category { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}