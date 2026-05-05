using System.Text.Json;

namespace Lab10;

public record Todo(int Id, string Title, int UserId, bool Completed);

public record Post(int Id, int UserId, string Title, string Body);

public record User(int id, string name, string username, string email, Address address);
public record Address(string street, string suite, string city, string zipcode, Geo geo);
public record Geo(string lat, string lng);

public class SerializeDemo
{
    public static void RunDeserialize()
    {
        HttpClient client = new HttpClient();
        var response = client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/3").Result;
        var json = JsonSerializer.Deserialize<Todo>(response, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true });
        Console.WriteLine(json);
    }

    public static void Task01()
    {
        HttpClient client = new HttpClient();
        var response = client.GetStringAsync("https://jsonplaceholder.typicode.com/todos").Result;
        var json = JsonSerializer.Deserialize<List<Todo>>(response, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true });
        // Console.WriteLine(string.Join("\n", json));

        IEnumerable<Todo> user2Tasks =
            from todo in json
            where todo.UserId == 2
            where todo.Completed == true
            select todo;
        Console.WriteLine(string.Join("\n", user2Tasks));
    }

    public static void Task02()
    {
        using HttpClient client = new HttpClient();
        var response = client.GetStringAsync("https://jsonplaceholder.typicode.com/posts").Result;
        var json = JsonSerializer.Deserialize<List<Post>>(response, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true });

        IEnumerable<Post> u2Posts =
            from post in json
            where post.UserId == 2
            select post;
        Console.WriteLine(string.Join("\n", u2Posts));
    }

    public static void Task03()
    {
        using HttpClient client = new HttpClient();
        var response = client.GetStringAsync("https://jsonplaceholder.typicode.com/users").Result;
        var json = JsonSerializer.Deserialize<List<User>>(response);

        IEnumerable<User> searchedUser =
            from user in json
            where user.id == 2
            select user;
        Console.WriteLine(string.Join("\n", searchedUser));
    }
    
    public static void RunSerialize()
    {
        Todo todo = new Todo(1, "Walk", 4, false);
        var output = JsonSerializer.Serialize(todo, JsonSerializerOptions.Default);
        Console.WriteLine(output);

        List<Todo> taskList = new()
        {
            todo,
            new Todo(2, "Dinner", 4, true),
            new Todo(5, "Run", 3, true)
        };
        var listOutput = JsonSerializer.Serialize(taskList, JsonSerializerOptions.Default);
        Console.WriteLine(listOutput);
    }
}