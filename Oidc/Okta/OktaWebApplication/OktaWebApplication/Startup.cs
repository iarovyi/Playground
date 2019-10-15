using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Okta.AspNetCore;
using CookieAuthenticationDefaults = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults;

namespace OktaWebApplication
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
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
                {
                    options.DefaultChallengeScheme = "my_okta";
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect("my_okta", options =>
                {
                    options.Authority = "https://evisiononline.okta.com";
                    options.ClientId = "0oa1dhl4kpf91Otxx0h8";
                    options.SaveTokens = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        NameClaimType = "name"
                    };
                });


            //services.AddAuthentication(options =>
            //    {
            //        options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
            //        options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
            //        options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
            //    })
            //    .AddOktaWebApi(new OktaWebApiOptions()
            //    {
            //        OktaDomain = "https://evisiononline.okta.com", //OktaDomain = Configuration["Okta:OktaDomain"]
            //        ClientId = "0oa1dhl4kpf91Otxx0h8",
            //        Audience = ""
            //    });

            /*var authenticationBuilder = services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(options =>
                {
                    options.Authority = "https://evisiononline.okta.com";
                    options.ClientId = "_XVRxgSdG64anwJjLE8YHMMXBo3qz01hB7E8G67i";
                }).

            AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.Name = "myApp";
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });*/


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
