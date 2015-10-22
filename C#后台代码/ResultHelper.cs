using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huoqishi.ISC
{
    /// <summary>
    /// 对插入的数据进行处理，并返回其他类型的结果
    /// </summary>
    public class ResultHelper
    {
        /// <summary>
        /// 只有当result==1时返回true
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool GetResultOne(int result)
        {
            if (result==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 当result>=1时返回true
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool GetResult(int result)
        {
            if (result >=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
