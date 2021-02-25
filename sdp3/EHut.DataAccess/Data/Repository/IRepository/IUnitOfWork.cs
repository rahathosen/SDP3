using System;
using System.Collections.Generic;
using System.Text;

namespace EHut.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IFoodTypeRepository FoodType { get; }

        void Save();
    }
}