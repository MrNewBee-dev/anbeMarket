using Anbe.Areas.API.Service;
using Anbe.Areas.Identity.Data.Services;
using Anbe.Hubs;
using BookShop.Areas.Identity.Services;
using BookShop.Models.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SignalR.Anbe.Models.Services;
using SignalR.Bugeto.Models.Services;
using System.Text;


namespace Anbe
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
          var mvcBuilder =   services.AddControllersWithViews();
            mvcBuilder.AddRazorRuntimeCompilation();
            services.AddRazorPages();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddTransient<_WalletService, WalletService>();
            services.AddSignalR();
            services.AddTransient<BooksRepository>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IChatRoomService, ChatRoomService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                }).AddCookie(cfg =>
                {
                    cfg.LoginPath = "/Home/login";
                })
                .AddJwtBearer(options =>
                    {
                        var secretkey = Encoding.UTF8.GetBytes("1234567890asdABCDEFGHIJ");
                        var encryptionkey = Encoding.UTF8.GetBytes("qwsadfrewtyh4532ABCDEFGHIJ");


                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;

                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            RequireSignedTokens = true,

                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(secretkey),

                            RequireExpirationTime = true,
                            ValidateLifetime = true,

                            ValidateAudience = true, //default : false
                            ValidAudience = "http://www.anbe.shop",

                            ValidateIssuer = true, //default : false
                            ValidIssuer = "http://www.anbe.shop",

                            TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
                        };

                    }
         );
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Home/login");
            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseDeveloperExceptionPage();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapHub<SiteChatHub>("/chathub");
                endpoints.MapHub<SupportHub>("/supporthub");
                endpoints.MapControllerRoute(
         name: "areas",
         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
       );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=FirstPage}/{id?}");
            });
            
        }
    }
}
