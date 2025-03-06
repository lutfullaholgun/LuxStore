using LuxStore.EntityLayer.Interface;
using System.ComponentModel;

namespace LuxStore.EntityLayer.Entities
{
    public class Author : IEntity
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }

        [DisplayName("Image")]
        public string? Img { get; set; }

        [DisplayName("Is Active?")]
        public bool IsActive { get; set; }

        [DisplayName("Order No")]
        public int OrderNo { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public IList<Product>? Products { get; set; }
    }
}