using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test2WebApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required] [MaxLength(20)] [DisplayName("Category Name")] public string Name { get; set; }

        [DisplayName("Display Order")] [Range(1,39)] public int DisplayOder { get; set; }
    }
}
