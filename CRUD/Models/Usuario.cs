using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD;

[Table("Usuarios")]
public class Usuario
{
    [Display(Name = "Código")]
    [Column("Id")]
    public int Id { get; set; }

    [Display(Name = "Nome")]
    [Column("Nome")]
    public string Nome { get; set; }
    
    [Display(Name = "Senha")]
    [Column("Senha")]
    public string Senha { get; set; }
}
