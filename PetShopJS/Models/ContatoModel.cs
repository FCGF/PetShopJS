using System.ComponentModel.DataAnnotations;

namespace PetShopJS.Models {
    public class ContatoModel {
        [DataType(DataType.EmailAddress), Display(Name = "Para")]
        [Required]
        public string ToEmail { get; set; }
        [Display(Name = "Mensagem")]
        [DataType(DataType.MultilineText)]
        public string EMailBody { get; set; }
        [Display(Name = "Assunto")]
        public string EmailSubject { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "CC")]
        public string EmailCC { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "CCO")]
        public string EmailBCC { get; set; }
    }
}