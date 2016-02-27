using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AptitudorService.Model
{
    public class TestDetails
    {

        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int Test_Time { get; set; }
        public int Test_Max { get; set; }
    }
}