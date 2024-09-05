namespace CleanArchitecture.Domain.Entities.Common
{
    //IAuditEntity Created ve Updated özelliklerini içerir. 
    public interface IAuditEntity
    {
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
