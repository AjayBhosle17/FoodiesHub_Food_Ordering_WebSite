using Data.Entities;

namespace InfraStructure.Interface
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        void Create(Product product);

        Product GetById(int? id);

        void Edit(Product product);

        void Delete(int? id);


    }
}
