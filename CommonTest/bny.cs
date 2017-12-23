using BasicCommon.Model.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonTest
{
    public class bny
    {
        BasicCommon.BNY bnytest = new BasicCommon.BNY();
        public void Test()
        {
            string bnyPath = @"H:\工作文件汇总\铁科院\程序\轨检二期\任务\bny工具文档\20170407广深港上行线（福田~广州南）_001.bny";

            BNYRequest request = new BNYRequest();
            request.path = bnyPath;
            request.isinc = false;
            request.mile = 2310;
            request.startmile = 2300;
            request.endmile = 2400;

            request.startfilepos = 29443392;
            request.endfilepos = 29448000;

            string json = JsonConvert.SerializeObject(request);

            string result = bnytest.GetBNYLastPosition(json);

            result = bnytest.GetBNYStartMile(json);

            result = bnytest.GetBNYEndMile(json);

            result = bnytest.GetMilePosition(json);

            result = bnytest.GetMilePostions(json);

            result = bnytest.GetBNYData(json);

            result = bnytest.GetChannelNameList(json);

            json = JsonConvert.SerializeObject(request);
        }
    }
}
