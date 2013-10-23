using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTools
{
    /// <summary>
    /// 窗体全屏化管理器
    /// </summary>
    public class FormFullScreenManager
    {
        private FormWindowState winState;
        private FormBorderStyle brdStyle;
        private bool topMost;
        private Rectangle bounds;
        private Form target;

        /// <summary>
        /// 窗体全屏化管理器
        /// </summary>
        /// <param name="target">窗体</param>
        public FormFullScreenManager(Form target)
        {
            this.target = target;
        }

        /// <summary>
        /// 是否全屏
        /// </summary>
        public bool IsFullScreen
        {
            get;
            private set;
        }

        /// <summary>
        /// 全屏化
        /// </summary>
        public void FullScreen()
        {
            if (!IsFullScreen)
            {
                IsFullScreen = true;
                SaveCurrentState();
                target.WindowState = FormWindowState.Maximized;
                target.FormBorderStyle = FormBorderStyle.None;
                target.TopMost = true;
                WinApi.SetWinFullScreen(target.Handle);
            }
        }

        /// <summary>
        /// 保存当前窗体状态
        /// </summary>
        private void SaveCurrentState()
        {
            winState = target.WindowState;
            brdStyle = target.FormBorderStyle;
            topMost = target.TopMost;
            bounds = target.Bounds;
        }

        /// <summary>
        /// 还原已保存的窗体状态
        /// </summary>
        public void Restore()
        {
            target.WindowState = winState;
            target.FormBorderStyle = brdStyle;
            target.TopMost = topMost;
            target.Bounds = bounds;
            IsFullScreen = false;
        }
    }
}
