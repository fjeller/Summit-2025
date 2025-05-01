using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var userService = builder.AddProject<SummitSample_UserService>( "userservice" )
	.WithExternalHttpEndpoints();

var todoService = builder.AddProject<SummitSample_TodoService>( "todoservice" )
	.WithExternalHttpEndpoints();

builder.AddProject<SummitSample_Web>( "webfrontend" )
	.WithReference( userService )
	.WaitFor( userService )
	.WithReference( todoService )
	.WaitFor( todoService );

builder.Build().Run();
