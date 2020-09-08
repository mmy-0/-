using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace 后台管理
{
    public static class MyDataGridBiew
    {
        /// <summary>
        /// 表格与数据关联
        /// </summary>
        /// <param name="dgv">表格</param>
        /// <param name="sql">sql语句</param>
        public static void DataConnection(DataGridView dgv, string sql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = SQLManage.Connection())
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    sda.SelectCommand = com;
                    com.ExecuteNonQuery();
                    sda.Fill(ds);
                }
            }
            dgv.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 格式化表格
        /// </summary>
        /// <param name="dgv">表格</param>
        /// <param name="RowHeadersVisible">是否显示头列</param>
        /// <param name="ColumnHeadersVisible">是否显示头行</param>
        /// <param name="ColumnHeadersDefaultCellStyleBackColor">头行背景颜色</param>
        /// <param name="ColumnHeadersDefaultCellStyleForceColor">头行字体颜色</param>
        /// <param name="DefaultCellStyleBackColor">表格内容背景颜色</param>
        /// <param name="DefaultCellStyleForeColor">表格内容字体颜色</param>
        public static void Format(DataGridView dgv, bool RowHeadersVisible, bool ColumnHeadersVisible, Color ColumnHeadersDefaultCellStyleBackColor,
             Color ColumnHeadersDefaultCellStyleForceColor, Color DefaultCellStyleBackColor, Color DefaultCellStyleForeColor)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = RowHeadersVisible;
            dgv.ColumnHeadersVisible = ColumnHeadersVisible;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColumnHeadersDefaultCellStyleBackColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColumnHeadersDefaultCellStyleForceColor;
            dgv.DefaultCellStyle.BackColor = DefaultCellStyleBackColor;
            dgv.DefaultCellStyle.ForeColor = DefaultCellStyleForeColor;
        }

        /// <summary>
        /// 用户能都调整表格
        /// </summary>
        /// <param name="dgv">表格</param>
        /// <param name="AllowUserToResizeColumns">用户是否能够调整列宽</param>
        /// <param name="AllowUserToResizeRows">用户是否能够调整行高</param>
        public static void IsControl(DataGridView dgv, bool AllowUserToResizeColumns, bool AllowUserToResizeRows)
        {
            dgv.AllowUserToResizeColumns = AllowUserToResizeColumns;
            dgv.AllowUserToResizeRows = AllowUserToResizeRows;
        }

        public static void SetWidth(DataGridView dgv, int[] widths)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = widths[i];
            }
        }
    }
}