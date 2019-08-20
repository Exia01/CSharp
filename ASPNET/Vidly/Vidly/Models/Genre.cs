using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}