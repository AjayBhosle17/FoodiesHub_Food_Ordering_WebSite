using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    CoreDBContext _context;
    public CategoryRepository(CoreDBContext context)
    {
        _context = context;
    }

    public void Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Delete(int? id)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
        
    }

    public void Edit(Category category)
    {
        var existingCategory = _context.Categories.Find(category.CategoryId);

        if (existingCategory != null)
        {
            existingCategory.CategoryId = category.CategoryId;
            existingCategory.CreatedDate = category.CreatedDate;
            existingCategory.UpdatedDate = DateTime.Now;
            existingCategory.IsActive = category.IsActive;
            existingCategory.ImageUrl = category.ImageUrl;
            existingCategory.Name = category.Name;

           // _context.Categories.Add(existingCategory);
            _context.SaveChanges(); 
        }
    }


    public List<Category> GetAll()
    {
        return _context.Categories.ToList();
    }

    public Category GetById(int? id)
    {
        return _context.Categories.Find(id);
    }
    public IEnumerable<Category> GetAllCategoriesWithProducts()  // to fetch all products
    {
        return _context.Categories.Include(c => c.Products).ToList();
    }

}