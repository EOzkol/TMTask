using ElifOzkolTMTask.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ElifOzkolTMTask.Controllers
{

    public class FizzBuzzController : ApiController
    {
        private static List<Rule> rules = new List<Rule>
            {new Rule("Modulo","15","0","fizzbuzz"),
                new Rule("Modulo","5","0","buzz"),
              new Rule("Modulo","3","0","fizz")};

        /* http://localhost:55235/api/FizzBuzzController/1/20 */
        [HttpGet]
        [Route("api/FizzBuzzController/{start}/{end}")]
        public IHttpActionResult Get(string start, string end)
        {
           
            string resultStr = "";
            int startInt;
            int endInt;
            bool isNumericStart = int.TryParse(start, out startInt);
            bool isNumericEnd = int.TryParse(end, out endInt);

            if (isNumericStart == false || isNumericEnd == false)
            {
                return BadRequest("Please input values should be integer.");
            }

            if (startInt>endInt)
            {
                return BadRequest("Please last input bigger than first input.");
            }

            if (endInt >= 100000)
            {
                return BadRequest("Please input values between 1 and 10^5");
            }
            
            /* we keep stats in int array for optimized access */
            int[] stats = new int[rules.Count + 1];

            /* loop on given input array */
            for (int i = startInt; i < endInt + 1; i++)
            {
                /* none of the rules matched yet */
                bool matched = false;

                /*check every rule, if one matched skip others */
                for (int j = 0; j < rules.Count; j++)
                {
                    if (rules[j].execute(i))
                    {
                        resultStr += rules[j].Output + " ";
                        stats[j] += 1;
                        matched = true;
                        break;
                    }
                }
                /* if none of the rules matched add number itself and update stats*/
                if (!matched)
                {
                    resultStr += i + " ";
                    stats[rules.Count] += 1;
                }
            }

            FizzBuzzResultSummary resultSummary =
                new FizzBuzzResultSummary(stats[2].ToString(),
                stats[1].ToString(), stats[0].ToString(), stats[3].ToString());
            FizzBuzzResult result = new FizzBuzzResult(resultStr, resultSummary);

            return Ok(result);
        }

    }
}
