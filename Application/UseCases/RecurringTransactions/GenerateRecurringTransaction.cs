using Application.Interfaces.Common;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.RecurringTransactions;
using Domain.Entities;

public class GenerateRecurringTransaction : IGenerateRecurringTransaction
{
    private readonly IRecurringMovementRepository _recurringMovementRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public GenerateRecurringTransaction(
        IRecurringMovementRepository recurringRepo,
        ITransactionRepository TransactionRepo,
        IDateTimeProvider dateTimeProvider)
    {
        _recurringMovementRepository = recurringRepo;
        _transactionRepository = TransactionRepo;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task ExecuteAsync()
    {
        var today = DateOnly.FromDateTime(_dateTimeProvider.UtcNow);
        var recurrents = await _recurringMovementRepository.GetAllAsync();

        foreach (RecurringTransaction r in recurrents)
        {
            if (r.ShouldGenerate(today))
            {
                var movement = new Transaction(r.AccountId,r.Id, r.CategoryId, r.Amount, r.Description, r.MovementType);
                

                await _transactionRepository.CreateTransactionAsync(movement);
                r.SetLastGenerated(today);
                await _recurringMovementRepository.UpdateAsync(r);
            }
        }
    }
}
