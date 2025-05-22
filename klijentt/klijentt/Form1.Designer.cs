namespace klijentt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPustiVideo = new System.Windows.Forms.Button();
            this.btnStartVideo = new System.Windows.Forms.Button();
            this.btnZatvori = new System.Windows.Forms.Button();
            this.btnOtvori = new System.Windows.Forms.Button();
            this.lblStatusVrata = new System.Windows.Forms.Label();
            this.lblVlaznost = new System.Windows.Forms.Label();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.btnSpoji = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "IP:";
            // 
            // btnPustiVideo
            // 
            this.btnPustiVideo.Location = new System.Drawing.Point(639, 87);
            this.btnPustiVideo.Name = "btnPustiVideo";
            this.btnPustiVideo.Size = new System.Drawing.Size(82, 23);
            this.btnPustiVideo.TabIndex = 35;
            this.btnPustiVideo.Text = "Pokreni video";
            this.btnPustiVideo.UseVisualStyleBackColor = true;
            this.btnPustiVideo.Click += new System.EventHandler(this.btnPustiVideo_Click);
            // 
            // btnStartVideo
            // 
            this.btnStartVideo.Location = new System.Drawing.Point(530, 87);
            this.btnStartVideo.Name = "btnStartVideo";
            this.btnStartVideo.Size = new System.Drawing.Size(87, 23);
            this.btnStartVideo.TabIndex = 34;
            this.btnStartVideo.Text = "Spremi video";
            this.btnStartVideo.UseVisualStyleBackColor = true;
            this.btnStartVideo.Click += new System.EventHandler(this.btnStartVideo_Click);
            // 
            // btnZatvori
            // 
            this.btnZatvori.Location = new System.Drawing.Point(192, 343);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(75, 23);
            this.btnZatvori.TabIndex = 33;
            this.btnZatvori.Text = "Zatvori vrata";
            this.btnZatvori.UseVisualStyleBackColor = true;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // btnOtvori
            // 
            this.btnOtvori.Location = new System.Drawing.Point(84, 343);
            this.btnOtvori.Name = "btnOtvori";
            this.btnOtvori.Size = new System.Drawing.Size(75, 23);
            this.btnOtvori.TabIndex = 32;
            this.btnOtvori.Text = "Otvori vrata";
            this.btnOtvori.UseVisualStyleBackColor = true;
            this.btnOtvori.Click += new System.EventHandler(this.btnOtvori_Click);
            // 
            // lblStatusVrata
            // 
            this.lblStatusVrata.AutoSize = true;
            this.lblStatusVrata.ForeColor = System.Drawing.Color.Red;
            this.lblStatusVrata.Location = new System.Drawing.Point(130, 396);
            this.lblStatusVrata.Name = "lblStatusVrata";
            this.lblStatusVrata.Size = new System.Drawing.Size(112, 13);
            this.lblStatusVrata.TabIndex = 31;
            this.lblStatusVrata.Text = "VRATA ZATVORENA";
            // 
            // lblVlaznost
            // 
            this.lblVlaznost.AutoSize = true;
            this.lblVlaznost.Location = new System.Drawing.Point(189, 251);
            this.lblVlaznost.Name = "lblVlaznost";
            this.lblVlaznost.Size = new System.Drawing.Size(0, 13);
            this.lblVlaznost.TabIndex = 30;
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Location = new System.Drawing.Point(102, 251);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(0, 13);
            this.lblTemperatura.TabIndex = 29;
            // 
            // btnSpoji
            // 
            this.btnSpoji.Location = new System.Drawing.Point(115, 151);
            this.btnSpoji.Name = "btnSpoji";
            this.btnSpoji.Size = new System.Drawing.Size(75, 23);
            this.btnSpoji.TabIndex = 28;
            this.btnSpoji.Text = "Spoji se";
            this.btnSpoji.UseVisualStyleBackColor = true;
            this.btnSpoji.Click += new System.EventHandler(this.btnSpoji_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(115, 89);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 27;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(115, 41);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 26;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(415, 190);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(348, 209);
            this.axWindowsMediaPlayer1.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPustiVideo);
            this.Controls.Add(this.btnStartVideo);
            this.Controls.Add(this.btnZatvori);
            this.Controls.Add(this.btnOtvori);
            this.Controls.Add(this.lblStatusVrata);
            this.Controls.Add(this.lblVlaznost);
            this.Controls.Add(this.lblTemperatura);
            this.Controls.Add(this.btnSpoji);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPustiVideo;
        private System.Windows.Forms.Button btnStartVideo;
        private System.Windows.Forms.Button btnZatvori;
        private System.Windows.Forms.Button btnOtvori;
        private System.Windows.Forms.Label lblStatusVrata;
        private System.Windows.Forms.Label lblVlaznost;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.Button btnSpoji;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

