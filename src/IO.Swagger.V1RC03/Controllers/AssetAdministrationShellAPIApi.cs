/*
 * DotAAS Part 2 | HTTP/REST | Entire API Collection
 *
 * The entire API collection as part of Details of the Asset Administration Shell Part 2
 *
 * OpenAPI spec version: V1.0RC03
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.V1RC03.Attributes;

using Microsoft.AspNetCore.Authorization;
using IO.Swagger.V1RC03.Models;

namespace IO.Swagger.V1RC03.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class AssetAdministrationShellAPIApiController : ControllerBase, IAssetAdministrationShellAPIApiController
    { 
        /// <summary>
        /// Deletes the submodel reference from the Asset Administration Shell
        /// </summary>
        /// <param name="submodelIdentifier">The Submodel’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <response code="204">Submodel reference deleted successfully</response>
        /// <response code="404">Not Found</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpDelete]
        [Route("/aas/submodels/{submodelIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteSubmodelReferenceById")]
        [SwaggerResponse(statusCode: 404, type: typeof(Result), description: "Not Found")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult DeleteSubmodelReferenceById([FromRoute][Required]byte[] submodelIdentifier)
        { 
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Result));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));

            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all submodel references
        /// </summary>
        /// <response code="200">Requested submodel references</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpGet]
        [Route("/aas/submodels")]
        [ValidateModelState]
        [SwaggerOperation("GetAllSubmodelReferences")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Reference>), description: "Requested submodel references")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult GetAllSubmodelReferences()
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Reference>));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));
            string exampleJson = null;
            exampleJson = "[ \"\", \"\" ]";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<List<Reference>>(exampleJson)
                        : default(List<Reference>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Returns the Asset Administration Shell
        /// </summary>
        /// <param name="content">Determines the request or response kind of the resource</param>
        /// <response code="200">Requested Asset Administration Shell</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpGet]
        [Route("/aas")]
        [ValidateModelState]
        [SwaggerOperation("GetAssetAdministrationShell")]
        [SwaggerResponse(statusCode: 200, type: typeof(AssetAdministrationShell), description: "Requested Asset Administration Shell")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult GetAssetAdministrationShell([FromQuery]string content)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(AssetAdministrationShell));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));
            string exampleJson = null;
            exampleJson = "\"\"";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<AssetAdministrationShell>(exampleJson)
                        : default(AssetAdministrationShell);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Returns the Asset Information
        /// </summary>
        /// <response code="200">Requested Asset Information</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpGet]
        [Route("/aas/asset-information")]
        [ValidateModelState]
        [SwaggerOperation("GetAssetInformation")]
        [SwaggerResponse(statusCode: 200, type: typeof(AssetInformation), description: "Requested Asset Information")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult GetAssetInformation()
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(AssetInformation));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));
            string exampleJson = null;
            exampleJson = "{\n  \"specificAssetId\" : \"\",\n  \"assetKind\" : \"Type\",\n  \"defaultThumbnail\" : {\n    \"path\" : \"path\",\n    \"contentType\" : \"contentType\"\n  },\n  \"globalAssetId\" : \"\"\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<AssetInformation>(exampleJson)
                        : default(AssetInformation);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Creates a submodel reference at the Asset Administration Shell
        /// </summary>
        /// <param name="body">Reference to the Submodel</param>
        /// <response code="201">Submodel reference created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpPost]
        [Route("/aas/submodels")]
        [ValidateModelState]
        [SwaggerOperation("PostSubmodelReference")]
        [SwaggerResponse(statusCode: 201, type: typeof(Reference), description: "Submodel reference created successfully")]
        [SwaggerResponse(statusCode: 400, type: typeof(Result), description: "Bad Request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult PostSubmodelReference([FromBody]Reference body)
        { 
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(Reference));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Result));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));
            string exampleJson = null;
            exampleJson = "\"\"";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<Reference>(exampleJson)
                        : default(Reference);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Updates the Asset Administration Shell
        /// </summary>
        /// <param name="body">Asset Administration Shell object</param>
        /// <param name="content">Determines the request or response kind of the resource</param>
        /// <response code="204">Asset Administration Shell updated successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpPut]
        [Route("/aas")]
        [ValidateModelState]
        [SwaggerOperation("PutAssetAdministrationShell")]
        [SwaggerResponse(statusCode: 400, type: typeof(Result), description: "Bad Request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult PutAssetAdministrationShell([FromBody]AssetAdministrationShell body, [FromQuery]string content)
        { 
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Result));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));

            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the Asset Information
        /// </summary>
        /// <param name="body">Asset Information object</param>
        /// <response code="204">Asset Information updated successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpPut]
        [Route("/aas/asset-information")]
        [ValidateModelState]
        [SwaggerOperation("PutAssetInformation")]
        [SwaggerResponse(statusCode: 400, type: typeof(Result), description: "Bad Request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult PutAssetInformation([FromBody]AssetInformation body)
        { 
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Result));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));

            throw new NotImplementedException();
        }
    }
}
