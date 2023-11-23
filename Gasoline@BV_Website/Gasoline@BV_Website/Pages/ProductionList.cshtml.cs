using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gasoline_Library.Business.Logic;
using Gasoline_Library.Business.ManagerClass;
using Gasoline_Library.Persistence;
using Gasoline_Library.Persistence.ReposInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gasoline_BV_Website.Pages
{
    [Authorize]
    public class ProductionListModel : PageModel
    {
        public ManuFacturerManager Manager = new ManuFacturerManager(new ProductionRepository());

        public List<ManuFacturer> GetFacturers = new List<ManuFacturer>();
        public void OnGet()
        {
            GetFacturers = Manager.GetManuFacturers();
        }
    }
}
