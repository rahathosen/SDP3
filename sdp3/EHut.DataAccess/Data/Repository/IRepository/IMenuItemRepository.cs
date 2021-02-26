using EHut.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EHut.DataAccess.Data.Repository.IRepository
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        void Update(MenuItem menuItem);
    }
}