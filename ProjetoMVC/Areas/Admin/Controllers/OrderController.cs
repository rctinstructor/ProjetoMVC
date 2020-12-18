using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.DataAccess.Data.Repository.IRepository;
using ProjetoMVC.Models;
using ProjetoMVC.Models.ViewModels;
using ProjetoMVC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Details(int id)
        {
            OrderViewModel orderVM = new OrderViewModel()
            {
                OrderHeader = _unitOfWork.OrderHeader.Get(id),
                OrderDetails = _unitOfWork.OrderDetails.GetAll(filter: o=> o.OrderHeader.Id == id)
            };
            return View(orderVM);
        }

        public IActionResult Approve(int id)
        {
            var orderFromDb = _unitOfWork.OrderHeader.Get(id);
            if (orderFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.OrderHeader.ChangeOrderStatus(id, SD.StatusApproved);
            return View(nameof(Index));
        }

        public IActionResult Reject(int id)
        {
            var orderFromDb = _unitOfWork.OrderHeader.Get(id);
            if (orderFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.OrderHeader.ChangeOrderStatus(id, SD.StatusRejected);
            return View(nameof(Index));
        }


        #region API

        public IActionResult GetAllOrders()
        {
            return Json( new {data = _unitOfWork.OrderHeader.GetAll()});
        }

        public IActionResult GetAllPendingOrders()
        {
            return Json(new { data = _unitOfWork.OrderHeader.GetAll(filter:o=>o.Status==SD.StatusSubmitted) });
        }

        public IActionResult GetAllApprovedOrders()
        {
            return Json(new { data = _unitOfWork.OrderHeader.GetAll(filter: o => o.Status == SD.StatusApproved) });
        }


        #endregion


    }
}
