using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using Dz4zad1.Models;
using System.Web.Mvc;

namespace Dz4zad1.Helpers
{
    public static class Helper_Table
    {
        public static MvcHtmlString PublishTable(this System.Web.Mvc.HtmlHelper html,List<Publisher> list)
        {
            TagBuilder table=new TagBuilder("table");
            table.AddCssClass("table");
            table.MergeAttribute("border","1");
            TagBuilder tr= new TagBuilder("tr");
            tr.AddCssClass("oglov");
            TagBuilder td=new TagBuilder("td");
            td.SetInnerText("id");
            tr.InnerHtml += td.ToString();
            td.SetInnerText("Name");
            tr.InnerHtml += td.ToString();
            td.SetInnerText("Edit");
            tr.InnerHtml += td.ToString();
            td.SetInnerText("Delete");
            tr.InnerHtml += td.ToString();
            table.InnerHtml += tr.ToString();
            foreach (Publisher VARIABLE in list)
            {
                TagBuilder tr1=new TagBuilder("tr");
                td.SetInnerText($"{VARIABLE.Id}");
                tr1.InnerHtml += td.ToString();
                td.SetInnerText($"{VARIABLE.Name}");
                tr1.InnerHtml += td.ToString();
                TagBuilder a=new TagBuilder("a");
                a.MergeAttribute("href",$"/Home/Edit/{VARIABLE.Id}");
                a.AddCssClass("buttom");
                a.SetInnerText("Edit");
                TagBuilder td1=new TagBuilder("td");
                td1.InnerHtml += a.ToString();
                tr1.InnerHtml += td1.ToString();
                TagBuilder a1 = new TagBuilder("a");
                a1.MergeAttribute("href", $"/Home/Delete/{VARIABLE.Id}");
                a1.AddCssClass("buttom");
                a1.SetInnerText("Delete");
                TagBuilder td2 = new TagBuilder("td");
                td2.InnerHtml += a1.ToString();
                tr1.InnerHtml += td2.ToString();
                table.InnerHtml += tr1.ToString();
            }

            return new MvcHtmlString(table.ToString());
        }
        public static MvcHtmlString AuthorsTable(this System.Web.Mvc.HtmlHelper html, List<Author> list)
        {
            TagBuilder table = new TagBuilder("table");
            table.AddCssClass("table");
            table.MergeAttribute("border", "1");
            TagBuilder tr = new TagBuilder("tr");
            tr.AddCssClass("oglov");
            TagBuilder td = new TagBuilder("td");
            td.SetInnerText("id");
            tr.InnerHtml += td.ToString();
            td.SetInnerText("Name");
            tr.InnerHtml += td.ToString();
            td.SetInnerText("Edit");
            tr.InnerHtml += td.ToString();
            td.SetInnerText("Delete");
            tr.InnerHtml += td.ToString();
            table.InnerHtml += tr.ToString();
            foreach (Author VARIABLE in list)
            {
                TagBuilder tr1 = new TagBuilder("tr");
                td.SetInnerText($"{VARIABLE.Id}");
                tr1.InnerHtml += td.ToString();
                td.SetInnerText($"{VARIABLE.Name}");
                tr1.InnerHtml += td.ToString();
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", $"/Author/Edit/{VARIABLE.Id}");
                a.AddCssClass("buttom");
                a.SetInnerText("Edit");
                TagBuilder td1 = new TagBuilder("td");
                td1.InnerHtml += a.ToString();
                tr1.InnerHtml += td1.ToString();
                TagBuilder a1 = new TagBuilder("a");
                a1.MergeAttribute("href", $"/Author/Delete/{VARIABLE.Id}");
                a1.AddCssClass("buttom");
                a1.SetInnerText("Delete");
                TagBuilder td2 = new TagBuilder("td");
                td2.InnerHtml += a1.ToString();
                tr1.InnerHtml += td2.ToString();
                table.InnerHtml += tr1.ToString();
            }

            return new MvcHtmlString(table.ToString());
        }
        public static MvcHtmlString BookTable(this System.Web.Mvc.HtmlHelper html, List<Book> list)
        {
            TagBuilder table = new TagBuilder("table");
            table.AddCssClass("table");
            table.MergeAttribute("border", "1");
            TagBuilder tr = new TagBuilder("tr");
            tr.AddCssClass("oglov");
            TagBuilder td = new TagBuilder("td");
            td.SetInnerText("id");
            tr.InnerHtml += td.ToString();
            td.SetInnerText("Name");
            tr.InnerHtml += td.ToString();
            td.SetInnerText("Edit");
            tr.InnerHtml += td.ToString();
            td.SetInnerText("Delete");
            tr.InnerHtml += td.ToString();
            table.InnerHtml += tr.ToString();
            foreach (Book VARIABLE in list)
            {
                TagBuilder tr1 = new TagBuilder("tr");
                td.SetInnerText($"{VARIABLE.Id}");
                tr1.InnerHtml += td.ToString();
                td.SetInnerText($"{VARIABLE.Name}");
                tr1.InnerHtml += td.ToString();
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", $"/Book/Edit/{VARIABLE.Id}");
                a.AddCssClass("buttom");
                a.SetInnerText("Edit");
                TagBuilder td1 = new TagBuilder("td");
                td1.InnerHtml += a.ToString();
                tr1.InnerHtml += td1.ToString();
                TagBuilder a1 = new TagBuilder("a");
                a1.MergeAttribute("href", $"/Book/Delete/{VARIABLE.Id}");
                a1.AddCssClass("buttom");
                a1.SetInnerText("Delete");
                TagBuilder td2 = new TagBuilder("td");
                td2.InnerHtml += a1.ToString();
                tr1.InnerHtml += td2.ToString();
                table.InnerHtml += tr1.ToString();
            }

            return new MvcHtmlString(table.ToString());
        }
    }
}