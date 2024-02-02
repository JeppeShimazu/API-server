WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapGet("/", GetSomething);
app.MapGet("/hello", () => "Goodbye!");
app.MapGet("/teachers/{number}", GetTeacher);

app.MapPost("/teachers", PostTeacher);

app.Urls.Add("http://*:5263");

app.Run();

static string GetSomething()
{
    return "Wazzup cuh";
}

static IResult PostTeacher()
{
Console.WriteLine("Yay");
return Results.Ok();
}

static IResult GetTeacher(int number)
{
    List<Teacher> teachers = new (){
    new Teacher() {Name = "Micke", Hitpoints = 100},
    new Teacher() {Name = "Martin", Hitpoints = 3},
    new Teacher() {Name = "Lena", Hitpoints = 300}
    };

if (number < 0 || number >= teachers.Count)
{
return Results.NotFound();
}

return Results.Ok(teachers[number]);

//return "No teacher";
}