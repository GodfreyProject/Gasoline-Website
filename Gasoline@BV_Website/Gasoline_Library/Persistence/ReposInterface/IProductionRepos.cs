using Gasoline_Library.Business.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gasoline_Library.Persistence.ReposInterface
{
   public interface IProductionRepos
    {

        // List
        public List<ManuFacturer> GetManuFacturers();


        public ManuFacturer ManuFacturer(int ID);
    }
}
