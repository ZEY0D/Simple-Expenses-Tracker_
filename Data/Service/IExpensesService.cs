using System;
using efinancee.Models;

namespace efinancee.Data.Service;

public interface IExpensesService
{
            // getting all the data in a table
    Task<IEnumerable<Expense>> GetAll();

            // adding data into a table
    Task Add(Expense expense);
}
