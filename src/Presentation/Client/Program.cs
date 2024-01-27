using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

// **************************************************
//System.Console.WriteLine(value: "Hello, World!");
// **************************************************

var userId = new System.Guid
	(g: "7116E729-BF67-4DB7-9CA3-FB00A5608664");

// **************************************************
//using var applicationDbContext =
//	new Persistence.ApplicationDbContext();

//var user =
//	new Domain.Features.Identity.Users.User
//	{
//		Id = userId
//		EmailAddress = "DariushT@GMail.com",
//	};

//await applicationDbContext.AddAsync(entity: user);

//await applicationDbContext.SaveChangesAsync();

//System.Console.WriteLine(value: "Finished...");
// **************************************************

// **************************************************
//using var applicationDbContext =
//	new Persistence.ApplicationDbContext();

//var userIdValueObject =
//	new Domain.Features.Identity.Users.ValueObjects.UserId(Value: userId);

////var user =
////	new Domain.Features.Identity.Users.User
////	{
////		Id = userIdValueObject,
////		EmailAddress = "DariushT@GMail.com",
////	};

////var user =
////	new Domain.Features.Identity.Users.User(id: userIdValueObject)
////	{
////		EmailAddress = "DariushT@GMail.com",
////	};

//var user =
//	Domain.Features.Identity.Users.User.Create(id: userIdValueObject);

//user.SetEmailAddress(emailAddress: "DariushT@GMail.com");

//await applicationDbContext.AddAsync(entity: user);

//await applicationDbContext.SaveChangesAsync();

//user =
//	await
//	applicationDbContext.Users
//	.Where(current => current.Id == userIdValueObject)
//	.FirstOrDefaultAsync();

//System.Console.WriteLine(value: user?.Id);

//System.Console.WriteLine(value: "Finished...");
// **************************************************

// **************************************************
using var applicationDbContext =
	new Persistence.ApplicationDbContext();

var userIdValueObject =
	new Domain.Features.Identity.Users.ValueObjects.UserId(Value: userId);

var user =
	Domain.Features.Identity.Users.User.Create(id: userIdValueObject);

user.SetEmailAddress(emailAddress: "DariushT@GMail.com");

user.AddAddress(postalCode: "1111111111");
user.AddAddress(postalCode: "2222222222");

await applicationDbContext.AddAsync(entity: user);

await applicationDbContext.SaveChangesAsync();

user =
	await
	applicationDbContext.Users
	.Include(current => current.Addresses)
	.Where(current => current.Id == userIdValueObject)
	.FirstOrDefaultAsync();

Console.ForegroundColor = ConsoleColor.Red;
var message =
	$"User Id: {user?.Id} - Address Count: {user?.Addresses.Count}";
Console.WriteLine(value: message);
Console.ResetColor();
// **************************************************
