using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3WebAPI.Data;
using Assignment3WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3WebAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private IAdultService adultService;
        public AdultsController(IAdultService adultService)
        {
            this.adultService = adultService;
        }

        /// <summary>
        /// Gets adults
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults([FromQuery] string name, [FromQuery] int? age, [FromQuery] int? id)
        {
            try
            {
                IList<Adult> adults = await adultService.GetAdultAsync(name, age, id);
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Creates a new Adult.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Adult
        ///     {
        ///         "JobTitle": "Database Manager",
        ///         "Id": 0,
        ///         "FirstName": "Yeshua",
        ///         "LastName": "Magana",
        ///         "EyeColor": "Blue",
        ///         "HairColor": "Grey",
        ///         "Age": 44,
        ///         "Weight": 61.4,
        ///         "Height": 166,
        ///         "Sex": "M"
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created adult</response>
        /// <response code="400">If the adult is null</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Adult added = await adultService.AddAdultAsync(adult);
                return Created($"/{added.Id}", added); // return newly added to-do, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Deletes a specific Adult
        /// </summary>
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id)
        {
            try
            {
                await adultService.RemoveAdultAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Updates a specific Adult
        /// </summary>
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult adult)
        {
            try
            {
                Adult updatedAdult = await adultService.UpdateAdultAsync(adult);
                return Ok(updatedAdult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }




    }
}
