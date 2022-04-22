using BookStore.Context;
using Microsoft.EntityFrameworkCore;
using BookStore.Repository.Interfaces;
using BookStore.Repository.Implementation;


var builder = WebApplication.CreateBuilder(args);
#region Configuration
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddDbContextPool<BookStoreDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookstoreConnection")));
builder.Services.AddScoped<IBookRepository, BookRepository>();




#endregion
var app = builder.Build();

#region Pipeline
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseMvc(Route =>
{
    Route.MapRoute("default", "{ Controller = Book}/{ Action = Index}/{ id}");
});
app.MapGet("/", () => "Hello World!");

app.Run();
#endregion