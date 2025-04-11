using Microsoft.AspNetCore.Mvc;
using employee_reimbursement.Data;
using employee_reimbursement.Models;

namespace employee_reimbursement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReceiptController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public ReceiptController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateReimbursement([FromForm] string date, [FromForm] string amount, [FromForm] string description, [FromForm] IFormFile receiptFile)
    {
        if (string.IsNullOrEmpty(date) || 
            string.IsNullOrEmpty(amount) || string.IsNullOrEmpty(description) || receiptFile == null)
        {
            return BadRequest("All fields are required before submission");
        }

        try
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                await receiptFile.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            // letting entity do the heavy lifting
            var receipt = new Receipt
            {
                Date = DateTime.Parse(date),
                Amount = decimal.Parse(amount),
                Description = description,
                FileContent = fileBytes
            };

            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();
            
            return Ok(new { id = receipt.Id, message = "Receipt submitted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}