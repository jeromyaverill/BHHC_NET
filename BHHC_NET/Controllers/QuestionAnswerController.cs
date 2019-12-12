using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHHC_NET.Models;
using BHHC_NET.ViewModels;

namespace BHHC_NET.Controllers
{
    public class QuestionAnswerController : Controller
    {
        private ApplicationDbContext _context;

        public QuestionAnswerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult GetQuestionAnswers()
        {
            var qas = _context.QuestionAnswer.ToList();

            return View(qas);
        }

        public ActionResult QuestionAnswerForm()
        {
            return View("QuestionAnswerForm");
        }

        public ActionResult Edit(int id)
        {
            var dbRecord = _context.QuestionAnswer.Single(x => x.Id == id);

            return View("QuestionAnswerForm", dbRecord);
        }

        public ActionResult Delete(int id)
        {
            var dbRecord = _context.QuestionAnswer.Single(x => x.Id == id);
            _context.QuestionAnswer.Remove(dbRecord);
            _context.SaveChanges();

            return RedirectToAction("GetQuestionAnswers", "QuestionAnswer");
        }

        [HttpPost]
        public ActionResult Save(QuestionAnswer questionAnswer)
        {
            if (questionAnswer.Id == 0)
            {
                _context.QuestionAnswer.Add(questionAnswer);

            }
            else
            {
                var dbRecord = _context.QuestionAnswer.Single(x => x.Id == questionAnswer.Id);
                dbRecord.Question = questionAnswer.Question;
                dbRecord.Answer = questionAnswer.Answer;

            }

            _context.SaveChanges();

            return RedirectToAction("GetQuestionAnswers", "QuestionAnswer");
        }

    }
}