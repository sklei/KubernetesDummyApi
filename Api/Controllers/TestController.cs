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

	public ActionResult WhatsMyName() => Ok(this.state.UniqueInstanceId); 

	public ActionResult Options() => Ok(options);

	public ActionResult Environment() => Ok(env.EnvironmentName);

	public ActionResult CreateFile()
	{
		var filename = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
		var path = Path.Combine(this.options.Value.CreateOnPath ?? "/", filename);
		using var stream = System.IO.File.CreateText(path);
		stream.WriteLine($"{DateTime.Now.Ticks} - Created from: {state.UniqueInstanceId}");

		return Ok("Touched");
	}

	public ActionResult ListFiles() => Ok(Directory.GetFiles(this.options.Value.CreateOnPath ?? "/"));

	public ActionResult ListFilesContents() 
	{
		var files = Directory.GetFiles(this.options.Value.CreateOnPath ?? "/", "*.txt");
		var fileContents = files.Select(f => System.IO.File.ReadAllText(f)).OrderBy(f => f);

		return Ok(fileContents);
	}

	public ActionResult DeleteFiles() 
	{
		var files = Directory.GetFiles(this.options.Value.CreateOnPath ?? "/", "*.txt");
		files.ToList().ForEach(f => System.IO.File.Delete(f));

		return Ok("All files deleted!");
	}
}