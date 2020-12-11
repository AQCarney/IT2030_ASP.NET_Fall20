using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using BlackJack.Models;

namespace BlackJack.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("h5", Attributes = "my-player")]
    [HtmlTargetElement("h5", Attributes = "my-dealer")]

    public class PlayerHeadingTagHelper : TagHelper
    {
        public Dealer MyDealer { get; set; }
        public Player MyPlayer { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string text = string.Empty;
            if(this.MyDealer!= null)
            {
                text = MyDealer.MustShowCards ? $"Dealer: {MyDealer.Hand.Total}" : "Dealer";
            }
            else if (this.MyPlayer != null)
            {
                text = MyPlayer.Hand.HasCards ? $"Player: {MyPlayer.Hand.Total}" : "Dealer";

            }
            output.Content.Append(text);

        }
    }
}
