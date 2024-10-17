using CarBookingApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using System.Text;
using WebApplication_MVC.Models;

namespace WebApplication_MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: Users/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Users/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserManagement model)
        {
            if (ModelState.IsValid)
            {
                // Placeholder: API call can be added later for registration
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // GET: Users/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Users/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserManagement model)
        {
            if (ModelState.IsValid)
            {
                // Placeholder: API call can be added later for login
                return RedirectToAction("Profile");
            }
            ModelState.AddModelError(string.Empty, "Login failed");
            return View(model);
        }

        // GET: Users/Profile
        [HttpGet]
        public IActionResult Profile()
        {
            // Placeholder: You can load user profile data here
            var profile = new UserManagement
            {
                UserID = 1,
                Username = "john_doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                Role = "Admin"
            };

            return View(profile);
        }

        // POST: Users/Profile (Update profile)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(UserManagement model)
        {
            if (ModelState.IsValid)
            {
                // Placeholder: API call for updating user profile
                return View(model);
            }
            return View(model);
        }

        // POST: Users/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            // Placeholder: Logout logic here (e.g., clear session)
            return RedirectToAction("Login");
        }

        // GET: Users (List all users)
        [HttpGet]
        public IActionResult Index()
        {
            // Placeholder: Hardcoded list of users for now
            var users = new List<UserManagement>
            {
                new UserManagement { UserID = 1, Username = "john_doe", Email = "john.doe@example.com", Role = "Admin" },
                new UserManagement { UserID = 2, Username = "jane_doe", Email = "jane.doe@example.com", Role = "User" }
            };

            return View(users);
        }

        // GET: Users/Details/{id}
        [HttpGet]
        public IActionResult Details(int id)
        {
            // Placeholder: Hardcoded user detail for now
            var user = new UserManagement
            {
                UserID = id,
                Username = "john_doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                Role = "Admin"
            };

            return View(user);
        }

        // POST: Users/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            // Placeholder: Logic for deleting user
            return RedirectToAction("Index");
        }
    }
}


