namespace XML4PFR
{
    partial class fmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.btnExecute = new System.Windows.Forms.Button();
            this.bntSelectSourceDirectory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTargetDirectory = new System.Windows.Forms.TextBox();
            this.btnSelectDirectory = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.history = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbSourceFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbStrategy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbProvider = new System.Windows.Forms.ComboBox();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExecute.Location = new System.Drawing.Point(447, 215);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(215, 52);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Конвертировать";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // bntSelectSourceDirectory
            // 
            this.bntSelectSourceDirectory.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bntSelectSourceDirectory.Location = new System.Drawing.Point(611, 130);
            this.bntSelectSourceDirectory.Name = "bntSelectSourceDirectory";
            this.bntSelectSourceDirectory.Size = new System.Drawing.Size(51, 26);
            this.bntSelectSourceDirectory.TabIndex = 3;
            this.bntSelectSourceDirectory.Text = "...";
            this.bntSelectSourceDirectory.UseVisualStyleBackColor = true;
            this.bntSelectSourceDirectory.Click += new System.EventHandler(this.bntSelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Файл для конвертации";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Сохранять в";
            // 
            // tbTargetDirectory
            // 
            this.tbTargetDirectory.Enabled = false;
            this.tbTargetDirectory.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTargetDirectory.Location = new System.Drawing.Point(12, 180);
            this.tbTargetDirectory.Name = "tbTargetDirectory";
            this.tbTargetDirectory.Size = new System.Drawing.Size(593, 24);
            this.tbTargetDirectory.TabIndex = 4;
            this.tbTargetDirectory.Text = "C:\\";
            // 
            // btnSelectDirectory
            // 
            this.btnSelectDirectory.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectDirectory.Location = new System.Drawing.Point(612, 180);
            this.btnSelectDirectory.Name = "btnSelectDirectory";
            this.btnSelectDirectory.Size = new System.Drawing.Size(50, 26);
            this.btnSelectDirectory.TabIndex = 5;
            this.btnSelectDirectory.Text = "...";
            this.btnSelectDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.history});
            this.status.Location = new System.Drawing.Point(0, 280);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(674, 22);
            this.status.TabIndex = 7;
            this.status.Text = "statusStrip1";
            // 
            // history
            // 
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(0, 17);
            // 
            // tbSourceFile
            // 
            this.tbSourceFile.Enabled = false;
            this.tbSourceFile.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSourceFile.Location = new System.Drawing.Point(12, 130);
            this.tbSourceFile.Name = "tbSourceFile";
            this.tbSourceFile.Size = new System.Drawing.Size(593, 24);
            this.tbSourceFile.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Обработчик";
            // 
            // cbStrategy
            // 
            this.cbStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStrategy.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbStrategy.FormattingEnabled = true;
            this.cbStrategy.Location = new System.Drawing.Point(12, 80);
            this.cbStrategy.Name = "cbStrategy";
            this.cbStrategy.Size = new System.Drawing.Size(650, 25);
            this.cbStrategy.TabIndex = 1;
            this.cbStrategy.DropDownClosed += new System.EventHandler(this.cbReader_DropDownClosed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Поставщик";
            // 
            // cbProvider
            // 
            this.cbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvider.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbProvider.FormattingEnabled = true;
            this.cbProvider.Location = new System.Drawing.Point(12, 30);
            this.cbProvider.Name = "cbProvider";
            this.cbProvider.Size = new System.Drawing.Size(650, 25);
            this.cbProvider.TabIndex = 0;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 302);
            this.Controls.Add(this.cbProvider);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbStrategy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.status);
            this.Controls.Add(this.btnSelectDirectory);
            this.Controls.Add(this.tbTargetDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSourceFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bntSelectSourceDirectory);
            this.Controls.Add(this.btnExecute);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(690, 340);
            this.MinimumSize = new System.Drawing.Size(590, 340);
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML4PFR";
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button bntSelectSourceDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTargetDirectory;
        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel history;
        private System.Windows.Forms.TextBox tbSourceFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbStrategy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbProvider;
    }
}

