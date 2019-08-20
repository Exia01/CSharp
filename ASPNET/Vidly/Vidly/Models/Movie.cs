using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        //A Plain Old CLR Objects(POCO) does not have behavior or logic
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(0, 20)]
        public int NumberInStock { get; set; }
        public DateTime DateReleased { get; set; }
        public DateTime DateAdded { get; set; }

        //[Required]
        public virtual Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}