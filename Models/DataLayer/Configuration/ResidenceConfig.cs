using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirBB.Models.DomainModels;

namespace AirBB.Models.DataLayer.Configuration
{
    public class ResidenceConfig : IEntityTypeConfiguration<Residence>
    {
        public void Configure(EntityTypeBuilder<Residence> entity)
        {
            entity.HasKey(r => r.ResidenceId);

            entity.Property(r => r.Name)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(r => r.Accommodation)
                  .IsRequired();

            entity.Property(r => r.PricePerNight)
                  .HasColumnType("decimal(10,2)");

            entity.Property(r => r.Bathrooms)
                  .HasColumnType("decimal(3,1)");

            entity.Property(r => r.ResidencePicture)
                  .HasMaxLength(255);

            entity.HasOne(r => r.Location)
                  .WithMany()
                  .HasForeignKey(r => r.LocationId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .IsRequired();

            entity.HasData(
                new Residence
                {
                    ResidenceId = 1,
                    Name = "Chicago Loop Apartment",
                    ResidencePicture = "chi1.jpg",
                    LocationId = 1,
                    OwnerId = 1,
                    Accommodation = 4,
                    Bedrooms = 2,
                    Bathrooms = 2m,
                    BuiltYear = 2000,
                    GuestNumber = 4,
                    PricePerNight = 180m
                },
                new Residence
                {
                    ResidenceId = 2,
                    Name = "River North Condo",
                    ResidencePicture = "chi2.jpg",
                    LocationId = 1,
                    OwnerId = 1,
                    Accommodation = 2,
                    Bedrooms = 1,
                    Bathrooms = 1m,
                    BuiltYear = 2005,
                    GuestNumber = 2,
                    PricePerNight = 140m
                },
                new Residence
                {
                    ResidenceId = 3,
                    Name = "Midtown Loft",
                    ResidencePicture = "ny1.jpg",
                    LocationId = 2,
                    OwnerId = 2,
                    Accommodation = 3,
                    Bedrooms = 1,
                    Bathrooms = 1m,
                    BuiltYear = 2010,
                    GuestNumber = 3,
                    PricePerNight = 220m
                },
                new Residence
                {
                    ResidenceId = 4,
                    Name = "Brooklyn Brownstone",
                    ResidencePicture = "ny2.jpg",
                    LocationId = 2,
                    OwnerId = 2,
                    Accommodation = 4,
                    Bedrooms = 2,
                    Bathrooms = 1m,
                    BuiltYear = 1995,
                    GuestNumber = 4,
                    PricePerNight = 200m
                },
                new Residence
                {
                    ResidenceId = 5,
                    Name = "Miami Beach House",
                    ResidencePicture = "miami1.jpg",
                    LocationId = 3,
                    OwnerId = 3,
                    Accommodation = 6,
                    Bedrooms = 3,
                    Bathrooms = 2m,
                    BuiltYear = 2012,
                    GuestNumber = 6,
                    PricePerNight = 260m
                },
                new Residence
                {
                    ResidenceId = 6,
                    Name = "South Beach Condo",
                    ResidencePicture = "miami2.jpg",
                    LocationId = 3,
                    OwnerId = 3,
                    Accommodation = 2,
                    Bedrooms = 1,
                    Bathrooms = 1m,
                    BuiltYear = 2015,
                    GuestNumber = 2,
                    PricePerNight = 180m
                },
                new Residence
                {
                    ResidenceId = 7,
                    Name = "Suburban Family Home",
                    ResidencePicture = "atlanta1.jpg",
                    LocationId = 4,
                    OwnerId = 4,
                    Accommodation = 5,
                    Bedrooms = 3,
                    Bathrooms = 2m,
                    BuiltYear = 2003,
                    GuestNumber = 5,
                    PricePerNight = 190m
                },
                new Residence
                {
                    ResidenceId = 8,
                    Name = "Downtown Apartment",
                    ResidencePicture = "atlanta2.jpg",
                    LocationId = 4,
                    OwnerId = 4,
                    Accommodation = 3,
                    Bedrooms = 2,
                    Bathrooms = 1m,
                    BuiltYear = 2008,
                    GuestNumber = 3,
                    PricePerNight = 160m
                }
            );
        }
    }
}