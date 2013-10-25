using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FontsPack
{
    public enum FontName
    {
        叶根友毛笔行书
    }
    public static class Fonts
    {
        private static Dictionary<FontName, FontFamily> fontFamilies = new Dictionary<FontName, FontFamily>();
        public static Font GetFont(FontName name, float size)
        {
            FontFamily ff;
            
            if (!fontFamilies.ContainsKey(name))
            {
                switch (name)
                {
                    case FontName.叶根友毛笔行书:
                        ff = GetFontFamily(FontResource.叶根友毛笔行书);
                        fontFamilies.Add(name, ff);
                        break;
                    default:
                        ff = null;
                        break;
                }
            }
            else
            {
                ff = fontFamilies[name];
            }
            if (ff == null) throw new Exception("字体未定义或者不存在！");
            return new Font(ff, size);
        }

        private static FontFamily GetFontFamily(byte[] bytes)
        {
            PrivateFontCollection privateFonts = new PrivateFontCollection();
            IntPtr pFont = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, pFont, bytes.Length);
            privateFonts.AddMemoryFont(pFont, bytes.Length);
            return privateFonts.Families[0];
        }

    }
}
