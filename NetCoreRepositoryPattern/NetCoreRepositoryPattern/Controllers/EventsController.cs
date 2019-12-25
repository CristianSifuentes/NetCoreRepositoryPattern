using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreRepositoryPattern.Services;
using repositorypattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController: ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Event[]>> Get(bool includeGigs = false)
        {
            try
            {
                var results = await _eventRepository.GetEventArgs(includeGigs);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }



    }
}
