using AspNetNetwork.DataAccess.Repository.IRepository;
using AspNetNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspNetNetwork.Controllers
{
    public class UserController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Users.Add(user);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Greet), new { id = user.Id });
            }

            return View(user);
        }

        public IActionResult Greet(int id)
        {
            var user = _unitOfWork.Users.GetWithFilter(x => x.Id == id);

            return View(user);
        }

        [HttpGet]
        public IActionResult AllUsers()
        {
            var users = _unitOfWork.Users.GetAll();
            return View(users);
        }
    }
}