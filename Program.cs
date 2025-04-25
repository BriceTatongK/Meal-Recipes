using TheRecipe.Components;
using TheRecipe.Services;
using MealRecipeLogClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddMealRecipeLogClient()
    .AddRazorComponents()
    .AddInteractiveServerComponents();

//var maxBufferSize = 30 * 1024 * 1024; // 30MB
//builder.Services.AddServerSideBlazor().AddHubOptions(opt => { opt.MaximumReceiveMessageSize = maxBufferSize; });

builder.Services.AddSingleton<IMealRecipeProvider, MealStore>();
//builder.Services.AddHttpClient<IMealRecipeProvider, MealClient>(op =>
//{
//    //op.BaseAddress = new Uri("http://themealdb.com/api/json/v1/1/filter.php");
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseAntiforgery();
app.UseStaticFiles();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
