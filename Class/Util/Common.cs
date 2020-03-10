using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OilPipe.Properties;

namespace OilPipe.Class.Util
{
    class Common
    {

        public delegate void ProgvarCall(int var, ProgressBar progress);

        public delegate void StatusBoxCall(string var, TextBox textBox);

        //프로그래스바 초기화
        public static void initProgressBar(ProgressBar pb)
        {
            pb.Style = ProgressBarStyle.Continuous;
            pb.Minimum = 0;
            pb.Maximum = 100;
            pb.Step = 1;
            pb.Value = 0;
        }

        //프로그래스바 진행
        public static void progValueSetting(int var, ProgressBar pb)
        {
            pb.Value = var;
        }

        //상태 텍스트박스 처리
        public static void statusBoxValueSetting(string var, TextBox tx)
        {
            tx.AppendText(var);
        }


        //마지막 선택 폴더 경로를 Settings에 저장
        public static void saveDirectory(string target, string path)
        {

            switch (target)
            {
                case "EXCEL":
                    Properties.Settings.Default.EXCEL = path;
                    break;
                case "DEM":
                    Properties.Settings.Default.DEM = path;
                    break;
                case "FOLDER":
                    Properties.Settings.Default.FOLDER = path;
                    break;
            }
            Properties.Settings.Default.Save();
        }

        //마지막 선택 폴더 경로를 불러옴
        public static string loadDirectory(string target, bool fileName)
        {

            string directory = "";

            switch (target)
            {
                case "EXCEL":
                    directory = Properties.Settings.Default.EXCEL;
                    break;
                case "DEM":
                    directory = Properties.Settings.Default.DEM;
                    break;
                case "FOLDER":
                    directory = Properties.Settings.Default.FOLDER;
                    break;
            }

            if (!directory.Equals(""))
            {

                if (fileName)
                {
                    return directory; //파일 이름을 포함한 전체경로
                }
                else
                {
                    return Path.GetDirectoryName(directory); //파일 이름을 제외한 경로
                }

            }
            else
            {
                return "";
            }

        }

        public static void progMaximumSetting(int var, ProgressBar progressBar)
        {
            progressBar.Maximum = var;
        }

        public static string getTime()
        {
            return System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        }

    }
}
