
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ExaminationSystem.Data;
using ExaminationSystem.Profiles;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExaminationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Context>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
            .EnableSensitiveDataLogging());
            
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
                builder.RegisterModule(new AutoFacModule()));

            builder.Services.AddAutoMapper(typeof(ExamProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
