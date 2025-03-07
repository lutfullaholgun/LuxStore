﻿using LuxStore.EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxStore.EntityLayer.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
