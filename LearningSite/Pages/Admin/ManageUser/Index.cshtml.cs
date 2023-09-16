using LearningWeb_Core.DTOs.AdminPanel;
using LearningWeb_Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearningSite.Pages.Admin.ManageUser
{
    public class IndexModel : PageModel
    {
        private readonly IUserServices _userServices;

        public IndexModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public UserForAdminViewModel UserForAdmin { get; set; }
        public void OnGet(int pageId = 1, string filterUserName = "", string filterEmail = "")
        {
            UserForAdmin = _userServices.GetUsers(pageId, filterEmail, filterUserName);
        }
    }
}
