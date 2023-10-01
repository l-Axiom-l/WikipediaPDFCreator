namespace WikipediaPDFCreatorDesktop
{
    partial class InputBox
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
            accept = new Button();
            cancel = new Button();
            textBox = new TextBox();
            SuspendLayout();
            // 
            // accept
            // 
            accept.Location = new Point(12, 41);
            accept.Name = "accept";
            accept.Size = new Size(107, 23);
            accept.TabIndex = 0;
            accept.Text = "Accept";
            accept.UseVisualStyleBackColor = true;
            accept.Click += accept_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(273, 41);
            cancel.Name = "cancel";
            cancel.Size = new Size(107, 23);
            cancel.TabIndex = 1;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // textBox
            // 
            textBox.Location = new Point(12, 12);
            textBox.Name = "textBox";
            textBox.Size = new Size(368, 23);
            textBox.TabIndex = 2;
            // 
            // InputBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 77);
            Controls.Add(textBox);
            Controls.Add(cancel);
            Controls.Add(accept);
            Name = "InputBox";
            Text = "InputBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button accept;
        private Button cancel;
        private TextBox textBox;
    }
}