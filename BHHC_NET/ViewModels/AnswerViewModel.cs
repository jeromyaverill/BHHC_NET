using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHHC_NET.Models;

namespace BHHC_NET.ViewModels
{
    public class AnswerViewModel
    {
        public Candidate Candidate;
        public List<Question> Questions;
        public QuestionType QuestionType;
        public Answer Answer;
    }
}