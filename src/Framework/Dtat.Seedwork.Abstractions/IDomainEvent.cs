namespace Dtat.Seedwork.Abstractions;

//public interface IDomainEvent : Mediator.INotification
//{
//}

public interface IDomainEvent : Mediator.INotification
{
	System.DateTime OccurredOn { get; }
}
