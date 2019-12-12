using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Configuration;
using BHHC_NET.Models;

namespace BHHC_NET.Controllers.API
{
    public class CandidatesController : ApiController
    {
        private ApplicationDbContext _context;

        public CandidatesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return _context.Candidate.ToList();
        }

        public Candidate GetCandidate( int id)
        {
            var candDbRecord =  _context.Candidate.SingleOrDefault(x=>x.Id == id);
            if (candDbRecord == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return candDbRecord;
        }

        [HttpPost]
        public Candidate CreateCandidate(Candidate candidate)
        {
            _context.Candidate.Add(candidate);
            _context.SaveChanges();

            return candidate;
        }

        [HttpPut]
        public void UpdateCandidate(int id, Candidate candidate)
        {
            var candDbRecord = _context.Candidate.SingleOrDefault(x => x.Id == id);
            if (candDbRecord == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }

            candDbRecord.FirstName = candidate.FirstName;
            candDbRecord.LastName = candidate.LastName;
            _context.SaveChanges();

        }

        [HttpDelete]
        public void UpdateCandidate(int id)
        {
            var candDbRecord = _context.Candidate.SingleOrDefault(x => x.Id == id);
            if (candDbRecord == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            _context.Candidate.Remove(candDbRecord);
            _context.SaveChanges();
        }
    }
}
