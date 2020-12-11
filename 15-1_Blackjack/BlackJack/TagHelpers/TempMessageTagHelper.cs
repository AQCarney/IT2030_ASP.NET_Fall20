using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace BlackJack.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("my-temp-message")]
    public class TempMessageTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBoundAttribute]
        public ViewContext ViewCtx { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var tempData = ViewCtx.TempData;

            if(tempData.ContainsKey("message"))
            {
                string background = tempData["background"]?.ToString() ?? "info";
                output.BuildTag("h4", $"bg-{background} text-center text-white p-2 ");
                output.Content.SetContent(tempData["message"].ToString());
            }
            else
            {
                output.SuppressOutput();
            }
}
    }
}
