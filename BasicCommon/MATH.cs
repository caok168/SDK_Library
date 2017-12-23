using BasicCommon.Model.Request;
using BasicCommon.Model.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BasicCommon
{
    public class MATH
    {
        MATHProcess.Process mathProcess = new MATHProcess.Process();

        [DispId(200)]
        public string GetAbsMaxValue(string json)
        {
            Response resultInfo = new Response();
            try
            {
                MATHRequest request = JsonConvert.DeserializeObject<MATHRequest>(json);

                double value = mathProcess.GetAbsMaxValue(request.data);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(value);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(201)]
        public string GetMinValue(string json)
        {
            Response resultInfo = new Response();
            try
            {
                MATHRequest request = JsonConvert.DeserializeObject<MATHRequest>(json);

                double value = mathProcess.GetMinValue(request.data);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(value);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(202)]
        public string GetAvgValue(string json)
        {
            Response resultInfo = new Response();
            try
            {
                MATHRequest request = JsonConvert.DeserializeObject<MATHRequest>(json);

                double value = mathProcess.GetAvgValue(request.data);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(value);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(203)]
        public string GetResultByTwoArray(string json)
        {
            Response resultInfo = new Response();
            try
            {
                MATHRequest request = JsonConvert.DeserializeObject<MATHRequest>(json);

                double[] value = mathProcess.GetResultByTwoArray(request.data1,request.data2,request.operation);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(value);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(204)]
        public string GetResultByConst(string json)
        {
            Response resultInfo = new Response();
            try
            {
                MATHRequest request = JsonConvert.DeserializeObject<MATHRequest>(json);

                double[] value = mathProcess.GetResultByConst(request.data,request.constvalue,request.operation);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(value);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(205)]
        public string GetSubResult(string json)
        {
            Response resultInfo = new Response();
            try
            {
                MATHRequest request = JsonConvert.DeserializeObject<MATHRequest>(json);

                double[] value = mathProcess.GetSubResult(request.data, request.condition1, request.value1, request.condition2, request.value2);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(value);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(206)]
        public string GetAbsValue(string json)
        {
            Response resultInfo = new Response();
            try
            {
                MATHRequest request = JsonConvert.DeserializeObject<MATHRequest>(json);

                double[] value = mathProcess.GetAbsValue(request.data);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(value);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(207)]
        public string GetLineInsertValue(string json)
        {
            Response resultInfo = new Response();
            try
            {
                MATHRequest request = JsonConvert.DeserializeObject<MATHRequest>(json);

                double[] value = mathProcess.GetLineInsertValue(request.data,request.insertvalue);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(value);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(208)]
        public string GetSumValue(string json)
        {
            Response resultInfo = new Response();
            try
            {
                MATHRequest request = JsonConvert.DeserializeObject<MATHRequest>(json);

                double value = mathProcess.GetSumValue(request.data);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(value);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(209)]
        public string GetStandardValue(string json)
        {
            Response resultInfo = new Response();
            try
            {
                MATHRequest request = JsonConvert.DeserializeObject<MATHRequest>(json);

                double value = mathProcess.GetStandardValue(request.data);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(value);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

    }
}
