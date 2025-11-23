using System.ComponentModel.DataAnnotations;

namespace ejerCore_T2_02.Models
{
    public class Distrito
    {
        [Display(Name = "Código")]public string Cod_distrito {  get; set; }   
        [Display(Name = "Distrito")]public string Nom_distrito { get; set; }
    }
}
