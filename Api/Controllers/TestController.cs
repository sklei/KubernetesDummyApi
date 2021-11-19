using System.IO;
using KubernetesDummyApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace KubernetesDummyApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TestController : ControllerBase
{
	private IWebHostEnvironment env;
	private IOptions<AppSettings> options;
	private AppState state;

	public TestController(IWebHostEnvironment env, IOptions<AppSettings> options, AppState state)
	{
		this.env = env;
		this.options = options;
		this.state = state;
	}

	public ActionResult Test() => Ok("PLOOP");

	public ActionResult Options() => Ok(options);

	public ActionResult<string> Environment() => Ok(env.EnvironmentName);

	public ActionResult TouchyDaFile()
	{
		var filename = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
		var path = Path.Combine(this.options.Value.CreateOnPath ?? "/", filename);
		using var stream = System.IO.File.CreateText(path);
		stream.WriteLine("PLOOP");

		return Ok("Touched");
	}

	public ActionResult WhereDaFiles() => Ok(Directory.GetFiles(this.options.Value.CreateOnPath ?? "/"));

	public ActionResult WhatsMyName() => Ok(this.state.UniqueInstanceId); 
}