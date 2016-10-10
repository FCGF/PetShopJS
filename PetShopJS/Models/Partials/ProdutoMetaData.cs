using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(ProdutoMetaData))]
    public partial class Produto {

    }
    public class ProdutoMetaData {
        
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public int IdFabricante { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Nullable<int> IdAnimal { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public virtual Animal Animal { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Especificacao> Especificacaos { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Fabricante Fabricante { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto_Empresa> Produto_Empresa { get; set; }
    }
}