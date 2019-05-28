using Util.Tools.Offices.Core;

namespace Util.Tools.Offices.Npoi {
    /// <summary>
    /// 颜色转换
    /// </summary>
    public class ColorResolver {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="color">颜色枚举</param>
        public static short Resolve( Color color ) {
            switch ( color ) {
                case Color.Aqua:
                    return 0x31;
                case Color.Black:
                    return 0x8;
                case Color.Blue:
                    return 0xc;
                case Color.BlueGrey:
                    return 0x36;
                case Color.BrightGreen:
                    return 0xb;
                case Color.Brown:
                    return 0x3c;
                case Color.Coral:
                    return 0x1d;
                case Color.CornflowerBlue:
                    return 0x1f;
                case Color.DarkBlue:
                    return 0x12;
                case Color.DarkGreen:
                    return 0x3a;
                case Color.DarkRed:
                    return 0x10;
                case Color.DarkTeal:
                    return 0x38;
                case Color.DarkYellow:
                    return 0x13;
                case Color.Gold:
                    return 0x33;
                case Color.Green:
                    return 0xb;
                case Color.Grey25Percent:
                    return 0x16;
                case Color.Grey40Percent:
                    return 0x37;
                case Color.Grey50Percent:
                    return 0x17;
                case Color.Grey80Percent:
                    return 0x3f;
                case Color.Indigo:
                    return 0x3e;
                case Color.Lavender:
                    return 0x2e;
                case Color.LemonChiffon:
                    return 0x1a;
                case Color.LightBlue:
                    return 0x30;
                case Color.LightCornflowerBlue:
                    return 0x1f;
                case Color.LightGreen:
                    return 0x2a;
                case Color.LightOrange:
                    return 0x34;
                case Color.LightTurquoise:
                    return 0x29;
                case Color.LightYellow:
                    return 0x2b;
                case Color.Lime:
                    return 0x32;
                case Color.Maroon:
                    return 0x19;
                case Color.OliveGreen:
                    return 0x3b;
                case Color.Orange:
                    return 0x35;
                case Color.Orchid:
                    return 0x1c;
                case Color.PaleBlue:
                    return 0x2c;
                case Color.Pink:
                    return 0xe;
                case Color.Plum:
                    return 0x3d;
                case Color.Red:
                    return 0xa;
                case Color.Rose:
                    return 0x2d;
                case Color.RoyalBlue:
                    return 0x1e;
                case Color.SeaGreen:
                    return 0x39;
                case Color.SkyBlue:
                    return 0x28;
                case Color.Tan:
                    return 0x2f;
                case Color.Teal:
                    return 0x15;
                case Color.Turquoise:
                    return 0xf;
                case Color.Violet:
                    return 0x14;
                case Color.White:
                    return 0x9;
                case Color.Yellow:
                    return 0xd;
                default:
                    return 0x3e;
            }
        }
    }
}
