using InfnetMVC.DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//******************************************************************************
// Adicionar o contexto do banco de dados:
//******************************************************************************
builder.Services.AddDbContext<InfnetDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("default"));
});


//***************************************************************************************************
// Adicionando o controle de usuarios do identity:
//***************************************************************************************************
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<InfnetDbContext>();


//**********************************************************************************************************************************************
// Configura��o do cookie:
//**********************************************************************************************************************************************
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "AspNetCore.Cookies";        // Define o nome do cookie que � usado para armazenar a informa��o de autentica��o.
        options.ExpireTimeSpan = TimeSpan.FromSeconds(30); // Define o tempo de expira��o do cookie.
        options.SlidingExpiration = true;                  // Define se o cookie vai expirar ou n�o.
    });


//***************************************************************************************************************************
// Configura��es das op��es para senha identity:
//***************************************************************************************************************************
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;              // Define o tamanho m�nimo da senha.
    options.Password.RequiredUniqueChars = 3;          // Define quantos caracteres �nicos(diferentes) a senha deve conter.
    options.Password.RequireNonAlphanumeric = false;   // Define se a senha deve conter caracteres especiais.
    options.Password.RequireUppercase = true;          // Define se a senha deve conter letras mai�sculas.
    options.Password.RequireLowercase = true;          // Define se a senha deve conter letras min�sculas.
});

//*************************
// Build da aplica��o:
//*************************
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//****************************
// Adicionando autentica��o:
//****************************
app.UseAuthentication();
app.UseAuthorization();

/*******************************************************/
// Configura��o de rotas:
/*******************************************************/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
/*******************************************************/

app.Run();