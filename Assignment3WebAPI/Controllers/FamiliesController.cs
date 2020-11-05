using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3WebAPI.Data;
using Assignment3WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3WebAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController :ControllerBase
    {

        private IFamilyService familyService;
        public FamiliesController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        /// <summary>
        /// Gets Families
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamilies()
        {
            try
            {
                IList<Family> families = await familyService.GetFamilytAsync();
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        /// <summary>
        /// Deletes a specific Family
        /// </summary>
        [HttpDelete]
        [Route("{houseNumber:int}/{streetName:required}")]
        public async Task<ActionResult> DeleteFamily([FromRoute] int houseNumber, [FromRoute] string streetName)
        {
            try
            {
                await familyService.RemoveFamilyAsync(houseNumber, streetName);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Updates a specific Family
        /// </summary>
        [HttpPatch]
        [Route("{houseNumber:int}")]
        public async Task<ActionResult<Family>> UpdateFamily([FromBody] Family family)
        {
            try
            {
                Family updatedFamily = await familyService.UpdateFamilyAsync(family);
                return Ok(updatedFamily);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
