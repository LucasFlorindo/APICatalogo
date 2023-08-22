using ApiCatalogo.ApiEndpoints;
using ApiCatalogo.AppServiceExtensions;
using ApiCatalogo.Context;
using ApiCatalogo.Models;
using ApiCatalogo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

//Service Collection
builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAutenticationJwt();

var app = builder.Build();

//Endpoints com métodos
app.MapAutenticacaoEndpoints();
app.MapCategoriasEndpoints();
app.MapProdutosEndpoints();


//Definição de swagger, tratamento de esxceções e política cors
var environment = app.Environment;
app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware()
    .UseAppCors();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

