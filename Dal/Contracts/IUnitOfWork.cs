using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IProductTypeRepository ProductTypeRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
