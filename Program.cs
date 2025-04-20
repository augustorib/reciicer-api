using Microsoft.EntityFrameworkCore;
using ReciicerAPI.Data;
using ReciicerAPI.Repository;
using ReciicerAPI.Repository.Interface;
using ReciicerAPI.Service.Cliente;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using ReciicerAPI.Service.Email;
using ReciicerAPI.Service.Premiacao;
using ReciicerAPI.Service.Material;
using ReciicerAPI.Service.TipoMaterial;
using ReciicerAPI.Service.Coleta;
using ReciicerAPI.Service.Material_Coleta;
using ReciicerAPI.Service.PontoColeta;
using ReciicerAPI.Service.Endereco;
using ReciicerAPI.Service.ClientePremiacao;
using ReciicerAPI.Service.UsuarioIdentity;
using ReciicerAPI.Models.Entities;
using ReciicerAPI.Service.Cooperativa;
using ReciicerAPI.Service.Recolhimento;
using ReciicerAPI.Service.Estoque;
using ReciicerAPI.Service.EstoqueMaterial;
using ReciicerAPI.Service.RecolhimentoEstoqueMaterial;
using ReciicerAPI.Service.Relatorio;
using ReciicerAPI.Service.Error;
using ReciicerAPI.Service.Audit;



var builder = WebApplication.CreateBuilder(args);

//Repository Interface
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IPremiacaoRepository, PremiacaoRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<ITipoMaterialRepository, TipoMaterialRepository>();
builder.Services.AddScoped<IColetaRepository, ColetaRepository>();
builder.Services.AddScoped<IMaterial_ColetaRepository, Material_ColetaRepository>();
builder.Services.AddScoped<IPontoColetaRepository, PontoColetaRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IClientePremiacaoRepository, ClientePremiacaoRepository>();
builder.Services.AddScoped<ICooperativaRepository, CooperativaRepository>();
builder.Services.AddScoped<IRecolhimentoRepository, RecolhimentoRepository>();
builder.Services.AddScoped<IRecolhimentoEstoqueMaterialRepository, RecolhimentoEstoqueMaterialRepository>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<IEstoqueMaterialRepository, EstoqueMaterialRepository>();

//Services
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<PremiacaoService>();
builder.Services.AddScoped<MaterialService>();
builder.Services.AddScoped<TipoMaterialService>();
builder.Services.AddScoped<ColetaService>();
builder.Services.AddScoped<Material_ColetaService>();
builder.Services.AddScoped<PontoColetaService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<ClientePremiacaoService>();
builder.Services.AddScoped<UsuarioIdentityService>();
builder.Services.AddScoped<CooperativaService>();
builder.Services.AddScoped<RecolhimentoService>();
builder.Services.AddScoped<EstoqueService>();
builder.Services.AddScoped<EstoqueMaterialService>();
builder.Services.AddScoped<RecolhimentoEstoqueMaterialService>();
builder.Services.AddScoped<RelatorioService>();
builder.Services.AddScoped<ErrorHandlingService>();
builder.Services.AddScoped<AuditService>();
builder.Services.AddScoped<IEmailService, EmailService>();


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

// Add Dbcontext
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

        
//Identity Login
builder.Services.AddIdentity<UsuarioIdentity, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

//IDENTITY CONFIG
//teste politicas de senha
builder.Services.Configure<IdentityOptions>(options =>
{
   // Password settings.
   options.Password.RequireDigit = false;
   options.Password.RequireLowercase = false;
   options.Password.RequireNonAlphanumeric = false;
   options.Password.RequireUppercase = false;
   options.Password.RequiredLength = 1;
   options.Password.RequiredUniqueChars = 1;
   
   
});

builder.Services.AddLogging( config => config.AddConsole());
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
        options.SlidingExpiration = true;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
