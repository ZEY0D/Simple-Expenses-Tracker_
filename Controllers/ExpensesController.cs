using efinancee.Data;
using efinancee.Data.Service;
using efinancee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace efinancee.Controllers
{
    public class ExpensesController : Controller
    {
            // reading an instance of the context and pass it as a dependency to the constructor
            // to touch the database
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }




        // GET: ExpensesController

        public async Task<IActionResult> Index()
        {
            // in this action method we should get all the expenses
            var expenses =await _expensesService.GetAll();     //(Expenses is the DbSet of all the expenses)
            return View(expenses);
        }
            // ///////// the previous method was for just showing the data ___ so , how and where does the user
                /////// actually inserts the data ... it should be another view page to submit the data into
                
        

                // /////this method just returns a view page to redirect the user to page where he can insert the data///
                // //// hence we should create a second [HttpPosT] method to let the data that user inserted to affect the database of the application

        public IActionResult Create(){
            return View();
        }



        [HttpPost]      // keep the async programming
                public async Task<IActionResult> Create(Expense expense){
                    if(ModelState.IsValid){
                        await _expensesService.Add(expense);

                        return RedirectToAction("Index");
                    }
            return View();
        }
        


    }
}
