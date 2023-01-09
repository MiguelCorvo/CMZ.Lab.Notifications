using CMZ.Lab.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CMZ.Lab.Infrastructure.Data
{
    /// <summary>
    /// Application Dbcontext
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        /// <remarks>
        /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see> and
        /// <see href="https://aka.ms/efcore-docs-dbcontext-options">Using DbContextOptions</see> for more information.
        /// </remarks>
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// <para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information.
        /// </para>
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(c => c.Subscriptions).WithOne(c => c.User).HasForeignKey(s => s.IdUser);
            modelBuilder.Entity<NotificationFrecuencie>().HasMany(c => c.Subscriptions).WithOne(c => c.NotificationFrecuencie).HasForeignKey(s => s.IdNotificationFrequency);
            modelBuilder.Entity<EntityActivityType>().HasMany(c=>c.Subscriptions).WithOne(c=>c.EntityActivityType).HasForeignKey(s=>s.IdEntityActivityType);            
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>
        /// The subscriptions.
        /// </value>
        public DbSet<Subscription> Subscriptions {get; set;}

        /// <summary>
        /// Gets or sets the enity activity types.
        /// </summary>
        /// <value>
        /// The enity activity types.
        /// </value>
        public DbSet<EntityActivityType> EnityActivityTypes { get; set; }

        /// <summary>
        /// Gets or sets the notification frecuencies.
        /// </summary>
        /// <value>
        /// The notification frecuencies.
        /// </value>
        public DbSet<NotificationFrecuencie> NotificationFrecuencies { get; set; }
    }
}
