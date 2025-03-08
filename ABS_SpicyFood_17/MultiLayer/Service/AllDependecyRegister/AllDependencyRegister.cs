using BAL.AutoMapper;
using InfraStructure.Implementation;
using InfraStructure.Interface;
using Microsoft.Extensions.DependencyInjection;
using Service.Implementation;
using Service.Interface;


namespace BAL.AllDependecyRegister
{
    public class AllDependencyRegister
    {
        public static void DependecyRegister(IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //add automapper dependecy

            services.AddAutoMapper(typeof(MyMapperProfile));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }
    }
}
