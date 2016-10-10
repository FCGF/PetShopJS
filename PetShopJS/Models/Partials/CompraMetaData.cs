using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(CompraMetaData))]
    public partial class Compra {

    }
    public class CompraMetaData {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdCondicao { get; set; }
        public string Codigo { get; set; }
        public decimal Desconto { get; set; }
        public int IdFormaPagamento { get; set; }
        public int IdParcela { get; set; }
        public System.DateTime Data { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Condicao Condicao { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Forma_Pagamento Forma_Pagamento { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Parcela Parcela { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra_Produto_Empresa> Compra_Produto_Empresa { get; set; }

    }
}