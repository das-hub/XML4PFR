using System.Windows.Forms;

namespace Extensions
{
    public static class Forms
    {
        private static OpenFileDialog _openFileDialog;
        private static FolderBrowserDialog _folderBrowserDialog;

        public static OpenFileDialog OpenFileDialog(string filter)
        {
            if (_openFileDialog == null)
            {
                _openFileDialog = new OpenFileDialog {Title = @"Укажите файл для конвертации"};
            }
            
            _openFileDialog.Filter = filter;

            return _openFileDialog;
        }

        public static FolderBrowserDialog OpenBrowserDialog()
        {
            if (_folderBrowserDialog == null)
            {
                _folderBrowserDialog = new FolderBrowserDialog {Description = @"Укажите каталог для сохранения файла"};
            }

            return _folderBrowserDialog;
        }

        public static void Error(string message)
        {
            MessageBox.Show(message, "Остановка обработки" ,MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public static void Info(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
