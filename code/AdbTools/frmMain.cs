using AdbTools.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdbTools
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private bool connect = false;
        private string savePath = "";
        private string apkFile = "";
        private string adbPath = "";
        private string adbDir = "";
        private AdbHelper adb = null;
        private frmLogcat frmlog = null;
        private LoggerHelper logger = new LoggerHelper(Application.StartupPath);
        private ConfigHelper config = new ConfigHelper(Application.StartupPath);
        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitView();
            InitData();
            // txtIp.Text = ";
        }
        /// <summary>
        /// 初始化视图
        /// </summary>
        private void InitView()
        {
            lblTips.Text = "";
            lblFilePath.Text = "";
            lblPsTips.Text = "";
            lblApkTips.Text = "";
            lblTips.ForeColor = Color.Red;
            lblPsTips.ForeColor = Color.Red;
            btnLogcat.Enabled = false;
            cmsPicCopy.Enabled = false;
            txtAdbDir.Text = "默认使用系统环境变量";
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            try
            {
                var data = config.GetConfig();
                foreach (var item in data)
                {
                    if (item.Key == "adbroot")
                    {
                        if (!string.IsNullOrWhiteSpace(item.Value))
                        {
                            txtAdbDir.Text = item.Value;
                        }
                    }
                    else
                    {
                        txtIp.Text = item.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtIp.Text.Trim()))
            {
                new Task(() =>
                {
                    try
                    {
                        if (txtAdbDir.Text != "默认使用系统环境变量")
                        {
                            adbDir = txtAdbDir.Text + "\\";
                        }
                        if (adb == null)
                        {
                            adb = new AdbHelper(adbDir);
                        }
                        logger.Info("正在检查adb..");
                        var flag = adb.CheckAdb();
                        logger.Info("adb:" + flag);
                        if (!flag)
                        {
                            UiShowMsg("没有找到adb软件");
                            return;
                        }
                        //判断是否已经连接
                        if (connect)
                            DisConnect();
                        else
                            Connect();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message + "\r\n" + ex.StackTrace);
                    }

                }).Start();
            }
        }


        /// <summary>
        /// 断开连接
        /// </summary>
        private void DisConnect()
        {
            adb.DisConnect(txtIp.Text);
            connect = false;
            UiShowMsg("已断开连接");
            Invoke(new Action(() =>
            {
                btnConnect.Text = "连接";
                txtIp.Enabled = true;
                btnLogcat.Enabled = false;
                if (frmlog != null)
                {
                    frmlog.Close();
                }

            }));

        }
        /// <summary>
        /// 连接
        /// </summary>
        private void Connect()
        {
            Invoke(new Action(() =>
            {
                btnConnect.Enabled = false;
                txtIp.Enabled = false;
            }));
            UiShowMsg("正在连接...");
            logger.Info("正在连接:" + txtIp.Text);
            if (adb.Connect(txtIp.Text))
            {
                connect = true;
            }
            else
            {
                Invoke(new Action(() =>
                {
                    btnConnect.Enabled = false;
                }));
                UiShowMsg("连接失败");
                Thread.Sleep(600);
                UiShowMsg("正在重新连接...");
                var retry = false;
                for (int i = 0; i < 10; i++)
                {

                    if (adb.Connect(txtIp.Text))
                    {
                        connect = true;
                        retry = true;
                        break;
                    }
                    //尝试5次后任然失败 则杀掉adb服务
                    if (i == 6)
                    {
                        adb.AdbKillServer();
                    }
                    Thread.Sleep(1000);
                }

                if (!retry)
                {
                    //连接失败
                    ConnectFailure();
                }
            }
            if (connect)
            {
                //连接成功
                ConnectSuccess();
            }


        }

        /// <summary>
        /// 连接成功
        /// </summary>
        private void ConnectSuccess()
        {
            UiShowMsg("连接成功");
            Invoke(new Action(() =>
            {
                txtIp.Enabled = false;
                btnConnect.Enabled = true;
                btnLogcat.Enabled = true;
                btnConnect.Text = "断开连接";

            }));

            //保存配置
            config.SaveConfig(
            new Dictionary<string, string>()
            {
                { "adbroot",this.adbDir},
                { "ip",txtIp.Text.Trim()}
            }
            );

        }
        /// <summary>
        /// 连接失败
        /// </summary>
        private void ConnectFailure()
        {
            UiShowMsg("连接失败");
            Invoke(new Action(() =>
            {
                btnConnect.Enabled = true;
                txtIp.Enabled = true;
            }));
            connect = false;

        }

        /// <summary>
        /// UI消息显示
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="type">消息类型 0:截图 1:安装apk</param>
        private void UiShowMsg(string msg, int type = 0)
        {
            Invoke(new Action(() =>
            {
                if (type == 0)
                    lblTips.Text = msg;
                else
                    lblApkTips.Text = msg;
            }));
            logger.Info(msg);
        }

        /// <summary>
        /// 选择保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择图片要保存的路径";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                savePath = fbd.SelectedPath;
                lblFilePath.Text = savePath;
            }
        }

        /// <summary>
        /// 截屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintScreen_Click(object sender, EventArgs e)
        {
            if (!connect)
            {
                lblPsTips.Text = "请先连接adb";
                return;
            }
            if (string.IsNullOrEmpty(savePath))
            {
                lblPsTips.Text = "请选择保存路径";
                return;
            }

            new Task(() =>
            {
                try
                {
                    StartPrintScreen();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "\r\n" + ex.StackTrace);
                }

            }).Start();

        }

        /// <summary>
        /// 开始截屏
        /// </summary>
        private void StartPrintScreen()
        {
            Invoke(new Action(() =>
            {
                lblPsTips.Text = "正在截图...";
                btnPrintScreen.Enabled = false;
            }));
            var picFileName = adb.PrintScreen(savePath, out string error);
            if (!string.IsNullOrEmpty(picFileName))
            {
                Bitmap bmap = new Bitmap(picFileName);

                Invoke(new Action(() =>
                {
                    cmsPicCopy.Enabled = true;
                    lblPsTips.Text = "";
                    picImg.ImageLocation = picFileName;
                    picImg.Refresh();
                    btnPrintScreen.Enabled = true;
                    ltPicLog.Items.Add(picFileName);
                }));

            }
            else
            {
                Invoke(new Action(() =>
                {
                    lblPsTips.Text = "失败请重试.";
                    btnPrintScreen.Enabled = true;
                }));
                if (error.Contains("adb异常:"))
                {
                    logger.Info("截图出现异常:" + error);
                }
            }
        }

        /// <summary>
        /// 选择图片文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltPicLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ltPicLog.SelectedIndex;
            if (index != -1)
            {
                var picPath = ltPicLog.Items[index].ToString();
                picImg.ImageLocation = picPath;
                picImg.Refresh();
            }

        }

        /// <summary>
        /// 复制图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuCopy_Click(object sender, EventArgs e)
        {
            Image bmap = new Bitmap(picImg.Image);
            Clipboard.SetImage(bmap);
        }

        private void lblApkFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lblApkFile_DragDrop(object sender, DragEventArgs e)
        {
            var fileName = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (!string.IsNullOrWhiteSpace(fileName))
            {

                var fileType = fileName.Substring(fileName.Length - 3).ToLower();
                if (fileType != "apk")
                {
                    lblApkFile.ForeColor = Color.Red;
                    lblApkFile.Text = "不支持的文件格式";
                    return;
                }
                //只获取文件名
                var name = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                lblApkFile.ForeColor = Color.Green;
                lblApkFile.Text = name;
                apkFile = fileName;

            }
        }

        /// <summary>
        /// 安装apk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstall_Click(object sender, EventArgs e)
        {

            if (!connect)
            {
                lblApkTips.Text = "请先连接adb";
                return;
            }
            //apkFile = "C:\\Users\\hou\\Documents\\Tencent Files\\312212378\\FileRecv\\canyin2.5.0_t_081401.apk";

            if (string.IsNullOrWhiteSpace(apkFile))
            {
                lblApkTips.Text = "请选择要安装的apk文件";
                return;
            }
            //子线程去执行安装操作
            new Task(() =>
            {
                try
                {
                    InstallApk();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "\r\n" + ex.StackTrace);
                }


            }).Start();
        }

        /// <summary>
        /// 安装apk
        /// </summary>
        private void InstallApk()
        {
            Invoke(new Action(() =>
            {
                btnInstall.Enabled = false;
            }));

            UiShowMsg("正在安装中...", 1);
            string errMsg = "";
            var flag = adb.InstallApk(apkFile, out errMsg);
            if (flag)
            {
                UiShowMsg("安装成功!", 1);

            }
            else
            {
                UiShowMsg(errMsg, 1);
            }
            Invoke(new Action(() =>
            {
                btnInstall.Enabled = true;
            }));
        }

        /// <summary>
        /// 选择adb目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAdbDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择ADB安装目录";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                adbPath = fbd.SelectedPath;
                txtAdbDir.Text = adbPath;
            }
        }

        /// <summary>
        /// 显示logcat页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogcat_Click(object sender, EventArgs e)
        {
            if (frmlog == null || frmlog.IsDisposed)
            {
                frmlog = new frmLogcat(adbDir);
            }
            frmlog.Show();
        }
    }
}
