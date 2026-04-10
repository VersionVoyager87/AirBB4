using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using AirBB.Models.Utilities;

namespace AirBB.Models.DomainModels
{
    public class Residence
    {
        public int ResidenceId { get; set; }

        [Required(ErrorMessage = "Please enter a residence name.")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or fewer.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Name must be alphanumeric only.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a location.")]
        public int LocationId { get; set; }

        public Location? Location { get; set; }

        [Required(ErrorMessage = "Please enter Owner ID.")]
        [Remote(action: "CheckOwner", controller: "Validation", areaName: "Admin",
            ErrorMessage = "Owner ID is invalid or not registered as Owner.")]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "Please enter accommodation.")]
        [Range(1, int.MaxValue, ErrorMessage = "Accommodation must be an integer.")]
        public int Accommodation { get; set; }

        [Required(ErrorMessage = "Please enter number of bedrooms.")]
        [Range(0, 20, ErrorMessage = "Bedrooms must be an integer.")]
        public int Bedrooms { get; set; }

        [Required(ErrorMessage = "Please enter number of bathrooms.")]
        [HalfStepNumber(ErrorMessage = "Bathrooms must be a whole number or end in .5.")]
        public decimal Bathrooms { get; set; }

        [Required(ErrorMessage = "Please enter built year.")]
        [PastYear(150, ErrorMessage = "Built year must be in the past and within 150 years.")]
        public int BuiltYear { get; set; }

        [Required(ErrorMessage = "Please enter guest number.")]
        [Range(1, 50, ErrorMessage = "Guest number must be an integer.")]
        public int GuestNumber { get; set; }

        [Required(ErrorMessage = "Please enter price per night.")]
        [Range(typeof(decimal), "0.01", "999999.99", ErrorMessage = "Price must be numeric.")]
        [Display(Name = "Price Per Night")]
        public decimal PricePerNight { get; set; }

        public string? ResidencePicture { get; set; }

        public int BedroomNumber => Bedrooms;
        public decimal BathroomNumber => Bathrooms;
        public decimal Price => PricePerNight;
        public string? Image => ResidencePicture;
    }
}