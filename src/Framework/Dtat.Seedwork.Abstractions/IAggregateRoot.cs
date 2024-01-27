namespace Dtat.Seedwork.Abstractions;

public interface IAggregateRoot
{
	void ClearDomainEvents();

	//void AddDomainEvent(IDomainEvent domainEvent);
	void RaiseDomainEvent(IDomainEvent domainEvent);
}
