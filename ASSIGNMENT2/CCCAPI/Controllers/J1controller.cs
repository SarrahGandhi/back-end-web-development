using Microsoft.AspNetCore.Mvc;


namespace CCCAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class J1controller : ControllerBase
    {
        /// <summary>
        /// Calculates the final score for the Deliv-e-droid game based on the number of deliveries and collisions.
        /// </summary>
        /// <param name="deliveries">The number of packages delivered.</param>
        /// <param name="collisions">The number of collisions with obstacles.</param>
        /// <returns>The final score as an integer.</returns>
        /// <example>
        /// POST: api/delive
        /// Body: {"deliveries": 5, "collisions": 2}
        /// Response: 730
        /// </example>
        [HttpPost(template: "Delivedroid")]
        public int CalculateScore([FromForm] int Deliveries, [FromForm] int Collisions)
        {


            // Gain 50 points for each package delivered
            int pointsForDeliveries = Deliveries * 50;

            // Lose 10 points for each collision
            int pointsLostForCollisions = Collisions * 10;

            // Calculate the initial final score
            int finalScore = pointsForDeliveries - pointsLostForCollisions;

            // Add bonus if deliveries are greater than collisions
            if (Deliveries > Collisions)
            {
                finalScore += 500; // Bonus points
            }

            return finalScore;
        }
        /// <summary>
        /// Calculates the number of leftover cupcakes after distributing one cupcake to each student.
        /// </summary>
        /// <param name="regularBoxes">The number of regular boxes (each containing 8 cupcakes).</param>
        /// <param name="smallBoxes">The number of small boxes (each containing 3 cupcakes).</param>
        /// <returns>The number of leftover cupcakes.</returns>
        /// <example>GET: /api/Cupcake?regularBoxes=2&smallBoxes=5 will return 3.</example>
        [HttpGet("Cupcake")]
        public int GetLeftoverCupcakes([FromQuery] int regularBoxes, [FromQuery] int smallBoxes)
        {
            int totalCupcakes = (regularBoxes * 8) + (smallBoxes * 3);
            int leftoverCupcakes = totalCupcakes % 28;

            return leftoverCupcakes;
        }
    }
}





