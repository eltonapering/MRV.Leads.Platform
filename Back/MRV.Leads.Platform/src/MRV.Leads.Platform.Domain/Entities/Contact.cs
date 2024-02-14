namespace MRV.Leads.Platform.Domain.Entities;

public class Contact
{
    public Contact(Guid id, string firstName, string fullName, string phoneNumber, string email)
    {
        Id = id;
        FirstName = firstName;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string FullName { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
}