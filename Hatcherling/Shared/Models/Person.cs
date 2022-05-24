namespace Hatcherling.Shared.Models
{
    public class Person
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FKOrganization { get; set; } = null!;
    }
}
