using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Database;
using Services;
using Microsoft.EntityFrameworkCore;
using OpenAI_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();

var configuration = builder.Configuration;

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});

builder.Host.ConfigureServices((host, services) =>
{
    var awsSettings = host.Configuration.GetSection("AWS");
    var credentials = new BasicAWSCredentials(
        awsSettings.GetValue<string>("AccessKeyId"),
        awsSettings.GetValue<string>("SecretAccessKey"));
    var region = RegionEndpoint.GetBySystemName(
        awsSettings.GetValue<string>("Region"));

    var s3Config = new AmazonS3Config
    {
        ServiceURL = awsSettings.GetValue<string>("Endpoint"),
        ForcePathStyle = true
    };

    var s3Client = new AmazonS3Client(credentials, s3Config);

    services.AddSingleton<IAmazonS3>(s3Client);
    services.AddSingleton(sg => new OpenAIAPI(
        configuration.GetValue<string>("OpenAI:API_KEY")));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
