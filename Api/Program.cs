using KubernetesDummyApi.Core;
using KubernetesDummyApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddHealthChecks()
	.AddCheck<HealthyHealthCheck>("Healthy Check");
	// .AddCheck<RandomHealthCheck>("Random Check");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add my stuff
builder.Services.AddSingleton<AppState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
	{
		endpoints.MapHealthChecks("/health/startup");
		endpoints.MapHealthChecks("/health/live");
		endpoints.MapHealthChecks("/health/ready");
		endpoints.MapControllers();
	});

app.Run();
