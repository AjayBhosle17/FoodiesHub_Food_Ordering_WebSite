using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name must be between 2 and 100 characters.", MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Url(ErrorMessage = "Please enter a valid URL for the image.")]
        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        public DateTime? UpdatedDate { get; set; }
    }
}
