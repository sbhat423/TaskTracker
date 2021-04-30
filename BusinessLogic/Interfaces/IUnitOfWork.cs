using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IBoardRepository Boards { get; set; }
        IColumnRepository Columns { get; set; }
        ITaskRepository Tasks { get; set; }
        IUserRepository Users { get; set; }
        Task<int> SaveChangesAsync();
    }
}
