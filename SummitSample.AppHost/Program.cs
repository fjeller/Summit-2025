using Projects;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder( args );

var cache = builder.AddRedis( "RedisCache" )
	.WithLifetime( ContainerLifetime.Persistent )
	.WithRedisInsight()
	.WithIconName( "Add_Circle" );

var userService = builder.AddProject<SummitSample_UserService>( "userservice" )
	.WithHttpHealthCheck( "/health" )
	.WithReference( cache )
	.WaitFor( cache )
	.WithExternalHttpEndpoints()
	.WithIconName("LaptopPerson", IconVariant.Regular);

var todoService = builder.AddProject<SummitSample_TodoService>( "todoservice" )
	.WithHttpHealthCheck( "/health" )
	.WithReference( cache )
	.WaitFor( cache )
	.WithExternalHttpEndpoints()
	.WithIconName("ClipboardBulletList", IconVariant.Regular);

builder.AddProject<SummitSample_Web>( "webfrontend" )
	.WithHttpHealthCheck( "/health" )
	.WithReference( userService )
	.WaitFor( userService )
	.WithReference( todoService )
	.WaitFor( todoService )
	.WithIconName("Globe");

builder.Build().Run();
