using Microsoft.AspNetCore.Mvc;

namespace SingletonScopeTransient.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ISingleton _singleton;
    private readonly IScoped _scoped;
    private readonly ITransient _transient;
    private readonly IScoped _secondScoped;
    private readonly ITransient _secondTransient;

    public WeatherForecastController(ISingleton singleton, IScoped scoped, ITransient transient, IScoped secondScoped, ITransient secondTransient)
    {
        _secondTransient = secondTransient;
        _secondScoped = secondScoped;
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var singletonGuid = _singleton.Value;
        var scopedGuid = _scoped.Value;
        var transientGuid = _transient.Value;

        var response = new ResponseModel
        {
            SingletonValue = singletonGuid,
            ScopedValue = scopedGuid,
            TransientValue = transientGuid,

            SecondScopedValue = _secondScoped.Value,
            SecondTransientValue = _secondTransient.Value
        };

        return Ok(response);
    }
}

public class ResponseModel
{
    public Guid SingletonValue { get; set; }
    public Guid ScopedValue { get; set; }
    public Guid TransientValue { get; set; }

    public Guid SecondScopedValue { get; set; }
    public Guid SecondTransientValue { get; set; }
}
