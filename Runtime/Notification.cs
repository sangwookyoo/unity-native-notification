using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NativeAlert.Tools
{
    public static class Notification
    {
#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        private const string AppleScriptPath = "/usr/bin/osascript";

        public static void Show(string title, string message)
        {
            string script = $"display notification \"{message}\" with title \"{title}\"";
            ExecuteAppleScript(script);
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
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        private static NotifyIcon _notifyIcon;

        public static void Show(string title, string message, string iconPath = null)
        {
            InitializeNotifyIcon(iconPath);

            _notifyIcon.BalloonTipTitle = title;
            _notifyIcon.BalloonTipText = message;
            _notifyIcon.ShowBalloonTip(3000);
            _notifyIcon.BalloonTipClicked += OnBalloonTipDispose;
            _notifyIcon.BalloonTipClosed += OnBalloonTipDispose;
        }

        private static void InitializeNotifyIcon(string iconPath)
        {
            _notifyIcon?.Dispose();
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Visible = true;
            _notifyIcon.Icon = SetIcon(iconPath);
        }
        
        private static Icon SetIcon(string iconPath)
        {
            return iconPath != string.Empty
                ? File.Exists(iconPath) ? new Icon(iconPath) : SystemIcons.Information
                : SystemIcons.Information;
        }
        
        private static void OnBalloonTipDispose(object sender, EventArgs e)
        {
            _notifyIcon?.Dispose();
        }
#endif
    }
}