using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repositorypattern.Context;
using repositorypattern.Models;
using Microsoft.Extensions.Logging;

namespace NetCoreRepositoryPattern.Services
{
    public class EventRepositiry : IEventRepository
    {
        private readonly EventContext _eventContext;
        private readonly ILogger<EventRepositiry> _logger;


        public EventRepositiry(EventContext eventContext, ILogger<EventRepositiry> logger)
        {
            _eventContext = eventContext;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<Comedian> GetComedian(int comedianId)
        {
            throw new NotImplementedException();
        }

        public Task<Comedian[]> GetComedians()
        {
            throw new NotImplementedException();
        }

        public Task<Comedian[]> GetComediansByEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetEvent(bool includeGigs = false)
        {
            throw new NotImplementedException();
        }

        public Task<Event[]> GetEventArgs(bool includeGigs = false)
        {
            throw new NotImplementedException();
        }

        public Task<Event[]> GetEventsByDate(DateTime date, bool includeGigs = false)
        {
            throw new NotImplementedException();
        }

        public Task<Gig> GetGigByEvent(int eventId, bool includeComedians = false)
        {
            throw new NotImplementedException();
        }

        public Task<Gig[]> GetGigsByEvent(int eventId, bool includeComedians = false)
        {
            throw new NotImplementedException();
        }

        public Task<Gig[]> GetGigsByVenue(int venueid, bool includeComedians = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
