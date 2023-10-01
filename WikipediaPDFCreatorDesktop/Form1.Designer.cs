namespace WikipediaPDFCreatorDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            list = new ListBox();
            up = new Button();
            down = new Button();
            textBox = new TextBox();
            add = new Button();
            edit = new Button();
            remove = new Button();
            generateBook = new Button();
            title = new TextBox();
            SuspendLayout();
            // 
            // list
            // 
            list.FormattingEnabled = true;
            list.ItemHeight = 15;
            list.Location = new Point(12, 41);
            list.Name = "list";
            list.Size = new Size(271, 244);
            list.TabIndex = 0;
            list.SelectedIndexChanged += list_SelectedIndexChanged;
            // 
            // up
            // 
            up.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            up.Location = new Point(289, 41);
            up.Name = "up";
            up.Size = new Size(39, 38);
            up.TabIndex = 1;
            up.Text = "⬆";
            up.UseVisualStyleBackColor = true;
            up.Click += up_Click;
            // 
            // down
            // 
            down.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            down.Location = new Point(289, 89);
            down.Name = "down";
            down.Size = new Size(39, 38);
            down.TabIndex = 2;
            down.Text = "⬇";
            down.UseVisualStyleBackColor = true;
            down.Click += down_Click;
            // 
            // textBox
            // 
            textBox.Location = new Point(12, 291);
            textBox.Name = "textBox";
            textBox.Size = new Size(221, 23);
            textBox.TabIndex = 3;
            // 
            // add
            // 
            add.Location = new Point(239, 290);
            add.Name = "add";
            add.Size = new Size(44, 23);
            add.TabIndex = 4;
            add.Text = "Add";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // edit
            // 
            edit.Location = new Point(12, 320);
            edit.Name = "edit";
            edit.Size = new Size(135, 23);
            edit.TabIndex = 5;
            edit.Text = "Edit";
            edit.UseVisualStyleBackColor = true;
            edit.Click += edit_Click;
            // 
            // remove
            // 
            remove.Location = new Point(153, 320);
            remove.Name = "remove";
            remove.Size = new Size(130, 23);
            remove.TabIndex = 6;
            remove.Text = "Remove";
            remove.UseVisualStyleBackColor = true;
            remove.Click += remove_Click;
            // 
            // generateBook
            // 
            generateBook.Location = new Point(12, 349);
            generateBook.Name = "generateBook";
            generateBook.Size = new Size(271, 23);
            generateBook.TabIndex = 7;
            generateBook.Text = "GenerateBook";
            generateBook.UseVisualStyleBackColor = true;
            generateBook.Click += generateBook_Click;
            // 
            // title
            // 
            title.Location = new Point(12, 12);
            title.Name = "title";
            title.PlaceholderText = "title";
            title.Size = new Size(271, 23);
            title.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 384);
            Controls.Add(title);
            Controls.Add(generateBook);
            Controls.Add(remove);
            Controls.Add(edit);
            Controls.Add(add);
            Controls.Add(textBox);
            Controls.Add(down);
            Controls.Add(up);
            Controls.Add(list);
            Name = "Form1";
            Text = "WikiPdf";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox list;
        private Button up;
        private Button down;
        private TextBox textBox;
        private Button add;
        private Button edit;
        private Button remove;
        private Button generateBook;
        private TextBox title;
    }
}