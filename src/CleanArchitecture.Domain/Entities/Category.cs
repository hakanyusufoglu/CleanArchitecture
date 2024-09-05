using CleanArchitecture.Domain.Entities.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Category : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
