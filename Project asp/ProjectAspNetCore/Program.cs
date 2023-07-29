var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddScoped<UserLogic>();
builder.Services.AddScoped<AnimalLogic>();
builder.Services.AddScoped<CategoryLogic>();
builder.Services.AddScoped<CommentLogic>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddControllersWithViews();

builder.Host.UseSerilog((ctx, lc) =>
        lc.ReadFrom.Configuration(ctx.Configuration));

string connectionString = builder.Configuration["ConnectionStrings:AnimalConnection"]!;
string connectionStringUsers = builder.Configuration["ConnectionStrings:UserConnection"]!;
builder.Services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer(connectionStringUsers));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AuthenticationContext>();

builder.Services.AddDbContext<PetShopContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();

if (app.Environment.IsStaging() || app.Environment.IsProduction())
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(new ArgumentException(), "An error occurred");
    app.UseExceptionHandler("/Error/UnexpectedError");
}

using (var scope = app.Services.CreateScope())
{
    var users = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
    var petShop = scope.ServiceProvider.GetRequiredService<PetShopContext>();
    petShop.Database.EnsureDeleted();
    users.Database.EnsureDeleted();
    users.Database.EnsureCreated();
    petShop.Database.EnsureCreated();
}

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute("Default", "{controller=Account}/{action=CreateRoleAndUsers}");

app.MapHub<ChatHub>("/chathub");

app.Run();



