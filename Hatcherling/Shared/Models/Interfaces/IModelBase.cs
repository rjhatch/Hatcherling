namespace Hatcherling.Shared.Models.Interfaces;
internal interface IModelBase
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateDeleted { get; set; }
}
