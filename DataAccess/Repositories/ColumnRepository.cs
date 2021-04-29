using DataAccess.DataContext;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class ColumnRepository : GenericRepository<Column>, IColumnRepository
    {
        public ColumnRepository(ApplicationDbContext dbContext): base(dbContext)
        {

        }
    }
}
