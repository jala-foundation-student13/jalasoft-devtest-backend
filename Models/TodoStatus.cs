using System.Text.Json.Serialization;

namespace jalasoft_devtest_backend.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TodoStatus
    {
        NotCompleted = 1,
        Completed = 2,
        Overdue = 3,
    }
}