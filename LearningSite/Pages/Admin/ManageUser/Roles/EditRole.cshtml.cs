using DataLayer.Entities.User;
using LearningWeb_Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearningSite.Pages.Admin.ManageUser.Roles
{
    public class EditRoleModel : PageModel
    {
        private readonly IPermitionServices _permitionServices;

        public EditRoleModel(IPermitionServices permitionServices)
        {
            _permitionServices = permitionServices;
        }

        [BindProperty]
        public Role Role { get; set; }

        public void OnGet(long id)
        {
            Role = _permitionServices.GetRole(id);
        }

        public IActionResult OnPost(string Title)
        {
            //if (!ModelState.IsValid)
            //    return Page();
            Role.RoleName = Title;
            _permitionServices.UpdateRole(Role);

            return RedirectToPage("./index");
        }
    }
}
