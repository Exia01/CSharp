using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vidly.Models;

namespace Vidly.ViewModels
{
    // Pure view model 
    public class MovieGenreViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        //A Plain Old CLR Objects(POCO) does not have behavior or logic
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        public string Name { get; set; }


        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte NumberInStock { get; set; }



        [Display(Name = "Release Date")]
        [Required]
        //DateTime is a value type.That means if no value has been explicitly assigned then is has the default value which is 1 Jan 0001. 
        public DateTime? DateReleased { get; set; } //Nullable date type

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Genre")] //nullable byte
        public byte? GenreId { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
        public MovieGenreViewModel() //constructor
        {
          
        }
        public MovieGenreViewModel(Movie movie) //overloading?
        {
            //may or may not be missing id
            Name = movie.Name;
            DateReleased = movie.DateReleased;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    public static readonly byte ValidStartingStockNumber = 1;
    public static readonly byte HighRangeStockNumber = 20;
    }
}