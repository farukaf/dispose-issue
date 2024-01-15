namespace WebApplication8;

public class TestBoth : IAsyncDisposable, IDisposable
{
    public virtual void Dispose()
    {
        Console.WriteLine("Dispose");
    }

    public ValueTask DisposeAsync()
    {
        Console.WriteLine("DisposeAsync");
        return ValueTask.CompletedTask;
    }

    public virtual void GetName()
    {
        Console.WriteLine();
        Console.WriteLine("TestBoth");
    }
}


public class TestDispose : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Dispose");
    }

    public virtual void GetName()
    {
        Console.WriteLine();
        Console.WriteLine("TestDispose");
    }
}

public class TestDisposeAsync : IAsyncDisposable
{
    public ValueTask DisposeAsync()
    {
        Console.WriteLine("DisposeAsync");
        return ValueTask.CompletedTask;
    }

    public virtual void GetName()
    {
        Console.WriteLine();
        Console.WriteLine("TestDisposeAsync");
    }
}

public class TestInheritedDispose : TestDispose, IAsyncDisposable
{
    public ValueTask DisposeAsync()
    {
        Console.WriteLine("DisposeAsync");
        return ValueTask.CompletedTask;
    }

    public override void GetName()
    {
        Console.WriteLine();
        Console.WriteLine("TestInheritedDispose");
    }
}

public class TestInheritedDisposeAsync : TestDisposeAsync, IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Dispose");
    }

    public override void GetName()
    {
        Console.WriteLine();
        Console.WriteLine("TestInheritedDisposeAsync");
    }
}

public class TestMemoryStream : IAsyncDisposable, IDisposable
{
    public virtual void Dispose()
    {
        Console.WriteLine("Dispose");
    }

    public ValueTask DisposeAsync()
    {
        Console.WriteLine("DisposeAsync");
        Dispose();
        return ValueTask.CompletedTask;
    }

    public virtual void GetName()
    {
        Console.WriteLine();
        Console.WriteLine("TestBoth");
    }
}
public class TestInheritedBoth : TestMemoryStream
{
    public override void GetName()
    {
        Console.WriteLine();
        Console.WriteLine("TestInheritedBoth");
    }

    public override void Dispose()
    {
        Console.WriteLine("Overrided Dispose");
    }
}