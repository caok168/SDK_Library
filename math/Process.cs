using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MATHProcess
{
    public class Process
    {
        /// <summary>
        /// 计算数组的绝对值的最大值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double GetAbsMaxValue(double[] data)
        {
            if (data.Length == 0)
            {
                throw new Exception("数组不能为空");
            }
            try
            {
                double result = 0.0;

                for (int i = 0; i < data.Length; i++)
                {
                    if (Math.Abs(data[i]) > result)
                    {
                        result = Math.Abs(data[i]);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 计算数组的最小值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double GetMinValue(double[] data)
        {
            if (data.Length == 0)
            {
                throw new Exception("数组不能为空");
            }

            try
            {
                double result = data.Min();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 计算数组的平均值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double GetAvgValue(double[] data)
        {
            if (data.Length == 0)
            {
                throw new Exception("数组不能为空");
            }

            try
            {
                double result = 0.0;
                result = data.Average();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 计算两个数组的加减乘除
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <returns></returns>
        public double[] GetResultByTwoArray(double[] data1, double[] data2,string operation)
        {
            if (data1.Length == 0 || data2.Length == 0)
            {
                throw new Exception("数组不能为空");
            }
            if (data1.Length != data2.Length)
            {
                throw new Exception("两个数组的个数不相同");
            }
            string operations = "+,-,*,/";
            if (!operations.Contains(operation))
            {
                throw new Exception("输入的操作符不符合格式，请输入+,-,*,/其中一个");
            }
            double[] result = new double[data1.Length];
            switch (operation)
            {
                case "+":
                    for (int i = 0; i < data1.Length; i++)
                    {
                        result[i] = data1[i] + data2[i];
                    }
                    break;
                case "-":
                    for (int i = 0; i < data1.Length; i++)
                    {
                        result[i] = data1[i] - data2[i];
                    }
                    break;
                case "*":
                    for (int i = 0; i < data1.Length; i++)
                    {
                        result[i] = data1[i] * data2[i];
                    }
                    break;
                case "/":
                    for (int i = 0; i < data1.Length; i++)
                    {
                        if (data2[i] == 0)
                        {
                            throw new Exception("第二个数组中含有为0的元素，不能进行除法");
                        }
                        result[i] = data1[i] / data2[i];
                    }
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// 数组和常数进行加减乘除
        /// </summary>
        /// <param name="data"></param>
        /// <param name="constData"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public double[] GetResultByConst(double[] data, double constData, string operation)
        {
            if (data.Length == 0)
            {
                throw new Exception("数组的个数不能为空");
            }
            string operations = "+,-,*,/";
            if (!operations.Contains(operation))
            {
                throw new Exception("输入的操作符不符合格式，请输入+,-,*,/其中一个");
            }
            double[] result = new double[data.Length];

            switch (operation)
            {
                case "+":
                    for (int i = 0; i < data.Length; i++)
                    {
                        result[i] = data[i] + constData;
                    }
                    break;
                case "-":
                    for (int i = 0; i < data.Length; i++)
                    {
                        result[i] = data[i] - constData;
                    }
                    break;
                case "*":
                    for (int i = 0; i < data.Length; i++)
                    {
                        result[i] = data[i] * constData;
                    }
                    break;
                case "/":
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (constData == 0)
                        {
                            throw new Exception("在除法的情况下，常数不能为0");
                        }
                        result[i] = data[i] / constData;
                    }
                    break;
                default:
                    throw new Exception("输入的操作符不符合格式，请输入+,-,*,/其中一个");
                    break;
            }
            return result;
        }

        /// <summary>
        /// 获取数组的子集
        /// </summary>
        /// <param name="data"></param>
        /// <param name="condition1"></param>
        /// <param name="value1"></param>
        /// <param name="condition2"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public double[] GetSubResult(double[] data, string condition1, double value1, string condition2, double value2)
        {
            if (data.Length == 0)
            {
                throw new Exception("数组的个数不能为空");
            }
            string conditions = "=,<,<=,>,>=";
            
            if (String.IsNullOrEmpty(condition1))
            {
                throw new Exception("条件一不能为空");
            }

            if (!conditions.Contains(condition1))
            {
                throw new Exception("输入的条件一不符合格式，请输入=,<,<=,>,>=其中一个");
            }
            if (!String.IsNullOrEmpty(condition2))
            {
                if (!conditions.Contains(condition2))
                {
                    throw new Exception("输入的条件二不符合格式，请输入=,<,<=,>,>=其中一个");
                }
            }

            List<double> listResult = new List<double>();
            switch (condition1)
            {
                case "=":
                    listResult = data.Where(s => s == value1).ToList();
                    break;
                case "<":
                    listResult = data.Where(s => s < value1).ToList();
                    break;
                case "<=":
                    listResult = data.Where(s => s <= value1).ToList();
                    break;
                case ">":
                    listResult = data.Where(s => s > value1).ToList();
                    break;
                case ">=":
                    listResult = data.Where(s => s >= value1).ToList();
                    break;
                default:
                    break;
            }
            if (!String.IsNullOrEmpty(condition2))
            {
                switch (condition2)
                {
                    case "=":
                        listResult = listResult.Where(s => s == value1).ToList();
                        break;
                    case "<":
                        listResult = listResult.Where(s => s < value1).ToList();
                        break;
                    case "<=":
                        listResult = listResult.Where(s => s <= value1).ToList();
                        break;
                    case ">":
                        listResult = listResult.Where(s => s > value1).ToList();
                        break;
                    case ">=":
                        listResult = listResult.Where(s => s >= value1).ToList();
                        break;
                    default:
                        break;
                }
            }

            return listResult.ToArray();
        }

        /// <summary>
        /// 获取数组的绝对值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double[] GetAbsValue(double[] data)
        {
            if(data.Length==0)
            {
                throw new Exception("数组的个数不能为空");
            }
            double[] result = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = Math.Abs(data[i]);
            }

            return result;
        }

        /// <summary>
        /// 线性插值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public double[] GetLineInsertValue(double[] data, double a)
        {
            try
            {
                if (data.Length == 0)
                {
                    throw new Exception("数组的个数不能为空");
                }
                double[] result = new double[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    if (i != data.Length - 1)
                    {
                        result[i] = data[i] + (data[i + 1] - data[i]) * a;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取数组的和
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double GetSumValue(double[] data)
        {
            try
            {
                if (data.Length == 0)
                {
                    throw new Exception("数组的个数不能为空");
                }
                return data.Sum();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取数组的标准差值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double GetStandardValue(double[] data)
        {
            try
            {
                if (data.Length == 0)
                {
                    throw new Exception("数组的个数不能为空");
                }

                double dResult = 0;
                double dSum = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    dSum += data[i];
                }
                dSum /= data.Length;
                double dAve = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    dAve += Math.Pow((data[i] - dSum), 2);
                }
                dAve /= data.Length;
                dResult = Math.Pow(dAve, 0.5);

                return dResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
