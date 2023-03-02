using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdbTools.Helper
{
    public class AdbHelper
    {
        /// <summary>
        /// and目录
        /// </summary>
        private string adbDir = "";
        /// <summary>
        /// android版本 
        /// </summary>
        private float androidVer = 0;
        public AdbHelper(string adbDir)
        {
            this.adbDir = adbDir;
        }
        /// <summary>
        /// 检查是否有安装adb
        /// </summary>
        /// <returns></returns>
        public bool CheckAdb()
        {
            var str = ExecCmd(new List<string>() { "adb" });
            if (str.Contains("不是内部或外部命令") || str.Contains("is not recognized as an internal or external command"))
                return false;
            return true;
        }
        public bool Connect(string ip)
        {
            var flag = false;
            List<string> connectCmds = new List<string>()
            {
                 $"adb connect {ip}",
                 "adb devices"
            };

            var str = ExecCmd(connectCmds);
            //str已经去掉了空格

            //代表连接失败
            if (str.Contains("unabletoconnect"))
                return flag;

            if (str.Contains($"connectedto{ip}"))
            {
                if (str.Contains($"{ip}	device"))
                {
                    flag = true;
                }
                //ip不包含端口 判断是否有使用默认端口5555
                else if (!ip.Contains(":") && str.Contains("5555"))
                {
                    if (str.Contains($"{ip}:5555 device"))
                    {
                        flag = true;
                    }
                }
            }

            return flag;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public void DisConnect(string ip)
        {
            List<string> connectCmds = new List<string>()
            {
                  $"adb disconnect {ip}",
            };
            var str = ExecCmd(connectCmds);

        }
        /// <summary>
        /// 关闭adb服务
        /// </summary>
        public void AdbKillServer()
        {
            List<string> connectCmds = new List<string>()
            {
                 $"adb kill-server",

            };
            var str = ExecCmd(connectCmds);
        }

        /// <summary>
        /// 获取android版本
        /// </summary>
        /// <returns></returns>
        public float GetAndroidVersion()
        {
            if (androidVer == 0)
            {
                var ver = 0f;
                List<string> connectCmds = new List<string>()
                {
                 $"adb shell getprop ro.build.version.release",

                };
                var str = ExecCmd(connectCmds, false);
                //提取版本信息
                var matchs = Regex.Matches(str, @"[^\n]*");
                if (matchs.Count >= 9)
                {
                    str = matchs[8].Value.Replace("\r", "");
                }
                //取第一个字符转换成数字 例如8.1.0 转换成8
                float.TryParse(str[0].ToString(), out ver);
                androidVer = ver;
            }
            return androidVer;
        }

        /// <summary>
        /// 获取进程信息
        /// </summary>
        public Dictionary<int, string> GetProcessInfo(string searchStr = "")
        {
            //android 8.1版本ps命令需要加"-A"参数 才能获取完整进程信息。
            string cmds = "adb shell ps";
            if (GetAndroidVersion() >= 8)
            {
                cmds = "adb shell ps -A";
            }
            if (!string.IsNullOrEmpty(searchStr))
            {
                cmds += " |findstr " + searchStr;
            }
            Dictionary<int, string> result = new Dictionary<int, string>();
            List<string> errReceive = new List<string>();
            ExecCmdAsync(new List<string>() { cmds },
            //匿名 数据接收函数
            (sender, e) =>
             {
                 var data = e.Data;
                 Console.WriteLine("data:" + e.Data);
                 if (!string.IsNullOrWhiteSpace(data))
                 {
                     //过滤cmd执行相关信息
                     if (e.Data.Contains("Microsoft") || e.Data.Contains("adb shell"))
                     {
                         return;
                     }
                     //过滤掉非进程信息和root用户的进程信息(root代表系统进程)
                     // "0"进程中包含的信息 不同字段都有包含 以此来确定当前行信息是进程信息
                     if (data.Contains("0") && !data.Contains("root"))
                     {
                         //提取pid
                         var pid = 0;
                         //将多个空格 合并一个空格
                         var newData = Regex.Replace(data, "\\s{2,}", " ");
                         var number = newData.Split(' ');
                         if (number.Length > 1)
                         {
                             pid = int.Parse(number[1]);
                         }
                         //提取进程名称
                         var pName = data.Substring(data.LastIndexOf("S") + 1).Trim();
                         Console.WriteLine("pid:" + pid + " pName:" + pName);
                         if (!result.ContainsKey(pid))
                             result.Add(pid, pName);
                     }
                 }
             },
            //匿名 错误数据接收函数
            (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                    errReceive.Add(e.Data);

            });
            //证明出错了
            if (errReceive.Count > 0)
            {
                //出错就返回一个空的数据
                return new Dictionary<int, string>();
            }
            return result;
        }
        /// <summary>
        /// 安装Apk文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool InstallApk(string fileName, out string errMsg)
        {
            errMsg = "";

            //检查连接
            var resultStr = ExecCmd(new List<string> { "adb devices" });
            resultStr = resultStr.Replace("adbdevicesListofdevicesattached", "");
            if (!resultStr.Contains("device"))
            {
                errMsg = "devicenotfound";
                return false;

            }

            resultStr = ExecCmd(new List<string> { $"adb install -r \"" + fileName + "\"" });
            if (resultStr.Contains("Success"))
            {
                return true;
            }
            else
            {
                //截取错误提示信息
                var sIndex = resultStr.IndexOf("Failure");
                if (sIndex >= 0)
                {
                    resultStr = resultStr.Substring(sIndex);
                    var eIndex = resultStr.IndexOf("]");
                    errMsg = resultStr.Substring(0, eIndex + 1);
                }
                else
                {
                    errMsg = resultStr;
                }
                return false;
            }
        }

        /// <summary>
        /// 截图
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public string PrintScreen(string savePath, out string error)
        {
            error = "";
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
            var filePath = savePath + "\\" + fileName;
            List<string> connectCmds = new List<string>()
            {
                 $"adb shell screencap -p /sdcard/{fileName}",
                 $"adb pull /sdcard/{fileName} {filePath}"
            };
            var str = ExecCmd(connectCmds);
            if (File.Exists(filePath))
            {
                return filePath;
            }
            error = str;
            return "";
        }


        /// <summary>
        /// 移除空格
        /// </summary>
        /// <param name="cmds"></param>
        /// <param name="rm_space"></param>
        /// <returns></returns>
        private string ExecCmd(List<string> cmds, bool rm_space = true)
        {
            var result = "";
            cmds = GetCmds(cmds);
            result = CmdHelper.ExecCmd(cmds);
            if (rm_space)
                result = result.Replace(" ", "").Replace("\r", "").Replace("\n", "");
            return result;
        }


        /// <summary>
        /// logcat
        /// </summary>
        /// <param name="pid">进程id</param>
        /// <param name="level">日志级别</param>
        /// <param name="searchStr">搜索字符串</param>
        /// <param name="outputDataReceived">output回调</param>
        /// <param name="errorDataReceived">error回调</param>
        public void Logcat(int pid, int level, DataReceivedEventHandler outputDataReceived, DataReceivedEventHandler errorDataReceived, string searchStr = "")
        {
            CmdHelper.KillAsyncProcess();
            Thread.Sleep(200);
            string[] levelInfo = new string[] { "V", "D", "I", "W", "E", "F", "S" };
            string pidCmd = "";
            string levelCmd = "";
            string searchCmd = "";
            if (pid > 0)
            {
                pidCmd = " |findstr \"" + pid.ToString() + "\"";
            }
            if (level >= 0)
            {
                levelCmd = " *:" + levelInfo[level];
            }
            if (!string.IsNullOrWhiteSpace(searchStr))
            {
                searchCmd = " |findstr " + "\"" + searchStr + "\"";
            }
            List<string> Cmds = new List<string>()
            {
                 $"adb logcat  -c",
                 $"adb logcat -v time"+levelCmd+pidCmd+searchCmd
            };

            ExecCmdAsync(Cmds, outputDataReceived, errorDataReceived);

        }
        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="cmds"></param>
        /// <param name="outputDataReceived"></param>
        /// <param name="errorDataReceived"></param>
        private void ExecCmdAsync(List<string> cmds, DataReceivedEventHandler outputDataReceived, DataReceivedEventHandler errorDataReceived)
        {
            cmds = GetCmds(cmds);
            CmdHelper.ExecCmdAsync(cmds, outputDataReceived, errorDataReceived);

        }

        /// <summary>
        /// 获取cmd命令
        /// </summary>
        /// <param name="cmds"></param>
        /// <returns></returns>
        private List<string> GetCmds(List<string> cmds)
        {
            if (!string.IsNullOrEmpty(this.adbDir))
            {
                for (int i = 0; i < cmds.Count; i++)
                {
                    cmds[i] = cmds[i].Replace("adb", this.adbDir + "adb");
                }
            }
            return cmds;
        }

        /// <summary>
        /// 停止异步的proces
        /// </summary>
        public void StopAsyncProcess()
        {
            CmdHelper.KillAsyncProcess();
        }

    }
}
