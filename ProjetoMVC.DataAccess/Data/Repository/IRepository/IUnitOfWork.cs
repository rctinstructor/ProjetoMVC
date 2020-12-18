using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IServiceRepository Service { get; }

        IOrderHeaderRepository OrderHeader { get; }

        IOrderDetailsRepository OrderDetails { get; }

        IUserRepository User { get; }

        ISP_Call SP_Call { get; }

        void Save();

    }
}
