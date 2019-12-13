using Autofac;
using Autofac.Extensions.DependencyInjection;
using IoCTest.AppService;
using IoCTest.Contract;
using IoCTest.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace IoCTest
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<TestDbContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductAppService, ProductAppService>();
            services.AddTransient<IRemoteAppService, RemoteAppService>();

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.DescribeAllParametersInCamelCase();
                options.DescribeStringEnumsInCamelCase();
                options.SwaggerDoc("v1", new Info { Title = "Test API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                //options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                //{
                //    In = "header",
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    Type = "apiKey"
                //});
            });

            var builder = new ContainerBuilder();
            builder.RegisterInstance(Configuration).As<IConfigurationRoot>().PropertiesAutowired();
            builder.Populate(services);
            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
                options.RoutePrefix = "";
                //options.RoutePrefix = env.IsProduction() ? "api-schema" : "";
            }); //URL: /swagger

            app.UseMvc();
        }
    }
}