using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace UsefulStuff
{
    /// <summary>
    /// Uses undocumented user32.dll string id's gained from running LoadString() against values 0-1000
    /// </summary>
    public static class LocaleStrings
    {
        public static string Close { get; }
        public static string Yes { get; }
        public static string TryAgain { get; }
        public static string Retry { get; }
        public static string Ok { get; }
        public static string No { get; }
        public static string Ignore { get; }
        public static string Help { get; }
        public static string Continue { get; }
        public static string Cancel { get; }
        public static string Abort { get; }
        public static string Error { get; }

        public static string Load(uint id) => LoadString(id);

        static LocaleStrings()
        {
            _libraryHandle = GetModuleHandle(Environment.SystemDirectory + "\\User32.dll");
            if (_libraryHandle == IntPtr.Zero) throw new FileLoadException("Unable to get User32.dll Module Handle");
            Error = LoadString((uint)User32StringIds.Error);
            Abort = LoadString((uint)User32StringIds.Abort);
            Cancel = LoadString((uint)User32StringIds.Cancel);
            Close = LoadString((uint)User32StringIds.Close);
            Continue = LoadString((uint)User32StringIds.Continue);
            Help = LoadString((uint)User32StringIds.Help);
            Ignore = LoadString((uint)User32StringIds.Ignore);
            No = LoadString((uint)User32StringIds.No);
            Ok = LoadString((uint)User32StringIds.Ok);
            Retry = LoadString((uint)User32StringIds.Retry);
            TryAgain = LoadString((uint)User32StringIds.TryAgain);
            Yes = LoadString((uint)User32StringIds.Yes);
        }

        static string LoadString(uint Ident)
        {
            var sb = new StringBuilder(1024);

            return LoadString(_libraryHandle, Ident, sb, 1024) > 0 
                ? sb.ToString().Replace("&","") 
                : string.Empty;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int LoadString(IntPtr hInstance, uint uID, StringBuilder lpBuffer, int nBufferMax);

        private static IntPtr _libraryHandle;
        private enum User32StringIds : uint
        {
            Error = 2,
            Ok = 800,
            Cancel = 801,
            Abort = 802,
            Retry = 803,
            Ignore = 804,
            Yes = 805,
            No = 806,
            Close = 807,
            Help = 808,
            TryAgain = 809,
            Continue = 810
            // Some other single word ones I found that aren't particularily useful
            //            Minimise = 900,
            //            Maximise = 901,
            //            RestoreUp = 902,
            //            RestoreDown = 903,
            //            Help2 = 904,
            //            Close2 = 905,
            //            Image = 1001,
            //            Text = 1002,
            //            Audio = 1003,
            //            Other = 1004,
            //            Unknown = 8267,
        }
    }
}