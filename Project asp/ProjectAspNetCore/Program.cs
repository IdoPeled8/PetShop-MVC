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

app.MapHub<MainHub>("/Mainhub");

app.Run();



//make more place for image name in add and edit

//more use with api and ajax

//use signalR for edit/add/remove -
//that if somthing happen this will change for all the users that login to the app without refreshing


//@*add show more button if the description too long*@

//need to make: if photo not valid send message to the user


//i can manipulate the confirm passwork in the register

//if user name is exist say the user that try to register that is exist (message)


//add ajax to everything that dont need to reload the page again (Login,photo changing...)


//after web api add some FrontEnd style - (learn more css and bootstrap)

// add all chat??

//add validation for empty messages in the admins chat

// use services instead of actionType? - learn again about services
