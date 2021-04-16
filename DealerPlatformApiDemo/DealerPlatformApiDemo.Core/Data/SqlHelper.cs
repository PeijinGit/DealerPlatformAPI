using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DealerPlatformApiDemo.Core.Data
{
    public class SqlHelper : SqlHelperBase
    {
        public SqlHelper(SqlHelperBuilder builder) : base(builder)
        {

        }

        public override void OnConfiguring(SqlHelperBuilder sqlHelperBuilder)
        {
            if (!sqlHelperBuilder.IsConfiged)
            {
                sqlHelperBuilder.UseSqlServer("bbb");
            }

        }
    }
}
