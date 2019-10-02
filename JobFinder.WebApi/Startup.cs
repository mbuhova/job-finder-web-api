using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JobFinder.Models;
using JobFinder.WebApi.Services;
using JobFinder.Repositories.Data;
using JobFinder.WebApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using JobFinder.WebApi.Extensions;
using System.Text;
using JobFinder.Repositories;
using JobFinder.Services.Contracts;
using JobFinder.Services.Implementations;
using AutoMapper;
using JobFinder.ViewModels;

namespace JobFinder.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        static string secretKey = "mysupersecret_secretkey!123";
        private SecurityKey _signingKey;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                //ValidateLifetime = true,
                //ClockSkew = TimeSpan.Zero
            };

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            this.ConfigureMappings(services);

            this.ConfigureRepositories(services);

            this.ConfigureApplicationServices(services);

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim(JwtClaimIdentifiers.Role, "Admin"));
                options.AddPolicy("Person", policy => policy.RequireClaim(JwtClaimIdentifiers.Role, "Person"));
                options.AddPolicy("Company", policy => policy.RequireClaim(JwtClaimIdentifiers.Role, "Company"));
            });
           
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IJwtFactory, JwtFactory>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            //app.UseJwtTokenMiddleware();

            app.UseCors(builder =>
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<ITownRepository, TownRepository>();
            services.AddScoped<IBusinessSectorRepository, BusinessSectorRepository>();
            services.AddScoped<IJobOfferRepository, JobOfferRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
        }

        private void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IApplicationService, ApplicationService>();
        }

        private void ConfigureMappings(IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                 cfg.CreateMap<Town, TownViewModel>().ReverseMap();
                 cfg.CreateMap<BusinessSector, BusinessSectorViewModel>().ReverseMap();
                 cfg.CreateMap<JobOffer, SearchResultOfferViewModel>()
                    .ForMember(dest => dest.Town, opts => opts.MapFrom(src => src.Town.Name))
                    .ForMember(dest => dest.BusinessSector, opts => opts.MapFrom(src => src.BusinessSector.Name))
                    .ForMember(dest => dest.CompanyName, opts => opts.MapFrom(src => src.Company.CompanyName))
                    .ReverseMap();
                /*cfg.CreateMap<Order, OrderViewModel>()
                    .ForMember(dest => dest.DeliveryTime, opts => opts.MapFrom(src => src.Deliveries.OrderBy(o => o.DeliveryId).Select(s => s.DeliveryTime).FirstOrDefault()));
                cfg.CreateMap<Delivery, DeliveryViewModel>()
                    .ForMember(dest => dest.OrderDate, opts => opts.MapFrom(src => src.Order.DeliveryDate))
                    .ForMember(dest => dest.TypeName, opts => opts.MapFrom(src => src.Order.Type.Description))
                    .ForMember(dest => dest.TypeId, opts => opts.MapFrom(src => src.Order.TypeId))
                    .ForMember(dest => dest.Latitude, opts => opts.MapFrom(src => src.Place.Latitude))
                    .ForMember(dest => dest.Longitude, opts => opts.MapFrom(src => src.Place.Longitude))
                    .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.Index.Description))
                    .ReverseMap();
                cfg.CreateMap<Delivery, DeliveredAmountViewModel>()
                    .ForMember(dest => dest.Unit, opts => opts.MapFrom(src => src.Order.Type.Unit))
                    .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Order.Type.Category.Description))
                    .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.Order.Type.CategoryId))
                    .ForMember(dest => dest.ProducedAmount, opts => opts.MapFrom(src => src.Order.ProducedAmount))
                    .ReverseMap();
                cfg.CreateMap<ConstructionPlace, ConstructionPlaceViewModel>().ReverseMap();
                cfg.CreateMap<Place, PlaceViewModel>().ReverseMap();*/
            });
        }
    }
}
