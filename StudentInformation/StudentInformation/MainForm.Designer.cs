namespace StudentInformation
{
    partial class MainForm
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
            this.metroButtonOpenFile = new MetroFramework.Controls.MetroButton();
            this.metroButtonAddStudent = new MetroFramework.Controls.MetroButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.metroButtonExit = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroButtonOpenFile
            // 
            this.metroButtonOpenFile.Location = new System.Drawing.Point(156, 88);
            this.metroButtonOpenFile.Name = "metroButtonOpenFile";
            this.metroButtonOpenFile.Size = new System.Drawing.Size(168, 88);
            this.metroButtonOpenFile.TabIndex = 0;
            this.metroButtonOpenFile.Text = "Открыть файл";
            this.metroButtonOpenFile.Click += new System.EventHandler(this.metroButtonOpenFile_Click);
            // 
            // metroButtonAddStudent
            // 
            this.metroButtonAddStudent.Location = new System.Drawing.Point(156, 208);
            this.metroButtonAddStudent.Name = "metroButtonAddStudent";
            this.metroButtonAddStudent.Size = new System.Drawing.Size(168, 88);
            this.metroButtonAddStudent.TabIndex = 1;
            this.metroButtonAddStudent.Text = "Добавить нового студента";
            this.metroButtonAddStudent.Click += new System.EventHandler(this.metroButtonAddStudent_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // metroButtonExit
            // 
            this.metroButtonExit.Location = new System.Drawing.Point(156, 326);
            this.metroButtonExit.Name = "metroButtonExit";
            this.metroButtonExit.Size = new System.Drawing.Size(168, 88);
            this.metroButtonExit.TabIndex = 2;
            this.metroButtonExit.Text = "Выход";
            this.metroButtonExit.Click += new System.EventHandler(this.metroButtonExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 450);
            this.Controls.Add(this.metroButtonExit);
            this.Controls.Add(this.metroButtonAddStudent);
            this.Controls.Add(this.metroButtonOpenFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "СВЕДЕНИЯ О СТУДЕНТЕ";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButtonOpenFile;
        private MetroFramework.Controls.MetroButton metroButtonAddStudent;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroButton metroButtonExit;
    }
}

