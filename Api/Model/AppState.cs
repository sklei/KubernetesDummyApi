namespace KubernetesDummyApi.Model;

public class AppState
{
	public AppState()
	{
		this.UniqueInstanceId = Guid.NewGuid();
	}

	public Guid UniqueInstanceId { get; init;}
}
