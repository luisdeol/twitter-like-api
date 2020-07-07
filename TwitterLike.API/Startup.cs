using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwitterLike.Application.Commands.CreateTweet;
using TwitterLike.Core.Repositories;
using TwitterLike.Infrastructure.Persistence;
using TwitterLike.Infrastructure.Persistence.Repositories;

namespace TwitterLike.API
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
            services.AddMediatR(typeof(CreateTweetCommand));
            
            services.AddDbContext<TwitterLikeDbContext>(options => options.UseInMemoryDatabase("TwitterLike"));

            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s => {
               s.SwaggerEndpoint("/swagger/v1/swagger.json", "TwitterLike API V1"); 
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
