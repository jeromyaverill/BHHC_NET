using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using AutoMapper;
using BHHC_NET.Dtos;
using BHHC_NET.Models;

namespace BHHC_NET.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Candidate, CandidateDto>();
            Mapper.CreateMap<CandidateDto, Candidate>();
        }
    }
}