using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations.Features.Identity.Users;

internal sealed class UserConfiguration : object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Features.Identity.Users.User>
{
	public UserConfiguration() : base()
	{
	}

	//public void Configure
	//	(Microsoft.EntityFrameworkCore.Metadata
	//	.Builders.EntityTypeBuilder<Domain.Features.Identity.Users.User> builder)
	//{
	//}

	public void Configure
		(Microsoft.EntityFrameworkCore.Metadata
		.Builders.EntityTypeBuilder<Domain.Features.Identity.Users.User> builder)
	{
		// **************************************************
		// **************************************************
		// **************************************************
		//builder
		//	.HasKey(current => current.Id.Value)
		//	;

		//builder
		//	.Property(current => current.Id.Value)
		//	.ValueGeneratedOnAdd()
		//	;
		// **************************************************

		// **************************************************
		//builder
		//	.ComplexProperty(current => current.Id), current =>
		//	{
		//		current
		//			.Property(other => other.Value)
		//			.HasColumnName(name: "Id")
		//			;
		//	});

		//builder
		//	.ComplexProperty(current => current.Id);

		builder
			.HasKey(d => d.Id);

		//builder
		//	.HasOne(d => d.Id);

		builder
			.Property(p => p.Id)
			.HasConversion(id => id.Value,
			value => new Domain.Features.Identity.Users.ValueObjects.UserId(value));
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.EmailAddress)
			.HasMaxLength(maxLength: 250)
			;

		builder
			.Property(current => current.EmailAddress)
			.IsUnicode(unicode: false)
			;

		//builder
		//	.HasIndex(current => current.EmailAddress)
		//	.IsUnique(unique: true)
		//	;

		builder
			.HasIndex(current => new { current.EmailAddress })
			.IsUnique(unique: true)
			;
		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		//builder
		//	.HasMany(current => current.Addresses)
		//	.WithOne(navigationName: "UserId")
		//	.HasForeignKey(foreignKeyPropertyNames: "UserId")
		//	.IsRequired(required: true)
		//	.OnDelete(deleteBehavior: DeleteBehavior.Cascade)
		//	;
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
