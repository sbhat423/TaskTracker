using DataAccess.DataContext;
using DataAccess.Repositories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Boards = new BoardRepository(_context);
            Columns = new ColumnRepository(_context);
            Tasks = new TaskRepository(_context);
        }

        public IBoardRepository Boards { get; set; }
        public IColumnRepository Columns { get; set; }
        public ITaskRepository Tasks { get;  set; }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}
