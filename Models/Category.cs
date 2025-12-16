using System.ComponentModel.DataAnnotations;

namespace SampleWebApplication.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }    

        public string DisplayOrder { get; set; }
    }
}
