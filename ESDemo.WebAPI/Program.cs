using Elastic.Clients.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

ElasticsearchClientSettings settings = new(new Uri("http://localhost:9200"));
settings.DefaultIndex("products");

ElasticsearchClient client = new(settings);

client.IndexAsync("products").GetAwaiter().GetResult();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.Run();
