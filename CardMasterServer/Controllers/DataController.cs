using Microsoft.AspNetCore.Mvc;

namespace CardMaster.Server.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return Json(new {name="Ivan", age=12});
        }

        public string Cards()
        {
            return "asd";
        }

        public string Collections()
        {
            return "";
        }


    }
}
