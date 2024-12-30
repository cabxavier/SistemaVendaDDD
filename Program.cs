using Aplicacao.Servico;
using Aplicacao.Servico.Interfaces;
using Dominio21.Interfaces;
using Dominio21.Repositorio;
using Dominio21.Servicos;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Entidades;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

// serviço aplicação
builder.Services.AddScoped<IServicoAplicacaoCategoria, ServicoAplicacaoCategoria>();
builder.Services.AddScoped<IServicoAplicacaoCliente, ServicoAplicacaoCliente>();
builder.Services.AddScoped<IServicoAplicacaoProduto, ServicoAplicacaoProduto>();
builder.Services.AddScoped<IServicoAplicacaoVenda, ServicoAplicacaoVenda>();
builder.Services.AddScoped<IServicoAplicacaoUsuario, ServicoAplicacaoUsuario>();

// domínio
builder.Services.AddScoped<IServicoCategoria, ServicoCategoria>();
builder.Services.AddScoped<IServicoCliente, ServicoCliente>();
builder.Services.AddScoped<IServicoProduto, ServicoProduto>();
builder.Services.AddScoped<IServicoVenda, ServicoVenda>();
builder.Services.AddScoped<IServicoUsuario, ServicoUsuario>();

// repositório
builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<IRepositorioProduto, RepositorioProduto>();
builder.Services.AddScoped<IRepositorioVenda, RepositorioVenda>();
builder.Services.AddScoped<IRepositorioVendaProdutos, RepositorioVendaProdutos>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
