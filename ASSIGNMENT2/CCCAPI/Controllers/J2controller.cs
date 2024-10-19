using Microsoft.AspNetCore.Mvc;

namespace CCCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        /// <summary>
        /// Calculates the total spiciness of the chili based on the peppers added.
        /// </summary>
        /// <param name="ingredients">A comma-separated list of pepper names.</param>
        /// <returns>Total spiciness of the chili.</returns>
        /// <example>GET /api/ChiliPeppers?ingredients=Poblano,Cayenne,Thai,Poblano</example>
        [HttpGet(template: "ChilliPeppers")]
        public int GetTotalSpiciness(string ingredients)
        {
            // Split the input string by commas
            int Poblano = 1500;
            int Mirasol = 6000;
            int Serrano = 15500;
            int Cayenne = 40000;
            int Thai = 75000;
            int Habanero = 125000;

            int totalSpiciness = 0;
            string[] peppers = ingredients.Split(',');

            // Loop through each pepper and calculate the SHU
            foreach (var npepper in peppers)
            {

                int shuValue = 0;
                string pepper = npepper.Trim();
                // Determine SHU value using if-else statements
                if (pepper == "Poblano")
                {
                    shuValue = Poblano;
                }
                else if (pepper == "Mirasol")
                {
                    shuValue = Mirasol;
                }
                else if (pepper == "Serrano")
                {
                    shuValue = Serrano;
                }
                else if (pepper == "Cayenne")
                {
                    shuValue = Cayenne;
                }
                else if (pepper == "Thai")
                {
                    shuValue = Thai;
                }
                else if (pepper == "Habanero")
                {
                    shuValue = Habanero;
                }
                else
                {
                    // Handle unknown pepper names (optional)
                    shuValue = 0; // Unknown pepper adds 0 to total spiciness
                }

                // Add the SHU value to the total spiciness
                totalSpiciness += shuValue;
            }

            // Return the total spiciness as the result
            return totalSpiciness;
        }
        [HttpGet(template: "FergusonBall")]
        public string GetStarRating(string TeamData)
        {
            /// <summary>
            /// Calculates whether a team is a star rating or not
            /// </summary>
            /// <remarks> Take 3 inputs in one line, the [0]would be number of players, every odd index would the score of the player, and even index would be the foul of the player. All data must be entered in the same array
            /// <param name="NewData">A comma-separated list of no of players,score and fouls.</param>
            /// <returns>Star Rating of team.</returns>
            /// <example>/api/J2/FergusonBall?TeamData=3,12,4,10,2,10,1'</example>

            int score;
            int foul;
            int StarRating = 0;
            string[] NewData = TeamData.Split(',');
            if (Int32.Parse(NewData[0]) != (NewData.Length - 1) / 2)
            {

                return "Invalid Input" ;

            }
            else
            {
                for (int i = 1; i < NewData.Length; i = i + 2)
                {
                    score = Int32.Parse(NewData[i]) * 5;
                    foul = Int32.Parse(NewData[i + 1]) * 3;
                    if (score - foul > 40)
                    {
                        StarRating = StarRating + 1;
                    }
                }
                if (Int32.Parse(NewData[0]) == StarRating)
                {
                    return StarRating.ToString() + "+";
                }
                else
                {
                    return StarRating.ToString();
                }
            }
        }
    }
}
