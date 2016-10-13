using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PetShopJS.Models {
    [MetadataType(typeof(EmpresaMetaData))]
    public partial class Empresa {

    }
    public class EmpresaMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Empresa")]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Telefone { get; set; }
        [Required]
        public int IdEndereco { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto_Empresa> Produto_Empresa { get; set; }

    }
}