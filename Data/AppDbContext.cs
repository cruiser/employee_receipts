using Microsoft.EntityFrameworkCore;
using employee_reimbursement.Models;

namespace employee_reimbursement.Data;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Receipt> Receipts { get; set; }
}
