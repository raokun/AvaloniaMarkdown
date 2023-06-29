using AvaloniaMarkdown.Views;
using ReactiveUI;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Threading;
using System.IO;

namespace AvaloniaMarkdown.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Window _mainWindow;

        public MainWindowViewModel(Window mainWindow)
        {
            _mainWindow = mainWindow;
            UploadCommand = ReactiveCommand.Create(UploadFile);
            SaveCommand = ReactiveCommand.Create(SaveFile);
        }

        private string _text="hello";
        public string Text
        {
            get => _text;
            set => this.RaiseAndSetIfChanged(ref _text, value);
        }
        private string _filePath;

        public string FilePath 
        { 
            get => _filePath;
            set => this.RaiseAndSetIfChanged(ref _filePath, value);
        }

        public ICommand UploadCommand { get; }
        public ICommand SaveCommand { get; }

        private async Task UploadFile()
        {
            // 打开文件选择对话框
            var openFileDialog = new OpenFileDialog
            {
                Filters = new List<FileDialogFilter>
                {
            new FileDialogFilter { Name = "Markdown Files", Extensions = { "md", "markdown" } }
        }
            };

            var selectedFiles = await openFileDialog.ShowAsync(_mainWindow);

            // 检查是否选择了文件
            if (selectedFiles == null || selectedFiles.Length == 0)
                return;
            FilePath= selectedFiles[0];
            // 读取文件内容
            Text = await File.ReadAllTextAsync(selectedFiles[0]);

            
        }

        private async Task SaveFile()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filters = new List<FileDialogFilter>
                {
            new FileDialogFilter { Name = "Markdown Files", Extensions = { "md", "markdown" } }
        }
                };
                var saveFile = await saveFileDialog.ShowAsync(_mainWindow);
                // 检查是否选择了文件
                if (saveFile == null || saveFile.Length == 0)
                    return;
                await File.WriteAllTextAsync(saveFile, Text);
                FilePath = saveFile;
            }
            await File.WriteAllTextAsync(FilePath, Text);
        }
    }
}