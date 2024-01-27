using System.Linq;
using System.Collections.Generic;
using Domain.Features.Identity.Users.ValueObjects;

namespace Domain.Features.Identity.Users;

//public class User : Seedwork.Entity
//{
//	public User() : base()
//	{
//	}

//	public System.Guid Id { get; set; }

//	public string? EmailAddress { get; set; }
//}

//public class User : Seedwork.AggregateRoot
//{
//	public User() : base()
//	{
//	}

//	public System.Guid Id { get; set; }

//	public string? EmailAddress { get; set; }
//}

//public class User : Seedwork.AggregateRoot
//{
//	public User() : base()
//	{
//	}

//	public ValueObjects.UserId Id { get; set; }

//	public string? EmailAddress { get; set; }
//}

//public class User : Seedwork.AggregateRoot<UserId, System.Guid>
//{
//	public User(UserId id) : base(id: id)
//	{
//	}

//	public string? EmailAddress { get; set; }
//}

//public class User(UserId id) : Seedwork.AggregateRoot<UserId, System.Guid>(id: id)
//{
//	public string? EmailAddress { get; set; }
//}

//public class User : Seedwork.AggregateRoot<UserId, System.Guid>
//{
//	public static User Create(UserId id)
//	{
//		User data = new(id: id);

//		return data;
//	}

//	private User(UserId id) : base(id: id)
//	{
//	}

//	public string? EmailAddress { get; private set; }

//	public void SetEmailAddress(string? emailAddress)
//	{
//		EmailAddress = emailAddress;
//	}
//}

public class User : Seedwork.AggregateRoot<UserId, System.Guid>
{
	public static User Create(UserId id)
	{
		User data = new(id: id);

		return data;
	}

	private User(UserId id) : base(id: id)
	{
	}

	private readonly List<UserAddress> _addresses = [];

	public IReadOnlyCollection<UserAddress> Addresses
	{
		get
		{
			return _addresses.AsReadOnly();
		}
	}

	public string? EmailAddress { get; private set; }

	public void SetEmailAddress(string? emailAddress)
	{
		EmailAddress = emailAddress;
	}

	public void AddAddress(string postalCode)
	{
		var foundedEntity =
			_addresses
			.Where(current => current.PostalCode == postalCode)
			.FirstOrDefault();

		if(foundedEntity is not null)
		{
			throw new System.Exception
				(message: "Postal code already exist!");
		}

		var address = new UserAddress
			(id: UserAddressId.New(), postalCode: postalCode);

		_addresses.Add(item: address);
	}
}
