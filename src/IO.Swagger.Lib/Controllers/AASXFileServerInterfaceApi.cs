/*
 * DotAAS Part 2 | HTTP/REST | Entire Interface Collection
 *
 * The entire interface collection as part of Details of the Asset Administration Shell Part 2
 *
 * OpenAPI spec version: Final-Draft
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO;
using System.Linq;
using AasxRestServerLibrary;
using AdminShellNS;
using IO.Swagger.Attributes;
using IO.Swagger.Models;
using IO.Swagger.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class AASXFileServerInterfaceApiController : ControllerBase
    {
        private IAASXFileServerInterfaceService _fileService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileService">Helper to deal with API calls</param>
        public AASXFileServerInterfaceApiController(IAASXFileServerInterfaceService fileService)
        {
            _fileService = fileService;
        }
        /// <summary>
        /// Deletes a specific AASX package from the server
        /// </summary>
        /// <param name="packageId">The Package Id (BASE64-URL-encoded)</param>
        /// <response code="204">Deleted successfully</response>
        [HttpDelete]
        [Route("/packages/{packageId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteAASXByPackageId")]
        public virtual IActionResult DeleteAASXByPackageId([FromRoute][Required] string packageId)
        {
            try
            {
                var found = _fileService.GetAASXByPackageId(Base64UrlEncoder.Decode(packageId), out _, out _, out _);
                if (!found)
                {
                    return NotFound($"AAXS with requested packageId not found.");
                }
                bool deleted = _fileService.DeleteAASXByPackageId(Base64UrlEncoder.Decode(packageId));
                if (deleted)
                {
                    return NoContent();
                }

                return StatusCode(500, $"Could not delete AASX Package");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Returns a specific AASX package from the server
        /// </summary>
        /// <param name="packageId">The package Id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested AASX package</response>
        [HttpGet]
        [Route("/packages/{packageId}")]
        [ValidateModelState]
        [SwaggerOperation("GetAASXByPackageId")]
        [SwaggerResponse(statusCode: 200, type: typeof(byte[]), description: "Requested AASX package")]
        public virtual IActionResult GetAASXByPackageId([FromRoute][Required] string packageId)
        {
            try
            {
                var found = _fileService.GetAASXByPackageId(Base64UrlEncoder.Decode(packageId), out byte[] content, out string fileName, out long fileSize);
                if (!found)
                {
                    return NotFound($"AAXS with requested packageId not found.");
                }
                //TODO: whether to use "content-disposition"
                HttpContext.Response.Headers.Add("X-FileName", fileName);
                HttpContext.Response.ContentLength = fileSize;
                HttpContext.Response.Body.WriteAsync(content);
                return new EmptyResult();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// Returns a list of available AASX packages at the server
        /// </summary>
        /// <param name="aasId">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested package list</response>
        [HttpGet]
        [Route("/packages")]
        [ValidateModelState]
        [SwaggerOperation("GetAllAASXPackageIds")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<PackageDescription>), description: "Requested package list")]
        public virtual IActionResult GetAllAASXPackageIds([FromQuery] string aasId)
        {
            try
            {
                var packages = _fileService.GetAllAASXPackageIds();

                //Filter w.r.t. aasId
                if (!string.IsNullOrEmpty(aasId))
                {
                    var decodedAASId = Base64UrlEncoder.Decode(aasId);
                    packages = packages.Where(x => x.AasIds.Contains(decodedAASId)).ToList();
                }

                return new ObjectResult(packages);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Returns a an AssetAdministrationShell based on aasId and packageId combination
        /// </summary>
        /// <param name="packageId">Package Id (BASE64-URL-encoded)</param>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested package list</response>
        [HttpGet]
        [Route("/packages/{packageId}/shells/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("GetAssetAdministrationShellAndAssetByPackageId")]
        [SwaggerResponse(statusCode: 200, type: typeof(AdminShell.AdministrationShell), description: "Requested package list")]
        public virtual IActionResult GetAssetAdministrationShellAndAssetByPackageId([FromRoute][Required] string packageId, [FromRoute][Required] string aasIdentifier)
        {
            try
            {
                var aas = _fileService.GetAssetAdministrationShellAndAssetByPackageId(Base64UrlEncoder.Decode(packageId), Base64UrlEncoder.Decode(aasIdentifier));

                if (aas == null)
                {
                    return NotFound();
                }

                return new ObjectResult(aas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Updates the AASX package at the server
        /// </summary>
        /// <param name="packageId">Package ID from the package list (BASE64-URL-encoded)</param>
        /// <param name="fileName">AASX Package Name</param>
        /// <param name="file">AASX Package</param>
        /// <param name="aasIds">Included AAS Identifiers</param>
        /// <returns></returns>
        [HttpPut]
        [Route("/packages/{packageId}")]
        [ValidateModelState]
        [SwaggerOperation("PutAASXPackageById")]
        public virtual IActionResult PutAASXPackageById([FromRoute][Required] string packageId, [FromForm] string fileName, [FromForm] IFormFile file, [FromForm] string aasIds)
        {
            try
            {
                var stream = new MemoryStream();
                file.CopyTo(stream);

                bool updated = _fileService.PutAASXPackageById(Base64UrlEncoder.Decode(packageId), stream.ToArray(), fileName);
                if (updated)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Creates an AASX package at the server
        /// </summary>
        /// <param name="fileName">Filename of the AASX package</param>
        /// <param name="aasIds">Included AAS Ids</param>
        /// <param name="file">AASX PAckage</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/packages")]
        [ValidateModelState]
        [SwaggerOperation("PostAASXPackage")]
        public virtual IActionResult PostAASXPackage([FromForm] string aasIds, [FromForm] IFormFile file, [FromForm] string fileName)
        {
            //TODO: aasIds
            try
            {
                var stream = new MemoryStream();
                file.CopyTo(stream);

                bool created = _fileService.PostAASXPackage(stream.ToArray(), fileName, out int packageIndex);
                if (created)
                {
                    AasxServer.Program.signalNewData(2);
                    return Created($"Requested Package updated successfully.", packageIndex);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
