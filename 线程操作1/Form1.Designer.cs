namespace 线程操作1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_async = new System.Windows.Forms.Button();
            this.backgroundThread = new System.Windows.Forms.Button();
            this.btnThreadPool = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_async
            // 
            this.btn_async.Location = new System.Drawing.Point(68, 166);
            this.btn_async.Name = "btn_async";
            this.btn_async.Size = new System.Drawing.Size(118, 59);
            this.btn_async.TabIndex = 1;
            this.btn_async.Text = "async";
            this.btn_async.UseVisualStyleBackColor = true;
            this.btn_async.Click += new System.EventHandler(this.btn_async_Click);
            // 
            // backgroundThread
            // 
            this.backgroundThread.Location = new System.Drawing.Point(68, 243);
            this.backgroundThread.Name = "backgroundThread";
            this.backgroundThread.Size = new System.Drawing.Size(118, 59);
            this.backgroundThread.TabIndex = 2;
            this.backgroundThread.Text = "后台线程";
            this.backgroundThread.UseVisualStyleBackColor = true;
            this.backgroundThread.Click += new System.EventHandler(this.backgroundThread_Click);
            // 
            // btnThreadPool
            // 
            this.btnThreadPool.Location = new System.Drawing.Point(237, 71);
            this.btnThreadPool.Name = "btnThreadPool";
            this.btnThreadPool.Size = new System.Drawing.Size(175, 59);
            this.btnThreadPool.TabIndex = 3;
            this.btnThreadPool.Text = "ThreadPool";
            this.btnThreadPool.UseVisualStyleBackColor = true;
            this.btnThreadPool.Click += new System.EventHandler(this.btnThreadPool_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 371);
            this.Controls.Add(this.btnThreadPool);
            this.Controls.Add(this.backgroundThread);
            this.Controls.Add(this.btn_async);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_async;
        private System.Windows.Forms.Button backgroundThread;
        private System.Windows.Forms.Button btnThreadPool;
    }
}

