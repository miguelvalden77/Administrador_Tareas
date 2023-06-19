using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Administrador_Tareas.Models;
using Microsoft.AspNetCore.Authentication;

namespace Administrador_Tareas.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UsuariosController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registro(RegistroViewModel modelo)
        {
            if(!ModelState.IsValid)
            {
                return View(modelo);
            }

            var usuario = new IdentityUser() {Email = modelo.Email, UserName = modelo.Email};
            var resultado = await userManager.CreateAsync(usuario, password: modelo.Password);

            if(resultado.Succeeded)
            {
                await signInManager.SignInAsync(usuario, isPersistent: true);
                return RedirectToAction("Index", "Home");
            } 
            else 
            {
                foreach(var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(modelo);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            
            var resultado = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.Recuerdame, lockoutOnFailure: false);

            if(resultado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nombre de usuario o contaseña incorrecta");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}