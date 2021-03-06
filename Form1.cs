﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using OilPipe.Class.Util;
using OilPipe.Class.Excel;
using OilPipe.Class.Shape;
using Excel = Microsoft.Office.Interop.Excel;
using OSGeo.GDAL;
using OSGeo.OGR;
using Driver = OSGeo.OGR.Driver;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;
using MaterialSkin;
using MaterialSkin.Controls;


namespace OilPipe
{
    public partial class Form1 : MaterialForm
    {
        bool On;
        Point Pos;
        public Form1()
        {
            InitializeComponent();
          
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                    Primary.Purple400, Primary.Purple500,
                    Primary.Blue500, Accent.LightBlue200,
                    TextShade.WHITE
                );

            Progress.progress_init(progressBar1);
        }
        // Excel
        Excel.Workbook wb = null;
        Excel.Worksheet ws = null;
        Excel.Application ap = null;
        Excel.Workbook workbook = null;

        bool wbclose = false;

        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        string comboStart = "";
        string comboEnd = "";

        private Boolean filtering=false;

        List<string> rList = new List<string>();
        List<string> keyList = new List<string>();
        int countList;
        string excel_fileName = "";

        // Encoding
        Encoding encode = System.Text.Encoding.GetEncoding("ks_c_5601-1987");
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        //panel
        private Boolean mousing;
        private int startX, startY;

        string[] ConvertToStringArray(System.Array values)
        {
            // create a new string array
            string[] theArray = new string[values.Length];
            // loop through the 2-D System.Array and populate the 1-D String Array
            Console.WriteLine(values.Length);
            for (int i = 1; i <= values.Length; i++)
            {
                if (values.GetValue(i, 1) == null)
                    theArray[i - 1] = "";
                else
                    theArray[i - 1] = (string)values.GetValue(i, 1).ToString();
            }

            return theArray;
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Common.loadDirectory("EXCEL", false);
            openFile.DefaultExt = "xlsx";
            openFile.Filter = "Excel 파일(*.xlsx)|*.xlsx";
            openFile.ShowDialog();
            excel_fileName = openFile.FileName;
            if (openFile.FileNames.Length > 0)
            {
                foreach (string filename in openFile.FileNames)
                {
                    this.textBox_excel.Text = filename;
                }
            }
            Common.saveDirectory("EXCEL", this.textBox_excel.Text);

            
        }

