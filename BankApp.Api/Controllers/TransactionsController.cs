
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BankApp.Application.Transactions.Commands;
using BankApp.Application.Transactions.Queries;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
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
        var result = await _mediator.Send(new GetAllTransactionsQuery());
        return Ok(result);
    }
}
