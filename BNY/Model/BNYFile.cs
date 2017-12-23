using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BNYProcess.Model
{
    public class BNYFile
    {
        /// <summary>
        /// 一个通道占用4个字节
        /// </summary>
        public static int OneByteSize = 4;

        /// <summary>
        /// BNY文件包括18个通道
        /// 通道依次是
        /// 【时间、里程、综合里程、速度、
        /// 左垂力、左横力、右垂力、右横力、
        /// 车体横加、车体垂加、车体纵加、
        /// 陀螺仪、构架垂、构架横、
        /// 左轴箱加、右轴箱加、曲率、ALD】
        /// 这些通道。
        /// </summary>
        public static int ChannelNum = 18;

        /// <summary>
        /// 一个采样点所占的字节大小
        /// </summary>
        /// <returns></returns>
        public static int GetChannelSize()
        {
            return OneByteSize * ChannelNum;
        }

    }
}
