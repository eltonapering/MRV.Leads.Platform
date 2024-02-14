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
            new Contact(id: contactOne,   firstName: "Bill",  fullName: "Bill Brady",      phoneNumber: "1234567890",  email: "billbrady@example.com"),
            new Contact(id: contactTwo,   firstName: "Craig", fullName: "Craig Flynn",     phoneNumber: "0987654321" , email: "craigflynn@example.com"),
            new Contact(id: contactThree, firstName: "Pete",  fullName: "Pete Edwards",    phoneNumber: "1020304050",  email: "peteedwards@example.com"),
            new Contact(id: contactFour,  firstName: "Chris", fullName: "Chris Sanderson", phoneNumber: "5040302010",  email: "chrissanderson@example.com")
        );

        // Seeding Intent
        modelBuilder.Entity<Intent>().HasData(
            new Intent
            (   
                contactId: contactOne,
                suburb: "Yandera 2574",
                category: Category.painters,
                description: "Need to paint 2 aluminium windows and a siding glass door",
                price: 99.99m,
                status: IntentStatus.New 
            ),
            new Intent
            (   
                contactId: contactTwo,
                suburb: "Woolooware 2230",
                category: Category.interiorPainters,
                description: "Internal wall 3 colours",
                price: 99.99m,
                status: IntentStatus.New
            ),
            new Intent
            (
                contactId: contactThree,
                suburb: "Caramar 6031",
                category: Category.building,
                description: "Plastes exposed brick wall (see photos), square off 2 archways (see photos), and " +
                             "expand pantry (see photos) ",
                price: 699.99m,
                status: IntentStatus.Accepted
            ),
            new Intent
            (
                contactId: contactFour,
                suburb: "Quinss Rocks 6030",
                category: Category.demolition,
                description: "There is a two story building at the front of the main house that´s about 10x5 that" +
                             "would like to convert into self contained living area ",
                price: 499.99m,
                status: IntentStatus.Accepted
            )
        );
    }

    // DbSets
    public DbSet<Intent> Intents { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<User> Users { get; set; }    
}