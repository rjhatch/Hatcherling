namespace Hatcherling.Shared.Models.Interfaces;
internal interface ICreatedAndDeleted
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateDeleted { get; set; }
}
