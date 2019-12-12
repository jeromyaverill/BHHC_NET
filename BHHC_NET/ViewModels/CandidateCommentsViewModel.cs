using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHHC_NET.Models;

namespace BHHC_NET.ViewModels
{
    public class CandidateCommentsViewModel
    {
        public Candidate Candidate { get; set; }
        public List<Comment> Comments { get; set; }
    }
}