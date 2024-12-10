using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace StoreApp.Infrastructure.TagHelpers
{        [HtmlTargetElement("div", Attributes = "products")]

    public class LastestProductTagHelpers: TagHelper
    {
        private readonly IServiceManager _manager;
        [HtmlAttributeName("number")]
        public int Number { get; set; }
        public LastestProductTagHelpers(IServiceManager manager)
        {
            _manager = manager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class","my-3");
            
        TagBuilder h6 = new TagBuilder("h6");
        h6.Attributes.Add("class","lead");
       
        TagBuilder i = new TagBuilder("i");
        i.Attributes.Add("class","fa fa-box text-secondary");

        h6.InnerHtml.AppendHtml(i);
        h6.InnerHtml.AppendHtml("En Son Eklenenler");

            
        TagBuilder ul = new TagBuilder("ul"); 
        ul.Attributes.Add("class","list-group ");
       var products = _manager.ProductService.GetLastestProduct(Number,false);
       foreach(Product product in products){
            TagBuilder li = new TagBuilder("li");
            li.Attributes.Add("class","list-group-item");
            TagBuilder a = new TagBuilder("a");
            a.Attributes.Add("href",$"/product/get/{product.ProductId}");
            a.Attributes.Add("class","link-offset-2 link-underline link-underline-opacity-0");
            a.InnerHtml.AppendHtml(product.ProductName);
            li.InnerHtml.AppendHtml(a);
            ul.InnerHtml.AppendHtml(li);
       }
       


        div.InnerHtml.AppendHtml(h6);
        div.InnerHtml.AppendHtml(ul);
        output.Content.AppendHtml(div);

        }

        
    }
}