using netchill.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netchill.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace netchill.Controllers
{
    [Authorize]

    public class SuperuserController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;//TO GET WWROOT FILES ACCESS

        private readonly UserManager<IdentityUser> _userInManager;

        private readonly DonationDBContext _db;

        public SuperuserController(DonationDBContext db, IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            _db = db;
            this.hostingEnvironment = hostingEnvironment;
            _userInManager = userManager;

        }




        public IActionResult Index(int? idref)
        {
            var users = _userInManager.Users;
            return View(users);



            //      string contentRootPath = hostingEnvironment.ContentRootPath;
            //     string webRootPath = hostingEnvironment.WebRootPath;

            //      return Content(contentRootPath + "\n" + webRootPath);


        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }

        // IMAGE UPLOADED PROCESSING
        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.ContentRootPath, "ClientApp\\src\\static\\images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }


        // VIDEO UPLOADED PROCESSING

        private string ProcessUploadedFileVideo(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.ContentRootPath, "ClientApp\\src\\static\\videos");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ContentFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ContentFile.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                string uniqueVideoName = ProcessUploadedFileVideo(model);

                SuperuserEvent obj = new SuperuserEvent
                {
                    Name = model.Name,
                    Category = model.Category,
                    Year_of_Release = model.Year_of_Release,
                    Availability_Starts = model.Availability_Starts,
                    Description = model.Description,
                    IsFeatured = model.IsFeatured,
                    IsUpcoming = model.IsUpcoming,
                    IsNewRelease = model.IsNewRelease,
                    genre = model.genre,
                    Movie_Poster_Path = uniqueFileName,
                    Content_Path = uniqueVideoName
                };
                _db.SuperuserEvents.Add(obj);
                _db.SaveChanges();


            }

            return RedirectToAction("Create", "Superuser");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            IdentityUser user = await _userInManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userInManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");

            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", _userInManager.Users);
        }


    }
}
