using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *                                                 *
 *                                                                                 *
 * Author $zho.li$                                                                 *
 *                                                                                 *
 * Time 2022/2/28 20:53:43                                                                     *
 *                                                                                 *
 * Describe $Used to do something$                                                 *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Service.config
{
    public class Config
    {
        private Config() { }
        private static Dictionary<string, string> Dict = new Dictionary<string, string>();
        public static string ServerIp { get => Get("serverIp"); }
        public static string Token { get; internal set; }
        public static string RefreshToken { get; internal set; }
#if DEBUG
        public static bool TestMode = true;
#endif

        public static string Get(string key)
        {
            if (Dict.ContainsKey(key))
                return Dict[key];
#if DEBUG
            if (key == "serverIp" &&
                string.IsNullOrEmpty(ConfigurationManager.AppSettings[key]))
                return "192.168.101.122:8990";  // 测试服
                                                //return 192.168.101.122:8990// 开发服  
#endif
            return ConfigurationManager.AppSettings[key];
        }

        public static void Set(string key, string value)
        {
            if (Dict.ContainsKey(key))
                Dict[key] = value;
            else
            {
                Dict.Add(key, value);
            }
        }

        public static void SetAppValue(string key, string value)
        {
            //获取Configuration对象
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                //写入<add>元素的Value
                config.AppSettings.Settings[key].Value = value;
            }
            //一定要记得保存，写不带参数的config.Save()也可以
            config.Save();
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
