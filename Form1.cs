using System;
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
using Excel = Microsoft.Office.Interop.Excel;
using OSGeo.GDAL;
using OSGeo.OGR;
using Driver = OSGeo.OGR.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace OilPipe
{
    public partial class Form1 : Form
    {
        bool On;
        Point Pos;
        public Form1()
        {
            InitializeComponent();
            MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { On = true; Pos = e.Location; } };
            MouseMove += (o, e) => { if (On) Location = new Point(Location.X + (e.X - Pos.X), Location.Y + (e.Y - Pos.Y)); };
            MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { On = false; Pos = e.Location; } };
        }

        Excel.Workbook wb = null;
        Excel.Worksheet ws = null;
        Excel.Application ap = null;

        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        string comboStart = "";
        string comboEnd = "";

        //panel
        private Boolean mousing;
        private int startX, startY;

        private Boolean filtering=false;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

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


        private void textBox_status_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.InitialDirectory = Common.loadDirectory("EXCEL", false);
                openFile.DefaultExt = "xlsx";
                openFile.Filter = "Excel 파일(*.xlsx)|*.xlsx";
                openFile.ShowDialog();

                if (openFile.FileNames.Length > 0)
                {
                    foreach (string filename in openFile.FileNames)
                    {
                        this.textBox_excel.Text = filename;
                    }
                }
                Common.saveDirectory("EXCEL", this.textBox_excel.Text);

                Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                string directory = Properties.Settings.Default.EXCEL;
                Excel.Workbook workbook = app.Workbooks.Open(Filename: directory);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

                //첫번째 Worksheet를 선택합니다.
                Excel.Range rng = worksheet.UsedRange;
                DataTable table = new DataTable();

                // 현재 Worksheet에서 사용된 셀 전체를 선택합니다.
                object[,] data = rng.Value;

                int rCnt = rng.Rows.Count;
                int cCnt = rng.Columns.Count;
                List<string> rList = new List<string>();

                Thread thread = new Thread(new ThreadStart(delegate () // thread create
                {
                    this.Invoke(new Action(delegate () //this == Form  ,  Form이 아닌 컨트롤의 Invoke를 직접호출해도 무방
                    {
                        for (int i = 2; i < rCnt; ++i)
                        {
                            rList.Clear();
                            for (int j = 1; j < cCnt; ++j)
                            {
                                string rData = Convert.ToString(data[i, j]);
                                rList.Add(rData);

                            }
                            dataGridView2.Rows.Add(rList[0], rList[1], rList[2], rList[3], rList[4], rList[5]);
                            if (!combo_st.Items.Contains(rList[0])) { combo_st.Items.Add(rList[0]); }
                            if (!combo_end.Items.Contains(rList[1])) { combo_end.Items.Add(rList[1]); }
                        }
                    }));
                }));
                thread.Start();   // thread 실행하여 병렬작업 시작
            
        }

        private void btn_sf_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            textBox_folder.Text = dialog.SelectedPath;
            Common.saveDirectory("FOLDER", this.textBox_folder.Text);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboStart = combo_st.SelectedItem as string;
            comboEnd = combo_end.SelectedItem as string;

            Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            string directory = Properties.Settings.Default.EXCEL;
            Excel.Workbook workbook = app.Workbooks.Open(Filename: directory);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);
         
            //첫번째 Worksheet를 선택합니다.
            Excel.Range rng = worksheet.UsedRange;
            DataTable table = new DataTable();

            // 현재 Worksheet에서 사용된 셀 전체를 선택합니다.
            object[,] data = rng.Value;

            int rCnt = rng.Rows.Count;
            int cCnt = rng.Columns.Count    ;
            List<string> rList = new List<string>();
            double dem= 0.0, d_z=0.0;
            string rData = "";

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
                                } else if(j == 6) {
                                    dem = Convert.ToDouble(data[i, j]);
                                } 
                                rData = Convert.ToString(data[i, j]);
                    
                                rList.Add(rData);

                            }
                            if (rList[0] == comboStart && rList[1] == comboEnd)
                            {
                                double dep = dem - d_z;
                                dep = Math.Abs(dep);
                                string dep_st = Convert.ToString(dep);
                                rList.Add(dep_st);
                                dataGridView1.Rows.Add(rList[0], rList[1], rList[2], rList[3], rList[4], rList[5], rList[6]);
                            }
                            filtering = true;
                        }
                    }));
                }));
            thread.Start();   // thread 실행하여 병렬작업 시작
        }

        private void combo_st_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo_end_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

       
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousing = true;
            startX = e.X;
            startY = e.Y; 
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousing = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mousing)
            {
                int changeX = e.X - startX;
                int changeY = e.Y - startY;

                panel1.Location = new System.Drawing.Point(panel1.Location.X + changeX, panel1.Location.Y + changeY);
            }
        }

        private void textBox_folder_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_shape_Click(object sender, EventArgs e)
        {
           if(filtering)
            {
                filter_true();
            } else
            {
                filter_false();
            }
        }

        private void filter_true()
        {
            string path = textBox_folder.Text;

            comboStart = dataGridView2.Rows[0].Cells[0].Value.ToString();
            comboEnd = dataGridView2.Rows[0].Cells[1].Value.ToString();

            string save_LM = "UFL_OPIP_LM" + comboStart + comboEnd;
            string save_PS = "UFL_OPIP_PS" + comboStart + comboEnd;
            string psFilePath = path + "\\" + save_PS;
            string lmFilePath = path + "\\" + save_LM;
            int dRcnt = dataGridView1.Rows.Count - 1;
            int dCcnt = dataGridView1.Columns.Count;

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
                var layer = data_source.CreateLayer(save_PS, srs, wkbGeometryType.wkbPoint, new string[] { "ENCODING=UTF-8" });

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
                }


                layer.CommitTransaction();
                layer.SyncToDisk();
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
                var layer = data_source.CreateLayer(save_LM, srs, wkbGeometryType.wkbLineString, new string[] { "ENCODING=UTF-8" });
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
                    }
                    else
                    {

                        lineWKT = lineWKT + s_x + " " + s_y + ",";
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
            }
        }
        private void filter_false()
        {
            string path = textBox_folder.Text;

            string save_LM = "UFL_OPIP_LM" + comboStart + comboEnd;
            string save_PS = "UFL_OPIP_PS" + comboStart + comboEnd;
            string psFilePath = path + "\\" + save_PS;
            string lmFilePath = path + "\\" + save_LM;
            int dRcnt = dataGridView1.Rows.Count - 1;
            int dCcnt = dataGridView1.Columns.Count;

            Driver driver = Ogr.GetDriverByName("ESRI Shapefile");
            DataSource data_source = driver.CreateDataSource(path, new string[] { "ENCODING=UTF-8" });

            OSGeo.OSR.SpatialReference srs = new OSGeo.OSR.SpatialReference("");
            srs.ImportFromEPSG(5186);

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
                var layer = data_source.CreateLayer(save_PS, srs, wkbGeometryType.wkbPoint, new string[] { "ENCODING=UTF-8" });

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
                }


                layer.CommitTransaction();
                layer.SyncToDisk();
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
                var layer = data_source.CreateLayer(save_LM, srs, wkbGeometryType.wkbLineString, new string[] { "ENCODING=UTF-8" });
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
                    }
                    else
                    {

                        lineWKT = lineWKT + s_x + " " + s_y + ",";
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
            }
        }
    }

}
