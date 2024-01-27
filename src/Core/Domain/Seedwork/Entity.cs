namespace Domain.Seedwork;

//public class Entity : object
//{
//}

public class Entity<TStronglyTypedId, TValue>
	: object,
	Dtat.Seedwork.Abstractions.IEntity<TStronglyTypedId, TValue>
	where TValue : notnull
	where TStronglyTypedId : Dtat.Seedwork.Abstractions.IStronglyTypedId<TValue>
{
	public Entity(TStronglyTypedId id) : base()
	{
		Id = id;
	}

	public TStronglyTypedId Id { get; init; }
}
