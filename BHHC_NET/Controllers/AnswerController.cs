using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHHC_NET.Models;
using BHHC_NET.ViewModels;

namespace BHHC_NET.Controllers
{
    public class AnswerController : Controller
    {
        private ApplicationDbContext _context;

        public AnswerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Answers
        public ActionResult GetCandAnswers( int Id )
        {
            var candAnswers = _context.Answer.Where(x => x.CandidateId == Id);
            return View(candAnswers);
        }

        public ActionResult AddCandAnswers()
        {
            int custId = 1;
            int qTypeId = 5;
            var cand = _context.Candidate.Single(x => x.Id == custId);
            var ques = _context.Question.Where(x => x.QuestionTypeId == qTypeId).ToList();
            var answerViewModel = new AnswerViewModel()
            {
                Candidate = cand,
                Questions = ques
            };
            return View(answerViewModel);
        }

        [HttpPost]
        public ActionResult Save(Answer answer)
        {
            _context.Answer.Add(answer);

            _context.SaveChanges();

            return RedirectToAction("GetCandAnswers", "Answer");
        }
    }
}