namespace ToDoList.Server.Configuration;

public static class Cors
{
    public static void AddCors(this WebApplicationBuilder builder)
    {
        const string localOrigin = "http://localhost:5078";
        
        builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy
            .WithOrigins(localOrigin)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
        ));
    }
}