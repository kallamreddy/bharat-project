using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess;
using TSABanking.DataAccess.Interfaces;
using TSABanking.DataAccess.Models;
using TSABanking.Services;
using TSABanking.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TsabankingContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("TSABankingContext"));
});

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPickListMasterRepository, PickListMasterRepository>();
builder.Services.AddTransient<IBankRepository, BankRepository>();
builder.Services.AddTransient<IJobRepository, JobRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IJobQueueRepository, JobQueueRepository>();
builder.Services.AddTransient<ITerminationQueueRepository, TerminationQueueRepository>();



builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPickListMasterService, PickListMasterService>();
builder.Services.AddTransient<IBankService, BankService>();
builder.Services.AddTransient<IJobService, JobService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IJobQueueService, JobQueueService>();
builder.Services.AddTransient<ITerminationQueueService, TerminationQueueService>();

// Add services to the container.
builder.Services.AddRazorPages();

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

app.MapRazorPages();

app.Run();
