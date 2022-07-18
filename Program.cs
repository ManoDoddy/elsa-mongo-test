using Elsa;
using Elsa.Persistence.MongoDb;
using elsa_mongo_test.Workflows;

var builder = WebApplication.CreateBuilder(args);

var elsaSection = builder.Configuration.GetSection("Elsa");

builder.Services.AddElsa(options =>
{
    options
        .AddConsoleActivities()
        .UseMongoDbPersistence(opt => opt.ConnectionString = "mongodb://localhost:27017/Elsa")
        .AddHttpActivities(elsaSection.GetSection("Server").Bind)
        .AddQuartzTemporalActivities()
        .AddWorkflow<TimeBasedWorkflow>();
});

builder.Services.AddElsaApiEndpoints();

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseHttpActivities();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapFallbackToPage("/_Host");
});

app.Run();
