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
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.V1RC03.Models;

namespace IO.Swagger.V1RC03.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public interface IAssetAdministrationShellApiController
    { 
        /// <summary>
        /// Deletes the submodel reference from the Asset Administration Shell
        /// </summary>
        
        /// <param name="submodelIdentifier">The Submodel’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <response code="204">Submodel reference deleted successfully</response>
        /// <response code="404">Not Found</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult DeleteSubmodelReferenceById([FromRoute][Required]string submodelIdentifier);

        /// <summary>
        /// Returns all submodel references
        /// </summary>
        
        /// <response code="200">Requested submodel references</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult GetAllSubmodelReferences();

        /// <summary>
        /// Returns the Asset Administration Shell
        /// </summary>
        
        /// <param name="content">Determines the request or response kind of the resource</param>
        /// <response code="200">Requested Asset Administration Shell</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult GetAssetAdministrationShell([FromQuery]string content);

        /// <summary>
        /// Returns the Asset Information
        /// </summary>
        
        /// <response code="200">Requested Asset Information</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult GetAssetInformation();

        /// <summary>
        /// Creates a submodel reference at the Asset Administration Shell
        /// </summary>
        
        /// <param name="body">Reference to the Submodel</param>
        /// <response code="201">Submodel reference created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult PostSubmodelReference([FromBody]Reference body);

        /// <summary>
        /// Updates the Asset Administration Shell
        /// </summary>
        
        /// <param name="body">Asset Administration Shell object</param>
        /// <param name="content">Determines the request or response kind of the resource</param>
        /// <response code="204">Asset Administration Shell updated successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult PutAssetAdministrationShell([FromBody]AssetAdministrationShell body, [FromQuery]string content);

        /// <summary>
        /// Updates the Asset Information
        /// </summary>
        
        /// <param name="body">Asset Information object</param>
        /// <response code="204">Asset Information updated successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult PutAssetInformation([FromBody]AssetInformation body);
    }
}