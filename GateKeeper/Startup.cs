
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GateKeeper.Core.Context;
using GateKeeper.Core.Entities;
using GateKeeper.Gateways;
using GateKeeper.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using GateKeeper.Authorization;

namespace GateKeeper
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
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("GateKeeper")));

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IAccessRightRepository, AccessRightRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddSingleton<IJwtFactory, JwtFactory>();

            services.AddIdentity<AppUser, IdentityRole>
                      (o =>
                      {
                          // configure identity options 
                          o.Password.RequireDigit = false;
                          o.Password.RequireLowercase = false;
                          o.Password.RequireUppercase = false;
                          o.Password.RequireNonAlphanumeric = false;
                          o.Password.RequiredLength = 6;
                      })
                      .AddEntityFrameworkStores<ApplicationDbContext>()
                      .AddDefaultTokenProviders();

            services.AddJwtAuthorization(Configuration);

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }

   
}
