using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(EspecificacaoMetaData))]
    public partial class Especificacao {

    }
    public class EspecificacaoMetaData {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public virtual Produto Produto { get; set; }

    }
}