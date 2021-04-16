using System;
using System.Collections.Generic;
using System.Text;

namespace DealerPlatformApiDemo.Core.Data
{
    public class DbHelper : SqlHelperBase
    {
        public DbHelper(SqlHelperBuilder builder) : base(builder)
        {

        }

        public override void OnConfiguring(SqlHelperBuilder sqlHelperBuilder)
        {
            sqlHelperBuilder.UseSqlServer("aaa");
        }
    }
}

