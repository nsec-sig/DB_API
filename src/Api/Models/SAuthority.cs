/*
 * Equipment Management API
 *
 * OpenAPI spec version: 1.0.0
 *
 */
using System;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IO.Swagger.Models
{
    [DataContract]
    public partial class SAuthorityDto : IEquatable<SAuthorityDto>
    {
        [DataMember]
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [DataMember]
        [JsonPropertyName("del_flg")]
        public int? DelFlg { get; set; }

        [DataMember]
        [JsonPropertyName("user_id")]
        public int? UserId { get; set; }

        [DataMember]
        [JsonPropertyName("authority_id")]
        public int? AuthorityId { get; set; }

        [DataMember]
        [JsonPropertyName("division_id")]
        public int? DivisionId { get; set; }

        [DataMember]
        [JsonPropertyName("so_id")]
        public int? SoId { get; set; }

        [DataMember]
        [JsonPropertyName("dept_id")]
        public int? DeptId { get; set; }

        [DataMember]
        [JsonPropertyName("note")]
        public string Note { get; set; } = string.Empty;

        [DataMember]
        [JsonPropertyName("reg_user_id")]
        public int? RegUserId { get; set; }

        [DataMember]
        [JsonPropertyName("reg_date")]
        public DateTime? RegDate { get; set; }

        // --- Option: ナビゲーションを持たせたい場合（循環注意）
        // [DataMember]
        // [JsonPropertyName("authority")]
        // public MAuthorityDto? Authority { get; set; }
        //
        // [DataMember]
        // [JsonPropertyName("division")]
        // public SDivisionDto? Division { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SAuthorityDto {\n");
            sb.Append("  Id: ").Append(Id).Append('\n');
            sb.Append("  DelFlg: ").Append(DelFlg).Append('\n');
            sb.Append("  UserId: ").Append(UserId).Append('\n');
            sb.Append("  AuthorityId: ").Append(AuthorityId).Append('\n');
            sb.Append("  DivisionId: ").Append(DivisionId).Append('\n');
            sb.Append("  SoId: ").Append(SoId).Append('\n');
            sb.Append("  DeptId: ").Append(DeptId).Append('\n');
            sb.Append("  Note: ").Append(Note).Append('\n');
            sb.Append("  RegUserId: ").Append(RegUserId).Append('\n');
            sb.Append("  RegDate: ").Append(RegDate).Append('\n');
            sb.Append("}\n");
            return sb.ToString();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((SAuthorityDto)obj);
        }

        public bool Equals(SAuthorityDto? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (Id == other.Id || (Id != null && Id.Equals(other.Id))) &&
                (DelFlg == other.DelFlg || (DelFlg != null && DelFlg.Equals(other.DelFlg))) &&
                (UserId == other.UserId || (UserId != null && UserId.Equals(other.UserId))) &&
                (AuthorityId == other.AuthorityId || (AuthorityId != null && AuthorityId.Equals(other.AuthorityId))) &&
                (DivisionId == other.DivisionId || (DivisionId != null && DivisionId.Equals(other.DivisionId))) &&
                (SoId == other.SoId || (SoId != null && SoId.Equals(other.SoId))) &&
                (DeptId == other.DeptId || (DeptId != null && DeptId.Equals(other.DeptId))) &&
                (Note == other.Note || (Note != null && Note.Equals(other.Note))) &&
                (RegUserId == other.RegUserId || (RegUserId != null && RegUserId.Equals(other.RegUserId))) &&
                (RegDate == other.RegDate || (RegDate != null && RegDate.Equals(other.RegDate)));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 41;
                if (Id != null) hashCode = hashCode * 59 + Id.GetHashCode();
                if (DelFlg != null) hashCode = hashCode * 59 + DelFlg.GetHashCode();
                if (UserId != null) hashCode = hashCode * 59 + UserId.GetHashCode();
                if (AuthorityId != null) hashCode = hashCode * 59 + AuthorityId.GetHashCode();
                if (DivisionId != null) hashCode = hashCode * 59 + DivisionId.GetHashCode();
                if (SoId != null) hashCode = hashCode * 59 + SoId.GetHashCode();
                if (DeptId != null) hashCode = hashCode * 59 + DeptId.GetHashCode();
                if (Note != null) hashCode = hashCode * 59 + Note.GetHashCode();
                if (RegUserId != null) hashCode = hashCode * 59 + RegUserId.GetHashCode();
                if (RegDate != null) hashCode = hashCode * 59 + RegDate.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591
        public static bool operator ==(SAuthorityDto? left, SAuthorityDto? right) => Equals(left, right);
        public static bool operator !=(SAuthorityDto? left, SAuthorityDto? right) => !Equals(left, right);
#pragma warning restore 1591
        #endregion Operators
    }
}
