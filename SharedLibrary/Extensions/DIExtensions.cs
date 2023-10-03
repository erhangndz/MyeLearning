using Business.Concrete;
using Business.Interfaces;
using DataAccess.Concrete;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SharedLibrary.Extensions
{
    public static class DIExtensions
    {
        public static void UseDIExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddDbContext<Context>();
            
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
			builder.Services.AddMvcCore(config =>
			{
				var policy = new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.Build();
				config.Filters.Add(new AuthorizeFilter(policy));
			});
			builder.Services.ConfigureApplicationCookie(_ =>
			{
				_.LoginPath = new PathString("/Login/Index");
				_.AccessDeniedPath = new PathString("/ErrorPage/AccessDenied/");
				_.LogoutPath = new PathString("/Account/Logout");


			});	
				


		}
	}
}
