using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NativeAlert.Tools
{
    public static class Notification
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr MessageBox(IntPtr hWnd, string text, string caption, uint type);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_RESTORE = 9;
        private const string AppleScriptPath = "/usr/bin/osascript";

        public static void Show(string message, string title)
        {
#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_OSX
        string script = $"display notification \"{message}\" with title \"{title}\"";
        ExecuteAppleScript(script);
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
            IntPtr hWnd = GetForegroundWindow();
            MessageBox(hWnd, message, title, 0);
            if (IsIconic(hWnd))
            {
                ShowWindow(hWnd, SW_RESTORE);
            }
#endif
        }

        private static void ExecuteAppleScript(string script)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = AppleScriptPath,
                Arguments = $"-e '{script}'",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}