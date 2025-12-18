using System.ComponentModel.DataAnnotations;

namespace SampleWebApplication.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, 50)]
        public int DisplayOrder { get; set; }
    }
}
