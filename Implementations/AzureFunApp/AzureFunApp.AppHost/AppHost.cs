var builder = DistributedApplication.CreateBuilder(args);

builder.AddAzureFunctionsProject<Projects.AzureFunApp>("azurefunapp");

builder.Build().Run();
