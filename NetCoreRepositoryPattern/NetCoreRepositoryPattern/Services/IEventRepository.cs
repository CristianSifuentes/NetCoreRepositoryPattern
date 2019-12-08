using repositorypattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreRepositoryPattern.Services
{
    public interface IEventRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> Save();

        //events;
        Task<Event[]> GetEventArgs(bool includeGigs = false);
        Task<Event> GetEvent(int eventId, bool includeGigs = false);
        Task<Event[]> GetEventsByDate(DateTime date, bool includeGigs = false);

        //gigs
        Task<Gig[]> GetGigsByEvent(int eventId, bool includeComedians = false);
        Task<Gig> GetGig(int gigid, bool includeComedians = false);
        Task<Gig[]> GetGigsByVenue(int venueid, bool includeComedians = false);

        //comedians
        Task<Comedian[]> GetComedians();
        Task<Comedian[]> GetComediansByEvent(int eventId);
        Task<Comedian> GetComedian(int comedianId);

    }
}
