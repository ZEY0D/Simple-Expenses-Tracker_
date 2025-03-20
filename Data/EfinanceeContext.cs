using System;

namespace efinancee.Data;

using efinancee.Models;
using Microsoft.EntityFrameworkCore;


public class EfinanceeContext (DbContextOptions<EfinanceeContext> options) : DbContext (options)
{
    public DbSet<Expense> Expenses => Set<Expense>();
}
