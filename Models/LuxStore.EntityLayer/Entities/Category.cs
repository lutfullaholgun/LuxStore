using LuxStore.EntityLayer.Interface;
using System.Collections;
using System.ComponentModel;

namespace LuxStore.EntityLayer.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }

        [DisplayName("Image")]
        public string? Image { get; set; }

        [DisplayName("Is Active ?")]
        public bool IsActive { get; set; }

        [DisplayName("Show in Top Menu")]
        public bool IsTopMenu { get; set; }

        [DisplayName("Top Category")]
        public int ParentId { get; set; }

        [DisplayName("Order No")]
        public int OrderNo { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


        public IList<Books>? Books { get; set; } //her bir kategorinin birden fazla ürünü olabilir.
    }
}