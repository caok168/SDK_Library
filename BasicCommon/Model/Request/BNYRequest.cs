using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCommon.Model.Request
{
    public class BNYRequest
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// 是否为增里程
        /// </summary>
        public bool isinc { get; set; }

        /// <summary>
        /// 里程
        /// </summary>
        public float mile { get; set; }

        /// <summary>
        /// 开始里程
        /// </summary>
        public float startmile { get; set; }

        /// <summary>
        /// 结束里程
        /// </summary>
        public float endmile { get; set; }

        /// <summary>
        /// 通道序号
        /// </summary>
        public int[] channelnums { get; set; }

        /// <summary>
        /// 文件开始指针位置
        /// </summary>
        public long startfilepos { get; set; }

        /// <summary>
        /// 文件结束指针位置
        /// </summary>
        public long endfilepos { get; set; }
    }
}
