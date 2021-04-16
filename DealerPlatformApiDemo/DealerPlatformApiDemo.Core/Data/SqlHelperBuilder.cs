using System;
using System.Collections.Generic;
using System.Text;

namespace DealerPlatformApiDemo.Core.Data
{
    public class SqlHelperBuilder
    {
        private SqlHelperOptions Options { get; }
        public bool IsConfiged => Options.IsConfiged;
        /// <summary>
        /// 构造函数，依赖注入SqlHelperOptions
        /// </summary>
        /// <param name="options"></param>
        public SqlHelperBuilder(SqlHelperOptions options)
        {
            Options = options;
        }
        /// <summary>
        /// 用于给SqlHelperOption类中的ConStr赋值
        /// </summary>
        /// <param name="sqlConStr">数据库链接字符串</param>
        public void UseSqlServer(string sqlConStr)
        {
            Options.ConStr = sqlConStr;
        }
        /// <summary>
        /// 返回SqlHelperOptions实例
        /// </summary>
        /// <returns></returns>
        public SqlHelperOptions GetOptions()
        {
            return Options;
        }
    }
}
