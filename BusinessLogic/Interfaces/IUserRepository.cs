using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        // can extend by providing more methods than the one mentioned in IGenericRepository
    }
}
