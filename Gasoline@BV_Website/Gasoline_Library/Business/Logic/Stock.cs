using System;
using System.Collections.Generic;
using System.Text;

namespace Gasoline_Library.Business.Logic
{
   public class Stock
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string FabricType { get; set; }
        public string QualityAndDurability { get; set; }
        public string Comfort { get; set; }
        public string ColourAndPattern { get; set; }
        public int Quantity { get; set; }
        public string Sustainability { get; set; }
        public string MaintenanceAndCare { get; set; }
        public string OriginAndManufacturingProcess { get; set; }
        public string HypoallergenicProperties { get; set; }
        public string Versatility { get; set; }
        public string ReviewsAndRecommendations { get; set; }
        public string BrandReputation { get; set; }
        public string ReturnAndExchange { get; set; }
        public string CertificationAndLabels { get; set; }
        public string Availability { get; set; }


        public Stock(int id,
        string brand,
        string model,
        decimal price,
        string fabricType,
        string qualityAndDurability,
        string comfort,
        string colourAndPattern,
        int quantity,
        string sustainability,
        string maintenanceAndCare,
        string originAndManufacturingProcess,
        string hypoallergenicProperties,
        string versatility,
        string reviewsAndRecommendations,
        string brandReputation,
        string returnAndExchange,
        string certificationAndLabels,
        string availability)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Price = price;
            FabricType = fabricType;
            QualityAndDurability = qualityAndDurability;
            Comfort = comfort;
            ColourAndPattern = colourAndPattern;
            Quantity = quantity;
            Sustainability = sustainability;
            MaintenanceAndCare = maintenanceAndCare;
            OriginAndManufacturingProcess = originAndManufacturingProcess;
            HypoallergenicProperties = hypoallergenicProperties;
            Versatility = versatility;
            ReviewsAndRecommendations = reviewsAndRecommendations;
            BrandReputation = brandReputation;
            ReturnAndExchange = returnAndExchange;
            CertificationAndLabels = certificationAndLabels;
            Availability = availability;
        }

        public Stock()
        {

        }
    }
}
