using AirBB.Models.DomainModels;

namespace AirBB.Models.Grid
{
    public class ResidenceGridData
    {
        public int ResidenceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;
        public int OwnerId { get; set; }
        public int Accommodation { get; set; }
        public int Bedrooms { get; set; }
        public decimal Bathrooms { get; set; }
        public int BuiltYear { get; set; }
        public int GuestNumber { get; set; }
        public decimal PricePerNight { get; set; }
        public string? ResidencePicture { get; set; }

        public ResidenceGridData(Residence residence)
        {
            ResidenceId = residence.ResidenceId;
            Name = residence.Name;
            LocationName = residence.Location?.Name ?? "Unknown";
            OwnerId = residence.OwnerId;
            Accommodation = residence.Accommodation;
            Bedrooms = residence.Bedrooms;
            Bathrooms = residence.Bathrooms;
            BuiltYear = residence.BuiltYear;
            GuestNumber = residence.GuestNumber;
            PricePerNight = residence.PricePerNight;
            ResidencePicture = residence.ResidencePicture;
        }

        public ResidenceGridData() { }
    }
}