# Auth_Practice
All The Authentication &amp; Authorization Techniques

Nugets
Microsoft.EntityFrameWorkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.AspNetCore.Authentication.JwtBearer

For Swagger Use This Nuget
=> Swashbuckle.AspNetCore

Add This Code To Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI( options=>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "AuthAPI");
    });
}


=> Endpoint : https://localhost:7085/swagger/   (After The URL add /swagger)

****.
=> Migration for The Identity Tables
	Add-Migration CreateIdentityTables
	Update-Database