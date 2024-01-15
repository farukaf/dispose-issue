using Microsoft.Extensions.DependencyInjection;

//https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync

//Only calls DisposeAsync
await using var test1 = new TestClass();

//Only calls Dispose
using var test2 = new TestClass();

var serviceCollection = new ServiceCollection();

// Register your services
serviceCollection.AddScoped<TestClass>();
var serviceProvider = serviceCollection.BuildServiceProvider();

//This calls only dispose 
using (var scope = serviceProvider.CreateScope())
{
    var tst = scope.ServiceProvider.GetRequiredService<TestClass>();
}

//This seems to work fine.... Calling both dispose and disposeasync
using (var scope = serviceProvider.CreateScope())
{
    await using var tst = scope.ServiceProvider.GetRequiredService<TestClass>();
}

class TestClass : IAsyncDisposable, IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Dispose");
    }

    public ValueTask DisposeAsync()
    {
        Console.WriteLine("DisposeAsync");
        return ValueTask.CompletedTask;
    }
}