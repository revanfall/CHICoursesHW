using ExpensesManager.DataAccess.Repository.IRepository;
using ExpensesManager.Models;
using ExpensesManager.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpensesManager.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ExpenseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ExpenseVM expenseVM = new()
            {
                Expense = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                })
            };

            if (id == null || id == 0)
            {

                return View(expenseVM);
            }
            else
            {
                expenseVM.Expense = _unitOfWork.Expense.GetFirstOrDefault(u => u.Id == id);
                return View(expenseVM);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ExpenseVM obj)
        {
            if(ModelState.IsValid)
            {
                if(obj.Expense.Id == 0)
                {
                    _unitOfWork.Expense.Add(obj.Expense);
                }
                else
                {
                    _unitOfWork.Expense.Update(obj.Expense);
                }

                _unitOfWork.Save();
                TempData["success"] = "Expense added successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var expenseList = _unitOfWork.Expense.GetAll(includeProperties: "Category").Select(u=>new Expense()
            {
                Id = u.Id,
                Comment = u.Comment,
                SpentMoney = u.SpentMoney,
                CategoryId = u.CategoryId,
                Category=u.Category,
                CreatedDateTime = u.CreatedDateTime,
                CreatedDateTimeToRender = u.CreatedDateTime.ToString("dddd, dd MMMM yyyy HH:mm")
            });
            return Json(new { data = expenseList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Expense.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Expense.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully" });
        }
        #endregion
    }

}


