using Gasoline_Library.Business.Logic;
using Gasoline_Library.Persistence.ReposInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gasoline_Library.Business.ManagerClass
{
   public class ManuFacturerManager:IProductionRepos
    {

        public IProductionRepos productionRepos;

        public ManuFacturerManager(IProductionRepos repos)
        {
            this.productionRepos = repos;
        }

        public List<ManuFacturer> GetManuFacturers()
        {
            return this.productionRepos.GetManuFacturers();
        }

        public ManuFacturer ManuFacturer(int ID)
        {
            return this.productionRepos.ManuFacturer(ID);
        }
    }
}
