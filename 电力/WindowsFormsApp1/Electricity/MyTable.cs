using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 控制table的工具类
/// </summary>
namespace Electricity
{
    class MyTable
    {
        public static void SetRowCount(TableLayoutPanel table, int count)
        {
            table.RowCount = count;
        }

        public static void SetColumnCount(TableLayoutPanel table, int count)
        {
            table.ColumnCount = count;
        }

        public static void SetRowHeight(TableLayoutPanel table, int row, float height)
        {
            table.RowStyles[row].Height = height;
        }

        public static void SetTableSize(TableLayoutPanel table, int width, int height)
        {
            table.Width = width;
            table.Height = height;
        }

        public static void SetTableWidth(TableLayoutPanel table, int width)
        {
            table.Width = width;
        }

        public static void SetTableHeight(TableLayoutPanel table, int height)
        {
            table.Height = height;
        }

        public static Control GetControl(TableLayoutPanel table, int row, int column)
        {
            return table.GetControlFromPosition(row, column);
        }
    }
}
