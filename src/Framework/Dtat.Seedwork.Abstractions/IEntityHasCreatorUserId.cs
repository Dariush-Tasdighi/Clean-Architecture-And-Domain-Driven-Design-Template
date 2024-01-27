namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasCreatorUserId<TIdentity> where TIdentity : notnull
{
	TIdentity CreatorUserId { get; }

	System.DateTimeOffset InsertDateTime { get; }

	void Create(TIdentity creatorUserId);
}
