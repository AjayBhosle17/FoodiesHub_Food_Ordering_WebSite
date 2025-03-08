using DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace WEB_UI_Client.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public IActionResult Index(int categoryId)
        {
            var products = _service.GetAll();

            if (categoryId != null && categoryId!=0)
            {
               
                var res=products.Where(p =>p.CategoryId == categoryId).ToList();

                return Ok(res);
            }
            else
            {
                return View(products);

            }
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // Get file name & path
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/product", fileName);

                    // Save file to wwwroot/images/category
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    // Store Image URL in model
                    model.ImageUrl = "/images/product/" + fileName;
                }

                _service.Create(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var product = _service.GetById(id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            var product = _service.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(model);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Category is Null Plz Check in All Category List");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var product = _service.GetById(id);
            return View(product);
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
