using Biblioteca82.Models;
using Biblioteca82.Models.Domain;
using Biblioteca82.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca82.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IRolServices _rolServices;

        public UserController(IUserServices userServices, IRolServices rolServices)
        {
            _userServices = userServices;
            _rolServices = rolServices;
        }

        public async Task<IActionResult> Index()
        {
            List<UserEntity> user = await _userServices.GetUsuarios();

            TempData["Message"] = "¡Bienvenido a Usuarios!";
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserEntity request)
        {
            var result = await _userServices.CreateUser(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            var roles = await _rolServices.GetRoles();
            var viewModel = new UserWithRolVM
            {
                Roles = roles
            };
            return View(viewModel);
        }
    }
}
