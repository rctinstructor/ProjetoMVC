using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.DataAccess.Data.Repository.IRepository
{
    public interface IServiceRepository : IRepository<Service>
    {
        void Update(Service service);
    }
}
