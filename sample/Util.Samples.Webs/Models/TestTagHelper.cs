using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Util.Samples.Webs.Models
{
    public class TestTagHelper : TagHelper {
        private const string EmailDomain = "contoso.com";

        // Can be passed via <email mail-to="..." />. 
        // Pascal case gets translated into lower-kebab-case.
        public string MailTo { get; set; }

        public override void Process( TagHelperContext context, TagHelperOutput output ) {
            output.TagName = "a";    // Replaces <email> with <a> tag

            var address = MailTo + "@" + EmailDomain;
            output.Attributes.SetAttribute( "href", "mailto:" + address );
            output.Content.SetContent( address );
        }
    }
}
