using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IColumnRepository : IGenericRepository<Column>
    {
        // can extend by providing more methods than the one mentioned in IGenericRepository
    }
}
