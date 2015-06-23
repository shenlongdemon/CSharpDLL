using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class UtilGeoGraph
    {
        public enum DistanceUnit
        {
            KM, 
            MILES, 
            NAUTICAL_MILES
        };

        public static double GetDistance(double lat1, double lon1, double lat2, double lon2, DistanceUnit unit)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case DistanceUnit.KM : //Kilometers -> default
                    return dist * 1.609344;
                case DistanceUnit.NAUTICAL_MILES: //Nautical Miles 
                    return dist * 0.8684;
                case DistanceUnit.MILES: //Miles
                    return dist;
            }

            return dist;
        }
        public static double GetDistance(GeoCoordinate p1, GeoCoordinate p2)
        {
            double d = p1.Latitude * 0.017453292519943295;
            double num3 = p1.Longitude * 0.017453292519943295;
            double num4 = p2.Latitude * 0.017453292519943295;
            double num5 = p2.Longitude * 0.017453292519943295;
            double num6 = num5 - num3;
            double num7 = num4 - d;
            double num8 = Math.Pow(Math.Sin(num7 / 2.0), 2.0) + ((Math.Cos(d) * Math.Cos(num4)) * Math.Pow(Math.Sin(num6 / 2.0), 2.0));
            double num9 = 2.0 * Math.Atan2(Math.Sqrt(num8), Math.Sqrt(1.0 - num8));
            return (6376500.0 * num9);
        }
        
    }
    /*
     
     namespace System.Data.Entity.Spatial
{
    [Serializable]
    public class DbGeography
     
     
     */
    /*
     function distance(lat1, lon1, lat2, lon2) {
  var R = 6371;
  var a = 
     0.5 - Math.cos((lat2 - lat1) * Math.PI / 180)/2 + 
     Math.cos(lat1 * Math.PI / 180) * Math.cos(lat2 * Math.PI / 180) * 
     (1 - Math.cos((lon2 - lon1) * Math.PI / 180))/2;

  return R * 2 * Math.asin(Math.sqrt(a));
}
     
     
     
     */

    /*
     CREATE FUNCTION [dbo].[DistanceBetween] (@Lat1 as real, 
                @Long1 as real, @Lat2 as real, @Long2 as real)
RETURNS real
AS
BEGIN

DECLARE @dLat1InRad as float(53);
SET @dLat1InRad = @Lat1 * (PI()/180.0);
DECLARE @dLong1InRad as float(53);
SET @dLong1InRad = @Long1 * (PI()/180.0);
DECLARE @dLat2InRad as float(53);
SET @dLat2InRad = @Lat2 * (PI()/180.0);
DECLARE @dLong2InRad as float(53);
SET @dLong2InRad = @Long2 * (PI()/180.0);

DECLARE @dLongitude as float(53);
SET @dLongitude = @dLong2InRad - @dLong1InRad;
DECLARE @dLatitude as float(53);
SET @dLatitude = @dLat2InRad - @dLat1InRad;
-- Intermediate result a.
DECLARE @a as float(53);
SET @a = SQUARE (SIN (@dLatitude / 2.0)) + COS (@dLat1InRad) 
                 * COS (@dLat2InRad) 
                 * SQUARE(SIN (@dLongitude / 2.0));
-- Intermediate result c (great circle distance in Radians).
DECLARE @c as real;
SET @c = 2.0 * ATN2 (SQRT (@a), SQRT (1.0 - @a));
DECLARE @kEarthRadius as real;
-- SET kEarthRadius = 3956.0 miles 
SET @kEarthRadius = 6376.5;        -- kms

DECLARE @dDistance as real;
SET @dDistance = @kEarthRadius * @c;
return (@dDistance);
END
     */


    /*  C
     
    #define SIM_Degree_to_Radian(x) ((float)x * 0.017453292F)
    #define SIM_PI_VALUE                         (3.14159265359)

    float GPS_Distance(float lat1, float lon1, float lat2, float lon2)
    {
       float theta;
       float dist;

       theta = lon1 - lon2;

       lat1 = SIM_Degree_to_Radian(lat1);
       lat2 = SIM_Degree_to_Radian(lat2);
       theta = SIM_Degree_to_Radian(theta);

       dist = (sin(lat1) * sin(lat2)) + (cos(lat1) * cos(lat2) * cos(theta));
       dist = acos(dist);

    //   dist = dist * 180.0 / SIM_PI_VALUE;
    //   dist = dist * 60.0 * 1.1515;
    //   // Convert to km
    //   dist = dist * 1.609344;

       dist *= 6370.693486F;

       return (dist);
    }
     
     */
}
