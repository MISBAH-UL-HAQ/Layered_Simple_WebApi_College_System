using Application.Interfaces;
using Application.Services;
using CollegeSystem2.Middleware;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Services.Application.Services;
using Microsoft.Extensions.Hosting;

//var builder = WebApplication.CreateBuilder(args);




//// Add services to the container.

//builder.Services.AddControllers();


//// CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReactApp", policy =>
//    {
//        policy.WithOrigins("http://localhost:3000") // Running React app URL
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});


//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


//// Add services
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Register repositories
//builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
//builder.Services.AddScoped<IStudentRepository, StudentRepository>();

//// Register services
//builder.Services.AddScoped<IDepartmentService, DepartmentService>();
//builder.Services.AddScoped<IStudentService, StudentService>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseMiddleware<ErrorHandlingMiddleware>();

//app.UseAuthorization();

//// Use CORS policy
//app.UseCors("AllowReactApp");

//app.MapControllers();

//app.Run();





var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Configure EF Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Configure Identity with our ApplicationUser
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
//{
//    options.Password.RequireDigit = false;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequiredLength = 6;
//})
//.AddEntityFrameworkStores<AppDbContext>()
//.AddDefaultTokenProviders();

//// Configure JWT Authentication
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    var jwtSettings = builder.Configuration.GetSection("Jwt");
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = jwtSettings["Issuer"],
//        ValidAudience = jwtSettings["Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
//    };
//});





// Configure Identity with ApplicationUser (relaxed password settings)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
})
.AddEntityFrameworkStores<AppDbContext>() 
.AddDefaultTokenProviders();

// Configure JWT Authentication (no issuer/audience validation)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],   // Accessed directly
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});



// Register DI for repositories and services
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAuthService, AuthService>();




//Add GraphQL Server configuration using Hot Chocolate:
builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
       .AddType<CollegeSystem2.GraphQL.Queries.DepartmentQueries>()  // Register Department queries
       .AddType<CollegeSystem2.GraphQL.Queries.StudentQueries>()     // Register Student queries
    .AddMutationType(d => d.Name("Mutation"))
       .AddType<CollegeSystem2.GraphQL.Mutations.DepartmentMutations>()  // Register Department mutations
       .AddType<CollegeSystem2.GraphQL.Mutations.StudentMutations>();    // Register Student mutations

// Add CORS (adjust origin as necessary)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddAuthorization();

// Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.MapGraphQL();
app.UseHttpsRedirection();
app.UseCors("AllowReactApp");

app.UseAuthentication();  
app.UseAuthorization();

app.MapControllers();

app.Run();
