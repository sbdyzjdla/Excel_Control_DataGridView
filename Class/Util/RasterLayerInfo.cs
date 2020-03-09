using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSGeo.OGR;
using OSGeo.GDAL;
using System.Windows.Forms;
using OilPipe.Class.Util;

namespace OilPipe.Class.Util
{
    public class RasterLayerInfo
    {

        private Dataset demDataset;
        private double[] transform;
        /// <summary>
        /// 이미지 높이
        /// </summary>
        private double xOrigin;
        private double yOrigin;
        private double width;
        private double height;
        private double pixelWidth;
        private double pixelHeight;

        /// <summary>
        /// 밴드
        /// </summary>
        private Band band;

        /// DEM 파일 경로
        private String demFilepath;

        private int MULTI_THREAD_COUNT = 10;

        public RasterLayerInfo(String DemFilepath)
        {
            if (String.IsNullOrWhiteSpace(DemFilepath))
                throw new ArgumentNullException();

            GdalConfiguration.ConfigureGdal();

            //Ogr.RegisterAll();
            Gdal.AllRegister();

            demDataset = Gdal.Open(DemFilepath, Access.GA_ReadOnly);

            if (demDataset != null)
            {

                //레스터 밴드 확인
                int bandCount = demDataset.RasterCount;

                if (bandCount > 1)
                {
                    MessageBox.Show("DEM 파일이 싱글밴드가 아닙니다.");
                }
                else
                {
                    this.demFilepath = DemFilepath;
                    this.transform = new double[6];

                    demDataset.GetGeoTransform(transform);
                    this.height = demDataset.RasterYSize;
                    this.width = demDataset.RasterXSize;

                    this.xOrigin = transform[0];
                    this.yOrigin = transform[3];
                    this.pixelWidth = transform[1];
                    this.pixelHeight = transform[5];
                    this.band = demDataset.GetRasterBand(1);

                }

            }
            else
            {
                MessageBox.Show("DEM 파일을 읽을 수 없습니다.");
            }

        }

        ~RasterLayerInfo()
        {
            demDataset.Dispose();
        }

        public double getHeight(double x, double y)
        {

            int xOffset = (int)((x - this.xOrigin) / this.pixelWidth);
            int yOffset = (int)((y - this.yOrigin) / this.pixelHeight);
            //r = new double[width * height];
            if (xOffset < 0 || yOffset < 0 || xOffset > width - 1 || yOffset > height - 1)
            {
                Console.WriteLine("xOffset : " + xOffset);
                Console.WriteLine("xOrigin : " + this.xOrigin);
                Console.WriteLine("pixelWidth : " + this.pixelWidth);

                throw new Exception("좌표가 범위를 벗어났음. x: " + x + ", y: " + y);

            }


            double[] doublebuff = new double[4];
            try
            {
                // 중단 요청이있으면 Throw
                //rulyCanceler.ThrowIfCancellationRequested();

                var cplerror = band.ReadRaster(xOffset, yOffset, 2, 2, doublebuff, 2, 2, 0, 0);

                if (cplerror == CPLErr.CE_None)
                {
                    //doublebuff[3] = this.r[xOffset+1 + (yOffset+1) * width];

                    double p, q, a, b;
                    p = ((x - this.xOrigin) / this.pixelWidth) - xOffset;
                    q = 1 - p;
                    b = ((y - this.yOrigin) / this.pixelHeight) - yOffset;
                    a = 1 - b;

                    //return doublebuff[0];
                    //바이리니어 보간
                    double P = q * b * doublebuff[2] + q * a * doublebuff[0] + p * b * doublebuff[3] + p * a * doublebuff[1];

                    /*  doublebuff[0] --  doublebuff[1]
                     *        |        p(X,Y)        |
                     *  doublebuff[2] --  doublebuff[3]
                     */
                    //doublebuff[0] = this.r[xOffset + yOffset * width];
                    //doublebuff[1] = this.r[xOffset+1 + yOffset * width];
                    //doublebuff[2] = this.r[xOffset + (yOffset+1) * width];
                    //doublebuff[3] = this.r[xOffset+1 + (yOffset+1) * width];

                    return P;
                }
                else
                {
                    throw new Exception("CPLERR " + cplerror);
                }


            }
            catch (OperationCanceledException ex)
            {
                return double.NaN;
            }
            catch (Exception ex)
            {
                return Double.NaN;
            }

        }

    }
}
