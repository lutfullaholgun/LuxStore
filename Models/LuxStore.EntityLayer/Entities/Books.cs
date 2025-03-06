using LuxStore.EntityLayer.Entities;
using LuxStore.EntityLayer.Interface;
using System.ComponentModel.DataAnnotations;

namespace LuxStore.EntityLayer.Entities
{
    public class Books : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Image")]
        public string? Image { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Book Code")]
        public string? BookCode { get; set; }

        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Display(Name = "ISBN")]
        public string? ISBN { get; set; }

        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Is Home?")]
        public bool IsHome { get; set; }

        [Display(Name = "Category Id")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        [Display(Name = "Author Id")]
        public int AuthorId { get; set; }

        public Author? Author { get; set; }

        [Display(Name = "Order No")]
        public int OrderNo { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}