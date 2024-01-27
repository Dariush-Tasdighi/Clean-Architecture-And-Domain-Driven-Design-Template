using Domain.Features.Identity.Users.ValueObjects;

namespace Domain.Features.Identity.Users;

//public class UserAddress : Seedwork.Entity<UserAddressId, System.Guid>
//{
//	public const int PostalCodeMaxLength = 10;

//	public UserAddress(UserAddressId id, string postalCode) : base(id: id)
//	{
//		PostalCode = postalCode;
//	}

//	public string PostalCode { get; private set; }
//}

//public class UserAddress(UserAddressId id, string postalCode)
//	: Seedwork.Entity<UserAddressId, System.Guid>(id: id)
//{
//	public const int PostalCodeMaxLength = 10;

//	public string PostalCode { get; private set; } = postalCode;
//}

public class UserAddress
	: Seedwork.Entity<UserAddressId, System.Guid>
{
	internal UserAddress(UserAddressId id, string postalCode) : base(id: id)
	{
		PostalCode = postalCode;
	}

	public const int PostalCodeMaxLength = 10;

	public string PostalCode { get; private set; }

	public void UpdatePostalCode(string postalCode)
	{
		PostalCode = postalCode;
	}
}
