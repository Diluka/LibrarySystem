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
    /// <summary>
    /// 可以使用的字体名称枚举
    /// </summary>
    public enum FontName
    {
        叶根友毛笔行书
    }
    public static class Fonts
    {
        private static Dictionary<FontName, FontFamily> fontFamilies = new Dictionary<FontName, FontFamily>();

        /// <summary>
        /// 获得字体
        /// </summary>
        /// <param name="name">FontsPack.FontName中的字体名称枚举</param>
        /// <param name="size">字体大小，Unit单位</param>
        /// <returns>字体</returns>
        public static Font GetFont(FontName name, float size)
        {
            FontFamily ff;

            if (!fontFamilies.ContainsKey(name))
            {
                switch (name)
                {
                    case FontName.叶根友毛笔行书:
                        ff = GetFontFamily(FontResource.Fontfile1);
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

        /// <summary>
        /// 获得字体类型
        /// </summary>
        /// <param name="name">FontsPack.FontName中的字体名称枚举</param>
        /// <returns>字体类型</returns>
        public static FontFamily GetFontFamily(FontName name)
        {
            FontFamily ff;

            if (!fontFamilies.ContainsKey(name))
            {
                switch (name)
                {
                    case FontName.叶根友毛笔行书:
                        ff = GetFontFamily(FontResource.Fontfile1);
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
            return ff;
        }

    }
}
