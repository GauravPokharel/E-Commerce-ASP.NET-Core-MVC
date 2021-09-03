
namespace CSIT2074.Web.DbContext
{
    /// <summary>
    /// Entity Framework is an Object/Relational Mapping (O/RM) framework. It is an enhancement 
    /// to ADO.NET that gives developers an automated mechanism for accessing & storing the data 
    /// in the database.
    /// 
    ///  It is open-source, lightweight, extensible and a cross-platform version of Entity Framework
    ///  data access technology.
    ///  
    /// EF Core supports two development approaches 1) Code-First 2) Database-First.
    ///     Code first:  first create entity classes with properties defined in it. Entity framework will 
    ///     create the database and tables based on the entity classes defined.    /// 
    ///     Database-First:Database and tables are created first. Then you create entity Data Model using the 
    ///     created database.
    /// 
    /// To access MS SQL Server database, we need to install Microsoft.EntityFrameworkCore.SqlServer 
    /// NuGet package.
    /// 
    /// DbContext:The DbContext class is an integral part of Entity Framework. An instance of DbContext 
    /// represents a session with the database which can be used to query and save instances of your 
    /// entities to a database.
    /// **DbContext in EF Core allows us to perform following tasks:
    ///     Manage database connection
    ///     Configure model & relationship
    ///     Querying database
    ///     Saving data to the database
    ///     Configure change tracking
    ///     Caching
    ///     Transaction management
    ///     
    /// **Create context class that derives from DbContext. 
    /// **This context class typically includes DbSet<TEntity> properties for each entity in the model.
    /// **OnConfiguring() method allows us to select and configure the data source to be used with a 
    ///   context using DbContextOptionsBuilder.
    /// **OnModelCreating() method allows us to configure the model using ModelBuilder Fluent API.
    /// </summary>
    public class EfContext //: DbContext
    {
        //public EfContext(DbContextOptions<EfContext> options) : base(options)
        //{

        //}
    }
}
