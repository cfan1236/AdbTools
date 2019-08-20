using System;
using System.IO;

namespace AdbTools.Helper
{
    /// <summary>
    /// 日志 简单记录文件就行 不需要依赖第三方dll
    /// </summary>
    public class LoggerHelper
    {

        private string rootPath = "";
        /// <summary>
        /// 构造函数 初始化目录
        /// </summary>
        /// <param name="filePath"></param>
        public LoggerHelper(string rootPath)
        {
            this.rootPath = rootPath;
        }

        /// <summary>
        /// info
        /// </summary>
        /// <param name="content"></param>
        public void Info(string content)
        {
            var fileName = $"{this.rootPath}\\{DateTime.Now.ToString("yyyy-MM-dd")}_info.log";
            File.AppendAllText(fileName, "[info] " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + " " + content + "\r\n");
        }
        /// <summary>
        /// error
        /// </summary>
        /// <param name="content"></param>
        public void Error(string content)
        {
            var fileName = $"{this.rootPath}\\{DateTime.Now.ToString("yyyy-MM-dd")}_error.log";
            File.AppendAllText(fileName, "[error] " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + " " + content + "\r\n");
        }

    }
}
