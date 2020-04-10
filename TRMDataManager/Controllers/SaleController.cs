using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        [Authorize(Roles = "Cashier")]
        public void Post(SaleModel sale)
        {
            var data = new SaleData();
            var userId = RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, userId);
        }

        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        public List<SaleReportModel> GetSalesReport()
        {
            if (RequestContext.Principal.IsInRole("Admin"))
            {
                // Do admin stuff
            }
            else if (RequestContext.Principal.IsInRole("Manager"))
            {
                // Do manager stuff
            }

            var data = new SaleData();
            return data.GetSaleReport();
        }
    }
}
