using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BHHC_NET.Models;

namespace BHHC_NET.Controllers.API
{
    public class QuestionAnswersController : ApiController
    {
        private ApplicationDbContext _context;

        public QuestionAnswersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [System.Web.Http.HttpGet]
        public IEnumerable<QuestionAnswer> GetQuestionAnswers()
        {
            return _context.QuestionAnswer.ToList();
        }

        [System.Web.Http.HttpPost]
        public void AddQuestionAnswer()
        {
            throw new HttpResponseException(HttpStatusCode.Forbidden);
            //_context.QuestionAnswer.Add(qa);
            //_context.SaveChanges();

            //return null;
        }
    }
}
