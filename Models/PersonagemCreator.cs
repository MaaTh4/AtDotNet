using System.ComponentModel.DataAnnotations;

namespace AssementDotNet.AtDotnet.Models
{
    public class PersonagemCreator
    {
        [Key]
        public int age { get; set; }
        public string name { get; set; }
        public string classe { get; set; }
        public string poder { get; set; }
        public string raca { get; set; }
    }
}
