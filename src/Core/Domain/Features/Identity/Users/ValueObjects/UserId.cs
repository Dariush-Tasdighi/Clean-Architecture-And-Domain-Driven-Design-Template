using System;

namespace Domain.Features.Identity.Users.ValueObjects;

//public sealed record class UserId(System.Guid Value);

//public sealed record class UserId(System.Guid Value)
//	: Seedwork.StronglyTypedId<System.Guid>(Value: Value);

public sealed record class
	UserId(Guid Value)
	: Seedwork.StronglyTypedId<Guid>(Value: Value)
{
	public static UserId New()
	{
		var result =
			new UserId
			(Value: Guid.NewGuid());

		return result;
	}
}
