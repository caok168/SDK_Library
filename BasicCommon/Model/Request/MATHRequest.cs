using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCommon.Model.Request
{
    public class MATHRequest
    {
        public double[] data { get; set; }

        public double[] data1 { get; set; }

        public double[] data2 { get; set; }

        public string operation { get; set; }

        public double constvalue { get; set; }

        public string condition1 { get; set; }

        public double value1 { get; set; }

        public string condition2 { get; set; }

        public double value2 { get; set; }

        /// <summary>
        /// 用于线性插值
        /// </summary>
        public double insertvalue { get; set; }
    }
}
