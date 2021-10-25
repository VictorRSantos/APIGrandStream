using APIGrandstream.Data;
using APIGrandstream.Data.Interface;
using APIGrandstream.Data.MSSQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace APIGrandstream
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
            services.AddDbContext<GrandstreamContext>(contexto => contexto.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            DependencyInjection(services);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .WithMethods("GET", "POST", "PUT", "DELETE")
                       .AllowAnyHeader();
            }));

            services.AddVersionedApiExplorer(option =>
            {
                option.GroupNameFormat = "'v'VVVV";
                option.SubstituteApiVersionInUrl = true;

            }).AddApiVersioning(option =>
            {
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.ReportApiVersions = true;
            });

            var apiProviderDescription = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(option =>
            {
                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    option.SwaggerDoc(description.GroupName, new OpenApiInfo()
                    {
                        Title = "Grandstream API",
                        Version = description.ApiVersion.ToString(),
                        TermsOfService = new Uri("https://www.eritel.com.br"),
                        Description = "WebAPI Grandstream Eritel",
                        License = new Microsoft.OpenApi.Models.OpenApiLicense { Name = "Grandstream License", Url = new Uri("https://www.mit.con") },
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Eritel", Url = new Uri("https://www.eritel.com.br") }

                    });

                }

            });
        }
         
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescription)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }            

            app.UseRouting();

            app.UseSwagger().UseSwaggerUI(options =>
            {
                foreach (var description in apiVersionDescription.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    options.RoutePrefix = "";
                }
            });

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void DependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IPostoDb, MSSQLPosto>();
           
        }
    }
}
