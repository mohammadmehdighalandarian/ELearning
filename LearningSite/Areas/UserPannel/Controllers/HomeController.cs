using LearningWeb_Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningSite.Areas.UserPannel.Controllers
{
    [Area("UserPannel")]
    public class HomeController : Controller
    {
        private readonly IUserServices _userServices;

        public HomeController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [Route("index")]
        public IActionResult Index()
        {
            
            return View(_userServices.ShowInfoInPannel(User.Identity.Name));
        }

    }
}
