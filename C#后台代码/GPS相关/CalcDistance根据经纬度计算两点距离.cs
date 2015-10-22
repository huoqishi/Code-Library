using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRK.Common
{
    /// <summary>
    /// 根据经纬度计算两点距离
    /// </summary>
    public class CalcDistance
    {
        private const double EARTH_RADIUS = 6378137D;//地球半径,单位m
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// 根据两点经纬度返回距离，单位m
        /// </summary>
        /// <param name="longitude1">经度1</param>
        /// <param name="latitude1">纬度1</param>
        /// <param name="longitude2"></param>
        /// <param name="latitude2"></param>
        /// 米为单位
        /// <returns></returns>
        public static double GetDistance(double longitude1, double latitude1, double longitude2, double latitude2)
        {
            double radLat1 = rad(latitude1);
            double radLat2 = rad(latitude2);
            double a = radLat1 - radLat2;
            double b = rad(longitude1) - rad(longitude2);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s*10000)/10000;
            return s;
        }
    }
}
