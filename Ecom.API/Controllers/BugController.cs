using AutoMapper;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    public class BugController : BaseController
    {
        public BugController(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
        {
        }
        //[HttpGet("Not-Found")]
        //public async Task<IActionResult> GetNotFound()
        //{

        //}
    }
}
