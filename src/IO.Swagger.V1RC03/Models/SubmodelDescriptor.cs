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
    /// 
    /// </summary>
    [DataContract]
    public partial class SubmodelDescriptor : Descriptor, IEquatable<SubmodelDescriptor>
    { 
        /// <summary>
        /// Gets or Sets Administration
        /// </summary>

        [DataMember(Name="administration")]
        public AdministrativeInformation Administration { get; set; }

        /// <summary>
        /// Gets or Sets Descriptions
        /// </summary>

        [DataMember(Name="descriptions")]
        public List<LangString> Descriptions { get; set; }

        /// <summary>
        /// Gets or Sets DisplayNames
        /// </summary>

        [DataMember(Name="displayNames")]
        public List<LangString> DisplayNames { get; set; }

        /// <summary>
        /// Gets or Sets IdShort
        /// </summary>

        [DataMember(Name="idShort")]
        public string IdShort { get; set; }

        /// <summary>
        /// Gets or Sets Identification
        /// </summary>
        [Required]

        [DataMember(Name="identification")]
        public string Identification { get; set; }

        /// <summary>
        /// Gets or Sets SemanticId
        /// </summary>

        [DataMember(Name="semanticId")]
        public Reference SemanticId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubmodelDescriptor {\n");
            sb.Append("  Administration: ").Append(Administration).Append("\n");
            sb.Append("  Descriptions: ").Append(Descriptions).Append("\n");
            sb.Append("  DisplayNames: ").Append(DisplayNames).Append("\n");
            sb.Append("  IdShort: ").Append(IdShort).Append("\n");
            sb.Append("  Identification: ").Append(Identification).Append("\n");
            sb.Append("  SemanticId: ").Append(SemanticId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public  new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((SubmodelDescriptor)obj);
        }

        /// <summary>
        /// Returns true if SubmodelDescriptor instances are equal
        /// </summary>
        /// <param name="other">Instance of SubmodelDescriptor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SubmodelDescriptor other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Administration == other.Administration ||
                    Administration != null &&
                    Administration.Equals(other.Administration)
                ) && 
                (
                    Descriptions == other.Descriptions ||
                    Descriptions != null &&
                    Descriptions.SequenceEqual(other.Descriptions)
                ) && 
                (
                    DisplayNames == other.DisplayNames ||
                    DisplayNames != null &&
                    DisplayNames.SequenceEqual(other.DisplayNames)
                ) && 
                (
                    IdShort == other.IdShort ||
                    IdShort != null &&
                    IdShort.Equals(other.IdShort)
                ) && 
                (
                    Identification == other.Identification ||
                    Identification != null &&
                    Identification.Equals(other.Identification)
                ) && 
                (
                    SemanticId == other.SemanticId ||
                    SemanticId != null &&
                    SemanticId.Equals(other.SemanticId)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Administration != null)
                    hashCode = hashCode * 59 + Administration.GetHashCode();
                    if (Descriptions != null)
                    hashCode = hashCode * 59 + Descriptions.GetHashCode();
                    if (DisplayNames != null)
                    hashCode = hashCode * 59 + DisplayNames.GetHashCode();
                    if (IdShort != null)
                    hashCode = hashCode * 59 + IdShort.GetHashCode();
                    if (Identification != null)
                    hashCode = hashCode * 59 + Identification.GetHashCode();
                    if (SemanticId != null)
                    hashCode = hashCode * 59 + SemanticId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(SubmodelDescriptor left, SubmodelDescriptor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SubmodelDescriptor left, SubmodelDescriptor right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
