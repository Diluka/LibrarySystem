using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagement
{
    class FontMgr
    {
        public static PrivateFontCollection fonts = new PrivateFontCollection();

        static FontMgr()
        {
            fonts.AddFontFile(Application.StartupPath + @"\fonts\ygyxsziti2.0.ttf");
        }
    }
}
