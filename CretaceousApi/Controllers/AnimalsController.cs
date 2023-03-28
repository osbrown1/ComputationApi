using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CretaceousApi.Models;

namespace StringModificationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringModificationController : ControllerBase
    {
        [HttpGet("snoop")]
        public ActionResult<string> SnoopifyString(string inputString)
        {
        string[] words = inputString.Split(' ');
        string snoopified = "";
        
        // Replace each word with its first letter + "izzle"
        foreach (string word in words) {
            snoopified += Char.ToUpper(word[0]) + "izzle ";
        }
        return snoopified;
      }


      [HttpGet("shatner")]
      public ActionResult<string> ShatnerizeString(string inputString)
      {
        string[] words = inputString.Split(' ');
        string shatnerized = "";

        foreach (string word in words) {
          shatnerized += Char.ToUpper(word[0]) + ". ";
        }
        return shatnerized;
      }
    }
}
