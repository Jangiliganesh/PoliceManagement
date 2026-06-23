using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoliceManagement.Entities;

namespace PoliceManagement.Mappings
{
    public class PMMapping : IEntityTypeConfiguration<PMEntity>
    {

        public void Configure(EntityTypeBuilder<PMEntity> builder)
        {
            builder.ToTable("PoliceOfficers", "police");
            builder.HasKey(x => x.Officerid);

            builder.Property(x => x.Officerid).HasColumnName("OfficerId");

            builder.Property(x => x.BadgeNumber);

            builder.Property(x => x.OfficerName);


            builder.Property(x => x.Department);

            builder.Property(x => x.Location);

            builder.Property(x => x.Salary).HasPrecision(12,2);

            builder.Property(x => x.JoiningDate);

            builder.Property(x => x.Rank);

        }
    }
}
