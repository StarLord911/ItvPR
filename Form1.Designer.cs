namespace Itv
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateForms = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateForms
            // 
            this.CreateForms.Location = new System.Drawing.Point(212, 304);
            this.CreateForms.Name = "CreateForms";
            this.CreateForms.Size = new System.Drawing.Size(149, 23);
            this.CreateForms.TabIndex = 1;
            this.CreateForms.Text = "Создать окно";
            this.CreateForms.UseVisualStyleBackColor = true;
            this.CreateForms.Click += new System.EventHandler(this.CreateForms_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.CreateForms);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Itv.Properties.Settings.Default, "HighForm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CreateForms;
    }
}

