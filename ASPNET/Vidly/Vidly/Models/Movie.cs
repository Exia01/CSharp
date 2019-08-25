using System;
using System.ComponentModel;
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

        [Required(ErrorMessage = "Please provide a name")]
        public string Name { get; set; }
        public Genre Genre { get; set; }


        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        [Display(Name = "Release Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
       [Required]
        public DateTime DateReleased { get; set; }

        public DateTime DateAdded { get; set; }


        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please provide a Genre")]
        public byte GenreId { get; set; }

        public static readonly byte ValidStartingStockNumber = 1;
        public static readonly byte HighRangeStockNumber = 20;
    }
}