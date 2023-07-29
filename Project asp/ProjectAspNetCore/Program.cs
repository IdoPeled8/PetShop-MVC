

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddScoped<UserLogic>();
builder.Services.AddScoped<AnimalLogic>();
builder.Services.AddScoped<CategoryLogic>();
builder.Services.AddScoped<CommentLogic>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>(); // can remove?
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

app.UseAuthentication(); // know the users

app.UseRouting();

app.UseAuthorization(); // check what user can or cant do

app.UseStaticFiles();


app.MapControllerRoute("Default", "{controller=Account}/{action=CreateRoleAndUsers}");

app.MapHub<ChatHub>("/chathub");

app.Run();

//new TODO
//need to make: if photo not valid send message to the user
//if add existing name category said this is exists
//i can manipulate the confirm passwork in the register
//if user name is exist say the user that try to register that is exist (message)

//add ajax to everything that dont need to reload the page again (Login,photo changing...)

//after web api add some FrontEnd style - (learn more css and bootstrap)
//when removing animal page refresh with the removed animal

//in the middle of adding users to comments not working well now
// add all chat??
//try to use signalR for updating animals
//add validation for empty messages in the admins chat

//||simple bugs||
//if photo file is not photo it dosent send validation message its just restart the page and the same if photo not good
//when submit new animal without image not sending error msg
//when photo not good need to send error msg
// photo msg still not working good

// make header look better

// use services instead of actionType? - learn again about services
//use web api for the not adding photo refresh? or js
//check about pop msg before delete

//Add Back button to all the add\edit\remove Methods


/* make new folder\project for Server logic.
 put all server logic in the logic folder for example: LoginLogic will hold method for check user login information.
 all ui logic (parameters that moves to the ui) keep in the controller.
*/
// FOR AMIR
//ask about the tuple i sending to the view component and if this ok
// Logger not working

//User not Login BUG!! (if i use the website and refresh alot the users not login )

//make better reuse in code (try to remove duplicated code and make the code more readble and easy)

//add SingelR
//add web api for comment adding?
//add alert msg before delete animal
//when i add big description and comment open more space to show the full msg 

// make error view + check the error view (change to Production in the lauchSettings.json
// use view componnent for similar pages? - login and register || admin and Catalog

//להבין טוב הכול בפרוייקט כולל הפרוגרם
//make better data base

/* ||things to add||
 * Unity Test
*/

/* ||Extra:||
 * better looking
 * add more animals
 * dont show all the animals from top to buttom make pages inside the category
 */

// פרק 8 דוגמה 8
// פרק דוגמה 4 Sections
// אחרון פרק 8 validation
