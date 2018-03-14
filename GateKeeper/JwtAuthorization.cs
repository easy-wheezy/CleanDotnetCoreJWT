namespace GateKeeper.Authorization
{

    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Net.Http.Headers;
    using Newtonsoft.Json.Linq;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using System.Threading.Tasks;
    using GateKeeper.Core.Entities;

    public static class JwtAuthorizationExtensions
    {
        public static IServiceCollection AddJwtAuthorization(this IServiceCollection services, IConfiguration Configuration)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("qp6woe5iru4tyal3skdjfhg2mzn1xbcv"));// Environment.GetEnvironmentVariable("JWT_SECRET")));

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKeys = new List<SecurityKey> { signingKey },

                
                // Validate the token expiry
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero

            };
            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim("rol", "api_access"));
                options.AddPolicy("Company Admin", policy => policy.RequireClaim("rol", "company_access"));
            });

            services.AddAuthentication(options =>
            {
              
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            })
            .AddJwtBearer(o =>
            {

                o.IncludeErrorDetails = true;
                
                o.TokenValidationParameters = tokenValidationParameters;
                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        System.Diagnostics.Debug.WriteLine("Failed to authenticate");
                        c.Response.StatusCode = 401;
                        c.Response.ContentType = "text/plain";

                        return c.Response.WriteAsync(c.Exception.ToString());
                    }

                };
            });

            return services;
        }
    }

}