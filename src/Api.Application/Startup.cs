using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Security;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace application
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //if (_environment.IsEnvironment("Testing"))
            //{
            Environment.SetEnvironmentVariable("DB_CONNECTION", "Persist Security Info=True;Server=localhost;userid=semente;password=w@g3691715Figueiredo;database=AgentesAgendamento");
            //Environment.SetEnvironmentVariable("DB_CONNECTION", "Persist Security Info=True;Server=95.111.233.31;PORT=3306;userid=semente;password=w@g3691715Figueiredo;database=trocasementes");
            Environment.SetEnvironmentVariable("DATABASE", "MYSQL");
            Environment.SetEnvironmentVariable("MIGRATION", "APLICAR");
            Environment.SetEnvironmentVariable("Audience", "ExemploAudience");
            Environment.SetEnvironmentVariable("Issuer", "ExemploIssue");
            Environment.SetEnvironmentVariable("Seconds", "28800");
            //}
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //para permissao de conexao cruzada
                    services.AddCors(options =>
                    {
                        options.AddPolicy("CorsPolicy", builder => builder
                            .WithOrigins("http://localhost:4200"
                                                    , "https://localhost:4200"                                         
                                                    , "http://localhost/"
                                                    , "http://localhost:8080"
                                                    , "http://localhost:80"
                                                    , "ionic://localhost:80"
                                                    , "https://trocadesemente.com.br"
                                                    , "https://www.trocadesemente.com.br"
                                                    , "https://truequedesemilla.com"
                                                    , "https://www.truequedesemilla.com"
                                                    , "https://macrosassessorias.com.br/api"
                                                    , "https://macrosassessorias.com.br"
                                        
                                                    )
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
                    }
            );

            services.AddSignalR();



            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {         
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new DtoToEntityProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = Environment.GetEnvironmentVariable("Audience");
                paramsValidation.ValidIssuer = Environment.GetEnvironmentVariable("Issuer");

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Agendamento de Agentes",
                    Description = "Arquitetura DDD, TDD core 3.1 ",
                    TermsOfService = new Uri("http://www.macrosassessorias.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "Wagner Figueiredo",
                        Email = "wagner@macrosassessorias.com.br",
                        Url = new Uri("http://www.macrosassessorias.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Front End App",
                        Url = new Uri("http://www.macrosassessorias.com.br")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre con el Token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });



            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //para permissao de conexao cruzada
            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseCors("CorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "agenda");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHub<ChartHub>("/chart");

            });

            if (Environment.GetEnvironmentVariable("MIGRATION").ToLower() == "APLICAR".ToLower())
            {
                using (var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                                                            .CreateScope())
                {
                    using (var context = service.ServiceProvider.GetService<MyContext>())
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}
