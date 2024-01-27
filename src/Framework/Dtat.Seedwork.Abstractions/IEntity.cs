namespace Dtat.Seedwork.Abstractions;

/// <summary>
/// Marker
/// </summary>
//public interface IEntity
//{
//}

//public interface IEntity
//{
//	System.Guid Id { get; set; }
//}

//public interface IEntity<TIdentity>
//{
//	TIdentity Id { get; set; }
//}

//public interface IEntity<TIdentity>
//{
//	TIdentity Id { get; }
//}

//public interface IEntity<TIdentity> where TIdentity : notnull
//{
//	TIdentity Id { get; }
//}

public interface IEntity<TStronglyTypedId, TValue>
	where TStronglyTypedId : IStronglyTypedId<TValue> where TValue : notnull
{
	TStronglyTypedId Id { get; }
}
