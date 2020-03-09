using System;
using System.IO;
using OSGeo.GDAL;
using OSGeo.OGR;
using System.Reflection;

namespace ManhValvCalculation.Class.Util
{

    /// <summary>
    /// GDAL 라이브러리 초기화를 위한 설정 자동화
    /// </summary>
    public static class GdalConfiguration
    {
        private static volatile bool _configuredOgr = false;
        private static volatile bool _configuredGdal = false;

        /// <summary>
        /// 어떤 플랫폼인지 판단
        /// </summary>
        private static string GetPlatform()
        {
            return (!Environment.Is64BitProcess) ? "x86" : "x64";
        }


        /// <summary>
        /// Gdal/Ogr의 초기화
        /// </summary>
        private static void GdalConfig()
        {
            var executingAssemblyFile = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            var executingDirectory = Path.GetDirectoryName(executingAssemblyFile);

            if (string.IsNullOrEmpty(executingDirectory))
                throw new InvalidOperationException("cannot get executing directory");


            var gdalPath = Path.Combine(executingDirectory, "gdal");
            var nativePath = Path.Combine(gdalPath, GetPlatform());

            // Prepend native path to environment path, to ensure the
            // right libs are being used.
            var path = Environment.GetEnvironmentVariable("PATH");
            path = nativePath + ";" + Path.Combine(nativePath, "plugins") + ";";// +path;
            Environment.SetEnvironmentVariable("PATH", path);//,EnvironmentVariableTarget.Process);

            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
            // Set the additional GDAL environment variables.
            var gdalData = Path.Combine(gdalPath, "data");
            Environment.SetEnvironmentVariable("GDAL_DATA", gdalData, EnvironmentVariableTarget.Process);
            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_DATA", gdalData);

            var driverPath = Path.Combine(nativePath, "plugins");
            Environment.SetEnvironmentVariable("GDAL_DRIVER_PATH", driverPath, EnvironmentVariableTarget.Process);
            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_DRIVER_PATH", driverPath);

            Environment.SetEnvironmentVariable("GEOTIFF_CSV", gdalData, EnvironmentVariableTarget.Process);
            OSGeo.GDAL.Gdal.SetConfigOption("GEOTIFF_CSV", gdalData);

            var projSharePath = Path.Combine(gdalPath, "share");
            Environment.SetEnvironmentVariable("PROJ_LIB", projSharePath, EnvironmentVariableTarget.Process);
            OSGeo.GDAL.Gdal.SetConfigOption("PROJ_LIB", projSharePath);
        }

        /// <summary>
        /// Method to ensure the static constructor is being called.
        /// </summary>
        /// <remarks>Be sure to call this function before using Gdal/Ogr/Osr</remarks>
        public static void ConfigureOgr()
        {
            if (_configuredOgr) return;
            GdalConfig();
            // Register drivers
            Ogr.RegisterAll();
            _configuredOgr = true;

            PrintDriversOgr();
        }

        /// <summary>
        /// Method to ensure the static constructor is being called.
        /// </summary>
        /// <remarks>Be sure to call this function before using Gdal/Ogr/Osr</remarks>
        public static void ConfigureGdal()
        {

            if (_configuredGdal) return;
            GdalConfig();
            // Register drivers
            Gdal.AllRegister();
            _configuredGdal = true;

            PrintDriversGdal();
        }

        private static void PrintDriversOgr()
        {
#if DEBUG
            var num = Ogr.GetDriverCount();
            for (var i = 0; i < num; i++)
            {
                var driver = Ogr.GetDriver(i);
                Console.WriteLine(string.Format("OGR {0}: {1}", i, driver.name));
            }
#endif
        }

        private static void PrintDriversGdal()
        {
#if DEBUG
            var num = Gdal.GetDriverCount();
            for (var i = 0; i < num; i++)
            {
                var driver = Gdal.GetDriver(i);
                Console.WriteLine(string.Format("GDAL {0}: {1}-{2}", i, driver.ShortName, driver.LongName));
            }
#endif
        }
    }
}
