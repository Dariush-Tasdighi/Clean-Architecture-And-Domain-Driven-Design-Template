using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
	#region Constructor
	public ApplicationDbContext() : base()
	{
		// TODO: Never use in production mode
		// نکته بسیار مهم
		// تا قبل از اولین نسخه‌ای که می‌خواهیم آن‌را منتشر نماییم
		Database.EnsureCreated();
	}
	#endregion /Constructor

	#region Properties

	#region Feature: Identity

	public Microsoft.EntityFrameworkCore.DbSet<Domain.Features.Identity.Users.User> Users { get; set; }

	/// <summary>
	/// ها را بنویسیم Entity نباید
	/// ها را بنویسیم Aggregate Root و صرفا باید
	/// </summary>
	//public Microsoft.EntityFrameworkCore.DbSet<Domain.Features.Identity.Users.UserAddress> UserAddresses { get; set; }

	#endregion /Feature: Identity

	#endregion /Properties

	#region Methods

	#region OnConfiguring()
	protected override void OnConfiguring
		(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	{
		// ******************************************************************
		// https://www.connectionstrings.com/sql-server/
		// Connect Timeout or Connection Timeout: Default: 15 Seconds
		// ******************************************************************

		// ******************************************************************
		// *** Windows Authentication Mode without TrustServerCertificate ***
		// ******************************************************************
		//var connectionString =
		//	"Server=.;Database=CleanDDDTemplateDb;MultipleActiveResultSets=true;Trusted_Connection=True;";
		// ******************************************************************

		// ***************************************************************
		// *** Windows Authentication Mode with TrustServerCertificate ***
		// ***************************************************************
		//var connectionString =
		//	"Server=.;Database=CleanDDDTemplateDb;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True;";
		// ******************************************************************

		// *********************************************************************
		// *** SQL Server Authentication Mode without TrustServerCertificate ***
		// *********************************************************************
		//var connectionString =
		//	"Server=.;User ID=sa;Password=1234512345;Database=CleanDDDTemplateDb;MultipleActiveResultSets=true";
		// ******************************************************************

		// ******************************************************************
		// *** SQL Server Authentication Mode with TrustServerCertificate ***
		// ******************************************************************
		var connectionString =
			"Server=.;User ID=sa;Password=1234512345;Database=CleanDDDTemplateDb;MultipleActiveResultSets=true;TrustServerCertificate=True;";
		// ******************************************************************

		// UseSqlServer -> using Microsoft.EntityFrameworkCore;
		optionsBuilder.UseSqlServer
			(connectionString: connectionString);

		optionsBuilder.EnableDetailedErrors(detailedErrorsEnabled: true);
		optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
		optionsBuilder.LogTo
			(action: System.Console.WriteLine,
			//minimumLevel: Microsoft.Extensions.Logging.LogLevel.Trace,
			minimumLevel: Microsoft.Extensions.Logging.LogLevel.Trace,
			options: Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.Id
			| Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.Level
			| Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.Category
			| Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.LocalTime);
	}
	#endregion /OnConfiguring()

	#region OnModelCreating()
	protected override void OnModelCreating
		(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
	{
		// Learning Fluent API

		// Solution (1)
		//modelBuilder
		//	.Entity<Domain.Features.Identity.Users.User>()
		//	.HasIndex(current => new { current.EmailAddress })
		//	.IsUnique(unique: true)
		//	;
		// /Solution (1)

		// Solution (2)
		//modelBuilder.ApplyConfiguration(configuration:
		//	new Configurations.Features.Identity.Users.UserConfiguration());
		// /Solution (2)

		// Solution (3)
		//new Configurations.Features.Identity.Users.UserConfiguration()
		//	.Configure(builder: modelBuilder.Entity<Domain.Features.Identity.Users.User>());
		// /Solution (3)

		// Solution (4)
		//modelBuilder.ApplyConfigurationsFromAssembly
		//	(assembly: System.Reflection.Assembly.GetExecutingAssembly());
		// /Solution (4)

		// Solution (5)
		//modelBuilder.ApplyConfigurationsFromAssembly
		//	(assembly: typeof(Configurations.Features.Identity.Users.UserConfiguration).Assembly);
		// /Solution (5)

		// Solution (6)
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(ApplicationDbContext).Assembly);
		// /Solution (6)

		//modelBuilder.Seed();
	}
	#endregion /OnModelCreating()

	#endregion /Methods
}
