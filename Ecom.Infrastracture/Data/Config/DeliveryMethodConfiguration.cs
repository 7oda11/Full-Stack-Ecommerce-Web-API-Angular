using Ecom.Core.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastracture.Data.Config
{
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(m => m.Price).HasColumnType("decimal(18,2)");
            builder.HasData
                 (
                     new DeliveryMethod { Id = 1, DeliveryTime = "Only a week", Description = "The first delivery in the world", Name = "DHL", Price = 15 },
                     new DeliveryMethod { Id = 2, DeliveryTime = "2-3 business days", Description = "Fast and reliable", Name = "FedEx", Price = 20 },
                     new DeliveryMethod { Id = 3, DeliveryTime = "Next day delivery", Description = "Lightning fast delivery", Name = "UPS", Price = 25 },
                     new DeliveryMethod { Id = 4, DeliveryTime = "3-5 business days", Description = "Economical shipping", Name = "USPS", Price = 10 },
                     new DeliveryMethod { Id = 5, DeliveryTime = "Same day delivery", Description = "Express service", Name = "Amazon Prime", Price = 30 }
                 );


        }
    }
}
