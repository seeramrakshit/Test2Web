using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TestRazor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required][MaxLength(20)][DisplayName("Category Name")] public string Name { get; set; }

        [DisplayName("Display Order")][Range(1, 39)] public int DisplayOder { get; set; }
    }
}
