using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        private readonly LinkGenerator _linkGenerator;

        public EventsController(IEventRepository eventRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
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


        [HttpGet("search")]
        public async Task<ActionResult<EventDto[]>> SearchByDate(DateTime date, bool includeGigs = false)
        {
            try
            {
                var results = await _eventRepository.GetEventsByDate(date, includeGigs);
                if (results == null) return NotFound();

                var mappedEntities = _mapper.Map<EventDto[]>(results);
                return Ok(mappedEntities);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }



        [HttpPost]
        public async Task<ActionResult<EventDto>> Post(EventDto dto)
        {
            try
            {
                var mappedEntity = _mapper.Map<Event>(dto);
                _eventRepository.Add(mappedEntity);

                if (await _eventRepository.Save())
                {
                    var location = _linkGenerator.GetPathByAction("Get", "Events", new { mappedEntity.EventId });
                    return Created(location, _mapper.Map<EventDto>(mappedEntity));
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

    }
}
