using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJ02D201812022328EP
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ///窗体启动顺序
            ///1.登录注册窗体frmLogRegister
            ///2.主窗体:frmMy

            frmLogRegister loginFrm = new frmLogRegister();//登录注册界面


            if (loginFrm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMy());///
            }

          //  Application.Run(new frmHistoryEletic());///
  
        }
    }
}
