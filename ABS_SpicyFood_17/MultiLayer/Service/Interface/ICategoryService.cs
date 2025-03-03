using DTO;

namespace Service.Interface
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAll();
        void Create(CategoryModel category);

        CategoryModel GetById(int? id);

        void Edit(CategoryModel category);

        void Delete(int? id);
    }
}
