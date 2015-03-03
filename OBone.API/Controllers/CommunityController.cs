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
        public async System.Threading.Tasks.Task<Community> Get()
        {
            Community c = new Community();
            c.CommunityName = "1223321";
            await _communityContract.AddCommunityAsync(c);
            return await _communityContract.GetByKeyAsync(1);
        }
    

    }
}
