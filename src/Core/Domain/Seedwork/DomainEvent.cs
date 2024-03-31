namespace Domain.Seedwork;

public abstract class DomainEvent(System.DateTime occurredOn)
	: object, Dtat.Seedwork.Abstractions.IDomainEvent
{
	public System.DateTime OccurredOn { get; init; } = occurredOn;
}
