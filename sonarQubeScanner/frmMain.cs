using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Diagnostics;
using System.IO;
using System.Net;

namespace sonarQubeScanner
{
    // 1.定义委托
    public delegate void DelReadStdOutput(string result);
    public delegate void DelReadErrOutput(string result);
    public delegate void DelRunCompleted(string completeMessage);
    

    public partial class FrmMain : Form
    {
        // 2.定义委托事件  
        public event DelReadStdOutput ReadStdOutput;
        public event DelReadErrOutput ReadErrOutput;
        public event DelRunCompleted RunCompleted;
        public string mc_runPath = string.Empty;
        public string mc_sonarRunnerUrl = "https://sonarsource.bintray.com/Distribution/sonar-scanner-cli/sonar-scanner-2.8.zip";
        public string mc_sonarRunnerZipFile = "sonar-scanner-2.8.zip";
        public string mc_sonarRunnerFolderName = "sonar-scanner-2.8";

        public FrmMain()
        {
            InitializeComponent();

            Init();

            mc_runPath = Path.GetDirectoryName(Application.ExecutablePath);
            CheckZipFileExist();
            ChecksonarScannerFolder();
        }

        private void Init()
        {
            //3.将相应函数注册到委托事件中  
            ReadStdOutput += new DelReadStdOutput(ReadStdOutputAction);
            ReadErrOutput += new DelReadErrOutput(ReadErrOutputAction);
            RunCompleted += new DelRunCompleted(runner_complete);  
        }

        private void RealAction(string StartFileName, string StartFileArg)
        {
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = StartFileName;      // 命令  
            //CmdProcess.StartInfo.Arguments = StartFileArg;      // 参数  

            CmdProcess.StartInfo.CreateNoWindow = true;         // 不创建新窗口  
            CmdProcess.StartInfo.UseShellExecute = false;

            CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入  
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出  
            CmdProcess.StartInfo.RedirectStandardError = true;  // 重定向错误输出  
            //CmdProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  


            CmdProcess.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);//正常输出信息
            CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);//输出错误信息
            CmdProcess.Exited += new EventHandler(CmdProcess_Exited);   // 注册进程结束事件  
            CmdProcess.EnableRaisingEvents = true;                      // 启用Exited事件  

            CmdProcess.Start();

            //add command
            CmdProcess.StandardInput.WriteLine(StartFileArg);
            CmdProcess.StandardInput.AutoFlush = true;


            CmdProcess.BeginOutputReadLine();
            CmdProcess.BeginErrorReadLine();

