namespace Domain.Features.Identity.Users.ValueObjects;

//public sealed record class UserAddressId(System.Guid Value)
//	: Seedwork.StronglyTypedId<System.Guid>(Value: Value);

//public sealed record class UserAddressId
//	: Seedwork.StronglyTypedId<System.Guid>
//{
//	public static UserAddressId New()
//	{
//		var result =
//			new UserAddressId(Value: System.Guid.NewGuid());

//		return result;
//	}

//	public UserAddressId(System.Guid Value) : base(Value: Value)
//	{
//	}
//}

public sealed record class
	UserAddressId(System.Guid Value)
	: Seedwork.StronglyTypedId<System.Guid>(Value: Value)
{
	public static UserAddressId New()
	{
		var result =
			new UserAddressId(Value: System.Guid.NewGuid());

		return result;
	}
}
