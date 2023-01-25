using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SWProvincias_MorenoAnais.Models
{
    public class Provincia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo es Obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        public List<Ciudad> Ciudades { get; set; }
    }
}
