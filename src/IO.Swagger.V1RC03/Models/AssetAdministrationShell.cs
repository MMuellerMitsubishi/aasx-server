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
    public partial class AssetAdministrationShell : Identifiable, IEquatable<AssetAdministrationShell>
    { 
        /// <summary>
        /// Gets or Sets EmbeddedDataSpecifications
        /// </summary>

        [DataMember(Name="embeddedDataSpecifications")]
        public List<EmbeddedDataSpecification> EmbeddedDataSpecifications { get; set; }

        /// <summary>
        /// Gets or Sets AssetInformation
        /// </summary>
        [Required]

        [DataMember(Name="assetInformation")]
        public AssetInformation AssetInformation { get; set; }

        /// <summary>
        /// Gets or Sets Submodels
        /// </summary>

        [DataMember(Name="submodels")]
        public List<Reference> Submodels { get; set; }

        /// <summary>
        /// Gets or Sets DerivedFrom
        /// </summary>

        [DataMember(Name="derivedFrom")]
        public Reference DerivedFrom { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AssetAdministrationShell {\n");
            sb.Append("  EmbeddedDataSpecifications: ").Append(EmbeddedDataSpecifications).Append("\n");
            sb.Append("  AssetInformation: ").Append(AssetInformation).Append("\n");
            sb.Append("  Submodels: ").Append(Submodels).Append("\n");
            sb.Append("  DerivedFrom: ").Append(DerivedFrom).Append("\n");
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
            return obj.GetType() == GetType() && Equals((AssetAdministrationShell)obj);
        }

        /// <summary>
        /// Returns true if AssetAdministrationShell instances are equal
        /// </summary>
        /// <param name="other">Instance of AssetAdministrationShell to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssetAdministrationShell other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    EmbeddedDataSpecifications == other.EmbeddedDataSpecifications ||
                    EmbeddedDataSpecifications != null &&
                    EmbeddedDataSpecifications.SequenceEqual(other.EmbeddedDataSpecifications)
                ) && 
                (
                    AssetInformation == other.AssetInformation ||
                    AssetInformation != null &&
                    AssetInformation.Equals(other.AssetInformation)
                ) && 
                (
                    Submodels == other.Submodels ||
                    Submodels != null &&
                    Submodels.SequenceEqual(other.Submodels)
                ) && 
                (
                    DerivedFrom == other.DerivedFrom ||
                    DerivedFrom != null &&
                    DerivedFrom.Equals(other.DerivedFrom)
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
                    if (EmbeddedDataSpecifications != null)
                    hashCode = hashCode * 59 + EmbeddedDataSpecifications.GetHashCode();
                    if (AssetInformation != null)
                    hashCode = hashCode * 59 + AssetInformation.GetHashCode();
                    if (Submodels != null)
                    hashCode = hashCode * 59 + Submodels.GetHashCode();
                    if (DerivedFrom != null)
                    hashCode = hashCode * 59 + DerivedFrom.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(AssetAdministrationShell left, AssetAdministrationShell right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AssetAdministrationShell left, AssetAdministrationShell right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
