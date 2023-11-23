using System;
using System.Collections.Generic;
using System.Text;

namespace Gasoline_Library.Business.Logic
{
   public class ManuFacturer
    {
        public int Nr { get; set; }

        public String Productionpart { get; set; }

        public String ProductionUnit { get; set; }

        public int Batchnr { get; set; }

        public int Stepnr { get; set; }

        public String Productionsteps { get; set; }


        public String start { get; set; }

        public String finish { get; set; }

        public String material { get; set; }


        public String quantity { get; set; }

        public String scrap { get; set; }


        public ManuFacturer()
        {

        }

        public ManuFacturer(int id, string part, string unit, int bacht,int step, string start, string finish, string mater, string qty, string scrap)
        {
            this.Nr = id;
            this.Productionpart = part;
            this.ProductionUnit = unit;
            this.Batchnr = bacht;
            this.Stepnr = step;
            this.start = start;
            this.finish = finish;
            this.material = mater;
            this.quantity = qty;
            this.scrap = scrap;
        }
    }
}
