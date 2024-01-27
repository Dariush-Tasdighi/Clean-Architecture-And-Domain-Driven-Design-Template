using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Users;
using System;

namespace Persistence.Configurations.Features.Identity.Users;

internal sealed class UserAddressConfiguration :
	object, IEntityTypeConfiguration<UserAddress>
{
	public UserAddressConfiguration() : base()
	{
	}

	public void Configure
		(Microsoft.EntityFrameworkCore.Metadata
		.Builders.EntityTypeBuilder<UserAddress> builder)
	{
		builder.ToTable(name: "UserAddresses");

		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasKey(d => d.Id);

		//builder
		//	.HasOne(d => d.Id);

		builder
			.Property(p => p.Id)
			.HasConversion(id => id.Value,
			value => new Domain.Features.Identity.Users.ValueObjects.UserAddressId(value));
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.PostalCode)
			.HasMaxLength(maxLength: UserAddress.PostalCodeMaxLength)
			;

		builder
			.Property(current => current.PostalCode)
			.IsUnicode(unicode: false)
			;
		// **************************************************

		// **************************************************
		builder
			.Property<Guid>(propertyName: "UserId")
			;

		//builder
		//	.HasIndex("UserId", "PostalCode")
		//	.IsUnique(unique: true)
		//	;

		builder
			.HasIndex("UserId", nameof(UserAddress.PostalCode))
			.IsUnique(unique: true)
			;
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
