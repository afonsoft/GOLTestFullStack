using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOLTestFullStack.Api.Entity
{
    public class Airplane
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Modelo { get; set; }

        [Required]
        [StringLength(20)]
        public string CodAviao { get; set; }

        public int QtsPassageiros { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
