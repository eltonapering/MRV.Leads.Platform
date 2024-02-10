using Microsoft.EntityFrameworkCore;
using MRV.Leads.Platform.Domain.Entities;
using MRV.Leads.Platform.Domain.Enums;

namespace MRV.Leads.Platform.Infrastructure;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        var hashedPassword = "SomeHashedPassword";
        // Seeding User
        modelBuilder.Entity<User>().HasData(
            new User(id:  Guid.NewGuid(), login: "user1", email: "user1@example.com", passwordHash: hashedPassword),
            new User(id:  Guid.NewGuid(), login: "user2", email: "user2@example.com", passwordHash: hashedPassword)
        );

        var contactOne = Guid.NewGuid();
        var contactTwo = Guid.NewGuid();
        var contactThree = Guid.NewGuid();
        var contactFour = Guid.NewGuid();        
        // Seeding Contact
        modelBuilder.Entity<Contact>().HasData(
            new Contact(id: contactOne,   fullName:  "Contact One",   phoneNumber: "1234567890", email: "user1@example.com"),
            new Contact(id: contactTwo,   fullName:  "Contact Two",   phoneNumber: "0987654321" , email: "user2@example.com"),
            new Contact(id: contactThree, fullName:  "Contact Three", phoneNumber: "1020304050", email: "user3@example.com"),
            new Contact(id: contactFour,  fullName:  "Contact Four",  phoneNumber: "5040302010", email: "user4@example.com")
        );

        // Seeding Intent
        modelBuilder.Entity<Intent>().HasData(
            new Intent
            (   
                contactId: contactOne,
                suburb: "Yandera 2574",
                category: Category.painters,
                description: "Initial intent",
                price: 99.99m,
                status: IntentStatus.Accepted 
            ),
            new Intent
            (   
                contactId: contactTwo,
                suburb: "Woolooware 2230",
                category: Category.interiorPainters,
                description: "Second intent",
                price: 99.99m,
                status: IntentStatus.Accepted
            ),
            new Intent
            (
                contactId: contactThree,
                suburb: "Caramar 6031",
                category: Category.building,
                description: "Thirty intent",
                price: 699.99m,
                status: IntentStatus.Declined
            ),
            new Intent
            (
                contactId: contactFour,
                suburb: "Quinss Rocks 6030",
                category: Category.demolition,
                description: "Fourthy intent",
                price: 499.99m,
                status: IntentStatus.Declined
            )
        );
    }

    // DbSets
    public DbSet<Intent> Intents { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<User> Users { get; set; }    
}