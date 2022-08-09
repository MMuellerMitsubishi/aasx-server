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
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.V1RC03.Models
{ 
        /// <summary>
        /// Gets or Sets ModelType
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ModelType
        {
            /// <summary>
            /// Enum AssetAdministrationShellEnum for AssetAdministrationShell
            /// </summary>
            [EnumMember(Value = "AssetAdministrationShell")]
            AssetAdministrationShellEnum = 0,
            /// <summary>
            /// Enum SubmodelEnum for Submodel
            /// </summary>
            [EnumMember(Value = "Submodel")]
            SubmodelEnum = 1,
            /// <summary>
            /// Enum SubmodelElementListEnum for SubmodelElementList
            /// </summary>
            [EnumMember(Value = "SubmodelElementList")]
            SubmodelElementListEnum = 2,
            /// <summary>
            /// Enum SubmodelElementCollectionEnum for SubmodelElementCollection
            /// </summary>
            [EnumMember(Value = "SubmodelElementCollection")]
            SubmodelElementCollectionEnum = 3,
            /// <summary>
            /// Enum PropertyEnum for Property
            /// </summary>
            [EnumMember(Value = "Property")]
            PropertyEnum = 4,
            /// <summary>
            /// Enum MultiLanguagePropertyEnum for MultiLanguageProperty
            /// </summary>
            [EnumMember(Value = "MultiLanguageProperty")]
            MultiLanguagePropertyEnum = 5,
            /// <summary>
            /// Enum RangeEnum for Range
            /// </summary>
            [EnumMember(Value = "Range")]
            RangeEnum = 6,
            /// <summary>
            /// Enum ReferenceElementEnum for ReferenceElement
            /// </summary>
            [EnumMember(Value = "ReferenceElement")]
            ReferenceElementEnum = 7,
            /// <summary>
            /// Enum BlobEnum for Blob
            /// </summary>
            [EnumMember(Value = "Blob")]
            BlobEnum = 8,
            /// <summary>
            /// Enum FileEnum for File
            /// </summary>
            [EnumMember(Value = "File")]
            FileEnum = 9,
            /// <summary>
            /// Enum AnnotatedRelationshipElementEnum for AnnotatedRelationshipElement
            /// </summary>
            [EnumMember(Value = "AnnotatedRelationshipElement")]
            AnnotatedRelationshipElementEnum = 10,
            /// <summary>
            /// Enum RelationshipElementEnum for RelationshipElement
            /// </summary>
            [EnumMember(Value = "RelationshipElement")]
            RelationshipElementEnum = 11,
            /// <summary>
            /// Enum EntityEnum for Entity
            /// </summary>
            [EnumMember(Value = "Entity")]
            EntityEnum = 12,
            /// <summary>
            /// Enum BasicEventElementEnum for BasicEventElement
            /// </summary>
            [EnumMember(Value = "BasicEventElement")]
            BasicEventElementEnum = 13,
            /// <summary>
            /// Enum OperationEnum for Operation
            /// </summary>
            [EnumMember(Value = "Operation")]
            OperationEnum = 14,
            /// <summary>
            /// Enum CapabilityEnum for Capability
            /// </summary>
            [EnumMember(Value = "Capability")]
            CapabilityEnum = 15,
            /// <summary>
            /// Enum ConceptDescriptionEnum for ConceptDescription
            /// </summary>
            [EnumMember(Value = "ConceptDescription")]
            ConceptDescriptionEnum = 16        }
}