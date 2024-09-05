using CleanArchitecture.Domain.Entities.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Product : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
