using ECommerse.Core.Entities;
using ECommerse.Core.Identity;

namespace ECommerse.WebUI.Models.StoreViewModels
{
    public class StoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Desription { get; set; }

        public string OwnerID { get; set; } = null!;
        public AppUser? Owner { get; set; }

        public ICollection<StoreReview>? StoreReviews { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
