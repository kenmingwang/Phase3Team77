#pragma checksum "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b4fd157df55b745c81515b48b3e35bc7fa6f61c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Professor_Students), @"mvc.1.0.view", @"/Views/Professor/Students.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Professor/Students.cshtml", typeof(AspNetCore.Views_Professor_Students))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS;

#line default
#line hidden
#line 3 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS.Models;

#line default
#line hidden
#line 4 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b4fd157df55b745c81515b48b3e35bc7fa6f61c", @"/Views/Professor/Students.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Professor_Students : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
  
  ViewData["Title"] = "Students";
  Layout = "~/Views/Shared/ProfessorLayout.cshtml";

#line default
#line hidden
            BeginContext(97, 10, true);
            WriteLiteral("\r\n<html>\r\n");
            EndContext();
            BeginContext(107, 934, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b4fd157df55b745c81515b48b3e35bc7fa6f61c4146", async() => {
                BeginContext(113, 921, true);
                WriteLiteral(@"
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
  <style>
    body {
      font-family: ""Lato"", sans-serif;
    }

    .sidenav {
      /*width: 130px;
      height: 210px;
      position: fixed;
      z-index: 1;
      top: 80px;
      left: 10px;*/
      width: 130px;
      height: 210px;
      position: fixed;
      left: 0;
      right: 0;
      /*margin-left: auto;
      margin-right: auto;*/
      z-index: 1;
      top: 50px;
      background: #eee;
      overflow-x: hidden;
      padding: 8px 0;
    }

      .sidenav a {
        padding: 6px 8px 6px 16px;
        text-decoration: none;
        font-size: 18px;
        color: #2196F3;
        display: block;
      }

        .sidenav a:hover {
          color: #064579;
        }

    .main {
      margin-left: 140px;
      min-height: 200px;
      padding: 0px 10px;
    }
  </style>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1041, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1043, 1307, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b4fd157df55b745c81515b48b3e35bc7fa6f61c6256", async() => {
                BeginContext(1049, 35, true);
                WriteLiteral("\r\n\r\n  <div class=\"sidenav\">\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1084, "\'", 1207, 8);
                WriteAttributeValue("", 1091, "/Professor/Class?subject=", 1091, 25, true);
#line 58 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1116, ViewData["subject"], 1116, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1136, "&num=", 1136, 5, true);
#line 58 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1141, ViewData["num"], 1141, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1157, "&season=", 1157, 8, true);
#line 58 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1165, ViewData["season"], 1165, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1184, "&year=", 1184, 6, true);
#line 58 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1190, ViewData["year"], 1190, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1208, 24, true);
                WriteLiteral(">Assignments</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1232, "\'", 1358, 8);
                WriteAttributeValue("", 1239, "/Professor/Students?subject=", 1239, 28, true);
#line 59 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1267, ViewData["subject"], 1267, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1287, "&num=", 1287, 5, true);
#line 59 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1292, ViewData["num"], 1292, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1308, "&season=", 1308, 8, true);
#line 59 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1316, ViewData["season"], 1316, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1335, "&year=", 1335, 6, true);
#line 59 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1341, ViewData["year"], 1341, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1359, 21, true);
                WriteLiteral(">Students</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1380, "\'", 1508, 8);
                WriteAttributeValue("", 1387, "/Professor/Categories?subject=", 1387, 30, true);
#line 60 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1417, ViewData["subject"], 1417, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1437, "&num=", 1437, 5, true);
#line 60 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1442, ViewData["num"], 1442, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1458, "&season=", 1458, 8, true);
#line 60 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1466, ViewData["season"], 1466, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1485, "&year=", 1485, 6, true);
#line 60 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
WriteAttributeValue("", 1491, ViewData["year"], 1491, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1509, 834, true);
                WriteLiteral(@">Assignment Categories</a>
  </div>


  <div class=""main"">
    <h4 id=""classname"">Class</h4>

    <div id=""studentsDiv"" class=""col-md-12"">
      <div class=""panel panel-primary"">
        <div class=""panel-heading"">
          <h3 class=""panel-title""></h3>
        </div>
        <div class=""panel-body"">
          <table id=""tblStudents"" class=""table table-bordered table-striped table-responsive table-hover"">
            <thead>
              <tr>
                <th align=""left"" class=""productth"">Name</th>
                <th align=""left"" class=""productth"">uID</th>
                <th align=""left"" class=""productth"">Standing</th>
                <th align=""left"" class=""productth"">Grade</th>
              </tr>
            </thead>
          </table>
        </div>
      </div>
    </div>
  </div>

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2350, 15, true);
            WriteLiteral("\r\n</html>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2386, 1528, true);
                WriteLiteral(@"
  <script type=""text/javascript"">

    LoadData();

    function PopulateTable(tbl, offerings) {
      var newBody = document.createElement(""tbody"");

      //courses.sort(function (a, b) {
      //  return parseInt(a.number) - parseInt(b.number);

      //});

      $.each(offerings, function (i, item) {
        var tr = document.createElement(""tr"");

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.lname + "", "" + item.fname));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.uid));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        var bYear = Number(item.dob.substring(0, 4));
        var cYear = new Date().getFullYear();
        var age = cYear - bYear;
        var standing = ""freshman"";
        if (age == 19) { standing = ""sohpomore""; }
        if (age == 20) { standing = ""junior""; }
        if (age > 20) { standin");
                WriteLiteral(@"g = ""senior"";}
        td.appendChild(document.createTextNode(standing));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.grade));
        tr.appendChild(td);

        newBody.appendChild(tr);
      });

      //var newTable = newDiv.getElementsByClassName(""table"")[0];
      tbl.appendChild(newBody);
      //newTable.appendChild(newBody);

    }

    function LoadData() {

      classname.innerText = '");
                EndContext();
                BeginContext(3915, 19, false);
#line 143 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
                        Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3934, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3936, 15, false);
#line 143 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
                                             Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(3951, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3953, 18, false);
#line 143 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
                                                              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(3971, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3973, 16, false);
#line 143 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
                                                                                  Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(3989, 118, true);
                WriteLiteral("\';\r\n\r\n      var tbl = document.getElementById(\"tblStudents\");\r\n\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(4108, 45, false);
#line 149 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
         Write(Url.Action("GetStudentsInClass", "Professor"));

#line default
#line hidden
                EndContext();
                BeginContext(4153, 68, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(4222, 19, false);
#line 152 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(4241, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(4269, 15, false);
#line 153 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(4284, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(4309, 18, false);
#line 154 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(4327, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(4356, 16, false);
#line 155 "C:\Users\Ken\Downloads\LMS_handout\LMS_handout\LMS\Views\Professor\Students.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(4372, 440, true);
                WriteLiteral(@"')},
        success: function (data, status) {
          //alert(JSON.stringify(data));
          PopulateTable(tbl, data);
        },
        error: function (ex) {
          var r = jQuery.parseJSON(response.responseText);
          alert(""Message: "" + r.Message);
          alert(""StackTrace: "" + r.StackTrace);
          alert(""ExceptionType: "" + r.ExceptionType);
        }
        });

        
    }

  </script>

");
                EndContext();
            }
            );
            BeginContext(4815, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
