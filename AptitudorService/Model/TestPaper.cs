using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AptitudorService.Model
{
    public class TestPapers
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string RightAns { get; set; }
        public int SubId { get; set; }
        public int ChapId { get; set; }

        public int save()
        {
            using (AptitudorEntities db = new AptitudorEntities())
            {
                TestPaper t = new TestPaper();
                t.TestId = TestId;
                t.Question = Question;
                t.Option1 = Option1;
                t.Option2 = Option2;
                t.Option3 = Option3;
                t.Option4 = Option4;
                t.RightAns = RightAns;
                t.SubId = SubId;
                t.ChapId = ChapId;
                db.TestPapers.Add(t);
                db.SaveChanges();
                return t.Id;
            }
        }
    
    }
}