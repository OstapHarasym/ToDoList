using MongoDB.Driver;

namespace ToDoList.Server.Configuration;

public static class IoC
{
    public static void AddIoC(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMongoCollection<ToDo>>(_ =>
            new MongoClient(builder.Configuration["mongoConnectionString"])
                .GetDatabase("ToDo")
                .GetCollection<ToDo>("ToDo"));
        
        builder.Services.AddAutoMapper(typeof(Mapping));

        builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
        builder.Services.AddScoped<IToDoService, ToDoService>();
    }
}