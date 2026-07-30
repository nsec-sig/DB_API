using System;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IO.Swagger.Models
{
    [DataContract]
    public partial class MAuthorityDto : IEquatable<MAuthorityDto>
    {
        [DataMember]
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [DataMember]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [DataMember]
        [JsonPropertyName("note")]
        public string Note { get; set; } = string.Empty;

        [DataMember]
        [JsonPropertyName("reg_date")]
        public DateTime? RegDate { get; set; }

        // 循環しやすいので通常はDTOでは持たない（必要なら一覧だけ等に）
        // [DataMember]
        // [JsonPropertyName("s_authorities")]
        // public List<SAuthorityDto> SAuthorities { get; set; } = new();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MAuthorityDto {\n");
            sb.Append("  Id: ").Append(Id).Append('\n');
            sb.Append("  Name: ").Append(Name).Append('\n');
            sb.Append("  Note: ").Append(Note).Append('\n');
            sb.Append("  RegDate: ").Append(RegDate).Append('\n');
            sb.Append("}\n");
            return sb.ToString();
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((MAuthorityDto)obj);
        }

        public bool Equals(MAuthorityDto? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (Id == other.Id || (Id != null && Id.Equals(other.Id))) &&
                (Name == other.Name || (Name != null && Name.Equals(other.Name))) &&
                (Note == other.Note || (Note != null && Note.Equals(other.Note))) &&
                (RegDate == other.RegDate || (RegDate != null && RegDate.Equals(other.RegDate)));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 41;
                if (Id != null) hashCode = hashCode * 59 + Id.GetHashCode();
                if (Name != null) hashCode = hashCode * 59 + Name.GetHashCode();
                if (Note != null) hashCode = hashCode * 59 + Note.GetHashCode();
                if (RegDate != null) hashCode = hashCode * 59 + RegDate.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591
        public static bool operator ==(MAuthorityDto? left, MAuthorityDto? right) => Equals(left, right);
        public static bool operator !=(MAuthorityDto? left, MAuthorityDto? right) => !Equals(left, right);
#pragma warning restore 1591
        #endregion Operators
    }
}