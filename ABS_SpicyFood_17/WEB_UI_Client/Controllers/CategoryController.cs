using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace WEB_UI_Client.Controllers
{
    public class CategoryController : Controller
    {
       ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var categories = _service.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create() { 
        
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // 1. Get file name & path
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/category", fileName);

                    // 2. Save file to wwwroot/images/category
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    // 3. Store Image URL in model
                    model.ImageUrl = "/images/category/" + fileName;
                }

                _service.Create(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            var category = _service.GetById(id);
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            var category = _service.GetById(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryModel model, IFormFile imageFile)
        {
            if (model.CategoryId == null || model.CategoryId == 0)
            {
                ModelState.AddModelError("", "Category ID is required.");
                return View(model);
            }

            try
            {
                // Image Upload Logic
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/category");
                    var uniqueFileName = $"category_{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    model.ImageUrl = "/images/category/" + uniqueFileName;
                }

               // model.UpdatedDate = DateTime.Now; // Ensure UpdatedDate is set

                _service.Edit(model);
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Category could not be updated. Please check.");
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
           var category= _service.GetById(id);
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeleteConfirmed(int? id)
        {
            if (ModelState.IsValid)
            {
                _service.Delete(id);
                return RedirectToAction("Index"); 
            }
            return View();
        }
    }
}
