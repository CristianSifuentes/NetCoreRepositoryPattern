using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreRepositoryPattern.Dto;
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
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EventDto[]>> Get(bool includeGigs = false)
        {
            try
            {
                var results = await _eventRepository.GetEventArgs(includeGigs);
                var mappedEntities = _mapper.Map<EventDto[]>(results);
                return Ok(mappedEntities);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventDto>> Get(int eventId, bool includeGigs = false)
        {
            try
            {
                var result = await _eventRepository.GetEvent(eventId, includeGigs);
                if (result == null) return NotFound();

                var mappedEntitiy = _mapper.Map<EventDto>(result);
                return Ok(mappedEntitiy);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

    }
}
