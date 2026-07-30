using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace IO.Swagger.Models
{
    [DataContract]
    public partial class SDivisionListItemDto
    {
        [DataMember] [JsonPropertyName("id")] public int? Id { get; set; }
        [DataMember] [JsonPropertyName("del_flg")] public int? DelFlg { get; set; }
        [DataMember] [JsonPropertyName("division_type_id")] public int? DivisionTypeId { get; set; }
        [DataMember] [JsonPropertyName("division_type_name")] public string DivisionTypeName { get; set; } = string.Empty;

        [DataMember] [JsonPropertyName("so_id")] public int? SoId { get; set; }
        [DataMember] [JsonPropertyName("dept_id")] public int? DeptId { get; set; }
        [DataMember] [JsonPropertyName("sort_key")] public int? SortKey { get; set; }

        [DataMember] [JsonPropertyName("note")] public string Note { get; set; } = string.Empty;
        [DataMember] [JsonPropertyName("reg_user_id")] public int? RegUserId { get; set; }
        [DataMember] [JsonPropertyName("reg_date")] public DateTime? RegDate { get; set; }
    }
}