namespace KubernetesDummyApi.Model;

public class AppState
{
	public AppState(ILogger<AppState> logger)
	{
		this.UniqueInstanceId = Guid.NewGuid();
		logger.LogInformation($"AppState started with GUID: {this.UniqueInstanceId}");
	}

	public Guid UniqueInstanceId { get; init;}
}
