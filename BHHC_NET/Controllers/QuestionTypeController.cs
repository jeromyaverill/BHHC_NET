using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHHC_NET.Models;

namespace BHHC_NET.Controllers
{
    public class QuestionTypeController : Controller
    {
        private ApplicationDbContext _context;

        public QuestionTypeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult GetAll()
        {
            var questionTypes = _context.QuestionType.ToList();

            return View(questionTypes);
        }

        public ActionResult QuestionTypeForm()
        {
            return View("QuestionTypeForm");
        }

        public ActionResult Edit( int id)
        {
            var dbRecord = _context.QuestionType.Single(x => x.Id == id);
            return View("QuestionTypeForm", dbRecord);
        }

        public ActionResult Delete(int id)
        {
            var dbRecord = _context.QuestionType.Single(x => x.Id == id);
            _context.QuestionType.Remove(dbRecord);
            _context.SaveChanges();

            return RedirectToAction("GetAll", "QuestionType");
        }

        [HttpPost]
        public ActionResult Save( QuestionType questionType )
        {

            if (questionType.Id == 0)
            {
                _context.QuestionType.Add(questionType);

            }
            else
            {
                var dbRecord = _context.QuestionType.Single(x => x.Id == questionType.Id);
                dbRecord.Text = questionType.Text;

            }

            _context.SaveChanges();

            return RedirectToAction("GetAll", "QuestionType");
        }
    }
}