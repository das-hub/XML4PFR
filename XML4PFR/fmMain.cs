using Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML4PFR.Core;
using XML4PFR.Engine.Builders;
using XML4PFR.Engine.Handlers;

namespace XML4PFR
{
    public partial class fmMain : Form
    {
        private readonly Dictionary<string, int> _providerCache;
        private readonly Dictionary<string, IStrategy> _strategies;

        public fmMain()
        {
            InitializeComponent();

            Text = $"{App.Name} v{App.Version}";

            _strategies = new Dictionary<string, IStrategy>()
            {
                {"Запросы валидации (CSV - обработка)", new ValidationCsvStrategy()},
                {"Запросы валидации (Excel - обработка)", new ValidationExcelStrategy()},
                {"Запросы идентификации (Excel - обработка)", new IdentificationExcelStrategy()},
            };

            _providerCache = new Dictionary<string, int>();

            Bind();
        }

        private void Lock()
        {
            this.InvokeEx(() =>
            {
                btnExecute.Enabled = !btnExecute.Enabled;
            });
        }

        private void Bind()
        {
            tbTargetDirectory.Text = App.Paths.XML;

            cbProvider.DataSource = new BindingSource(App.Config.Providers, null);
            cbProvider.DisplayMember = "caption";
            cbProvider.ValueMember = "code";
            cbProvider.SelectedIndex = 0;

            cbStrategy.DataSource = new BindingSource(_strategies, null);
            cbStrategy.DisplayMember = "Key";
            cbStrategy.ValueMember = "Value";
            cbStrategy.SelectedIndex = 0;
            
            btnExecute.DataBindings.Add(new Binding("Enabled", tbSourceFile, "Text.Length"));
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            StatusMessage = "";

            IStrategy strategy = (IStrategy) cbStrategy.SelectedValue;

            string provider = cbProvider.SelectedValue.ToString();

            if (!_providerCache.ContainsKey(provider))
                _providerCache.Add(provider, 1);            

            Task.Factory.StartNew(() =>
            {
                Lock();
              
                RequestBuilder builder = strategy.Handler(tbSourceFile.Text, provider, _providerCache[provider]++);

                builder.Information += Information;
                builder.Error += Error;
                builder.Complete += Complete;
                
                builder.BuildTo(tbTargetDirectory.Text);
                
                Lock();

            }).ContinueWith(t =>
            {
                foreach (var ex in t.Exception.Flatten().InnerExceptions)
                {
                    App.Log.Error($" Произошла ошибка [{ex.GetType()}]: {ex.Message}");
                }

                StatusMessage = "Произошла критическая ошибка (см. лог программы).";

                Lock();

            }, TaskContinuationOptions.OnlyOnFaulted);            
        }

        private void Complete(object sender, RequestBuilderEventArgs requestBuilderEventArgs)
        {
            StatusMessage = requestBuilderEventArgs.Message;
        }

        private void Error(object sender, RequestBuilderEventArgs requestBuilderEventArgs)
        {
            App.Log.Error(requestBuilderEventArgs.Message);
        }

        private void Information(object sender, RequestBuilderEventArgs requestBuilderEventArgs)
        {
            App.Log.Info(requestBuilderEventArgs.Message);
            StatusMessage = requestBuilderEventArgs.Message;            
        }

        private void bntSelectFile_Click(object sender, EventArgs e)
        {
            IStrategy strategy = (IStrategy)cbStrategy.SelectedValue;

            Forms.OpenFileDialog(strategy.Filter).If(d => d.ShowDialog() == DialogResult.OK).Do(d =>
            {
                tbSourceFile.Text = d.FileName;
            }); 
        }

        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            Forms.OpenBrowserDialog().If(d => d.ShowDialog() == DialogResult.OK).Do(d => tbTargetDirectory.Text = d.SelectedPath);
        }

        private void cbReader_DropDownClosed(object sender, EventArgs e)
        {
            if (tbSourceFile.Text.Length != 0)
                tbSourceFile.Text = "";
        }

        public string StatusMessage
        {
            set
            {
                this.InvokeEx(() =>
                {
                    history.Text = value;
                });
            }
        }
    }
}
