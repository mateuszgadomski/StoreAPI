using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public StoreContactDetails ContactDetails { get; set; } = default!;

        public string EncodedName { get; set; } = default!;

        public List<StoreProduct> Products { get; set; } = new();

        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
    }
}