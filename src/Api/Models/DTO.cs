
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace IO.Swagger.Models
{
    [DataContract]
    public partial class SAuthorityListItemDto
    {
        [DataMember] [JsonPropertyName("id")] public int? Id { get; set; }
        [DataMember] [JsonPropertyName("user_id")] public int? UserId { get; set; }
        [DataMember] [JsonPropertyName("authority_id")] public int? AuthorityId { get; set; }
        [DataMember] [JsonPropertyName("authority_name")] public string AuthorityName { get; set; } = string.Empty;

        [DataMember] [JsonPropertyName("division_id")] public int? DivisionId { get; set; }
        [DataMember] [JsonPropertyName("division_type_id")] public int? DivisionTypeId { get; set; }
        [DataMember] [JsonPropertyName("so_id")] public int? SoId { get; set; }
        [DataMember] [JsonPropertyName("dept_id")] public int? DeptId { get; set; }

        [DataMember] [JsonPropertyName("note")] public string Note { get; set; } = string.Empty;
        [DataMember] [JsonPropertyName("reg_user_id")] public int? RegUserId { get; set; }
        [DataMember] [JsonPropertyName("reg_date")] public DateTime? RegDate { get; set; }
    }
}
