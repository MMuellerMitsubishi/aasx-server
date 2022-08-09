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
using IO.Swagger.V1RC03.ApiModel;

namespace IO.Swagger.V1RC03.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public interface ISubmodelRegistryApiController
    { 
        /// <summary>
        /// Deletes a Submodel Descriptor, i.e. de-registers a submodel
        /// </summary>
        
        /// <param name="submodelIdentifier">The Submodel’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <response code="204">Submodel Descriptor deleted successfully</response>
        /// <response code="404">Not Found</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult DeleteSubmodelDescriptorById([FromRoute][Required]string submodelIdentifier);

        /// <summary>
        /// Returns all Submodel Descriptors
        /// </summary>
        
        /// <response code="200">Requested Submodel Descriptors</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult GetAllSubmodelDescriptors();

        /// <summary>
        /// Returns a specific Submodel Descriptor
        /// </summary>
        
        /// <param name="submodelIdentifier">The Submodel’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <response code="200">Requested Submodel Descriptor</response>
        /// <response code="404">Not Found</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult GetSubmodelDescriptorById([FromRoute][Required]string submodelIdentifier);

        /// <summary>
        /// Creates a new Submodel Descriptor, i.e. registers a submodel
        /// </summary>
        
        /// <param name="body">Submodel Descriptor object</param>
        /// <response code="201">Submodel Descriptor created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult PostSubmodelDescriptor([FromBody]SubmodelDescriptor body);

        /// <summary>
        /// Updates an existing Submodel Descriptor
        /// </summary>
        
        /// <param name="body">Submodel Descriptor object</param>
        /// <param name="submodelIdentifier">The Submodel’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <response code="204">Submodel Descriptor updated successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        IActionResult PutSubmodelDescriptorById([FromBody]SubmodelDescriptor body, [FromRoute][Required]string submodelIdentifier);
    }
}
