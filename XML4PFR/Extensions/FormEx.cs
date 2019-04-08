using System;
using System.Text;
using System.Windows.Forms;

namespace Extensions
{
    static class FormEx
    {
        public static StringBuilder AppendFormatLine(this StringBuilder sb, string format, params object[] args)
        {
            return sb.AppendFormat(format, args).AppendLine();
        }

        public static FileDialog If(this FileDialog dialog, Predicate<FileDialog> predicat)
        {
            if (predicat(dialog))
                return dialog;
            return null;
        }
        
        public static void Do(this FileDialog dialog, Action<FileDialog> action)
        {
            if (dialog != null) 
                action(dialog);
        }

        public static FolderBrowserDialog If(this FolderBrowserDialog dialog, Predicate<FolderBrowserDialog> predicat)
        {
            if (predicat(dialog))
                return dialog;
            return null;
        }

        public static void Do(this FolderBrowserDialog dialog, Action<FolderBrowserDialog> action)
        {
            if (dialog != null)
                action(dialog);
        }

        public static void InvokeEx(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}
