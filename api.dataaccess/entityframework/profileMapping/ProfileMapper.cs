using api.common.model;
using api.dataaccess.entityframework.model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.dataaccess.entityframework.profileMapping
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<TblUser, User>().ReverseMap();
        }
    }
}
