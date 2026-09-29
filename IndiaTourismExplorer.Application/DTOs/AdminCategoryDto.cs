using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.DTOs
{
    public class AdminCategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
