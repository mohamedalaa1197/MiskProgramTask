using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MiskProgramTask.DomainLayer;

public class Skill
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required] public string Title { get; set; }
}