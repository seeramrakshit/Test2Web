using System.ComponentModel.DataAnnotations;

namespace Test2WebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public int DisplayOder { get; set; }
    }
}
