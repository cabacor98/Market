using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Display (Name = "País")]
        [MaxLength (100, ErrorMessage ="El campo {0} tiene un maximo de 100 caracteres")]
        [Required(ErrorMessage ="El campo (0) no puede ir vacio.")]
        public string? Name { get; set; }

        public ICollection<State> States { get; set; }
    }
}
