namespace HuffmanRealization
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.encodeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.decodeBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openText = new System.Windows.Forms.ToolStripMenuItem();
            this.openCode = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCodeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTextBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.compressedTextBox = new System.Windows.Forms.RichTextBox();
            this.encodeTreeBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // encodeBtn
            // 
            this.encodeBtn.Location = new System.Drawing.Point(12, 326);
            this.encodeBtn.Name = "encodeBtn";
            this.encodeBtn.Size = new System.Drawing.Size(147, 40);
            this.encodeBtn.TabIndex = 1;
            this.encodeBtn.Text = "Получить сжатый код";
            this.encodeBtn.UseVisualStyleBackColor = true;
            this.encodeBtn.Click += new System.EventHandler(this.encodeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // decodeBtn
            // 
            this.decodeBtn.Location = new System.Drawing.Point(423, 326);
            this.decodeBtn.Name = "decodeBtn";
            this.decodeBtn.Size = new System.Drawing.Size(147, 40);
            this.decodeBtn.TabIndex = 8;
            this.decodeBtn.Text = "Получить текст из кода";
            this.decodeBtn.UseVisualStyleBackColor = true;
            this.decodeBtn.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.clearBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(665, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openText,
            this.openCode,
            this.сохранитьToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.менюToolStripMenuItem.Text = "Файл";
            // 
            // openText
            // 
            this.openText.Name = "openText";
            this.openText.Size = new System.Drawing.Size(180, 22);
            this.openText.Text = "Открыть текст";
            this.openText.Click += new System.EventHandler(this.openText_Click);
            // 
            // openCode
            // 
            this.openCode.Name = "openCode";
            this.openCode.Size = new System.Drawing.Size(180, 22);
            this.openCode.Text = "Открыть код";
            this.openCode.Click += new System.EventHandler(this.openCode_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveCodeBtn,
            this.SaveTextBtn});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // SaveCodeBtn
            // 
            this.SaveCodeBtn.Name = "SaveCodeBtn";
            this.SaveCodeBtn.Size = new System.Drawing.Size(163, 22);
            this.SaveCodeBtn.Text = "Сохранить код";
            this.SaveCodeBtn.Click += new System.EventHandler(this.SaveCodeBtn_Click);
            // 
            // SaveTextBtn
            // 
            this.SaveTextBtn.Name = "SaveTextBtn";
            this.SaveTextBtn.Size = new System.Drawing.Size(163, 22);
            this.SaveTextBtn.Text = "Сохранить текст";
            this.SaveTextBtn.Click += new System.EventHandler(this.SaveTextBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(71, 20);
            this.clearBtn.Text = "Очистить";
            this.clearBtn.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.Window;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(12, 27);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(302, 293);
            this.textBox.TabIndex = 11;
            this.textBox.Text = "";
            // 
            // compressedTextBox
            // 
            this.compressedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.compressedTextBox.Location = new System.Drawing.Point(346, 27);
            this.compressedTextBox.Name = "compressedTextBox";
            this.compressedTextBox.ReadOnly = true;
            this.compressedTextBox.Size = new System.Drawing.Size(302, 255);
            this.compressedTextBox.TabIndex = 12;
            this.compressedTextBox.Text = "";
            // 
            // encodeTreeBtn
            // 
            this.encodeTreeBtn.Location = new System.Drawing.Point(167, 326);
            this.encodeTreeBtn.Name = "encodeTreeBtn";
            this.encodeTreeBtn.Size = new System.Drawing.Size(147, 40);
            this.encodeTreeBtn.TabIndex = 15;
            this.encodeTreeBtn.Text = "Получить дерево с кодом";
            this.encodeTreeBtn.UseVisualStyleBackColor = true;
            this.encodeTreeBtn.Click += new System.EventHandler(this.encodeWithTreeBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 16;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(665, 370);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.encodeTreeBtn);
            this.Controls.Add(this.compressedTextBox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.decodeBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.encodeBtn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "Алгоритм Хаффмана";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button encodeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button decodeBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openText;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.RichTextBox compressedTextBox;
        private System.Windows.Forms.ToolStripMenuItem openCode;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveCodeBtn;
        private System.Windows.Forms.ToolStripMenuItem SaveTextBtn;
        private System.Windows.Forms.ToolStripMenuItem clearBtn;
        private System.Windows.Forms.Button encodeTreeBtn;
        private System.Windows.Forms.Label label2;
    }
}

