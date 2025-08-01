using Microsoft.AspNetCore.Mvc;
using BankApp.Domain.Entities;
using BankApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _db;
    public TransactionsController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _db.Transactions.OrderByDescending(t => t.CreatedAt).ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Transaction t)
    {
        _db.Transactions.Add(t);
        await _db.SaveChangesAsync();
        return Created("", t);
    }
}
