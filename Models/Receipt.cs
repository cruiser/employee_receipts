using System;
using System.ComponentModel.DataAnnotations;



namespace employee_reimbursement.Models;

public class Receipt
{
    [Key]  
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public byte[] FileContent { get; set; }
}