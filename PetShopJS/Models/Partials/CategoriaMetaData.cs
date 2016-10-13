using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models {
    [MetadataType(typeof(CategoriaMetaData))]
    public partial class Categoria {

    }
    public class CategoriaMetaData {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }
        public Nullable<int> IdCategoriaPai { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Categoria> Categoria1 { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Categoria Categoria2 { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto> Produtos { get; set; }

    }
}