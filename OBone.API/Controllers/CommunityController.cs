using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using OBone.Application;
using OBone.Core.Models;

namespace OBone.API.Controllers
{
    [RoutePrefix("api/Community")]
    public class CommunityController : ApiController
    {
        private readonly ICommunityContract _communityContract;
        public CommunityController(ICommunityContract communityContract)
        {
            _communityContract = communityContract;
        }

        [HttpGet]
        [Route("Query/All")]
        public IQueryable<Community> Get()
        {
            return _communityContract.Communities;
        }
    }
}
