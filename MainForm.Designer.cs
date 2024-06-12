namespace DiskPart_Control_Assistant
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Main_treeView = new System.Windows.Forms.TreeView();
            this.Update_Disks_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Main_treeView
            // 
            this.Main_treeView.Location = new System.Drawing.Point(12, 41);
            this.Main_treeView.Name = "Main_treeView";
            this.Main_treeView.Size = new System.Drawing.Size(283, 397);
            this.Main_treeView.TabIndex = 0;
            // 
            // Update_Disks_button
            // 
            this.Update_Disks_button.Location = new System.Drawing.Point(12, 12);
            this.Update_Disks_button.Name = "Update_Disks_button";
            this.Update_Disks_button.Size = new System.Drawing.Size(283, 23);
            this.Update_Disks_button.TabIndex = 1;
            this.Update_Disks_button.Text = "&Update Disks";
            this.Update_Disks_button.UseVisualStyleBackColor = true;
            this.Update_Disks_button.Click += new System.EventHandler(this.Update_Disks_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Update_Disks_button);
            this.Controls.Add(this.Main_treeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DiskPart Control Assistant";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Main_treeView;
        private System.Windows.Forms.Button Update_Disks_button;
    }
}

