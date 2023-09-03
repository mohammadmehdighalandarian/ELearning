using LearningWeb_Core.DTOs.UserPanel;
using LearningWeb_Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningSite.Areas.UserPannel.Controllers
{
    [Area("UserPannel")]
    [Authorize]
    public class HomeController : Controller
    {
        
        private readonly IUserServices _userServices;

        public HomeController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IActionResult Index()
        {

            return View(_userServices.GetInformaion(User.Identity.Name));
        }

        [Route("/UserPannel/Edit")]
        public IActionResult EditUser()
        {
            var EditModel = _userServices.EditUser(User.Identity.Name);
            return View(EditModel);
        }

        [Route("/UserPannel/Edit")]
        [HttpPost]
        public IActionResult EditUser(EditUserViewModel user)
        {
            _userServices.EditProfile(User.Identity.Name, user);
            return View("Index");
        }
    }
}
