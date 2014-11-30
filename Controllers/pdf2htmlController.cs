using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMvc.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class pdf2htmlController : Controller
    {
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var body = Request.Body;
            var fileName = String.Format("/src/Convert_{0}", Guid.NewGuid());

            using (FileStream fs = System.IO.File.Create(fileName + ".pdf"))
            {
                await body.CopyToAsync(fs);
                fs.Close();
            }

            var p = new Process();
            p.StartInfo.FileName = "pdf2htmlEX";
            p.StartInfo.Arguments = fileName + ".pdf";
            p.Start();
            p.WaitForExit();

            return Content(System.IO.File.ReadAllText(fileName + ".html"));
        }
    }
}
