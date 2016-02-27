using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using AptitudorService.Model;


namespace AptitudorService
{
    /// <summary>
    /// Summary description for ServiceAptitudor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ServiceAptitudor : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetSubjects(int limit, int offset)
        {
            using (AptitudorEntities db = new AptitudorEntities())
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                HttpContext.Current.Response.ContentType = "text/HTML";
                var jsonObject = js.Serialize(db.Subjects.Select(b => new Subjects { Id = b.Id, Name = b.Name }).OrderBy(p => p.Id).Skip(offset).Take(limit).ToList());

                HttpContext.Current.Response.Write(jsonObject);

            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetClass()
        {
            using (AptitudorEntities db = new AptitudorEntities())
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                HttpContext.Current.Response.ContentType = "text/HTML";
                HttpContext.Current.Response.Write(js.Serialize(db.Classes.Select(b => new Classes { Id = b.Id, Name = b.Name }).ToList()));

            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetChapters(int subid, int classid)
        {
            using (AptitudorEntities db = new AptitudorEntities())
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                HttpContext.Current.Response.ContentType = "text/HTML";
                HttpContext.Current.Response.Write(js.Serialize(db.Chapters.Where(x => x.SubId.Equals(subid) && x.ClassId.Equals(classid)).Select(b => new Chapters { Id=b.Id,Name= b.Name, ClassId= b.ClassId, SubId = b.SubId }).ToList()));

            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<KeyValuePair<string,int>> InsertTestDetails(int classid, string name, int time, int max_marks)
        {
            using (AptitudorEntities db = new AptitudorEntities())
            {
                TestDetail d = new TestDetail();
                d.ClassId = classid;
                d.Name = name;
                d.Test_Time = time;
                d.Test_Max = max_marks;
                db.TestDetails.Add(d);
                db.SaveChanges();

                var list = new List<KeyValuePair<string, int>>();
                list.Add(new KeyValuePair<string,int>("value", d.Id));

                return list;
                //JavaScriptSerializer js = new JavaScriptSerializer();
                //HttpContext.Current.Response.ContentType = "text/HTML";
                //HttpContext.Current.Response.Write(js.Serialize(list[0]));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public void InsertTestPapers(TestPapers[] obj)
        {
            for (var i = 0; i < obj.Length; i++)
            {
                TestPapers t = new TestPapers();
                t.TestId = obj[i].TestId;
                t.Question = obj[i].Question;
                t.Option1 = obj[i].Option1;
                t.Option2 = obj[i].Option2;
                t.Option3 = obj[i].Option3;
                t.Option4 = obj[i].Option4;
                t.RightAns = obj[i].RightAns;
                t.SubId = obj[i].SubId;
                t.ChapId = obj[i].ChapId;
                int id = t.save();
            }
                


        }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
