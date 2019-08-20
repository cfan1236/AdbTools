using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdbTools.Helper
{
    public class CmdHelper
    {
        /// <summary>
        /// 异步的Process
        /// </summary>
        private static Process proAsync = null;
        private static bool isClose = false;
        /// <summary>
        /// 执行cmd命令
        /// </summary>
        /// <param name="cmds"></param>
        /// <returns></returns>
        public static string ExecCmd(List<string> cmds)
        {
            System.Diagnostics.Process pro = new System.Diagnostics.Process();
            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardError = true;
            pro.StartInfo.RedirectStandardInput = true;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.CreateNoWindow = true;
            //pro.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pro.Start();
            foreach (var item in cmds)
            {
                pro.StandardInput.WriteLine(item);
            }
            pro.StandardInput.WriteLine("exit");
            pro.StandardInput.AutoFlush = true;
            string errOutput = pro.StandardError.ReadToEnd();
            string output = pro.StandardOutput.ReadToEnd();
            //获取cmd窗口的输出信息

            //超时1分钟
            pro.WaitForExit(1000 * 60);//等待程序执行完退出进程
            pro.Close();
            //安装apk的时候 Kb/s 会被识别为错误信息
            if (!string.IsNullOrEmpty(errOutput) && !errOutput.Contains("KB/s"))
            {
                output = "adb异常:" + errOutput;
            }
            return output;

        }

        /// <summary>
        /// 执行cmd命令 异步方法
        /// </summary>
        /// <param name="cmds"></param>
        /// <param name="outputDataReceived"></param>
        /// <param name="errorDataReceived"></param>
        public static void ExecCmdAsync(List<string> cmds, DataReceivedEventHandler outputDataReceived, DataReceivedEventHandler errorDataReceived)
        {
            proAsync = new Process();
            proAsync.StartInfo.FileName = "cmd.exe";
            proAsync.StartInfo.UseShellExecute = false;
            proAsync.StartInfo.RedirectStandardError = true;
            proAsync.StartInfo.RedirectStandardInput = true;
            proAsync.StartInfo.RedirectStandardOutput = true;
            proAsync.StartInfo.CreateNoWindow = true;
            proAsync.StartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
            proAsync.StartInfo.StandardErrorEncoding = System.Text.Encoding.UTF8;
            proAsync.Start();
            isClose = false;
            foreach (var item in cmds)
            {
                proAsync.StandardInput.WriteLine(item);
            }
            proAsync.StandardInput.WriteLine("exit");
            proAsync.StandardInput.AutoFlush = true;

            var output = new StringBuilder();
            var errOutput = new StringBuilder();

            proAsync.OutputDataReceived += outputDataReceived;
            proAsync.ErrorDataReceived += errorDataReceived;

            proAsync.BeginOutputReadLine();
            proAsync.BeginErrorReadLine();

            proAsync.WaitForExit();//等待程序执行完退出进程
            proAsync.Close();
            isClose = true;
        }

        /// <summary>
        /// 终止异步process
        /// </summary>
        public static void KillAsyncProcess()
        {
            if (proAsync != null && !isClose)
            {
                proAsync.CancelErrorRead();
                proAsync.CancelOutputRead();
                proAsync.CloseMainWindow();
                proAsync.Kill();
                proAsync.Close();

            }

        }
        public static void RefreshAsyncProcess()
        {
            if (proAsync != null && !isClose)
            {
                proAsync.Refresh();
            }
        }


    }
}
