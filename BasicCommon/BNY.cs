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
    public class BNY
    {
        BNYProcess.Process bnyProcess = new BNYProcess.Process();

        [DispId(1)]
        public string GetBNYLastPosition(string json)
        {
            Response resultInfo = new Response();
            try
            {
                BNYRequest request = JsonConvert.DeserializeObject<BNYRequest>(json);

                if (String.IsNullOrEmpty(request.path))
                {
                    resultInfo.flag = 0;
                    resultInfo.msg = "BNY文件路径不能为空";

                    return JsonConvert.SerializeObject(resultInfo);
                }

                long position = bnyProcess.GetBNYLastPosition(request.path);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(position);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(2)]
        public string GetBNYStartMile(string json)
        {
            Response resultInfo = new Response();
            try
            {
                BNYRequest request = JsonConvert.DeserializeObject<BNYRequest>(json);

                if (String.IsNullOrEmpty(request.path))
                {
                    resultInfo.flag = 0;
                    resultInfo.msg = "BNY文件路径不能为空";

                    return JsonConvert.SerializeObject(resultInfo);
                }

                float result = bnyProcess.GetBNYStartMile(request.path);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(3)]
        public string GetBNYEndMile(string json)
        {
            Response resultInfo = new Response();
            try
            {
                BNYRequest request = JsonConvert.DeserializeObject<BNYRequest>(json);

                if (String.IsNullOrEmpty(request.path))
                {
                    resultInfo.flag = 0;
                    resultInfo.msg = "BNY文件路径不能为空";

                    return JsonConvert.SerializeObject(resultInfo);
                }

                float result = bnyProcess.GetBNYEndMile(request.path);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(4)]
        public string GetMilePosition(string json)
        {
            Response resultInfo = new Response();
            try
            {
                BNYRequest request = JsonConvert.DeserializeObject<BNYRequest>(json);

                if (String.IsNullOrEmpty(request.path))
                {
                    resultInfo.flag = 0;
                    resultInfo.msg = "BNY文件路径不能为空";

                    return JsonConvert.SerializeObject(resultInfo);
                }

                long position = bnyProcess.GetMilePosition(request.path,request.isinc,request.mile);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(position);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(5)]
        public string GetMilePostions(string json)
        {
            Response resultInfo = new Response();
            try
            {
                BNYRequest request = JsonConvert.DeserializeObject<BNYRequest>(json);

                if (String.IsNullOrEmpty(request.path))
                {
                    resultInfo.flag = 0;
                    resultInfo.msg = "BNY文件路径不能为空";

                    return JsonConvert.SerializeObject(resultInfo);
                }

                long[] positions = bnyProcess.GetMilePostions(request.path,request.isinc,request.startmile,request.endmile);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(positions);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(6)]
        public string GetBNYData(string json)
        {
            Response resultInfo = new Response();
            try
            {
                BNYRequest request = JsonConvert.DeserializeObject<BNYRequest>(json);

                if (String.IsNullOrEmpty(request.path))
                {
                    resultInfo.flag = 0;
                    resultInfo.msg = "BNY文件路径不能为空";

                    return JsonConvert.SerializeObject(resultInfo);
                }

                List<float[]> datas = bnyProcess.GetBNYData(request.path,request.startfilepos,request.endfilepos);

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(datas);
            }
            catch (Exception ex)
            {
                resultInfo.flag = 0;
                resultInfo.msg = ex.Message;
            }

            return JsonConvert.SerializeObject(resultInfo);
        }

        [DispId(7)]
        public string GetChannelNameList(string json)
        {
            Response resultInfo = new Response();
            try
            {
                BNYRequest request = JsonConvert.DeserializeObject<BNYRequest>(json);

                if (String.IsNullOrEmpty(request.path))
                {
                    resultInfo.flag = 0;
                    resultInfo.msg = "BNY文件路径不能为空";

                    return JsonConvert.SerializeObject(resultInfo);
                }

                var models = bnyProcess.GetChannelNameList();

                resultInfo.flag = 1;
                resultInfo.msg = "Success";
                resultInfo.data = JsonConvert.SerializeObject(models);
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
