using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxStore.EntityLayer.Interface;

namespace LuxStore.EntityLayer.Entities
{
    public class News : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
