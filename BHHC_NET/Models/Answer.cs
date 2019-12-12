using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace BHHC_NET.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public string CandidateAnswer { get; set; }
    }
}