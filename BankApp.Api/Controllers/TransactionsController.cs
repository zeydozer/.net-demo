
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BankApp.Application.Transactions.Commands;
using BankApp.Domain.Entities;
using BankApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly AppDbContext _db;

    public TransactionsController(IMediator mediator, AppDbContext db)
    {
        _mediator = mediator;
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTransactionCommand cmd)
    {
        var id = await _mediator.Send(cmd);
        return CreatedAtAction(nameof(GetAll), new { id }, cmd);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new BankApp.Application.Transactions.Queries.GetAllTransactionsQuery());
        return Ok(result);
    }
}
