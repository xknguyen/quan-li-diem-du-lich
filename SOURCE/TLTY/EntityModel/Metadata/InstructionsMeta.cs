using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EntityModel.EF
{
    public class InstructionsMeta
    {
        [AllowHtml]
        public string Detail { get; set; }
    }
	[MetadataType(typeof(InstructionsMeta))]
    public partial class Instruction
    {

    }
}