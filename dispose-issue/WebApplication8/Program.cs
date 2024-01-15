using WebApplication8;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TestBoth>();
builder.Services.AddScoped<TestDispose>();
builder.Services.AddScoped<TestDisposeAsync>();
builder.Services.AddScoped<TestInheritedDispose>();
builder.Services.AddScoped<TestInheritedDisposeAsync>();
builder.Services.AddScoped<TestInheritedBoth>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Here it only calls dispose
app.MapGet("/TestDispose", (TestDispose tb) =>
{
    tb.GetName();
    return new { Ok = "Ok" };
});

//Here it only calls disposeasync
//Me try without the builder throws an exception
app.MapGet("/TestDisposeAsync", (TestDisposeAsync tb) =>
{
    tb.GetName();
    return new { Ok = "Ok" };
});

//Here it only calls disposeasync, where in the documentation is not so clear
//https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync#implement-both-dispose-and-async-dispose-patterns
app.MapGet("/TestBoth", (TestBoth tb) =>
{
    tb.GetName();
    return new { Ok = "Ok" };
});

//Here it only calls disposeasync, where in the documentation is not so clear as why it reimplement dispose
//In a inherited class may be a problem since the inherited class may not call the base class dispose for lack of knowledge/visibility
//https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync#implement-both-dispose-and-async-dispose-patterns
app.MapGet("/TestInheritedDispose", (TestInheritedDispose tb) =>
{
    tb.GetName();
    return new { Ok = "Ok" };
});

//Here again it only calls disposeasync, 
//And here is a real problem since we are unable to do like the documentation says
//https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync#implement-both-dispose-and-async-dispose-patterns
app.MapGet("/TestInheritedDisposeAsync", (TestInheritedDispose tb) =>
{
    tb.GetName();
    return new { Ok = "Ok" };
});

//Here again it only calls disposeasync, check the MemoryStream example
app.MapGet("/TestInheritedBoth", (TestInheritedDispose tb) =>
{
    tb.GetName();
    return new { Ok = "Ok" };
});

app.Run();
