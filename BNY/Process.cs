using BNYProcess.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BNYProcess
{
    /// <summary>
    /// BNY操作类
    /// </summary>
    public class Process
    {
        /// <summary>
        /// 获取BNY文件的长度
        /// </summary>
        /// <param name="bnyFilePath">bny文件路径</param>
        /// <returns>bny文件的长度</returns>
        public long GetBNYLastPosition(string bnyFilePath)
        {
            try
            {
                FileStream fs = new FileStream(bnyFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs, Encoding.Default);

                long position = br.BaseStream.Length;

                br.Close();
                fs.Close();

                return position;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取BNY文件的开始里程
        /// </summary>
        /// <param name="bnyFilePath">bny文件路径</param>
        /// <returns>开始里程</returns>
        public float GetBNYStartMile(string bnyFilePath)
        {
            try
            {
                FileStream fs = new FileStream(bnyFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs, Encoding.Default);
                br.BaseStream.Position = 0;

                int iChannelNumberSize = BNYFile.GetChannelSize();

                byte[] b = new byte[iChannelNumberSize];
                b = br.ReadBytes(iChannelNumberSize);

                float fGL = (BitConverter.ToSingle(b, (3 - 1) * BNYFile.OneByteSize));

                br.Close();
                fs.Close();

                return fGL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取BNY文件的结束里程
        /// </summary>
        /// <param name="bnyFilePath">bny文件路径</param>
        /// <returns>结束里程</returns>
        public float GetBNYEndMile(string bnyFilePath)
        {
            try
            {
                FileStream fs = new FileStream(bnyFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs, Encoding.Default);
                br.BaseStream.Position = 0;

                int iChannelNumberSize = BNYFile.GetChannelSize();

                br.BaseStream.Position = br.BaseStream.Length - iChannelNumberSize;

                byte[] b = new byte[iChannelNumberSize];
                b = br.ReadBytes(iChannelNumberSize);

                float fGL = (BitConverter.ToSingle(b, (3 - 1) * BNYFile.OneByteSize));

                br.Close();
                fs.Close();

                return fGL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取BNY文件里程的位置
        /// </summary>
        /// <param name="bnyFilePath">bny文件路径</param>
        /// <param name="isInc">是否为增里程</param>
        /// <param name="mile">里程</param>
        /// <returns>位置</returns>
        public long GetMilePosition(string bnyFilePath, bool isInc, float mile)
        {
            try
            {
                long position = -1;

                FileStream fs = new FileStream(bnyFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs, Encoding.Default);
                br.BaseStream.Position = 0;

                int iChannelNumberSize = BNYFile.GetChannelSize();
                long endFilePos = br.BaseStream.Length;

                int sampleNum = Convert.ToInt32(endFilePos / iChannelNumberSize);

                byte[] b = new byte[iChannelNumberSize];


                for (int i = 0; i < sampleNum; i++)
                {
                    b = br.ReadBytes(iChannelNumberSize);

                    float fGL = (BitConverter.ToSingle(b, (3 - 1) * BNYFile.OneByteSize));

                    if (isInc)
                    {
                        if (fGL >= mile)
                        {
                            position = br.BaseStream.Position - iChannelNumberSize;
                            break;
                        }
                    }
                    else
                    {
                        if (fGL <= mile)
                        {
                            position = br.BaseStream.Position - iChannelNumberSize;
                            break;
                        }
                    }
                }
                br.Close();
                fs.Close();

                return position;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取BNY文件里指定里程的位置点信息
        /// </summary>
        /// <param name="bnyFilePath">bny文件路径</param>
        /// <param name="isInc">是否为增里程</param>
        /// <param name="startmile">开始里程</param>
        /// <param name="endmile">结束里程</param>
        /// <returns>开始里程、结束里程对应的位置数组</returns>
        public long[] GetMilePostions(string bnyFilePath, bool isInc, float startmile, float endmile)
        {
            try
            {
                long[] positions = new long[2];
                long startpos = 0;
                long endpos = 0;

                startpos = GetMilePosition(bnyFilePath, isInc, startmile);
                endpos = GetMilePosition(bnyFilePath, isInc, endmile);
                if (startpos != -1 && endpos != -1)
                {
                    if (startpos < endpos)
                    {
                        positions[0] = startpos;
                        positions[1] = endpos;
                    }
                    else
                    {
                        positions[0] = endpos;
                        positions[1] = startpos;
                    }
                }
                return positions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询指定采样点的BNY数据集合
        /// </summary>
        /// <param name="bnyFilePath">bny文件路径</param>
        /// <param name="sampleNum">采样点个数</param>
        /// <param name="startFilePos">开始位置</param>
        /// <param name="endFilePos">结束位置</param>
        /// <returns>数据集合</returns>
        public List<float[]> GetBNYData(string bnyFilePath, int sampleNum, long startFilePos, ref long endFilePos)
        {
            try
            {
                FileStream fs = new FileStream(bnyFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs, Encoding.Default);
                br.BaseStream.Position = startFilePos;

                int iChannelNumberSize = BNYFile.GetChannelSize();
                endFilePos = startFilePos + iChannelNumberSize * sampleNum;

                if (endFilePos > br.BaseStream.Length)
                {
                    endFilePos = br.BaseStream.Length;

                    sampleNum = Convert.ToInt32((endFilePos - startFilePos) / iChannelNumberSize);
                }

                byte[] b = new byte[iChannelNumberSize];

                List<float[]> allList = new List<float[]>();
                for (int i = 0; i < BNYFile.ChannelNum; i++)
                {
                    float[] array = new float[sampleNum];
                    allList.Add(array);
                }

                for (int i = 0; i < sampleNum; i++)
                {
                    b = br.ReadBytes(iChannelNumberSize);

                    for (int channelId = 1; channelId <= BNYFile.ChannelNum; channelId++)
                    {
                        float fGL = (BitConverter.ToSingle(b, (channelId - 1) * BNYFile.OneByteSize));

                        allList[channelId - 1][i] = fGL;
                    }
                }
                br.Close();
                fs.Close();

                return allList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询指定采样点的BNY数据集合
        /// </summary>
        /// <param name="bnyFilePath">bny文件路径</param>
        /// <param name="channelNums">通道号数组</param>
        /// <param name="sampleNum">采样点个数</param>
        /// <param name="startFilePos">开始位置</param>
        /// <param name="endFilePos">结束位置</param>
        /// <returns>数据集合</returns>
        public List<float[]> GetBNYData(string bnyFilePath, int[] channelNums, int sampleNum, long startFilePos, ref long endFilePos)
        {
            try
            {
                FileStream fs = new FileStream(bnyFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs, Encoding.Default);
                br.BaseStream.Position = startFilePos;

                int iChannelNumberSize = BNYFile.GetChannelSize();
                endFilePos = startFilePos + iChannelNumberSize;

                if (endFilePos > br.BaseStream.Length)
                {
                    endFilePos = br.BaseStream.Length;

                    sampleNum = Convert.ToInt32((endFilePos - startFilePos) / iChannelNumberSize);
                }

                byte[] b = new byte[iChannelNumberSize];

                List<float[]> allList = new List<float[]>();

                int channelCount = channelNums.Length;

                for (int i = 0; i < channelCount; i++)
                {
                    float[] array = new float[sampleNum];
                    allList.Add(array);
                }

                for (int i = 0; i < sampleNum; i++)
                {
                    b = br.ReadBytes(iChannelNumberSize);

                    for (int j = 0; j < channelCount; j++)
                    {
                        float fGL = (BitConverter.ToSingle(b, (channelNums[j] - 1) * BNYFile.OneByteSize));

                        allList[j][i] = fGL;
                    }
                }
                br.Close();
                fs.Close();

                return allList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询指定区间位置的BNY数据集合
        /// </summary>
        /// <param name="bnyFilePath">bny文件路径</param>
        /// <param name="startFilePos">开始位置</param>
        /// <param name="endFilePos">结束位置</param>
        /// <returns>数据集合</returns>
        public List<float[]> GetBNYData(string bnyFilePath, long startFilePos, long endFilePos)
        {
            try
            {
                FileStream fs = new FileStream(bnyFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs, Encoding.Default);
                br.BaseStream.Position = startFilePos;

                int iChannelNumberSize = BNYFile.GetChannelSize();

                if (endFilePos > br.BaseStream.Length)
                {
                    endFilePos = br.BaseStream.Length;
                }

                int sampleNum = Convert.ToInt32((endFilePos - startFilePos) / iChannelNumberSize);

                byte[] b = new byte[iChannelNumberSize];

                List<float[]> allList = new List<float[]>();
                for (int i = 0; i < BNYFile.ChannelNum; i++)
                {
                    float[] array = new float[sampleNum];
                    allList.Add(array);
                }

                for (int i = 0; i < sampleNum; i++)
                {
                    b = br.ReadBytes(iChannelNumberSize);

                    for (int channelId = 1; channelId <= BNYFile.ChannelNum; channelId++)
                    {
                        float fGL = (BitConverter.ToSingle(b, (channelId - 1) * BNYFile.OneByteSize));

                        allList[channelId - 1][i] = fGL;
                    }
                }
                br.Close();
                fs.Close();

                return allList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        

        /// <summary>
        /// 获取通道信息
        /// </summary>
        /// <returns></returns>
        public List<BNYChannel> GetChannelNameList()
        {
            List<BNYChannel> list = new List<BNYChannel>();

            string[] channelNames = GetChannelNames();
            for (int i = 0; i < channelNames.Length; i++)
            {
                BNYChannel channel = new BNYChannel();
                channel.ID = i + 1;
                channel.ChannelName = channelNames[i];

                list.Add(channel);
            }

            return list;
        }


        #region 私有方法
        /// <summary>
        /// 初始化通道名称
        /// </summary>
        /// <returns></returns>
        private string[] GetChannelNames()
        {
            string[] channelNames = new string[18];

            channelNames[0] = "时间";
            channelNames[1] = "里程";
            channelNames[2] = "综合里程";
            channelNames[3] = "速度";
            channelNames[4] = "左垂力";
            channelNames[5] = "左横力";
            channelNames[6] = "右垂力";
            channelNames[7] = "右横力";
            channelNames[8] = "车体横加";
            channelNames[9] = "车体垂加";
            channelNames[10] = "车体纵加";
            channelNames[11] = "陀螺仪";
            channelNames[12] = "构架垂";
            channelNames[13] = "构架横";
            channelNames[14] = "左轴箱加";
            channelNames[15] = "右轴箱加";
            channelNames[16] = "曲率";
            channelNames[17] = "ALD";

            return channelNames;
        }

        /// <summary>
        /// 将long类型的时间转换为DateTime类型
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private DateTime ConvertLongDateTime(long d)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(d + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime dtResult = dtStart.Add(toNow);
            return dtResult;
        }

        #endregion
    }
}
