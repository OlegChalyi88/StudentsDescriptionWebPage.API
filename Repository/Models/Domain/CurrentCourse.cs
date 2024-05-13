using System.Text.Json.Serialization;

namespace Repository.Models.Domain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CurrentCourse
{
    CsharpStarter = 1,
    Git = 2,
    CsharpEssential = 3,
    CsharpProfessional = 4,
    Sql = 5,
    EFCore = 6,
    AspNetCore = 7
}
