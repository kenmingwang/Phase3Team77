#pragma checksum "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1dfc49602902f82086a1ad3a12e7e82a4c522c53"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Professor_CatAssignments), @"mvc.1.0.view", @"/Views/Professor/CatAssignments.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Professor/CatAssignments.cshtml", typeof(AspNetCore.Views_Professor_CatAssignments))]
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
#line 1 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\_ViewImports.cshtml"
using LMS;

#line default
#line hidden
#line 3 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\_ViewImports.cshtml"
using LMS.Models;

#line default
#line hidden
#line 4 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\_ViewImports.cshtml"
using LMS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\_ViewImports.cshtml"
using LMS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dfc49602902f82086a1ad3a12e7e82a4c522c53", @"/Views/Professor/CatAssignments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Professor_CatAssignments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
  
  ViewData["Title"] = "CatAssignments";
  Layout = "~/Views/Shared/ProfessorLayout.cshtml";

#line default
#line hidden
            BeginContext(103, 10, true);
            WriteLiteral("\r\n<html>\r\n");
            EndContext();
            BeginContext(113, 934, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1dfc49602902f82086a1ad3a12e7e82a4c522c534257", async() => {
                BeginContext(119, 921, true);
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
            BeginContext(1047, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1049, 2747, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1dfc49602902f82086a1ad3a12e7e82a4c522c536367", async() => {
                BeginContext(1055, 35, true);
                WriteLiteral("\r\n\r\n  <div class=\"sidenav\">\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1090, "\'", 1213, 8);
                WriteAttributeValue("", 1097, "/Professor/Class?subject=", 1097, 25, true);
#line 58 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1122, ViewData["subject"], 1122, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1142, "&num=", 1142, 5, true);
#line 58 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1147, ViewData["num"], 1147, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1163, "&season=", 1163, 8, true);
#line 58 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1171, ViewData["season"], 1171, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1190, "&year=", 1190, 6, true);
#line 58 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1196, ViewData["year"], 1196, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1214, 24, true);
                WriteLiteral(">Assignments</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1238, "\'", 1364, 8);
                WriteAttributeValue("", 1245, "/Professor/Students?subject=", 1245, 28, true);
#line 59 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1273, ViewData["subject"], 1273, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1293, "&num=", 1293, 5, true);
#line 59 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1298, ViewData["num"], 1298, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1314, "&season=", 1314, 8, true);
#line 59 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1322, ViewData["season"], 1322, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1341, "&year=", 1341, 6, true);
#line 59 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1347, ViewData["year"], 1347, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1365, 21, true);
                WriteLiteral(">Students</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1386, "\'", 1514, 8);
                WriteAttributeValue("", 1393, "/Professor/Categories?subject=", 1393, 30, true);
#line 60 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1423, ViewData["subject"], 1423, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1443, "&num=", 1443, 5, true);
#line 60 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1448, ViewData["num"], 1448, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1464, "&season=", 1464, 8, true);
#line 60 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1472, ViewData["season"], 1472, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1491, "&year=", 1491, 6, true);
#line 60 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
WriteAttributeValue("", 1497, ViewData["year"], 1497, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1515, 277, true);
                WriteLiteral(@">Assignment Categories</a>
  </div>


  <div class=""main"">
    <h4 id=""classname"">Class</h4>

    <div id=""departmentDiv"" class=""col-md-12"">
      <div class=""panel panel-primary"">
        <div class=""panel-heading"">
          <h3 class=""panel-title"">Assignments in '");
                EndContext();
                BeginContext(1793, 15, false);
#line 70 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                                             Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(1808, 1981, true);
                WriteLiteral(@"'</h3>
        </div>
        <div class=""panel-body"">
          <table id=""tblAssignments"" class=""table table-bordered table-striped table-responsive table-hover"">
            <thead>
              <tr>
                <th align=""left"" class=""productth"">Name</th>
                <th align=""left"" class=""productth"">Due</th>
                <th align=""left"" class=""productth"">Submissions</th>
              </tr>
            </thead>
            <tbody></tbody>
          </table>
        </div>
      </div>
    </div>

    <div class=""col-md-12"">
      <div class=""panel panel-primary"">
        <div class=""panel-heading"">
          <h3 class=""panel-title"">New Assignment</h3>
        </div>
        <div class=""panel-body"">
          <div class=""clearfix""></div>
          <div class=""form-group col-md-5"">
            <label>Name</label>
            <input type=""text"" name=""AsgName"" id=""AsgName"" class=""form-control"" placeholder=""Enter assignment name"" required="""" />
          </div>
      ");
                WriteLiteral(@"    <div class=""form-group col-md-5"">
            <label>Points</label>
            <input type=""text"" name=""AsgPoints"" id=""AsgPoints"" class=""form-control"" placeholder=""Enter max points"" required="""" />
          </div>
          <br />
          <div class=""form-group col-md-5"">
            <label>Due</label>
            <input type=""datetime-local"" name=""AsgDue"" id=""AsgDue"" value=""2018-01-01T23:59:59"">
          </div>
          <br />
          <div class=""form-group col-md-3"">
            <textarea rows=""4"" cols=""50"" name=""AsgContents"" id=""AsgContents"">Enter contents here</textarea>
          </div>

          <div class=""form-group col-md-5"">
            <div style=""float: right; display:inline-block;"">
              <input class=""btn btn-primary"" name=""submitButton"" id=""btnSave"" value=""Add"" type=""button"" onclick=""AddAssignment()"">
            </div>
          </div>
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
            BeginContext(3796, 21, true);
            WriteLiteral("\r\n</html>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3838, 428, true);
                WriteLiteral(@"
  <script type=""text/javascript"">

    LoadData();

    function PopulateTable(tbl, offerings) {
      var newBody = document.createElement(""tbody"");

      $.each(offerings, function (i, item) {
        var tr = document.createElement(""tr"");

        
        var td = document.createElement(""td"");
        var a = document.createElement(""a"");
        a.setAttribute(""href"", ""/Professor/Assignment/?subject="" + '");
                EndContext();
                BeginContext(4267, 19, false);
#line 144 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                                                               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(4286, 15, true);
                WriteLiteral("\' + \"&num=\" + \'");
                EndContext();
                BeginContext(4302, 15, false);
#line 144 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                                                                                                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(4317, 18, true);
                WriteLiteral("\' + \"&season=\" + \'");
                EndContext();
                BeginContext(4336, 18, false);
#line 144 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                                                                                                                                    Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(4354, 16, true);
                WriteLiteral("\' + \"&year=\" + \'");
                EndContext();
                BeginContext(4371, 16, false);
#line 144 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                                                                                                                                                                       Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(4387, 15, true);
                WriteLiteral("\' + \"&cat=\" + \'");
                EndContext();
                BeginContext(4403, 15, false);
#line 144 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                                                                                                                                                                                                       Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(4418, 974, true);
                WriteLiteral(@"' + ""&aname="" + item.aname);
        a.appendChild(document.createTextNode(item.aname));
        td.appendChild(a);
        tr.appendChild(td);


        //var td = document.createElement(""td"");
        //td.appendChild(document.createTextNode(item.aname));
        //tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.due));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.submissions));
        tr.appendChild(td);

        newBody.appendChild(tr);
      });

      tbl.appendChild(newBody);


    }

    function AddAssignment() {

      var asgName = $(""#AsgName"").val();
      var asgPoints = Number($(""#AsgPoints"").val());
      var asgContents = $(""#AsgContents"").val();
      var asgDue = document.getElementById(""AsgDue"").value;

      $.ajax({
        type: 'POST',
        url: '");
                EndContext();
                BeginContext(5393, 43, false);
#line 179 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
         Write(Url.Action("CreateAssignment", "Professor"));

#line default
#line hidden
                EndContext();
                BeginContext(5436, 68, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(5505, 19, false);
#line 182 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(5524, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(5552, 15, false);
#line 183 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(5567, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(5592, 18, false);
#line 184 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(5610, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(5639, 16, false);
#line 185 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(5655, 26, true);
                WriteLiteral("\'),\r\n          category: \'");
                EndContext();
                BeginContext(5682, 15, false);
#line 186 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(5697, 707, true);
                WriteLiteral(@"',
          asgname: asgName,
          asgpoints: asgPoints,
          asgdue: asgDue,
          asgcontents: asgContents},
        success: function (data, status) {
          //alert(JSON.stringify(data));
          if (!data.success) {
            alert(""Unable to add assignment"");
          }
          location.reload();
          //LoadData();
        },
        error: function (ex) {
          var r = jQuery.parseJSON(response.responseText);
          alert(""Message: "" + r.Message);
          alert(""StackTrace: "" + r.StackTrace);
          alert(""ExceptionType: "" + r.ExceptionType);
        }
        });

    }

    function LoadData() {
      classname.innerText = '");
                EndContext();
                BeginContext(6405, 19, false);
#line 210 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                        Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(6424, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(6426, 15, false);
#line 210 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                                             Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(6441, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(6443, 18, false);
#line 210 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                                                              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(6461, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(6463, 16, false);
#line 210 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                                                                                  Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(6479, 207, true);
                WriteLiteral("\';\r\n\r\n      var tbl = document.getElementById(\"tblAssignments\");\r\n      var body = tbl.getElementsByTagName(\"tbody\")[0];\r\n      tbl.removeChild(body);\r\n\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(6687, 51, false);
#line 218 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
         Write(Url.Action("GetAssignmentsInCategory", "Professor"));

#line default
#line hidden
                EndContext();
                BeginContext(6738, 68, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(6807, 19, false);
#line 221 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(6826, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(6854, 15, false);
#line 222 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(6869, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(6894, 18, false);
#line 223 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(6912, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(6941, 16, false);
#line 224 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(6957, 26, true);
                WriteLiteral("\'),\r\n          category: \'");
                EndContext();
                BeginContext(6984, 15, false);
#line 225 "C:\Users\Ken\Documents\GitRepo\LibraryWebServerHandout\LMS\Views\Professor\CatAssignments.cshtml"
                Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(6999, 433, true);
                WriteLiteral(@"'},
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
            BeginContext(7435, 4, true);
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
