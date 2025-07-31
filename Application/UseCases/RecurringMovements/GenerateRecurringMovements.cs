using Application.Interfaces.Common;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.RecurringMovements;
using Domain.Entities;

public class GenerateRecurringMovements : IGenerateRecurringMovements
{
    private readonly IRecurringMovementRepository _recurringMovementRepository;
    private readonly IMovementRepository _movementRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public GenerateRecurringMovements(
        IRecurringMovementRepository recurringRepo,
        IMovementRepository movementRepo,
        IDateTimeProvider dateTimeProvider)
    {
        _recurringMovementRepository = recurringRepo;
        _movementRepository = movementRepo;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task ExecuteAsync()
    {
        var today = DateOnly.FromDateTime(_dateTimeProvider.UtcNow);
        var recurrents = await _recurringMovementRepository.GetAllAsync();

        foreach (RecurringMovement r in recurrents)
        {
            if (r.ShouldGenerate(today))
            {
                var movement = new Movement(r.AccountId,r.Id, r.CategoryId, r.Amount, r.Description, r.MovementType);
                

                await _movementRepository.CreateMovementAsync(movement);
                r.SetLastGenerated(today);
                await _recurringMovementRepository.UpdateAsync(r);
            }
        }
    }
}
