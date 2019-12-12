using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using BHHC_NET.Models;
using BHHC_NET.ViewModels;

namespace BHHC_NET.Controllers
{
    public class CandidateController : Controller
    {
        private ApplicationDbContext _context;

        public CandidateController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        public ActionResult GetCandidates()
        {
            var candidates = _context.Candidate.ToList();

            return View(candidates);
        }

        public ActionResult CandidateForm()
        {
            return View("CandidateForm");
        }

        public ActionResult Edit(int id)
        {
            var localCandidate = _context.Candidate.Single(x => x.Id == id);

            return View("CandidateForm", localCandidate);
        }

        public ActionResult Details( int id)
        {
            var localCandidate = _context.Candidate.Single(x => x.Id == id);

            return View( "Details", localCandidate);
        }

        public ActionResult Delete(int id)
        {
            var candidate = _context.Candidate.Find(id);
            _context.Candidate.Remove(candidate);
            _context.SaveChanges();

            return RedirectToAction("GetCandidates", "Candidate");
        }

        [HttpPost]
        public ActionResult Save(Candidate candidate)
        {
            if (candidate.Id == 0)
            {
                _context.Candidate.Add(candidate);

            }
            else
            {
                var localCandidate = _context.Candidate.Single(x => x.Id == candidate.Id);
                localCandidate.FirstName = candidate.FirstName;
                localCandidate.LastName = candidate.LastName;

            }

            _context.SaveChanges();

            return RedirectToAction("GetCandidates", "Candidate");
        }

    }
}