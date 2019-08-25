using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class NumberInStockValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (movie.NumberInStock < Movie.ValidStartingStockNumber || movie.NumberInStock > Movie.HighRangeStockNumber)
            {
                return new ValidationResult("Valid stock number must be between 1-20");
            }

            //no negative numbers and no more than 20 qty
            if (movie.NumberInStock >= Movie.ValidStartingStockNumber ||
                movie.NumberInStock <= Movie.HighRangeStockNumber)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Please provide a stock number");



        }
    }
}