using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BHHC_NET.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }
        public int QuestionTypeId { get; set; }
    }
}