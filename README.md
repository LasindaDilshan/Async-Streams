# Async-Streams
C# feature - Async Streams 

# What we want :

We want to do asynchoronous work during enumeration.


Async Streams were introduced in C# 8.0 and allow programmers to asynchronously iterate over a sequence of values. Async streams are more efficient than traditional synchronous streams since they do not block the currently executing thread.

They have introduced IAsyncEnumerble<T> , IAsyncEnumeratot<T> and IAsyncDisposable Interfaces .

This feature allows you to handle data sequence where each element is generated asynchoronously.

Example :-
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        await foreach (var number in GenerateNumbersAsync())
        {
            Console.WriteLine(number);
        }
    }

    public static async IAsyncEnumerable<int> GenerateNumbersAsync()
    {
        for (int i = 1; i <= 5; i++)
        {
            // Simulate an asynchronous operation
            await Task.Delay(100);
            yield return i;
        }
    }
}
```
# Use cases.

Streaming data from web apis (Page Apis - https://www.youtube.com/watch?v=Ylcl8hKks_Y) .
Reading Large Files .


# Entity Framework Core
The most obvious library to benefit from async streams is Entity Framework Core. Records being read from a database are a great use case for a collection of items to access asynchronously.

With the AsAsyncEnumerable() extension method, any instance of IQueryable<T> can be converted to IAsyncEnumerable<T> and then accessed using the asynchronous foreach statement:
```
var persons = context.Persons
    .Where(person => person.LastName == "LD")
    .AsAsyncEnumerable();
 
await foreach (var person in persons)
{
    // use the person
}
```

