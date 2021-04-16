using System;
using System.Collections.Generic;
using System.Text;

namespace DealerPlatformApiDemo.Core.Data
{
    public class SqlHelperOptions
    {
        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        public string ConStr { get; set; }
        public bool IsConfiged => !string.IsNullOrEmpty(ConStr);

    }
}
