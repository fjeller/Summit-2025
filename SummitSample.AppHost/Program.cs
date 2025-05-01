var builder = DistributedApplication.CreateBuilder(args);

var userService = builder.AddProject<Projects.SummitSample_UserService>( "userservice" )
	.WithExternalHttpEndpoints();

builder.AddProject<Projects.SummitSample_Web>("webfrontend")
    .WithReference(userService)
    .WaitFor(userService);

builder.Build().Run();
