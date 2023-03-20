using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensumAPI.Models;

[Table("tbl_Lektion")]
public class Lektion
{
    [Key]
    public int Id { get; set; }
    [Required]
    public char Klasse { get; set; }
    [Required]
    public char WochenTag { get; set; }
    [Required]
    public char Uhrzeit { get; set; }
    public char Fach { get; set; }
    public char Lehrperson { get; set; }
    public char Zimmer { get; set; }
}