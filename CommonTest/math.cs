using BasicCommon.Model.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonTest
{
    public class math
    {
        BasicCommon.MATH mathObj = new BasicCommon.MATH();

        public void Test()
        {
            MATHRequest request = new MATHRequest();
            request.data = new double[] { 12, 13, 14, 15 };
            request.data1 = new double[] { 12, 13, 14, 15 };
            request.data2 = new double[] { 12, 13, 14, 15 };
            request.insertvalue = 3;
            request.operation = "+";
            request.value1 = 10;
            request.value2 = 12;
            request.condition1 = ">";
            request.condition2 = ">";
            request.constvalue = 4;

            string json = JsonConvert.SerializeObject(request);

            string result = mathObj.GetAbsMaxValue(json);

            result = mathObj.GetMinValue(json);

            result = mathObj.GetAvgValue(json);

            result = mathObj.GetResultByTwoArray(json);

            result = mathObj.GetResultByConst(json);

            result = mathObj.GetSubResult(json);

            result = mathObj.GetAbsValue(json);

            result = mathObj.GetLineInsertValue(json);

            result = mathObj.GetSumValue(json);

            result = mathObj.GetStandardValue(json);
        }
    }
}
