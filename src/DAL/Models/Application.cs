using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DAL.Models
{
    public class Application
    {
        [Key]
        [MaxLength(200)]
        public string Name { get; set; }
    }
    
    [ExcludeFromCodeCoverage]
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasData(
                new Application
                {
                    Name = "App1"
                },
                new Application
                {
                    Name = "App2"
                }
                );
        }
    }
}