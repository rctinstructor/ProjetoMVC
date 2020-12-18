using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMVC.DataAccess.Data.Repository.IRepository;
using ProjetoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoMVC.DataAccess.Data.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails> , IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;


        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


    }
}
