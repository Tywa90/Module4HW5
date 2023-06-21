using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALevelSample.Data.EntityConfigurations
{
    public class Task2QueryEntityConfiguration : IEntityTypeConfiguration<Task2QueryEntity>
    {
        public void Configure(EntityTypeBuilder<Task2QueryEntity> builder)
        {
            builder.HasKey(h => h.BreedName);
            builder.Property(p => p.CountNames).HasMaxLength(255)
                .IsRequired();
        }
    }
}
