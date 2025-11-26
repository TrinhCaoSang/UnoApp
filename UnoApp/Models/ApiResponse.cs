using System.Text.Json.Serialization;

namespace UnoApp.Models
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        // Dữ liệu thực sự (ví dụ danh sách sản phẩm) sẽ nằm trong biến này
        [JsonPropertyName("data")]
        public T? Data { get; set; }
        [JsonPropertyName("errors")]
        public List<string> Errors { get; set; }
    }
}
