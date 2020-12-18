using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.DataAccess.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void LockUser(string userid);

        void UnLockUser(string userid);
    }
}
