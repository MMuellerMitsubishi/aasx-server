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
    public partial class Qualifier : HasSemantics, IEquatable<Qualifier>
    { 
        /// <summary>
        /// Gets or Sets Kind
        /// </summary>

        [DataMember(Name="kind")]
        public QualifierKind Kind { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Required]

        [MinLength(1)]
        [DataMember(Name="type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets ValueType
        /// </summary>
        [Required]

        [DataMember(Name="valueType")]
        public DataTypeDefXsd ValueType { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>

        [DataMember(Name="value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets ValueId
        /// </summary>

        [DataMember(Name="valueId")]
        public Reference ValueId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Qualifier {\n");
            sb.Append("  Kind: ").Append(Kind).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  ValueType: ").Append(ValueType).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  ValueId: ").Append(ValueId).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Qualifier)obj);
        }

        /// <summary>
        /// Returns true if Qualifier instances are equal
        /// </summary>
        /// <param name="other">Instance of Qualifier to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Qualifier other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Kind == other.Kind ||
                    Kind != null &&
                    Kind.Equals(other.Kind)
                ) && 
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
                ) && 
                (
                    ValueType == other.ValueType ||
                    ValueType != null &&
                    ValueType.Equals(other.ValueType)
                ) && 
                (
                    Value == other.Value ||
                    Value != null &&
                    Value.Equals(other.Value)
                ) && 
                (
                    ValueId == other.ValueId ||
                    ValueId != null &&
                    ValueId.Equals(other.ValueId)
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
                    if (Kind != null)
                    hashCode = hashCode * 59 + Kind.GetHashCode();
                    if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                    if (ValueType != null)
                    hashCode = hashCode * 59 + ValueType.GetHashCode();
                    if (Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                    if (ValueId != null)
                    hashCode = hashCode * 59 + ValueId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Qualifier left, Qualifier right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Qualifier left, Qualifier right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