            // 如果打开注释，则以同步方式执行命令，此例子中用Exited事件异步执行。  
            // CmdProcess.WaitForExit();
        }

        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                // 4. 异步调用，需要invoke  
                this.Invoke(ReadStdOutput, new object[] { e.Data });
            }
        }

        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.Invoke(ReadErrOutput, new object[] { e.Data });
            }
        }

        private void CmdProcess_Exited(object sender, EventArgs e)
        {
            // 执行结束后触发              
            this.Invoke(RunCompleted, new object[] { "sonarQube Scanner Run Completed !" });
        }  

        private void ReadStdOutputAction(string result)
        {
            this.txt_ScannerLog.SelectionColor = Color.Black;
            this.txt_ScannerLog.AppendText(result + "\r\n");
            this.txt_ScannerLog.ScrollToCaret();
        }

        private void ReadErrOutputAction(string result)
        {
            this.txt_ScannerLog.SelectionColor = Color.Red;
            this.txt_ScannerLog.AppendText(result + "\r\n");
            this.txt_ScannerLog.ScrollToCaret();
        }

        private void runner_complete(string completeMessage)
        {
            btn_runner.Enabled = true;
            this.txt_ScannerLog.SelectionColor = Color.Green;
            this.txt_ScannerLog.AppendText(completeMessage);

            SettingButtons(false);
        }


        public void SettingButtons(bool pi_blnScanFlag)
        {
            if(pi_blnScanFlag)txt_ScannerLog.Text = "";
            
            btn_runner.Enabled = !pi_blnScanFlag;

            txt_ProjectKey.Enabled = !pi_blnScanFlag;
            txt_ProjectName.Enabled = !pi_blnScanFlag;
            txt_ProjectVersion.Enabled = !pi_blnScanFlag;
            txt_Source.Enabled = !pi_blnScanFlag;
            txt_SourceEncoding.Enabled = !pi_blnScanFlag;
            txt_Language.Enabled = !pi_blnScanFlag;
        }

        public void ShowError(string pi_message)
        {
            MessageBox.Show(pi_message);
        }
        
        public void ShowError(Exception ex)
        {
            MessageBox.Show(ex.StackTrace, "sonarQube Scanner Tool Error Message");
        }

        public bool check_projectParameter()
        {
            bool l_returnFlag = true;

            if(string.IsNullOrEmpty(txt_ProjectFolder.Text.Trim()))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txt_ProjectKey.Text.Trim()))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txt_ProjectName.Text.Trim()))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txt_ProjectVersion.Text.Trim()))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txt_Language.Text.Trim()))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txt_Source.Text.Trim()))
            {
                return false;
            }

            return l_returnFlag;
        }

        public void CheckZipFileExist()
        {
            string l_zipFileFullPath = mc_runPath + "\\"+mc_sonarRunnerZipFile;
            if (File.Exists(l_zipFileFullPath))
            {
                btn_downloadsonarScanner.Enabled = false;
            }
        }

        public void ChecksonarScannerFolder()
        {
            string l_sonarScannPath = mc_runPath + "\\" + mc_sonarRunnerFolderName;
            if(!Directory.Exists(l_sonarScannPath))
            {
                btn_runner.Enabled = false;
                btn_unzipAndSettingParameter.Enabled = false;
            }
            else
            {
                btn_runner.Enabled = true;
                btn_unzipAndSettingParameter.Enabled = true;
            }
        }

        //-------------------------------------------------------------------------------------------------
        private void cmd_OpenProjectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog_ProjectFolder.RootFolder = Environment.SpecialFolder.Desktop;
                if (folderBrowserDialog_ProjectFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txt_ProjectFolder.Text = folderBrowserDialog_ProjectFolder.SelectedPath;

                    System.IO.DirectoryInfo l_SelectPathFolder = new DirectoryInfo(folderBrowserDialog_ProjectFolder.SelectedPath);

                    txt_ProjectKey.Text = l_SelectPathFolder.Name;
                    txt_ProjectName.Text = l_SelectPathFolder.Name;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void btn_runner_Click(object sender, EventArgs e)
        {
            try
            {
                if (!check_projectParameter()) return;

                SettingButtons(true);

                string pi_path = System.AppDomain.CurrentDomain.BaseDirectory;
                string l_root = Path.GetPathRoot(txt_ProjectFolder.Text.Trim());

                StringBuilder l_strParameter = new StringBuilder();
                l_strParameter.Append(" -X");
                l_strParameter.Append(string.Format(" -Dsonar.projectKey=\"{0}\"", txt_ProjectKey.Text.Trim()));
                l_strParameter.Append(string.Format(" -Dsonar.projectName=\"{0}\"", txt_ProjectName.Text.Trim()));
                l_strParameter.Append(string.Format(" -Dsonar.projectVersion=\"{0}\"", txt_ProjectVersion.Text.Trim()));
                l_strParameter.Append(string.Format(" -Dsonar.sources=\"{0}\"", txt_Source.Text.Trim()));
                l_strParameter.Append(string.Format(" -Dsonar.language=\"{0}\" ", txt_Language.Text.Trim()));
                l_strParameter.Append(string.Format(" -Dsonar.sourceEncoding=\"{0}\"", txt_SourceEncoding.Text.Trim()));

                string cmd = string.Format("{0}&cd {1}&{2}sonar-scanner-2.8\\bin\\sonar-scanner {3}&exit", l_root.Substring(0, l_root.Length - 1), txt_ProjectFolder.Text.Trim(), pi_path,l_strParameter.ToString());

                #region sonar-project.properties
                //StringBuilder l_file = new StringBuilder();

                //l_file.Append("# Required metadata" + "\r\n");
                //l_file.Append(string.Format("sonar.projectKey={0}", txt_ProjectKey.Text.Trim()) + "\r\n");
                //l_file.Append(string.Format("sonar.projectName={0}", txt_ProjectName.Text.Trim()) + "\r\n");
                //l_file.Append(string.Format("sonar.projectVersion={0}", txt_ProjectVersion.Text.Trim()) + "\r\n");
                //l_file.Append("# Comma-separated paths to directories with sources (required)" + "\r\n");
                //l_file.Append(string.Format("sonar.sources={0}", txt_Source.Text.Trim()) + "\r\n");
                //l_file.Append("#sonar.binaries=bin\\classes" + "\r\n");
                //l_file.Append("# Language" + "\r\n");
                //l_file.Append(string.Format("sonar.language={0}", txt_Language.Text.Trim()) + "\r\n");
                //l_file.Append("# Encoding of the source files" + "\r\n");
                //l_file.Append(string.Format("sonar.sourceEncoding={0}", txt_SourceEncoding.Text.Trim()) + "\r\n");

                ////write file
                //if(File.Exists(txt_ProjectFolder.Text.Trim() + "\\sonar-project.properties"))
                //{
                //    File.Delete(txt_ProjectFolder.Text.Trim() + "\\sonar-project.properties");
                //}

                //FileStream fs = new FileStream(txt_ProjectFolder.Text.Trim() + "\\sonar-project.properties", FileMode.CreateNew);
                //StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                //sw.Write(l_file.ToString());
                //sw.Close();
                //fs.Close();

                #endregion

                RealAction("cmd.exe", cmd);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                SettingButtons(false);
            }
        }

        private void btn_run_preview_Click(object sender, EventArgs e)
        {
            try
            {
                if (!check_projectParameter()) return;
                if (string.IsNullOrEmpty(txt_github_token.Text.Trim())) return;
                if (string.IsNullOrEmpty(txt_sonarqube_token.Text.Trim())) return;
                if (string.IsNullOrEmpty(txt_github_pullrequestid.Text.Trim())) return;
                if (string.IsNullOrEmpty(txt_github_repository.Text.Trim())) return;

                SettingButtons(true);

                string pi_path = System.AppDomain.CurrentDomain.BaseDirectory;
                string l_root = Path.GetPathRoot(txt_ProjectFolder.Text.Trim());

                StringBuilder l_strParameter = new StringBuilder();

                l_strParameter.Append(" -X");
                l_strParameter.Append(" -Dsonar.analysis.mode=preview");
                l_strParameter.Append(string.Format(" -Dsonar.github.pullRequest={0}", txt_github_pullrequestid.Text.Trim()));
                l_strParameter.Append(string.Format(" -Dsonar.github.repository={0}", txt_github_repository.Text.Trim()));
                l_strParameter.Append(string.Format(" -Dsonar.github.oauth={0}", txt_github_token.Text.Trim()));
                l_strParameter.Append(" -Dsonar.host.url=http://localhost:9000/");
                l_strParameter.Append(string.Format(" -Dsonar.login={0}", txt_sonarqube_token.Text.Trim()));
                l_strParameter.Append(string.Format(" -Dsonar.projectKey=\"{0}\"", txt_ProjectKey.Text.Trim()));
                l_strParameter.Append(string.Format(" -Dsonar.sources=\"{0}\"", txt_Source.Text.Trim()));

                string cmd = string.Format("{0}&cd {1}&{2}sonar-scanner-2.8\\bin\\sonar-scanner {3}&exit", l_root.Substring(0, l_root.Length - 1), txt_ProjectFolder.Text.Trim(), pi_path, l_strParameter.ToString());


                RealAction("cmd.exe", cmd);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                SettingButtons(false);
            }
        }
        //-------------------------------------------------------------------------------------------------        

        private void btn_downloadsonarScanner_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                string l_zipFileFullPath = mc_runPath + "\\" + mc_sonarRunnerZipFile;
                if (File.Exists(l_zipFileFullPath))
                {
                    File.Delete(l_zipFileFullPath);
                }

                client.DownloadFile(mc_sonarRunnerUrl, l_zipFileFullPath);
                CheckZipFileExist();

                btn_unzipAndSettingParameter.Enabled=true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btn_unzipAndSettingParameter_Click(object sender, EventArgs e)
        {
            try
            {
                string l_zipFilePath=mc_runPath+"\\"+mc_sonarRunnerZipFile;
                string l_sonarScannerFolder=mc_runPath+"\\"+mc_sonarRunnerFolderName;
                if(!Directory.Exists(l_sonarScannerFolder))
                {
                    Directory.CreateDirectory(l_sonarScannerFolder);
                }

                ZipHelper.UnZip(l_zipFilePath, mc_runPath, "", true);

                ChecksonarScannerFolder();

                sonarScannParameterHelper l_class=new sonarScannParameterHelper(mc_runPath+"\\"+"sonar-scanner-2.8\\conf\\sonar-scanner.properties");
                string l_getvalue=l_class.GetSonarScannerValue("sonar.jdbc.username");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

    }    
}
