using AdbTools.Helper;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdbTools
{
    public partial class frmLogcat : Form
    {
        private string adbDir = "";
        public frmLogcat(string adbDir)
        {
            InitializeComponent();
            this.adbDir = adbDir;
        }
        private AdbHelper adb = null;
        private LoggerHelper logger = new LoggerHelper(Application.StartupPath);
        private void frmLogcat_Load(object sender, EventArgs e)
        {
            Init();
            this.Text += " 正在获取进程信息..";
            btnStart.Enabled = false;
            GetProcessInfo();
            this.Text = "Logcat";
            btnStart.Enabled = true;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if (adb == null)
                adb = new AdbHelper(this.adbDir);

            //设置进程选择框可搜索
            cmbProcess.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProcess.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProcess.DisplayMember = "Value";
            cmbProcess.ValueMember = "Key";
            cmbLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            //防止DropDownList 显示为灰色像禁用状态
            cmbLevel.FlatStyle = FlatStyle.Popup;
            cmbLevel.Items.AddRange(new string[] { "V--verbose", "D--debug", "I--info", "W--warn", "E--error", "F--fatal", "S--silent" });
            txtLogs.ReadOnly = true;


        }
        /// <summary>
        /// 获取进程信息
        /// </summary>
        private void GetProcessInfo()
        {
            new Task(() =>
            {
                try
                {
                    logger.Info("正在获取进程信息.");
                    //异步获取进程信息
                    var psinfo = adb.GetProcessInfo();
                    Invoke(new Action(() =>
                    {
                        foreach (var item in psinfo)
                        {
                            cmbProcess.Items.Add(new { item.Key, item.Value });
                        }
                        cmbProcess.Refresh();

                    }));
                    logger.Info("获取进程信息:[" + psinfo.Count + "]个");
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "\r\n" + ex.StackTrace);
                }

            }).Start();
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "开始")
            {
                var flag = Start();
                if (flag)
                    btnStart.Text = "停止";
            }
            else
            {
                adb.StopAsyncProcess();
                btnStart.Text = "开始";
                txtLogs.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")} 已停止监控。");
                logger.Info("停止日志监控.");
            }
        }

        /// <summary>
        /// 开始
        /// </summary>
        private bool Start()
        {
            var pid = 0;
            var level = -1;
            var text = "";
            var processInfo = cmbProcess.SelectedItem;
            if (processInfo == null && !string.IsNullOrEmpty(cmbProcess.Text))
            {
                MessageBox.Show("无效的进程名");
                return false;
            }
            if (processInfo != null)
            {
                //获取匿名类key的值
                pid = int.Parse(processInfo.GetType().GetProperty("Key").GetValue(processInfo).ToString());
            }
            level = cmbLevel.SelectedIndex;
            text = txtSearch.Text.Trim();
            txtLogs.Text = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")} 正在监控: {(pid > 0 ? "进程[" + cmbProcess.Text + "]" : "[所有]")}日志...\r\n\r\n";
            logger.Info($"开始日志监控，进程名[{cmbProcess.Text}]级别[{cmbLevel.Text}]搜索[{text}]");
            new Task(() =>
            {
                try
                {
                    ShowLogInfo(pid, level, text);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "\r\n" + ex.StackTrace);
                }


            }).Start();

            return true;
        }

        /// <summary>
        /// 显示日志信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="level"></param>
        /// <param name="text"></param>
        private void ShowLogInfo(int pid, int level, string text)
        {
            int line = 0;
            adb.Logcat(pid, level, (sender, e) =>
              {
                  Console.WriteLine("data:" + e.Data);
                  Invoke(new Action(() =>
                  {

                      //如果当前已积累50W行数据 则清空文本数据，避免太大造成内存太大。
                      if (line == 500000)
                      {
                          txtLogs.Clear();
                          line = 6;
                          txtLogs.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")} 已自动清空文本数据.");

                      }
                      //过滤前6行数据
                      if (line >= 6)
                      {
                          IntPtr i = this.Handle;
                          if (!string.IsNullOrWhiteSpace(text))
                          {
                              if (e.Data.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                              {
                                  txtLogs.AppendText(e.Data + "\r\n");
                              }
                          }
                          else
                          {
                              txtLogs.AppendText(e.Data + "\r\n");
                          }
                      }

                      line++;

                  }));
              },
            (sender, e) =>
            {
                logger.Info("[ShowLogInfo]ADB异常信息:" + e.Data);
            });


        }

        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogcat_FormClosed(object sender, FormClosedEventArgs e)
        {
            adb.StopAsyncProcess();
        }

        /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtLogs.Clear();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llblExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtLogs.TextLength > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "TXT|*txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var fileName = sfd.FileName;
                    if (!fileName.Contains(".txt"))
                    {
                        fileName += ".txt";
                    }
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.Write(txtLogs.Text);
                    }
                    MessageBox.Show("导出成功!");
                }
            }
            else
            {
                MessageBox.Show("暂无导出内容");
            }
        }
    }
}
