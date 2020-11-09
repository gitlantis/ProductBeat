using System;
using TaskAPI.Models;
using TaskAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BeatsController : ControllerBase
    {
        private readonly BeatService _beatService;

        public BeatsController(BeatService beatService)
        {
            _beatService = beatService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Beat>>> Get() => await _beatService.Get();

        [HttpPost]        
        public async Task<ActionResult<Beat>> Create(BeatVM beatvm)
        {
            var beat = new Beat();

            beat.BeaterId = beatvm.BeaterId;
            beat.Price = beatvm.Price;
            beat.BeatTime = DateTime.Now;

            var result = await _beatService.Create(beat);
            
            return Ok(result);
        }

        [HttpGet("lastbeat")]
        public async Task<ActionResult<Beat>> LastBeat(){
            var lastBeat = await _beatService.LastBeat();
            return Ok(lastBeat);
        }         
    }
    
}