using Microsoft.Extensions.DependencyInjection;

namespace TestWithServiceCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var serviceCollection = new ServiceCollection();

            // Register your services
            serviceCollection.AddScoped<OtherTestClass>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var tst = scope.ServiceProvider.GetRequiredService<OtherTestClass>();
            }
            /*
             If TestClass Implements IDisposable it only calls Dispose()
             If TestClass Implements IAsyncDisposable it throws an exception
             An unhandled exception of type 'System.InvalidOperationException' occurred in Microsoft.Extensions.DependencyInjection.dll
            'TestClass' type only implements IAsyncDisposable. Use DisposeAsync to dispose the container.
             */

            Console.WriteLine("Good bye, World!");
        }

        class OtherTestClass : IAsyncDisposable//, IDisposable
        {
            //public void Dispose()
            //{
            //    Console.WriteLine("Dispose");
            //}

            public ValueTask DisposeAsync()
            {
                Console.WriteLine("DisposeAsync");
                return ValueTask.CompletedTask;
            }

        }
    }
}