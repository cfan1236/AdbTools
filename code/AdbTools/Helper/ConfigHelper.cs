using System.Collections.Generic;
using System.IO;

namespace AdbTools.Helper
{
    /// <summary>
    /// 配置文件 简单打开记录文件即可
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 根目录
        /// </summary>
        private string rootPath = "";
        /// <summary>
        /// 构造函数 初始化目录
        /// </summary>
        /// <param name="filePath"></param>
        public ConfigHelper(string rootPath)
        {
            this.rootPath = rootPath;
        }


        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="dict"></param>
        public void SaveConfig(Dictionary<string, string> dict)
        {
            var fileName = $"{this.rootPath}\\data.ini";
            string[] fileContent = new string[dict.Count];
            int i = 0;
            foreach (var item in dict)
            {
                fileContent[i] = item.Key + "=" + item.Value;
                i++;
            }
            File.WriteAllLines(fileName, fileContent);
        }

        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetConfig()
        {
            var result = new Dictionary<string, string>();
            var fileName = $"{this.rootPath}\\data.ini";
            if (File.Exists(fileName))
            {
                var content = File.ReadAllLines(fileName);
                for (int i = 0; i < content.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(content[i]))
                    {
                        var arr = content[i].Split('=');
                        if (arr.Length >= 2)
                        {
                            result.Add(arr[0], arr[1]);
                        }
                    }
                }
            }
            return result;
        }



    }
}
