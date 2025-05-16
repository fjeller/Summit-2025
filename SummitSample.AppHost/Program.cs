using Projects;

var builder = DistributedApplication.CreateBuilder( args );

var cache = builder.AddRedis( "RedisCache" )
	.WithLifetime( ContainerLifetime.Persistent )
	.WithRedisInsight();

var userService = builder.AddProject<SummitSample_UserService>( "userservice" )
	.WithReference( cache )
	.WaitFor( cache )
	.WithExternalHttpEndpoints();

var todoService = builder.AddProject<SummitSample_TodoService>( "todoservice" )
	.WithReference( cache )
	.WaitFor( cache )
	.WithExternalHttpEndpoints();

builder.AddProject<SummitSample_Web>( "webfrontend" )
	.WithReference( userService )
	.WaitFor( userService )
	.WithReference( todoService )
	.WaitFor( todoService );

builder.Build().Run();