        private void btn_sf_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog(); 
            dialog.ShowDialog();
            textBox_folder.Text = dialog.SelectedPath;
            Common.saveDirectory("FOLDER", this.textBox_folder.Text);
        }

        private void btn_dem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Common.loadDirectory("DEM", false);
            openFile.DefaultExt = "img";
            openFile.Filter = "Erdas Imagine(*.img)|*.img|GeoTiff(*.tif)|*.tif";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                foreach (string filename in openFile.FileNames)
                {
                    this.textBox_dem.Text = filename;
                }
            }
            Common.saveDirectory("DEM", this.textBox_dem.Text);
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (textBox_excel.Text == "")
            {
                MessageBox.Show("Excel 파일을 선택하세요");
            } else if(textBox_dem.Text == "") {
                MessageBox.Show("DEM 파일을 선택하세요");
            } 
            else
            {
                ap = new Microsoft.Office.Interop.Excel.Application();
                string directory = Properties.Settings.Default.EXCEL;
                workbook = ap.Workbooks.Open(Filename: directory);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

                //첫번째 Worksheet를 선택합니다.
                Excel.Range rng = worksheet.UsedRange;
                DataTable table = new DataTable();

                // 현재 Worksheet에서 사용된 셀 전체를 선택합니다.
                object[,] data = rng.Value;

                int rCnt = rng.Rows.Count;
                int cCnt = rng.Columns.Count;

                ExcelControl excelControl = new ExcelControl();
                excelControl.addGrid(rCnt, cCnt, data, dataGridView2, combo_st, combo_end, textBox_folder, progressBar1);
                keyList = excelControl.keylist();
                wbclose = true;
            }
        }


        private void btn_clear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        // Thread Testing
        private long Calc(long cnt)
        {
            long result = 0;
            for(long i=0; i< cnt; i++)
            {
                result += 2;
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboStart = combo_st.SelectedItem as string;
            comboEnd = combo_end.SelectedItem as string;

            Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            string directory = Properties.Settings.Default.EXCEL;
            workbook = ap.Workbooks.Open(Filename: directory);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

            //첫번째 Worksheet를 선택합니다.
            Excel.Range rng = worksheet.UsedRange;
            DataTable table = new DataTable();

            // 현재 Worksheet에서 사용된 셀 전체를 선택합니다.
            object[,] data = rng.Value;

            int rCnt = rng.Rows.Count;
            int cCnt = rng.Columns.Count;
            List<string> rList = new List<string>();
            double dem = 0.0, d_z = 0.0;
            string rData = "";

            RasterLayerInfo rasterLayerInfo = new RasterLayerInfo(Properties.Settings.Default.DEM);

            Thread thread = new Thread(new ThreadStart(delegate () // thread create
            {
                this.Invoke(new Action(delegate () //this == Form  ,  Form이 아닌 컨트롤의 Invoke를 직접호출해도 무방
                {

                    for (int i = 2; i < rCnt; ++i)
                    {
                        rList.Clear();
                        for (int j = 1; j < cCnt; ++j)
                        {
                            if (j == 7) break;
                            if (j == 5)
                            {
                                d_z = Convert.ToDouble(data[i, j]);
                            }
                            else if (j == 6)
                            {
                                dem = Convert.ToDouble(data[i, j]);
                            }
                            rData = Convert.ToString(data[i, j]);

                            rList.Add(rData);

                        }
                        if (rList[0] == comboStart && rList[1] == comboEnd)
                        {
                            double raster_X = Convert.ToDouble(rList[2]);
                            double raster_Y = Convert.ToDouble(rList[3]);

                            dem = rasterLayerInfo.getHeight(raster_X, raster_Y);
                            double dep = dem - d_z;
                            dep = Math.Abs(dep);
                            string dep_st = Convert.ToString(dep);
                            rList.Add(dep_st);
                            dataGridView1.Rows.Add(rList[0], rList[1], rList[2], rList[3], rList[4], dem, dep_st);
                        }
                        filtering = true;
                    }
                }));
            }));
            thread.Start();   // thread 실행하여 병렬작업 시작
            wbclose = true;
        }

        private void btn_shape_Click(object sender, EventArgs e)
        {
            if (filtering)
            {
                filter_true();

            }
            else
            {
                filter_false();
            }
        }

        private void filter_true()
        {
            string path = textBox_folder.Text;

            comboStart = dataGridView1.Rows[0].Cells[0].Value.ToString();
            comboEnd = dataGridView1.Rows[0].Cells[1].Value.ToString();

            string save_LM = "UFL_OPIP_LM" + "_" + comboStart + "_" + comboEnd;
            string save_PS = "UFL_OPIP_PS" + "_" + comboStart + "_" + comboEnd;
            string temp_LM = "UFL_OPIP_LM";
            string temp_PS = "UFL_OPIP_PS";
            string psFilePath = path + "\\" + save_PS;
            string lmFilePath = path + "\\" + save_LM;
            int dRcnt = dataGridView1.Rows.Count - 1;
            int dCcnt = dataGridView1.Columns.Count;

            textBox_status.AppendText("Shape파일을 생성합니다..." + "\r\n" + "\r\n");

            Driver driver = Ogr.GetDriverByName("ESRI Shapefile");
            DataSource data_source = driver.CreateDataSource(path, new string[] { "ENCODING=UTF-8" });

            OSGeo.OSR.SpatialReference srs = new OSGeo.OSR.SpatialReference("");
            srs.ImportFromEPSG(5186);

            // MessageBox.Show( dataGridView1.Rows[1].Cells[5].Value.ToString());

            System.IO.FileInfo fi = new System.IO.FileInfo(psFilePath + ".shp");
            if (fi.Exists)
            {
                MessageBox.Show("파일이 있습니다");
                File.Delete(psFilePath + ".prj");
                File.Delete(psFilePath + ".shp");
                File.Delete(psFilePath + ".dbf");
                File.Delete(psFilePath + ".shx");
            }
            else
            {
                //Ps
                var layer = data_source.CreateLayer(temp_PS, srs, wkbGeometryType.wkbPoint, new string[] { "ENCODING=UTF-8" });
                textBox_status.AppendText(psFilePath + ".shp 파일 생성" + "\r\n");
                //string x_temp = dataGridView1.Rows[0].Cells[2].Value.ToString();

                FieldDefn ftr_cde = new FieldDefn("FTR_CDE", FieldType.OFTString);
                FieldDefn hjd_cde = new FieldDefn("HJD_CDE", FieldType.OFTString);
                FieldDefn pip_dep = new FieldDefn("PIP_DEP", FieldType.OFTReal);
                FieldDefn start_point = new FieldDefn("시점", FieldType.OFTString);
                FieldDefn end_point = new FieldDefn("종점", FieldType.OFTString);
                FieldDefn field_x = new FieldDefn("X", FieldType.OFTReal);
                FieldDefn field_y = new FieldDefn("Y", FieldType.OFTReal);
                FieldDefn field_z = new FieldDefn("Z", FieldType.OFTReal);

                layer.CreateField(ftr_cde, 1);
                layer.CreateField(hjd_cde, 1);
                layer.CreateField(pip_dep, 1);
                layer.CreateField(start_point, 1);
                layer.CreateField(end_point, 1);
                layer.CreateField(field_x, 1);
                layer.CreateField(field_y, 1);
                layer.CreateField(field_z, 1);

                FeatureDefn ftr = layer.GetLayerDefn();
                //FeatureDefn ftr = new FeatureDefn(null);
                ftr.SetGeomType(layer.GetLayerDefn().GetGeomType());
                Feature ipFeature = new Feature(ftr);
                string wktPointZ = "";
                Geometry ipGeom = null;
                for (int i = 0; i < dRcnt; ++i)
                {
                    wktPointZ = String.Format("POINT Z({0} {1} {2})", dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        dataGridView1.Rows[i].Cells[4].Value.ToString());
                    ipGeom = Ogr.CreateGeometryFromWkt(ref wktPointZ, srs);
                    ipFeature.SetGeometry(ipGeom);
                    ipFeature.SetField("FTR_CDE", "SF900");
                    ipFeature.SetField("HJD_CDE", "");
                    ipFeature.SetField("PIP_DEP", "");
                    ipFeature.SetField("시점", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    ipFeature.SetField("종점", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    ipFeature.SetField("X", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    ipFeature.SetField("Y", dataGridView1.Rows[i].Cells[3].Value.ToString());
                    ipFeature.SetField("Z", dataGridView1.Rows[i].Cells[4].Value.ToString());
                    layer.CreateFeature(ipFeature);
                    progressBar1.PerformStep();
                }
                layer.CommitTransaction();
                layer.SyncToDisk();
                layer.Dispose();
                data_source.Dispose();

                System.IO.FileInfo fil = new System.IO.FileInfo(path + "\\" + temp_PS + ".shp");
                if (fil.Exists)
                {
                    System.IO.File.Move(path + "\\" + temp_PS + ".shp", psFilePath + ".shp");
                    System.IO.File.Move(path + "\\" + temp_PS + ".cpg", psFilePath + ".cpg");
                    System.IO.File.Move(path + "\\" + temp_PS + ".dbf", psFilePath + ".dbf");
                    System.IO.File.Move(path + "\\" + temp_PS + ".prj", psFilePath + ".prj");
                    System.IO.File.Move(path + "\\" + temp_PS + ".shx", psFilePath + ".shx");
                }
            }


            //LM
            System.IO.FileInfo fLM = new System.IO.FileInfo(lmFilePath + ".shp");
            if (fLM.Exists)
            {
                MessageBox.Show(lmFilePath + "이 있습니다");
                File.Delete(lmFilePath + ".prj");
                File.Delete(lmFilePath + ".shp");
                File.Delete(lmFilePath + ".dbf");
                File.Delete(lmFilePath + ".shx");
            }
            else
            {
                //LM
                DataSource data_source2 = driver.CreateDataSource(path, new string[] { "ENCODING=UTF-8" });

                var layer = data_source2.CreateLayer(temp_LM, srs, wkbGeometryType.wkbLineString, new string[] { "ENCODING=UTF-8" });
                textBox_status.AppendText(lmFilePath + ".shp 파일 생성" + "\r\n");
                FieldDefn ftr_cde = new FieldDefn("FTR_CDE", FieldType.OFTString);
                FieldDefn hjd_cde = new FieldDefn("HJD_CDE", FieldType.OFTString);
                FieldDefn pip_dep = new FieldDefn("PIP_DEP", FieldType.OFTReal);
                FieldDefn start_point = new FieldDefn("시점", FieldType.OFTString);
                FieldDefn end_point = new FieldDefn("종점", FieldType.OFTString);
                FieldDefn field_x = new FieldDefn("X", FieldType.OFTReal);
                FieldDefn field_y = new FieldDefn("Y", FieldType.OFTReal);
                FieldDefn field_z = new FieldDefn("Z", FieldType.OFTReal);

                layer.CreateField(ftr_cde, 1);
                layer.CreateField(hjd_cde, 1);
                layer.CreateField(pip_dep, 1);
                layer.CreateField(start_point, 1);
                layer.CreateField(end_point, 1);
                layer.CreateField(field_x, 1);
                layer.CreateField(field_y, 1);
                layer.CreateField(field_z, 1);
                FeatureDefn ftr = layer.GetLayerDefn();
                //FeatureDefn ftr = new FeatureDefn(null);

                ftr.SetGeomType(layer.GetLayerDefn().GetGeomType());
                Feature ipFeature = new Feature(ftr);
                Geometry ipGeom = null;
                string lineWKT = "LINESTRING (";
                for (int i = 0; i < dRcnt; ++i)
                {
                    string s_x = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string s_y = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    if (i == dRcnt - 1)
                    {
                        lineWKT = lineWKT + s_x + " " + s_y + ")";
                        progressBar1.PerformStep();
                    }
                    else
                    {
                        lineWKT = lineWKT + s_x + " " + s_y + ",";
                        progressBar1.PerformStep();
                    }

                }
                ipGeom = Ogr.CreateGeometryFromWkt(ref lineWKT, srs);
                ipFeature.SetGeometry(ipGeom);
                ipFeature.SetField("FTR_CDE", "SF900");
                ipFeature.SetField("HJD_CDE", "");
                ipFeature.SetField("PIP_DEP", "");
                ipFeature.SetField("시점", dataGridView1.Rows[0].Cells[0].Value.ToString());
                ipFeature.SetField("종점", dataGridView1.Rows[0].Cells[1].Value.ToString());
                layer.CreateFeature(ipFeature);
                layer.CommitTransaction();
                layer.SyncToDisk();
                layer.Dispose();
                data_source2.Dispose();

                System.IO.FileInfo film = new System.IO.FileInfo(path + "\\" + temp_LM + ".shp");
                if (film.Exists)
                {
                    System.IO.File.Move(path + "\\" + temp_LM + ".shp", lmFilePath + ".shp");
                    System.IO.File.Move(path + "\\" + temp_LM + ".cpg", lmFilePath + ".cpg");
                    System.IO.File.Move(path + "\\" + temp_LM + ".dbf", lmFilePath + ".dbf");
                    System.IO.File.Move(path + "\\" + temp_LM + ".prj", lmFilePath + ".prj");
                    System.IO.File.Move(path + "\\" + temp_LM + ".shx", lmFilePath + ".shx");
                }
                textBox_status.AppendText("\r\n" + "Shape파일 생성이 완료되었습니다.");
            }
        }

        // ---------------------------------- filiter_false start ----------------------------------------------
        private void filter_false()
        {
            ToShape toShape = new ToShape();
            toShape.filter_false(textBox_status, textBox_folder, progressBar1, dataGridView2, label3, countList, keyList);
           
        } 
        // ---------------------------------- filter_false end  -------------------------------------------------

        private static void releaseObject(object obj)
         //region memory deallocate
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (wbclose == true)
            {
                workbook.Close(false);
                ap.Quit();
                Application.Exit();
            } else
            {
                Application.Exit();
            }
        }
       

       

        private void button3_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(delegate () // thread 생성
            {
                this.Invoke(new Action(delegate ()
                {
                    Calc2(9999999);
                }));
               
            }));
            thread.Start();
          
        }

        private void Calc2(long cnt)
        {
            long result = 0;
            for (long i = 0; i < cnt; i++)
            {
                result += 2;
                textBox_status.AppendText(Convert.ToString(result));
            }
        }

    }
}


