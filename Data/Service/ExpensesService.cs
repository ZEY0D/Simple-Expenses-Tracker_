using System;
using efinancee.Models;
using Microsoft.EntityFrameworkCore;

namespace efinancee.Data.Service;

public class ExpensesService : IExpensesService
{
    // we can access the context here
            private readonly EfinanceeContext _context;

        public ExpensesService(EfinanceeContext context)
        {
            _context = context;
        }


    public async Task Add(Expense expense)
     {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync(); 
     }

    public async Task<IEnumerable<Expense>> GetAll()
    {
    var expenses =await _context.Expenses.ToListAsync();
    return expenses;
    }
}
