using Business.Concrete;
using Business.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SharedLibrary.Extensions
{
    public static class DIExtensions
    {
        public static void UseDIExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
