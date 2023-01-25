using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWProvincias_MorenoAnais.Models
{
    public class Ciudad
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo es Obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        public int ProvinciaID { get; set; }
        [ForeignKey("ProvinciaID")]
        public Provincia provincia { get; set; }  

    }
}
