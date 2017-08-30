using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EntityModel.EF
{
    public class ContentsMeta
    {
        [AllowHtml]
        public string Detail { get; set; }
    }
    [MetadataType(typeof(ContentsMeta))]
    public partial class Content
    {

    }
}