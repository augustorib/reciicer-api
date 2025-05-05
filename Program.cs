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
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPremiacaoRepository, PremiacaoRepository>();
builder.Services.AddTransient<IMaterialRepository, MaterialRepository>();
builder.Services.AddTransient<ITipoMaterialRepository, TipoMaterialRepository>();
builder.Services.AddTransient<IColetaRepository, ColetaRepository>();
builder.Services.AddTransient<IMaterial_ColetaRepository, Material_ColetaRepository>();
builder.Services.AddTransient<IPontoColetaRepository, PontoColetaRepository>();
builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddTransient<IClientePremiacaoRepository, ClientePremiacaoRepository>();
builder.Services.AddTransient<ICooperativaRepository, CooperativaRepository>();
builder.Services.AddTransient<IRecolhimentoRepository, RecolhimentoRepository>();
builder.Services.AddTransient<IRecolhimentoEstoqueMaterialRepository, RecolhimentoEstoqueMaterialRepository>();
builder.Services.AddTransient<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddTransient<IEstoqueMaterialRepository, EstoqueMaterialRepository>();

//Services
builder.Services.AddTransient<ClienteService>();
builder.Services.AddTransient<PremiacaoService>();
builder.Services.AddTransient<MaterialService>();
builder.Services.AddTransient<TipoMaterialService>();
builder.Services.AddTransient<ColetaService>();
builder.Services.AddTransient<Material_ColetaService>();
builder.Services.AddTransient<PontoColetaService>();
builder.Services.AddTransient<EnderecoService>();
builder.Services.AddTransient<ClientePremiacaoService>();
builder.Services.AddTransient<UsuarioIdentityService>();
builder.Services.AddTransient<CooperativaService>();
builder.Services.AddTransient<RecolhimentoService>();
builder.Services.AddTransient<EstoqueService>();
builder.Services.AddTransient<EstoqueMaterialService>();
builder.Services.AddTransient<RecolhimentoEstoqueMaterialService>();
builder.Services.AddTransient<RelatorioService>();
builder.Services.AddTransient<ErrorHandlingService>();
builder.Services.AddTransient<AuditService>();
builder.Services.AddTransient<IEmailService, EmailService>();


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
