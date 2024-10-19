using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CCCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {

        /// <summary>
        /// Decodes a list of five-digit sequences into instructions (direction and steps).
        /// </summary>
        /// <param name="sequences">List of five-digit sequences.</param>
        /// <returns>A list of decoded directions and steps.</returns>
        /// <remarks>
        /// First two digits determine direction:
        /// - Odd sum: "left"
        /// - Even sum: "right"
        /// - Sum is zero: keep previous direction
        /// Last three digits: number of steps.
        /// Sequence "99999" stops processing.
        /// </remarks>
        /// <example>
        /// GET api/J3/code?sequences=57234&sequences=99999  ->  right 234
        /// </example>


        [HttpGet(template: "code")]
        public string code([FromQuery] List<string> sequences)
        {
            string result = "";
            string preDirection = "";

            foreach (var num in sequences)
            {
                if (num == "99999")
                {
                    break;
                }

                if (num.Length != 5)
                {
                    result += "Each instruction must be exactly five digits.\n";
                    continue;
                }

                int firstDigit = int.Parse(num.Substring(0, 1));
                int secondDigit = int.Parse(num.Substring(1, 1));
                int sum = firstDigit + secondDigit;

                string steps = num.Substring(2);
                string direction = "";

                if (sum == 0)
                {
                    direction = preDirection;
                }
                else if ((sum % 2) != 0)
                {
                    direction = "left";
                }
                else
                {
                    direction = "right";
                }

                result += $"{direction} {steps}\n";
                preDirection = direction;
            }

            return result;
        }
    }
}