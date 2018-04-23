using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sender.API.Models;

namespace Sender.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        

        [HttpPost("visitor")]
        public Visitor Create([FromBody]Visitor v)
        {
            //  Debug.WriteLine(v.Firstname);

            string xmlVisitor = new Sender().CreateVisitorXML(v);

            // Debug.WriteLine(xmlVisitor);

            new Sender().SendMessage(xmlVisitor);

            return v;
        }
    }
}
