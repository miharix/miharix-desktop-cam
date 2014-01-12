namespace miharixDesktopCamV2
{
    partial class Okno
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Okno));
            this.VideoKanal = new AForge.Controls.VideoSourcePlayer();
            this.Naprave = new System.Windows.Forms.ComboBox();
            this.Resolucije = new System.Windows.Forms.ComboBox();
            this.ResolucijeFoto = new System.Windows.Forms.ComboBox();
            this.DesniKlik = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.namig = new System.Windows.Forms.ToolTip(this.components);
            this.KameraMenjaj = new System.Windows.Forms.Button();
            this.Full = new System.Windows.Forms.Button();
            this.Povezi = new System.Windows.Forms.Button();
            this.Vrh = new System.Windows.Forms.Button();
            this.Odlozi = new System.Windows.Forms.Button();
            this.Shrani = new System.Windows.Forms.Button();
            this.Okvir = new System.Windows.Forms.Button();
            this.IzberiMapo = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // VideoKanal
            // 
            this.VideoKanal.BackColor = System.Drawing.Color.Black;
            this.VideoKanal.Location = new System.Drawing.Point(12, 56);
            this.VideoKanal.Name = "VideoKanal";
            this.VideoKanal.Size = new System.Drawing.Size(304, 217);
            this.VideoKanal.TabIndex = 1;
            this.VideoKanal.Text = "videoSourcePlayer1";
            this.VideoKanal.VideoSource = null;
            this.VideoKanal.Click += new System.EventHandler(this.VideoKanal_Click);
            this.VideoKanal.DoubleClick += new System.EventHandler(this.VideoKanal_DoubleClick);
            this.VideoKanal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            this.VideoKanal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VideoKanal_MouseDown);
            this.VideoKanal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VideoKanal_MouseMove);
            this.VideoKanal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VideoKanal_MouseUp);
            // 
            // Naprave
            // 
            this.Naprave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Naprave.FormattingEnabled = true;
            this.Naprave.Location = new System.Drawing.Point(1, 2);
            this.Naprave.Name = "Naprave";
            this.Naprave.Size = new System.Drawing.Size(183, 21);
            this.Naprave.TabIndex = 2;
            this.Naprave.SelectedIndexChanged += new System.EventHandler(this.Naprave_SelectedIndexChanged);
            this.Naprave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            // 
            // Resolucije
            // 
            this.Resolucije.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Resolucije.FormattingEnabled = true;
            this.Resolucije.Location = new System.Drawing.Point(184, 2);
            this.Resolucije.Name = "Resolucije";
            this.Resolucije.Size = new System.Drawing.Size(108, 21);
            this.Resolucije.TabIndex = 3;
            this.Resolucije.SelectedIndexChanged += new System.EventHandler(this.Resolucije_SelectedIndexChanged);
            this.Resolucije.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            // 
            // ResolucijeFoto
            // 
            this.ResolucijeFoto.BackColor = System.Drawing.Color.Black;
            this.ResolucijeFoto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ResolucijeFoto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ResolucijeFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResolucijeFoto.ForeColor = System.Drawing.Color.White;
            this.ResolucijeFoto.FormattingEnabled = true;
            this.ResolucijeFoto.Location = new System.Drawing.Point(250, 27);
            this.ResolucijeFoto.Name = "ResolucijeFoto";
            this.ResolucijeFoto.Size = new System.Drawing.Size(66, 21);
            this.ResolucijeFoto.TabIndex = 4;
            this.ResolucijeFoto.Visible = false;
            this.ResolucijeFoto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            // 
            // DesniKlik
            // 
            this.DesniKlik.Name = "DesniKlik";
            this.DesniKlik.Size = new System.Drawing.Size(61, 4);
            // 
            // KameraMenjaj
            // 
            this.KameraMenjaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.KameraMenjaj.BackColor = System.Drawing.Color.Transparent;
            this.KameraMenjaj.BackgroundImage = global::miharixDesktopCamV2.Properties.Resources.config;
            this.KameraMenjaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.KameraMenjaj.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.KameraMenjaj.FlatAppearance.BorderSize = 0;
            this.KameraMenjaj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.KameraMenjaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KameraMenjaj.Location = new System.Drawing.Point(146, 294);
            this.KameraMenjaj.Name = "KameraMenjaj";
            this.KameraMenjaj.Size = new System.Drawing.Size(29, 19);
            this.KameraMenjaj.TabIndex = 10;
            this.KameraMenjaj.UseVisualStyleBackColor = false;
            this.KameraMenjaj.Click += new System.EventHandler(this.KameraMenjaj_Click);
            this.KameraMenjaj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            // 
            // Full
            // 
            this.Full.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Full.BackgroundImage = global::miharixDesktopCamV2.Properties.Resources.fullscreen;
            this.Full.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Full.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Full.FlatAppearance.BorderSize = 0;
            this.Full.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.Full.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Full.Location = new System.Drawing.Point(117, 294);
            this.Full.Name = "Full";
            this.Full.Size = new System.Drawing.Size(29, 19);
            this.Full.TabIndex = 6;
            this.Full.UseVisualStyleBackColor = true;
            this.Full.Click += new System.EventHandler(this.Full_Click);
            this.Full.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            // 
            // Povezi
            // 
            this.Povezi.BackColor = System.Drawing.Color.Transparent;
            this.Povezi.BackgroundImage = global::miharixDesktopCamV2.Properties.Resources.start;
            this.Povezi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Povezi.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Povezi.FlatAppearance.BorderSize = 0;
            this.Povezi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.Povezi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Povezi.Location = new System.Drawing.Point(292, 0);
            this.Povezi.Name = "Povezi";
            this.Povezi.Size = new System.Drawing.Size(32, 23);
            this.Povezi.TabIndex = 4;
            this.Povezi.UseVisualStyleBackColor = false;
            this.Povezi.Click += new System.EventHandler(this.Povezi_Click);
            this.Povezi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            // 
            // Vrh
            // 
            this.Vrh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Vrh.BackColor = System.Drawing.Color.Transparent;
            this.Vrh.BackgroundImage = global::miharixDesktopCamV2.Properties.Resources.ontop;
            this.Vrh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Vrh.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Vrh.FlatAppearance.BorderSize = 0;
            this.Vrh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.Vrh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Vrh.Location = new System.Drawing.Point(88, 294);
            this.Vrh.Name = "Vrh";
            this.Vrh.Size = new System.Drawing.Size(29, 19);
            this.Vrh.TabIndex = 8;
            this.Vrh.UseVisualStyleBackColor = false;
            this.Vrh.Click += new System.EventHandler(this.Vrh_Click);
            this.Vrh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            // 
            // Odlozi
            // 
            this.Odlozi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Odlozi.BackColor = System.Drawing.Color.Transparent;
            this.Odlozi.BackgroundImage = global::miharixDesktopCamV2.Properties.Resources.clipboard;
            this.Odlozi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Odlozi.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Odlozi.FlatAppearance.BorderSize = 0;
            this.Odlozi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.Odlozi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Odlozi.Location = new System.Drawing.Point(30, 294);
            this.Odlozi.Name = "Odlozi";
            this.Odlozi.Size = new System.Drawing.Size(29, 19);
            this.Odlozi.TabIndex = 9;
            this.Odlozi.UseVisualStyleBackColor = false;
            this.Odlozi.Click += new System.EventHandler(this.Odlozi_Click);
            this.Odlozi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            // 
            // Shrani
            // 
            this.Shrani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Shrani.BackColor = System.Drawing.Color.Transparent;
            this.Shrani.BackgroundImage = global::miharixDesktopCamV2.Properties.Resources.shrani;
            this.Shrani.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Shrani.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Shrani.FlatAppearance.BorderSize = 0;
            this.Shrani.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.Shrani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Shrani.Location = new System.Drawing.Point(1, 294);
            this.Shrani.Name = "Shrani";
            this.Shrani.Size = new System.Drawing.Size(29, 19);
            this.Shrani.TabIndex = 5;
            this.Shrani.UseVisualStyleBackColor = false;
            this.Shrani.Click += new System.EventHandler(this.Shrani_Click);
            this.Shrani.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            // 
            // Okvir
            // 
            this.Okvir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Okvir.BackColor = System.Drawing.Color.Transparent;
            this.Okvir.BackgroundImage = global::miharixDesktopCamV2.Properties.Resources.noborder;
            this.Okvir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Okvir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Okvir.FlatAppearance.BorderSize = 0;
            this.Okvir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.Okvir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Okvir.Location = new System.Drawing.Point(59, 294);
            this.Okvir.Name = "Okvir";
            this.Okvir.Size = new System.Drawing.Size(29, 19);
            this.Okvir.TabIndex = 7;
            this.Okvir.UseVisualStyleBackColor = false;
            this.Okvir.Click += new System.EventHandler(this.Okvir_Click);
            this.Okvir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            // 
            // Okno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(325, 316);
            this.Controls.Add(this.KameraMenjaj);
            this.Controls.Add(this.ResolucijeFoto);
            this.Controls.Add(this.Resolucije);
            this.Controls.Add(this.Vrh);
            this.Controls.Add(this.Povezi);
            this.Controls.Add(this.Full);
            this.Controls.Add(this.Shrani);
            this.Controls.Add(this.Odlozi);
            this.Controls.Add(this.Naprave);
            this.Controls.Add(this.Okvir);
            this.Controls.Add(this.VideoKanal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Okno";
            this.Text = "Miharix\'s Desktop Cam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Okno_FormClosing);
            this.Load += new System.EventHandler(this.Okno_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Okno_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Okno_MouseDown);
            this.Resize += new System.EventHandler(this.Okno_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer VideoKanal;
        private System.Windows.Forms.ComboBox Naprave;
        private System.Windows.Forms.ComboBox Resolucije;
        private System.Windows.Forms.ComboBox ResolucijeFoto;
        private System.Windows.Forms.Button Povezi;
        private System.Windows.Forms.ContextMenuStrip DesniKlik;
        private System.Windows.Forms.Button Shrani;
        private System.Windows.Forms.Button Full;
        private System.Windows.Forms.Button Okvir;
        private System.Windows.Forms.Button Vrh;
        private System.Windows.Forms.Button Odlozi;
        private System.Windows.Forms.Button KameraMenjaj;
        private System.Windows.Forms.ToolTip namig;
        private System.Windows.Forms.FolderBrowserDialog IzberiMapo;
    }
}

