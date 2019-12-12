using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHHC_NET.Models;

namespace BHHC_NET.ViewModels
{
    public class QuestionViewModel
    {
        public List<QuestionType> QuestionTypes { get; set; }
        public Question Question { get; set; }
    }
}