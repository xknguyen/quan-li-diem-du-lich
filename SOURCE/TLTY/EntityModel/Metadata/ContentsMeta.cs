using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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