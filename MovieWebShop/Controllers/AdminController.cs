using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieWebShop.Data;
using MovieWebShop.ViewModels;

namespace MovieWebShop.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly AppDbContext _context;


        public AdminController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._context = context;    
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }
        public IActionResult ListMovies()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
        //public IActionResult GetUser(string id)
        //{
        //    var user = userManager.Users.Where(x => x.Id == id);
        //    return user;
        //}
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        public IActionResult UpdateUser()
        {
            return View();
        }
        public IActionResult DeleteUser()
        {
            return View();
        }
    }
}
