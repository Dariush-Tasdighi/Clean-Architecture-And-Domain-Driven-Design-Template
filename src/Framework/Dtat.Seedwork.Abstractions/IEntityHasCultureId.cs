namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasCultureId<TIdentity> where TIdentity : notnull
{
	TIdentity CultureId { get; }
}
