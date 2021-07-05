using domain.rarecarat.Business;
using domain.rarecarat.Contracts;
using model.rarecarat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace api.rarecarat.Controllers
{
    /// <summary>
    /// Diamond Controller.
    /// </summary>
    [Route( "diamonds" )]
    [ApiController]
    public class DiamondController : ControllerBase
    {
        private IDiamondBusiness _diamondBusiness;
        private ILogger<DiamondController> _logger;
        public DiamondController( IDiamondBusiness DiamondBusiness, ILogger<DiamondController> logger )
        {
            _diamondBusiness = DiamondBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get Diamond data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<DiamondListItemModel>>> Get()
        {
            _logger.LogInformation( "Get Called" );
            var response = await _diamondBusiness.GetAllAsync();
            if ( !response.Error )
                return Ok( response.Result );
            else
                return BadRequest( response.Message );
        }

        /// <summary>
        /// Get Diamond Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet( "{id}" )]
        public async Task<ActionResult<DiamondDetailsModel>> Get( int id )
        {
            _logger.LogInformation( "Get By Id Called" );
            var response = await _diamondBusiness.GetDetailsModelAsync( id );
            if ( !response.Error )
            {
                if ( response.Result == null )
                    return NotFound();
                else
                    return Ok( response.Result );
            }
            else
                return BadRequest( response.Message );
        }

        /// <summary>
        /// Saving new Diamond
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<int>> Post( [FromBody] DiamondCreateModel value )
        {
            _logger.LogInformation( "Post Called" );
            var response = await _diamondBusiness.CreateAsync( value );
            if ( !response.Error )
                return Ok( (int)response.Result );
            else
                return BadRequest( response.Message );
        }

        /// <summary>
        /// Updating Diamond 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut( "{id}" )]
        public async Task<ActionResult> Put( int id, [FromBody] DiamondUpdateModel value )
        {
            _logger.LogInformation( "Put Called" );
            var responseDetail = await _diamondBusiness.GetDetailsModelAsync( id );
            if ( !responseDetail.Error )
            {
                if ( responseDetail.Result == null )
                    return NotFound();
                else
                {
                    value.Id = id;
                    var responseUpdate = await _diamondBusiness.UpdateAsync( value );
                    if ( !responseUpdate.Error )
                        return Ok();
                    else
                        return BadRequest( responseUpdate.Message );
                }
            }
            else
                return BadRequest( responseDetail.Message );
        }

        /// <summary>
        /// Deleting Diamond
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete( "{id}" )]
        public async Task<ActionResult> Delete( int id )
        {
            _logger.LogInformation( "Delete Called" );
            var response = await _diamondBusiness.GetDetailsModelAsync( id );
            if ( !response.Error )
            {
                if ( response.Result == null )
                    return NotFound();
                else
                {
                    var responseDelete = await _diamondBusiness.DeleteAsync( id );
                    if ( !responseDelete.Error )
                        return Ok();
                    else
                        return BadRequest( responseDelete.Message );
                }
            }
            else
                return BadRequest( response.Message );
        }
    }
}
