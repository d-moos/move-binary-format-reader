// See https://aka.ms/new-console-template for more information

using Explorer;
using Explorer.BinaryRepository;
using Explorer.ObjectTypes.Signature;
using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.JsonRpc;

var builder = WebApplication.CreateBuilder(args);
var configuration = LoadConfiguration();

builder.Services
    .AddSingleton<IJsonRpcClient>(new JsonRpcClient(configuration.RpcNodeUrl))
    .AddSingleton<IReadApi, ReadApi>()
    .AddSingleton<IBinaryRepository, BinaryRepository>();
    
builder.Services
    .AddGraphQLServer()
    .AddFiltering()
    .AddType<U8Token>()
    .AddType<U16Token>()
    .AddType<U32Token>()
    .AddType<U64Token>()
    .AddType<U128Token>()
    .AddType<U256Token>()
    .AddType<AddressToken>()
    .AddType<BooleanToken>()
    .AddType<MutableReferenceToken>()
    .AddType<ReferenceToken>()
    .AddType<SignerToken>()
    .AddType<StructInstantiationToken>()
    .AddType<StructToken>()
    .AddType<TypeParameterToken>()
    .AddType<VectorToken>()
    .AddQueryType<Query>();

var app = builder.Build();
app.MapGraphQL(PathString.Empty);
app.Run();


ApplicationConfiguration LoadConfiguration()
{
    var currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
    var builder = new ConfigurationBuilder()
        .AddJsonFile($"appsettings.json")
        .AddJsonFile($"appsettings.{currentEnvironment}.json", true)
        .AddEnvironmentVariables();

    var configurationRoot = builder.Build();
    var configuration = new ApplicationConfiguration();
    configurationRoot.Bind(configuration);

    return configuration;
}