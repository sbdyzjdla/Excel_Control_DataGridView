using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OilPipe.Class.Util;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OilPipe.Class.Excel
{
    public class ExcelControl
    {

        string comboStart = "";
        string comboEnd = "";

        List<string> rList = new List<string>();
        List<string> keyList = new List<string>();


        public void addGrid(int rCnt, int cCnt, object[,] data, DataGridView dataGridView2, ComboBox combo_st, ComboBox combo_end, TextBox textBox_folder, ProgressBar progressBar1)
        {
            int countList;
            // Raster class create instance
            RasterLayerInfo rasterLayerInfo_dem = new RasterLayerInfo(Properties.Settings.Default.DEM);
            
            for (int i = 2; i < rCnt; ++i)
            {
                rList.Clear();
                for (int j = 1; j < cCnt; ++j)
                {
                    string rData = Convert.ToString(data[i, j]);
                    rList.Add(rData);

                }
                double raster_X = Convert.ToDouble(rList[2]);
                double raster_Y = Convert.ToDouble(rList[3]);
                double raster_Z = Convert.ToDouble(rList[4]);
                double oilDepth = rasterLayerInfo_dem.getHeight(raster_X, raster_Y);
                double qDep = oilDepth - raster_Z;
                qDep = Math.Abs(qDep);
                String dep_st = Convert.ToString(qDep);
                if (rList[0] == "") { break; }
                dataGridView2.Rows.Add(rList[0], rList[1], rList[2], rList[3], rList[4], oilDepth, dep_st);
                keyList.Add(rList[0] + " " + rList[1]);
                if (!combo_st.Items.Contains(rList[0])) { combo_st.Items.Add(rList[0]); }
                if (!combo_end.Items.Contains(rList[1])) { combo_end.Items.Add(rList[1]); }

            }
            countList = keyList.Count();
            keyList = keyList.Distinct().ToList();
            int keyListInt = Convert.ToInt32(keyList.Count());
            progressBar1.Step = (100 / keyListInt) - 1;
        
        }
        public List<string> keylist()
        {
            return keyList;
        }
    }
}
