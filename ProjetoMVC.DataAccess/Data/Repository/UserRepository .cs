using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMVC.DataAccess.Data.Repository.IRepository;
using ProjetoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoMVC.DataAccess.Data.Repository
{
    public class UserRepository : Repository<ApplicationUser> , IUserRepository
    {
        private readonly ApplicationDbContext _db;


        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void LockUser(string userid)
        {
            var userFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == userid);
            userFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        public void UnLockUser(string userid)
        {
            var userFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == userid);
            userFromDb.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
