using System;

namespace Stock_Inventory_Library
{
    public class Product
    {
        public int ID { get; set; }

        public String ProductName { get; set; }

       

        public String Origin { get; set; }

        public int Quantity { get; set; }

        public Decimal Price { get; set; }

        public Decimal  CostPrice { get; set; }

        public String FabricType { get; set; }

        public Byte[] ImagePath { get; set; }

        public String Comfort { get; set; }
        public String QualityAndDurability { get; set; }

        public String ColourAndPattern { get; set; }

        public String Sustainability { get; set; }
          public String MaintenanceAndCare { get; set; }

        public String OriginAndManufacturingProcess { get; set; }
         public String HypoallergenicProperties { get; set; }

        public String Versatility { get; set; }
            
           public String ReviewsAndRecommendations { get; set; }

        public String BrandReputation { get; set; }
            
         public String ReturnAndExchangePolicies { get; set; }

        public String  CertificationsAndLabels { get; set; }
        
        public String Availability { get; set; }
        
        public Product()
        {

        }

       


        public Product(int Id, String FabricType, String QualityAndDurability, String Comfort, String ColourAndPattern, int Quantity,decimal CostPrice, decimal Price, String Sustainability, String MaintenanceAndCare, String OriginAndManufacturingProcess, String HypoallergenicProperties, String Versatility, String ReviewsAndRecommendations, String BrandReputation, String ReturnAndExchangePolicies, String CertificationsAndLabels, String Availability, byte[] img,  String name)
        {
            this.ID = Id;
            this.FabricType = FabricType;
            this.QualityAndDurability = QualityAndDurability;
            this.Comfort = Comfort;
            this.ColourAndPattern = ColourAndPattern;
            this.Quantity = Quantity;
            this.CostPrice = CostPrice;
            this.Price = Price;
            this.Sustainability = Sustainability;
            this.MaintenanceAndCare = MaintenanceAndCare;
            this.OriginAndManufacturingProcess = OriginAndManufacturingProcess;
            this.HypoallergenicProperties = HypoallergenicProperties;
            this.Versatility = Versatility;
            this.ReviewsAndRecommendations = ReviewsAndRecommendations;
            this.BrandReputation = BrandReputation;
            this.ReturnAndExchangePolicies = ReturnAndExchangePolicies;

            this.CertificationsAndLabels = CertificationsAndLabels;
            this.Availability = Availability;
            ImagePath = img;
            this.ProductName = name;


        }

        public Product( String FabricType, String QualityAndDurability, String Comfort, String ColourAndPattern, int Quantity, decimal CostPrice, decimal Price, String Sustainability, String MaintenanceAndCare, String OriginAndManufacturingProcess, String HypoallergenicProperties, String Versatility, String ReviewsAndRecommendations, String BrandReputation, String ReturnAndExchangePolicies, String CertificationsAndLabels, String Availability, byte[] img, String name)
        {
         
            this.FabricType = FabricType;
            this.QualityAndDurability = QualityAndDurability;
            this.Comfort = Comfort;
            this.ColourAndPattern = ColourAndPattern;
            this.Quantity = Quantity;
            this.CostPrice = CostPrice;
            this.Price = Price;
            this.Sustainability = Sustainability;
            this.MaintenanceAndCare = MaintenanceAndCare;
            this.OriginAndManufacturingProcess = OriginAndManufacturingProcess;
            this.HypoallergenicProperties = HypoallergenicProperties;
            this.Versatility = Versatility;
            this.ReviewsAndRecommendations = ReviewsAndRecommendations;
            this.BrandReputation = BrandReputation;
            this.ReturnAndExchangePolicies = ReturnAndExchangePolicies;

            this.CertificationsAndLabels = CertificationsAndLabels;
            this.Availability = Availability;
            ImagePath = img;
            this.ProductName = name;


        }


    }


}