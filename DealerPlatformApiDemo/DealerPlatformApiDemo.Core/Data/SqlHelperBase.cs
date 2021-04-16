using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DealerPlatformApiDemo.Core.Data
{
    public class SqlHelperBase
    {
        private SqlHelperOptions _options;

        public SqlHelperBase(SqlHelperBuilder builder)
        {
            //在构造函数中调用OnConfiguring，并将依赖注入的SqlHelperBuilder实例传给该方法
            //此时子类重写该方法是就可以使用依赖注入的SqlHelperBuilder的实例了
            OnConfiguring(builder);
            _options = builder.GetOptions();
        }
        /// <summary>
        /// 虚方法，用于子类重写
        /// </summary>
        /// <param name="sqlHelperBuilder"></param>
        public virtual void OnConfiguring(SqlHelperBuilder sqlHelperBuilder)
        {
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sqlText">Sql语句</param>
        /// <param name="sqlParameters">传入的参数</param>
        /// <returns></returns>
        public DataTable ExecuteTable(string sqlText, params SqlParameter[] sqlParameters)
        {
            //创建仓库钥匙
            using SqlConnection conn = new SqlConnection(_options.ConStr);
            conn.Open();
            //告诉仓库管理员要干什么，即sqlText。
            //把钥匙交到管理员手上，即conn
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            cmd.Parameters.Add(sqlParameters);
            //管理员推着车进入仓库
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //把一个个集装箱放到推车里放满
            DataSet ds = new DataSet();
            sda.Fill(ds);
            //返回需要取得数据
            return ds.Tables[0];
        }
        /// <summary>
        /// 增删改非查询操作
        /// </summary>
        /// <param name="sqlText">sql语句</param>
        /// <param name="sqlParameters">传入的参数</param>
        /// <returns></returns>
        public int ExecuteNoQuery(string sqlText, params SqlParameter[] sqlParameters)
        {
            //创建仓库钥匙
            using SqlConnection conn = new SqlConnection(_options.ConStr);
            conn.Open();
            //告诉仓库管理员要干什么，即sqlText。
            //把钥匙交到管理员手上，即conn
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            cmd.Parameters.Add(sqlParameters);
            int rows = cmd.ExecuteNonQuery();
            return rows;
        }
        /// <summary>
        /// 执行sql并返回首行首列
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sqlText, params SqlParameter[] sqlParameters)
        {
            //创建仓库钥匙
            using SqlConnection conn = new SqlConnection(_options.ConStr);
            conn.Open();
            //告诉仓库管理员要干什么，即sqlText。
            //把钥匙交到管理员手上，即conn
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            cmd.Parameters.Add(sqlParameters);
            object res = cmd.ExecuteScalar();
            return res;
        }
        /// <summary>
        /// C#=>null 转换 DB=>DBNUll
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public object ToDbValue(object value)
        {
            return value == null ? DBNull.Value : value;
        }
        /// <summary>
        ///  DB=>DBNUll 转换 C#=>null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public object FromDbValue(object value)
        {
            return value == DBNull.Value ? null : value;
        }
    }
}
