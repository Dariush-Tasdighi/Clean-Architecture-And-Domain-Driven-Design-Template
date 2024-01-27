namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasCode<TCode> where TCode : notnull
{
	TCode Code { get; }
}
