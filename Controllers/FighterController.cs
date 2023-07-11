using FighterApi.Core;
using FighterApi.Data;
using FighterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FighterApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FighterController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public FighterController (IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //Get All Fighters
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _unitOfWork.Fighters.All());
    }

    //Get Fighters by Id
    [HttpGet]
    [Route(template:"GetById")]
    public async Task<ActionResult> Get(int id)
    {
        var fighter = await _unitOfWork.Fighters.GetById(id);
        if(fighter == null) return NotFound();
        return Ok(fighter);
    }

    //Add Fighters
    [HttpPost]
    [Route(template:"AddFighter")]
    public async Task<IActionResult> Add(FighterModel fighter)
    {
       await _unitOfWork.Fighters.Add(fighter);
       await _unitOfWork.CompleteAsync();
       return Ok();
    }

    //Delete Fighters
    [HttpDelete]
    [Route(template:"DeleteFighter")]
    public async Task<IActionResult> Delete(int id)
    {
        var fighter = await _unitOfWork.Fighters.GetById(id);
         if(fighter != null)
        {
             await _unitOfWork.Fighters.Delete(fighter);
             await _unitOfWork.CompleteAsync();
             return NoContent();
        }else{
            return NotFound();
        }
    }

    //Update Fighter
    [HttpPatch]
    [Route(template:"UpdateFighter")]
    public async Task<IActionResult> Update(FighterModel fighter)
    {
        var existingFighter= await _unitOfWork.Fighters.GetById(fighter.Id);
        Console.WriteLine(existingFighter.fName);
        if(existingFighter != null)
        {
            await _unitOfWork.Fighters.Update(fighter);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
        else
        {
            return NoContent();
        }
    }
}
