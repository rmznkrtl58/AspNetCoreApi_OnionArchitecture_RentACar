using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.WriteHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.WriteHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.WriteHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers.WriteHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.WriteHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.WriteHandlers;
using CarBook.Application.Features.RepositoryPattern.ICommentRepositories;
using CarBook.Application.Features.RepositoryPattern.IGenericRepositories;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Application.Interfaces.ReservationInterfaces;
using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Application.Services;
using CarBook.Application.Tools;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Persistence.Repositories.CarDescriptionRepositories;
using CarBook.Persistence.Repositories.CarFeatureRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Persistence.Repositories.CommentRepositories;
using CarBook.Persistence.Repositories.RentACarRepositories;
using CarBook.Persistence.Repositories.ReservationRepositories;
using CarBook.Persistence.Repositories.ReviewRepositories;
using CarBook.Persistence.Repositories.StatisticsRepositories;
using CarBook.WebApi.Hubs;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//SignalR yapýlanmasý
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});
builder.Services.AddSignalR();

//JWT Yapýlandýrmasý
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = false;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience=JWTTokenDefaults.ValidAudience,
            ValidIssuer= JWTTokenDefaults.ValidIssuer,
            ClockSkew=TimeSpan.Zero,
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTTokenDefaults.Key)),
            ValidateLifetime=true,
            ValidateIssuerSigningKey=true
		};
    });
//newlemelerden kurtarmak için kullanýyorum
//Repositories
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
builder.Services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository<Comment>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
//Abouts
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<DeleteAboutCommandHandler>();
//Banners
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<DeleteBannerCommandHandler>();
//Brands
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<DeleteBrandCommandHandler>();
//Cars
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<DeleteCarCommandHandler>();
builder.Services.AddScoped<GetCarsWithBrandsQueryHandler>();
builder.Services.AddScoped<GetLast4CarsWithBrandsQueryHandler>();
builder.Services.AddScoped<GetCarWithBrandByCarIdQueryHandler>();
//Category
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<DeleteCategoryCommandHandler>();
//Contact
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<DeleteContactCommandHandler>();
//MediatR Yapýlanmasý
builder.Services.AddApplicationService(builder.Configuration);
//Fluent Validation Yapýlanmasý
builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//SignalR Cors yapýlanmasý
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

//JWT için gerekli
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//SignalR yapýlanmasý
app.MapHub<CarHub>("/carhub");

app.Run();
