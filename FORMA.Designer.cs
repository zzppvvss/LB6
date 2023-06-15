namespace C_LAB6
{
  partial class LB6
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
            this.select_file = new System.Windows.Forms.Button();
            this.upload_file = new System.Windows.Forms.Button();
            this.file = new System.Windows.Forms.Label();
            this.files_list = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.update_files_list = new System.Windows.Forms.Button();
            this.play_selected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // select_file
            // 
            this.select_file.BackColor = System.Drawing.Color.Silver;
            this.select_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_file.Location = new System.Drawing.Point(259, 405);
            this.select_file.Name = "select_file";
            this.select_file.Size = new System.Drawing.Size(165, 23);
            this.select_file.TabIndex = 1;
            this.select_file.Text = "Обрати";
            this.select_file.UseVisualStyleBackColor = false;
            this.select_file.Click += new System.EventHandler(this.select_file_Click);
            // 
            // upload_file
            // 
            this.upload_file.BackColor = System.Drawing.Color.Thistle;
            this.upload_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upload_file.Location = new System.Drawing.Point(477, 402);
            this.upload_file.Name = "upload_file";
            this.upload_file.Size = new System.Drawing.Size(165, 68);
            this.upload_file.TabIndex = 2;
            this.upload_file.Text = "Завантажити на сервер";
            this.upload_file.UseVisualStyleBackColor = false;
            this.upload_file.Click += new System.EventHandler(this.upload_file_Click);
            // 
            // file
            // 
            this.file.AutoSize = true;
            this.file.Location = new System.Drawing.Point(101, 13);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(10, 13);
            this.file.TabIndex = 4;
            this.file.Text = "-";
            // 
            // files_list
            // 
            this.files_list.BackColor = System.Drawing.Color.PeachPuff;
            this.files_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.files_list.FormattingEnabled = true;
            this.files_list.Location = new System.Drawing.Point(24, 31);
            this.files_list.Name = "files_list";
            this.files_list.Size = new System.Drawing.Size(618, 351);
            this.files_list.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Audio:";
            // 
            // update_files_list
            // 
            this.update_files_list.BackColor = System.Drawing.Color.MediumTurquoise;
            this.update_files_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update_files_list.Location = new System.Drawing.Point(24, 405);
            this.update_files_list.Name = "update_files_list";
            this.update_files_list.Size = new System.Drawing.Size(165, 63);
            this.update_files_list.TabIndex = 7;
            this.update_files_list.Text = "Оновити список";
            this.update_files_list.UseVisualStyleBackColor = false;
            this.update_files_list.Click += new System.EventHandler(this.update_files_list_Click);
            // 
            // play_selected
            // 
            this.play_selected.BackColor = System.Drawing.Color.YellowGreen;
            this.play_selected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.play_selected.Location = new System.Drawing.Point(259, 445);
            this.play_selected.Name = "play_selected";
            this.play_selected.Size = new System.Drawing.Size(165, 23);
            this.play_selected.TabIndex = 8;
            this.play_selected.Text = "Відтворити";
            this.play_selected.UseVisualStyleBackColor = false;
            this.play_selected.Click += new System.EventHandler(this.play_selected_Click);
            // 
            // LB6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(667, 480);
            this.Controls.Add(this.play_selected);
            this.Controls.Add(this.update_files_list);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.files_list);
            this.Controls.Add(this.file);
            this.Controls.Add(this.upload_file);
            this.Controls.Add(this.select_file);
            this.Name = "LB6";
            this.Text = "LB6 -- Korovina";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button select_file;
    private System.Windows.Forms.Button upload_file;
    private System.Windows.Forms.Label file;
    private System.Windows.Forms.ListBox files_list;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button update_files_list;
    private System.Windows.Forms.Button play_selected;
    }
}

