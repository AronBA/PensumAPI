using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensumAPI.Models;

[Table("tbl_Lektion")]
public class Lektion
{
    [Key]
    public int Id { get; set; }
    public string? Klasse { get; set; }
    public string? WochenTag { get; set; }
    public string? Fach { get; set; }
    public string? Lehrperson { get; set; }
    public string? Zimmer { get; set; } 
}