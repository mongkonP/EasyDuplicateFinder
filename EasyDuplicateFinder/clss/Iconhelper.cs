using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyDuplicateFinder
{
    public enum IconSizes : int
    {
        Large32x32 = 0,
        Small16x16 = 1
    }

    public class Iconhelper
    {
        private const int SHGFI_ICON = 0x100;
        private const int SHGFI_USEFILEATTRIBUTES = 0x10;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct SHFILEINFOW
        {
            public IntPtr hIcon;
            public int iIcon;
            public int dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [DllImport("shell32.dll", EntryPoint = "SHGetFileInfoW")]
        private static extern int SHGetFileInfoW([MarshalAs(UnmanagedType.LPTStr)] string pszPath, int dwFileAttributes, ref SHFILEINFOW psfi, int cbFileInfo, int uFlags);



        [DllImport("user32.dll", EntryPoint = "DestroyIcon")]
        private static extern bool DestroyIcon(IntPtr hIcon);
        

        /// <summary>Gets a Bitmap image of the specified file or folder icon.</summary>
        ///     ''' <param name="FileOrFolderPath">The full path to the folder or file to get the icon image from, or just a file extension (.ext) to get the registered icon image of the file type.</param>
        ///     ''' <param name="IconSize">The size of the icon to retrieve.</param>
        public static Bitmap GetIconImage(string FileOrFolderPath, IconSizes IconSize)
        {
            Bitmap bm = null/* TODO Change to default(_) if this is not a reference type */;
            SHFILEINFOW fi = new SHFILEINFOW();
            int flags = FileOrFolderPath.StartsWith(".") ?  (((int)IconSize)|SHGFI_USEFILEATTRIBUTES) : ((int)IconSize);
            if (SHGetFileInfoW(FileOrFolderPath, 0, ref fi, Marshal.SizeOf(fi), SHGFI_ICON | flags) != 0)
                bm = Icon.FromHandle(fi.hIcon).ToBitmap();
            DestroyIcon(fi.hIcon).ToString();
            return bm;
        }
    }
}
