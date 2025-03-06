using LuxStore.EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxStore.EntityLayer.Entities
{
    public class Slider : IEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Link { get; set; }
    }
}
