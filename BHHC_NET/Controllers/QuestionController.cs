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
    public class QuestionController : Controller
    {
        private ApplicationDbContext _context;

        public QuestionController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Question
        public ActionResult GetAll()
        {
            var questions = _context.Question.Include(x => x.QuestionType).ToList();

            return View(questions);
        }



        public ActionResult QuestionForm()
        {
            var questionTypes = _context.QuestionType.ToList();
            var viewModel = new QuestionViewModel()
            {
                QuestionTypes = questionTypes
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var dbRecord = _context.Question.Single(x => x.Id == id);
            var questionTypes = _context.QuestionType.ToList();
            var viewModel = new QuestionViewModel()
            {
                Question = dbRecord,
                QuestionTypes = questionTypes
            };
            return View("QuestionForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var dbRecord = _context.Question.Single(x => x.Id == id);
            _context.Question.Remove(dbRecord);
            _context.SaveChanges();

            return RedirectToAction("GetAll", "Question");
        }

        [HttpPost]
        public ActionResult Save(Question question)
        {

            if (question.Id == 0)
            {
                _context.Question.Add(question);

            }
            else
            {
                var dbRecord = _context.Question.Single(x => x.Id == question.Id);
                dbRecord.Text = question.Text;
                dbRecord.QuestionTypeId = question.QuestionTypeId;

            }

            _context.SaveChanges();

            return RedirectToAction("GetAll", "Question");
        }
    }
}