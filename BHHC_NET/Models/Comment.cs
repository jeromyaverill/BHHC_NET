using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHHC_NET.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public string Text { get; set; }
    }
}