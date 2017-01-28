using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hello.Models {
    public class ResponseModel {
        public int i { get; set; }
        public int j { get; set; }
        public int iterationNumber { get; set; }
        public List<int> results;

    }
}