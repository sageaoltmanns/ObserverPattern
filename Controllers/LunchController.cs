using System.Net;
using Microsoft.AspNetCore.Mvc;
using ObserverPattern.DataAccess;

namespace ObserverPattern.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LunchController : Controller
{
    private readonly ILunchDataAccess _lunchDataAccess;
    private readonly IInternDataAccess _internDataAccess;

    public LunchController(ILunchDataAccess lunchDataAccess, IInternDataAccess internDataAccess)
    {
        _lunchDataAccess = lunchDataAccess;
        _internDataAccess = internDataAccess;
    }

    [HttpPost("{lunchId}/{internName}")]
    public async Task<IActionResult> AddInternToLunch([FromRoute] int lunchId, [FromRoute] string internName)
    {
        var intern = _internDataAccess.GetInternByName(internName);

        if (intern == null)
            return BadRequest();

        _lunchDataAccess.AddInternToLunch(lunchId, intern);

        return Ok();
    }
    
    [HttpGet("{lunchId}")]
    public async Task<IActionResult> GetIntern([FromRoute] int lunchId)
    {
        var lunch = _lunchDataAccess.GetLunchById(lunchId);

        if (lunch == null)
            return BadRequest();


        return Ok(lunch.Interns);
    }
    
    [HttpDelete("{lunchId}")]
    public async Task<IActionResult> RemoveInternFromLunch([FromRoute]int lunchId, [FromBody]string internName)
    {
        var intern = _internDataAccess.GetInternByName(internName);

        if (intern == null)
            return BadRequest();

        _lunchDataAccess.RemoveInternFromLunch(lunchId, intern);

        return Ok();
    }

    [HttpPut("{lunchId}/leader")]
    public async Task<IActionResult> UpdateLunchLeader([FromRoute]int lunchId, [FromBody]string leaderName)
    {
        var lunch = _lunchDataAccess.GetLunchById(lunchId);

        if (lunch == null)
            return BadRequest();

        var result = _lunchDataAccess.UpdateLeader(leaderName, lunch);

        if (!result)
            return BadRequest();

        _internDataAccess.NotifyAboutUpdatedLeader(lunch);

        return Ok();
    }
    
    [HttpPut("{lunchId}/subject")]
    public async Task<IActionResult> UpdateLunchSubject([FromRoute]int lunchId, [FromBody]string subject)
    {
        var lunch = _lunchDataAccess.GetLunchById(lunchId);

        if (lunch == null)
            return BadRequest();

        var result = _lunchDataAccess.UpdateSubject(subject, lunch);

        if (!result)
            return BadRequest();

        _internDataAccess.NotifyAboutUpdatedLeader(lunch);

        return Ok();
    }
}
