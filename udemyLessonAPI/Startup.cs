using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using udemyLessonAPI.Domain;
using udemyLessonAPI.Domain.Repositories;
using udemyLessonAPI.Domain.Service;
using udemyLessonAPI.Domain.UnitOfWork;
using udemyLessonAPI.Service;
using AutoMapper;
using System;

namespace udemyLessonAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();

            //services.AddTransient<IProductService,ProductService>();// Uygulamanın yaşam döngüsü boyunca Her IProductService ile her karşılaştığında ProductService bir instance oluşturacak.


            //services.AddSingleton<IProductService, ProductService>(); // ProductService den bir kez oluşturur. Tüm uygulamada aynı instance kullanılır. Yeniden oluşturulmaz. 

            services.AddScoped<IProductService, ProductService>();// Her request işleminde ilk IProductService ile her karşılaştığında ProductService bir instance oluşturacak. Eğer birden fazla kez kullanılır ise daha önce oluşturduğu instance kullanılır.
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICitiesService, CitiesService>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder=>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                });


            });


            



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<UdemyAPIWithTokenContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //*/
        }
    }
}
