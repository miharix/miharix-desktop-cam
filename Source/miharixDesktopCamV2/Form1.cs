using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;


using System.Text;
using System.Windows.Forms;


using AForge.Video;
using AForge.Video.DirectShow;

using System.IO;
using System.Xml.Serialization;

using System.Threading;

using System.Globalization;

namespace miharixDesktopCamV2
{
    public partial class Okno : Form
    {
        private FilterInfoCollection VideoNaprave;
        private VideoCaptureDevice VideoNaprava;
        private VideoCapabilities[] VideoZmoznosti;
        private VideoCapabilities[] ZmoznostiSlikanja;

        private Point MiskaTemp = new Point();
        private Boolean MiskaSledi = false;

        String Dan = "03_04_1984";
        String Ura = "00_00_00";
        Boolean maximum = false;
      
        Rectangle okno;
        int levo = 1;
        int desno = 1;




        [Serializable()]
        public class Data
        {
            public Boolean ButtonsShow { get; set; }
            public Boolean SettingsShow { get; set; }            
            public int DefaultCameraID { get; set; }
            public int DefaultResolutionID { get; set; }            
            public Boolean OnTop { get; set; }
         //   public String LanguageFile { get; set; }
            public String SaveFolder { get; set; }
        }

        [Serializable()]
        public class Jezik
        {
            public String SavePhoto { get; set; }
            public String OnTop { get; set; }
            public String BorderApp { get; set; }
            public String FullScreenApp { get; set; }
            public String StopCam { get; set; }
            public String Help { get; set; }


            public String SaveOnClipboard { get; set; }
            public String SaveDefault { get; set; }
            public String ShowConfig { get; set; }
            public String ShowButtons { get; set; }
            public String ExitProgram { get; set; }
        }

       // Jezik izbran_jezik = null;

        String OkvirOkna = "Okvir okna";        
        String NaOdlozisce = "Slika na odložišče";
        String ShraniPrivzeto = "Shrani kot privzeto";
        String NastaviKamero = "Nastavitve";
        String Izhod = "Izhod";
        String PoveziNaKamero = "Zaženi Kamero";
        String ShraniSliko = "Shrani sliko";
        String CelZaslon = "Preko celega zaslona";
        String Gumbi = "Prikaži Gumbe";
        String NaVrh = "Stalno na vrhu";
        String Pomoc = "O programu";

      //  String JezikovnaDatoteka = "sl-SI.xml";

        private void SpremeniJezik(String id)
        {


            if (id == "sl-SI")
            {
                /*slo*/
                OkvirOkna = "Okvir okna";
                NaOdlozisce = "Slika na odložišče";
                ShraniPrivzeto = "Shrani kot privzeto";
                NastaviKamero = "Nastavitve";
                Izhod = "Izhod";
                PoveziNaKamero = "Zaženi Kamero";
                ShraniSliko = "Shrani sliko";
                CelZaslon = "Preko celega zaslona";
                Gumbi = "Prikaži Gumbe";
                NaVrh = "Stalno na vrhu";
                Pomoc = "O programu";
                IzberiMapo.Description = "Shranjuj slike v";
            }
            else
            {
                if ((id == "de-DE") || (id == "de-AT"))
                {
                    OkvirOkna = "Fensterumrundung";
                    NaOdlozisce = "Kopieren";
                    ShraniPrivzeto = "Einstelungen Speichern";
                    NastaviKamero = "Einstellungen";
                    Izhod = "Beenden";
                    PoveziNaKamero = "Kamera starten";
                    ShraniSliko = "Bild Speichern";
                    CelZaslon = "Vollbild";
                    Gumbi = "Menüleiste";
                    NaVrh = "Immer im Vordergrund halten";
                    Pomoc = "Info";
                    IzberiMapo.Description = "Alle Bilder Speichern ins";
                }
                else
                {


                    /*ang*/

                    OkvirOkna = "Hide Border";
                    NaOdlozisce = "Save frame to clipboard";
                    ShraniPrivzeto = "Save settings";
                    NastaviKamero = "Cammera settings";
                    Izhod = "Exit";
                    PoveziNaKamero = "Enable Camera";
                    ShraniSliko = "Save frame to drive";
                    CelZaslon = "Full Screen";
                    Gumbi = "Show Buttons";
                    NaVrh = "Always on Top";
                    Pomoc = "Info";
                    IzberiMapo.Description = "Change default picture folder";

                }
            }

           
        }

        private void ShraniNastavitve()
        {
            
                Data nastavitev = new Data();

                
                nastavitev.DefaultCameraID = PrivzetaKamera;
                nastavitev.DefaultResolutionID = PrivzetaResolucija;
                nastavitev.OnTop = navrhu;
              //  nastavitev.LanguageFile = Jezik_Datoteka;
                nastavitev.SaveFolder = GlavniDir;
                nastavitev.ButtonsShow = PrikaziGumbe;
                nastavitev.SettingsShow = PrikaziNastavitve;


                int poizkusaj = 30;
            if(File.Exists("my_settings.xml")){
                File.Delete("my_settings.xml");
            }
                for (int i = 0; i < poizkusaj; i++)
                {
                    try
                    {
                        // Write to XML
                        XmlSerializer writer = new XmlSerializer(typeof(Data));
                        using (FileStream file = File.OpenWrite("my_settings.xml"))
                        {
                            writer.Serialize(file, nastavitev);
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        if (i == poizkusaj - 1)
                        {
                            throw;
                        }
                    }

                    Thread.Sleep(300);


                }
        }

        

        String GlavniDir = "foto/";
        Boolean navrhu = true;
        int PrivzetaKamera = 0;
        int PrivzetaResolucija = 0;
        Boolean PrikaziGumbe=true;
      //  String Jezik_Datoteka = "sl-SI";

        private void BeriNastavitve()
        {
            if (!File.Exists("my_settings.xml")) { 
                ShraniNastavitve();
                //če ne mi ob prvem zagonu skrije vse gumbe
                PrikaziGumbe = false;
                PrikaziNastavitve = false;
            }
            else
            {

                Data shranjeno;

                XmlSerializer reader = new XmlSerializer(typeof(Data));
                using (FileStream input = File.OpenRead("my_settings.xml"))
                {
                    shranjeno = reader.Deserialize(input) as Data;
                }

                GlavniDir = shranjeno.SaveFolder;
                navrhu = !shranjeno.OnTop;
              //  Jezik_Datoteka = shranjeno.LanguageFile;
                PrikaziGumbe = !shranjeno.ButtonsShow;
                PrivzetaKamera = shranjeno.DefaultCameraID;
                PrivzetaResolucija = shranjeno.DefaultResolutionID;
                PrikaziNastavitve = !shranjeno.SettingsShow;

            
            }
            VidnostGumbov();
            VidnostNastavitev();
        }

   

        public Okno()
        {
            InitializeComponent();
        }

 

     

        private void NastaviNamige()
        {
            this.namig.SetToolTip(this.Shrani, ShraniSliko);
            this.namig.SetToolTip(this.Okvir, OkvirOkna);
            this.namig.SetToolTip(this.Odlozi, NaOdlozisce);
            this.namig.SetToolTip(this.KameraMenjaj, NastaviKamero);
            this.namig.SetToolTip(this.Povezi, PoveziNaKamero);
            this.namig.SetToolTip(this.Full, CelZaslon);
            this.namig.SetToolTip(this.Vrh, NaVrh);

        }

        private void SpremniMapoZaSlike()
        {
            if (IzberiMapo.ShowDialog() == DialogResult.OK)
            {
                GlavniDir=IzberiMapo.SelectedPath+"/";
            }
        }


        private void Okno_Load(object sender, EventArgs e)
         {

          /*   FolderBrowserDialog folderDlg = new FolderBrowserDialog();

             folderDlg.ShowNewFolderButton = true;

             // Show the FolderBrowserDialog. 

             DialogResult result = folderDlg.ShowDialog();

             if (result == DialogResult.OK)
             {

                MessageBox.Show(folderDlg.SelectedPath);

             //    Environment.SpecialFolder root = folderDlg.RootFolder;

             }*/

            

             


        //   ShraniNastavitve();
          // ShraniJezik();

             SpremeniJezik(CultureInfo.CurrentCulture.Name);
            // SpremeniJezik("de-DE");

            


            BeriNastavitve();
            NastaviNamige();
         ///  BeriJezik();
           // NastaviNaShranjeno();
            Vrh_Click(sender, e);
         //   Thread.Sleep(150);

             VideoNaprave = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (VideoNaprave.Count != 0)
            {
                // add all devices to combo
                foreach (FilterInfo device in VideoNaprave)
                {
                    Naprave.Items.Add(device.Name);
                }
            }
            else
            {
                Naprave.Items.Add("No DirectShow devices found");
            }

            if (PrivzetaKamera < VideoNaprave.Count)
            {
                Naprave.SelectedIndex = PrivzetaKamera;
            }
            else
            {
                Naprave.SelectedIndex = 0;
            }

           // EnableConnectionControls(true);
        }

 

        private void Prekini()
        {
            if (VideoKanal.VideoSource != null)
            {
                // stop video device
                VideoKanal.SignalToStop();
                VideoKanal.WaitForStop();
                VideoKanal.VideoSource = null;

                if (VideoNaprava.ProvideSnapshots)
                {
                    VideoNaprava.SnapshotFrame -= new NewFrameEventHandler(VideoNaprava_SnapshotFrame);
                }

              //  EnableConnectionControls(true);
            }
        }

      

        public NewFrameEventHandler VideoNaprava_SnapshotFrame { get; set; }

        private void Okno_FormClosing(object sender, FormClosingEventArgs e)
        {
            Prekini();
          //  ShraniNastavitve();
        }

        private void Naprave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VideoNaprava != null)
            {
                if (VideoNaprava.IsRunning)
                {
                    VideoNaprava.Stop();
                    bPoveziNaKamero = false;
                    NastaviNaShranjeno();
                }
            }
            if (VideoNaprave.Count != 0)
            {
                VideoNaprava = new VideoCaptureDevice(VideoNaprave[Naprave.SelectedIndex].MonikerString);
                UgotoviResolucije(VideoNaprava);
                PrivzetaKamera = Naprave.SelectedIndex;
            }
        }

        private void UgotoviResolucije(VideoCaptureDevice VideoNaprava)
        {
            this.Cursor = Cursors.WaitCursor;


            Resolucije.Items.Clear();
            ResolucijeFoto.Items.Clear();

            try
            {
                VideoZmoznosti = VideoNaprava.VideoCapabilities;
                ZmoznostiSlikanja = VideoNaprava.SnapshotCapabilities;

                foreach (VideoCapabilities capabilty in VideoZmoznosti)
                {
                    Resolucije.Items.Add(string.Format("{0} x {1}",capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }

                foreach (VideoCapabilities capabilty in ZmoznostiSlikanja)
                {
                    ResolucijeFoto.Items.Add(string.Format("{0} x {1}",capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }

                if (VideoZmoznosti.Length == 0)
                {
                    Resolucije.Items.Add("Not supported");
                }
                if (ZmoznostiSlikanja.Length == 0)
                {
                    ResolucijeFoto.Items.Add("Not supported");
                }

                if (PrivzetaResolucija < Resolucije.Items.Count)
                {
                    Resolucije.SelectedIndex = PrivzetaResolucija;
                }
                else
                {
                    Resolucije.SelectedIndex = 0;
                }
                ResolucijeFoto.SelectedIndex = 0;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Povezi_Click(object sender, EventArgs e)
        {
            if (VideoNaprava != null)
            {
                if ((VideoZmoznosti != null) && (VideoZmoznosti.Length != 0))
                {
                    VideoNaprava.VideoResolution = VideoZmoznosti[Resolucije.SelectedIndex];
                }

                /*  if ((ZmoznostiSlikanja != null) && (ZmoznostiSlikanja.Length != 0))
                   {
                       VideoNaprava.ProvideSnapshots = true;
                       VideoNaprava.SnapshotResolution = ZmoznostiSlikanja[ResolucijeFoto.SelectedIndex];
                       VideoNaprava.SnapshotFrame += new NewFrameEventHandler(Fotografiraj_SnapshotFrame);
                   }*/

                //  EnableConnectionControls(false);

                VideoKanal.VideoSource = VideoNaprava;

                if (VideoKanal.IsRunning)
                {
                    VideoKanal.Stop();
                    bPoveziNaKamero = false;

                }
                else
                {
                    VideoKanal.Start();
                    VideoKanal.VideoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    bPoveziNaKamero = true;
               
                }
                NastaviNaShranjeno();
            }
            
        }



        private void Okno_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                NovaVelikost(Okno.ActiveForm.Size);
            }

            if (VideoKanal.Width <= this.Width)
            {
                //VideoKanal.Top = 1;
                VideoKanal.Top = (int)(((Double)Okno.ActiveForm.Height / (Double)2) - ((Double)VideoKanal.Height / (Double)2));
                
            }

            if (VideoKanal.Height <= this.Height)
            {
                //VideoKanal.Left = 1;
                VideoKanal.Left = (int)(((Double)Okno.ActiveForm.Width / (Double)2) - ((Double)VideoKanal.Width / (Double)2));
            }
        }

        //Zoomiranje
        protected override void OnMouseWheel(MouseEventArgs miska)
        {
           /* textBox1.Text = "Širina slike=" + pictureBoxVideo.Width + "\r\n" +
            "Višina slike=" + pictureBoxVideo.Height + "\r\n" +
            "Odmik Levo=" + pictureBoxVideo.Top + "\r\n" +
            "Odmik desno=" + pictureBoxVideo.Left + "\r\n" +
            "Širina okna=" + this.Width + "\r\n" +
            "Višina okna=" + this.Height*/
              //  ;
            // Override OnMouseWheel event, for zooming in/out with the scroll wheel

            // If the mouse wheel is moved forward (Zoom in)
            if (miska.Delta > 0)
            {
                // Check if the pictureBox dimensions are in range (15 is the minimum and maximum zoom level)
                if ((VideoKanal.Width < (9 * this.Width)) && (VideoKanal.Height < (9 * this.Height)))
                {
                    // Change the size of the picturebox, multiply it by the ZOOMFACTOR
                    VideoKanal.Width = (int)(VideoKanal.Width * 1.25);
                    VideoKanal.Height = (int)(VideoKanal.Height * 1.25);

                    // Formula to move the picturebox, to zoom in the point selected by the mouse cursor
                    VideoKanal.Top = (int)(miska.Y - 1.25 * (miska.Y - VideoKanal.Top));
                    VideoKanal.Left = (int)(miska.X - 1.25 * (miska.X - VideoKanal.Left));
                }
            }
            else
            {
                // Check if the pictureBox dimensions are in range (15 is the minimum and maximum zoom level)
                if ((VideoKanal.Width > (this.Width)) || (VideoKanal.Height > (this.Height)))
                {

                    // Change the size of the picturebox, divide it by the ZOOMFACTOR
                    VideoKanal.Width = (int)(VideoKanal.Width / 1.25);
                    VideoKanal.Height = (int)(VideoKanal.Height / 1.25);

                    // Formula to move the picturebox, to zoom in the point selected by the mouse cursor
                    VideoKanal.Top = (int)(miska.Y - 0.80 * (miska.Y - VideoKanal.Top));
                    VideoKanal.Left = (int)(miska.X - 0.80 * (miska.X - VideoKanal.Left));

          
                }      
            }          
        }

        private void VideoKanal_MouseDown(object sender, MouseEventArgs miska)
        {
            if (miska.Button == MouseButtons.Right)
            {

                Control c = sender as Control;
                if (miska.Button == MouseButtons.Right)
                {
                    this.DesniKlik.Show(c, miska.Location);
                }

            }
            else
            {
                if (miska.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    MiskaTemp = miska.Location;
                    MiskaSledi = true;
                }
            }
        }

        private void VideoKanal_MouseMove(object sender, MouseEventArgs e)
        {
            if (MiskaSledi)
            {
                VideoKanal.Left = -(-VideoKanal.Left + (MiskaTemp.X - e.X));
                VideoKanal.Top = -(-VideoKanal.Top + (MiskaTemp.Y - e.Y));
            }
        }

        private void VideoKanal_MouseUp(object sender, MouseEventArgs e)
        {
            MiskaSledi = false;
        }

        private void Okno_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            centriraj();
        }

        

        private void NovaVelikost(Size Velikost){

            if (VideoNaprava != null)//če ne krešira ob dvokliku pred prvim zagonom kamere
            {
                if (VideoNaprava.VideoResolution != null)
                {

                    double razmerje = (double)VideoNaprava.VideoResolution.FrameSize.Height / (double)VideoNaprava.VideoResolution.FrameSize.Width;

                    if (this.Width > this.Height)
                    {
                        VideoKanal.Height = Velikost.Height;
                        VideoKanal.Width = (int)((double)Velikost.Height / razmerje);
                    }
                    else
                    {
                        VideoKanal.Width = Velikost.Width;
                        VideoKanal.Height = (int)((double)Velikost.Width * razmerje);
                    }
                }
            }
            
        }

        private void centriraj()
        {
            VideoKanal.Top = (int)(((Double)Okno.ActiveForm.Height / (Double)2) - ((Double)VideoKanal.Height / (Double)2));
            VideoKanal.Left = (int)(((Double)Okno.ActiveForm.Width / (Double)2) - ((Double)VideoKanal.Width / (Double)2));
        }

        private void VideoKanal_DoubleClick(object sender, EventArgs e)
        {
            NovaVelikost(Okno.ActiveForm.Size);
            centriraj();
        }

        private void ShraniNaOdlozisce()
        {
            tempSlika = false;
            Vdatoteko = true;

            if (VideoKanal != null)
            {
                if (VideoKanal.IsRunning)
                {
                    while (tempSlika == false)
                    {
                        Thread.Sleep(1);
                    }
                    Clipboard.SetImage(fotka);
                }
            }
        }

        private void Odlozi_Click(object sender, EventArgs e)
        {
               // VideoKanal.VideoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            ShraniNaOdlozisce();
        }

        private void ShraniNaDisk()
        {
            Dan = DateTime.Now.ToString("dd_MM_yyyy");
            Ura = DateTime.Now.ToString("HH_mm_ss");
            Directory.CreateDirectory(GlavniDir + Dan);

            tempSlika = false;
            Vdatoteko = true;

            if (VideoKanal != null)
            {
                if (VideoKanal.IsRunning)
                {
                    while (tempSlika == false)
                    {
                        Thread.Sleep(1);
                    }
                    fotka.Save(GlavniDir + Dan + "/" + Ura + ".png");
                }
            }
        }

        private void Shrani_Click(object sender, EventArgs e)
        {
            ShraniNaDisk();                     
        }

        Boolean Vdatoteko = false;
        Boolean tempSlika = false;
        Image fotka = null;
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {


            if (Vdatoteko)
            {
                Vdatoteko = false;
                tempSlika = false;

                
                fotka = (Image)eventArgs.Frame.Clone();
                Thread.Sleep(60);
                tempSlika = true;
            }
              
               // VideoKanal.VideoSource.NewFrame -= new NewFrameEventHandler(video_NewFrame);
                
            
            
        }

        private void CezCelZaslon()
        {
            if (maximum)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                maximum = false;

                this.Bounds = okno;
                VideoKanal.Top = levo;
                VideoKanal.Left = desno;

            }
            else
            {
                maximum = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                okno = this.Bounds;
                desno = VideoKanal.Top;
                levo = VideoKanal.Left;

                this.Bounds = Screen.FromControl(this).Bounds;

            }
        }

        private void Full_Click(object sender, EventArgs e)
        {
            CezCelZaslon();
            NastaviNaShranjeno();
        }

        private void Okvir_Click(object sender, EventArgs e)
        {
            if (bokvirOkna)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                bokvirOkna = false;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                bokvirOkna = true;
                

            }
            NastaviNaShranjeno();
        }

        private void Vrh_Click(object sender, EventArgs e)
        {
            if (navrhu)
            {
                this.TopMost = false;
                navrhu = false;
            }
            else
            {
                this.TopMost = true;
                navrhu = true;
            }
            NastaviNaShranjeno();
        }

      

        private void NastaviNaShranjeno()
        {
            
          
          //  DesniKlik=new System.Windows.Forms.ContextMenuStrip();

            DesniKlik.Items.Clear();
           // DesniKlik = new ContextMenuStrip();


            /*******shrani sliko na odložišče*******/
            ToolStripMenuItem Predmet = new ToolStripMenuItem(NaOdlozisce);
            Predmet.Click += new EventHandler(DesniMeni_Click);
            Predmet.Name = "ShraniO";
            Predmet.ShortcutKeys = Keys.Control | Keys.C;
            DesniKlik.Items.Add(Predmet);

            /*******shrani sliko*******/
            Predmet = new ToolStripMenuItem(ShraniSliko);
            Predmet.Click += new EventHandler(DesniMeni_Click);
            Predmet.Name = "ShraniS";
            Predmet.ShortcutKeys = Keys.F4;
            DesniKlik.Items.Add(Predmet);

            /*********Poveži**********/
            Predmet = new ToolStripMenuItem(PoveziNaKamero);
            Predmet.Click += new EventHandler(DesniMeni_Click);
            Predmet.Name = "PoveziC";
            Predmet.Checked = bPoveziNaKamero;
            if (bPoveziNaKamero)
            {
                Predmet.CheckState = CheckState.Checked;
            }
            else
            {
                Predmet.CheckState = CheckState.Unchecked;
            }
            Predmet.CheckOnClick = true;
            Predmet.ShortcutKeys = Keys.F5;
            DesniKlik.Items.Add(Predmet);

            /*********Nastavitve kamere**********/
            Predmet = new ToolStripMenuItem(NastaviKamero);
            Predmet.Click += new EventHandler(DesniMeni_Click);

            Predmet.Checked = PrikaziNastavitve;
            if (PrikaziNastavitve)
            {
                Predmet.CheckState = CheckState.Checked;
            }
            else
            {
                Predmet.CheckState = CheckState.Unchecked;
            }
            Predmet.CheckOnClick = true;
            Predmet.Name = "Kamera";
            Predmet.ShortcutKeys = Keys.F2;
            DesniKlik.Items.Add(Predmet);

            /*******cel zaslon************/
            Predmet = new ToolStripMenuItem(CelZaslon);
            Predmet.Click += new EventHandler(DesniMeni_Click);
            Predmet.Name = "CelZaslon";
            Predmet.Checked = maximum;
            if (maximum)
            {
                Predmet.CheckState = CheckState.Checked;
            }
            else
            {
                Predmet.CheckState = CheckState.Unchecked;
            }
            Predmet.CheckOnClick = true;
            Predmet.ShortcutKeys = Keys.F11;
            DesniKlik.Items.Add(Predmet);

            /*********okvir okna**********/
            Predmet = new ToolStripMenuItem(OkvirOkna);
            Predmet.Click += new EventHandler(DesniMeni_Click);

            Predmet.Checked = bokvirOkna;
            if (bokvirOkna)
            {
                Predmet.CheckState = CheckState.Checked;
            }
            else
            {
                Predmet.CheckState = CheckState.Unchecked;
            }
            Predmet.CheckOnClick = true;
            Predmet.Name = "Okvir";
            Predmet.ShortcutKeys = Keys.F12;
            DesniKlik.Items.Add(Predmet);

            /*******Na Vrh*******/
            Predmet = new ToolStripMenuItem(NaVrh);
            Predmet.Click += new EventHandler(DesniMeni_Click);
            Predmet.Name = "Vrh";
            Predmet.Checked = navrhu;
            if (navrhu)
            {
                Predmet.CheckState = CheckState.Checked;
            }
            else
            {
                Predmet.CheckState = CheckState.Unchecked;
            }
            Predmet.CheckOnClick = true;
            Predmet.ShortcutKeys = Keys.F9;
            DesniKlik.Items.Add(Predmet);

            /*******skrij gumbe********/
            Predmet = new ToolStripMenuItem(Gumbi);
            Predmet.Click += new EventHandler(DesniMeni_Click);
            Predmet.Name = "Gumbi";
            Predmet.Checked = PrikaziGumbe;
            if (PrikaziGumbe)
            {
                Predmet.CheckState = CheckState.Checked;
            }
            else
            {
                Predmet.CheckState = CheckState.Unchecked;
            }
            Predmet.CheckOnClick = true;
            Predmet.ShortcutKeys = Keys.F8;
            DesniKlik.Items.Add(Predmet);

            /*********Shranjuj slike v**********/
            Predmet = new ToolStripMenuItem(IzberiMapo.Description);
            Predmet.Click += new EventHandler(DesniMeni_Click);
            Predmet.Name = "SlikeV";
            DesniKlik.Items.Add(Predmet);

          


            /*********Shrani kot privzeto**********/
            Predmet = new ToolStripMenuItem(ShraniPrivzeto);
            Predmet.Click += new EventHandler(DesniMeni_Click);
            Predmet.Name = "ShraniN";           
            DesniKlik.Items.Add(Predmet);            

            /*********Pomoč**********/
            Predmet = new ToolStripMenuItem(Pomoc);
            Predmet.Click += new EventHandler(DesniMeni_Click);
            Predmet.Name = "SOS";
            Predmet.ShortcutKeys = Keys.F1;
            DesniKlik.Items.Add(Predmet);

            /*********Izhod**********/
            Predmet = new ToolStripMenuItem(Izhod);
            Predmet.Click += new EventHandler(DesniMeni_Click);
            Predmet.Name = "Adijo";
            Predmet.ShortcutKeys = Keys.Alt | Keys.F4;
            DesniKlik.Items.Add(Predmet);

           /*
            Predmet = new ToolStripMenuItem("Language");
            Predmet.Click += new EventHandler(DesniMeni_Click);
            Predmet.Name = "Jezik";
            DesniKlik.Items.Add(Predmet);*/


            
        }

      
        Boolean bPoveziNaKamero = false;
        Boolean PrikaziNastavitve = true;
        Boolean bokvirOkna = true;


        


        private void VidnostGumbov()
        {
            if (PrikaziGumbe)
            {
                Shrani.Visible = false;
                Full.Visible = false;
                Okvir.Visible = false;
                Vrh.Visible = false;
                Odlozi.Visible = false;
                KameraMenjaj.Visible = false;
                
                PrikaziGumbe = false;           
            }
            else
            {
                Shrani.Visible = true;
                Full.Visible = true;
                Okvir.Visible = true;
                Vrh.Visible = true;
                Odlozi.Visible = true;
                KameraMenjaj.Visible = true;

                PrikaziGumbe = true;
            }
            
        }

   

        private void VidnostNastavitev()
        {
            if (PrikaziNastavitve)
            {
                Naprave.Visible = false;
                Resolucije.Visible = false;
                Povezi.Visible = false;

                PrikaziNastavitve = false;
            }
            else
            {
                Naprave.Visible = true;
                Resolucije.Visible = true;
                Povezi.Visible = true;

                PrikaziNastavitve = true;
            }
        }


        void DesniMeni_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem)sender;

            if (menuItem.Name == "Vrh")
            {
                Vrh_Click(sender, e);
            }

            if (menuItem.Name == "Gumbi")
            {                
                VidnostGumbov();
            }
            if (menuItem.Name == "SOS")
            {
                FAQ();
            }
            if (menuItem.Name == "Kamera")
            {
                VidnostNastavitev();
            }
            if (menuItem.Name == "CelZaslon")
            {
                CezCelZaslon();
            }
            if (menuItem.Name == "ShraniN")
            {
                ShraniNastavitve();
            }
            if (menuItem.Name == "Adijo")
            {
                this.Close();
            }
            if (menuItem.Name == "ShraniO")
            {
                ShraniNaOdlozisce();
            }
            if (menuItem.Name == "ShraniS")
            {
                ShraniNaDisk();
            }
            if (menuItem.Name == "PoveziC")
            {
                Povezi_Click(sender, e);
            }

             if (menuItem.Name == "Okvir")
            {
                Okvir_Click(sender, e);
            }
            if (menuItem.Name == "SlikeV")
            {
                SpremniMapoZaSlike();
            }
          /*   if (menuItem.Name == "Jezik")
             {
                 OpenFileDialog openFileDialog1 = new OpenFileDialog();
                 openFileDialog1.Filter = "xml translation (*.xml)|*.xml";
                 if (openFileDialog1.ShowDialog() == DialogResult.OK)
                 {                    
                         JezikovnaDatoteka=System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                 }
                
             }*/
        }

        private void FAQ()
        {
            /*
             OkvirOkna = "Fensterumrundung";
                    NaOdlozisce = "Kopieren";
                    ShraniPrivzeto = "Einstelungen Speichern";
                    NastaviKamero = "Einstellungen";
                    Izhod = "Beenden";
                    PoveziNaKamero = "Kamera starten";
                    ShraniSliko = "Bild Speichern";
                    CelZaslon = "Vollbild";
                    Gumbi = "Men";
                    NaVrh = "Immer im Vordergrund halten";
                    Pomoc = "Info";
             */


            MessageBox.Show(
                   "Author: miharix" + "\r\n" +
                   "Licence: freeware\r\n\r\n" +
                   IzberiMapo.Description+" "+"\""+IzberiMapo.RootFolder+"\""+"\r\n\r\n"+
                   "F1 == "+Pomoc+"\r\n" +
                   "F11 || ESC == "+CelZaslon+"\r\n" +
                   "F12 == " + OkvirOkna + "\r\n" +
                   "F5 == " + ShraniSliko + "\r\n" +
                   "F9 == " + NaVrh + "\r\n" +
                   "F8 == " + Gumbi + "\r\n" +
                   "F2 == "+NastaviKamero + "\r\n" +
                   "F5 == " + PoveziNaKamero

                   
               , "F1,F1,F1...", MessageBoxButtons.OK);
        }

        //http://deepak-sharma.net/2012/11/18/how-to-create-context-menu-in-windows-forms-application-using-c-sharp/
        private void Okno_KeyDown(object sender, KeyEventArgs tipka)
        {
            if (tipka.KeyData == Keys.F11 || tipka.KeyData == Keys.Escape)
            {
                //FullScreen
                CezCelZaslon();
                NastaviNaShranjeno();
            }

            if (tipka.KeyData == Keys.F8)
            {
                VidnostGumbov();
                NastaviNaShranjeno();
            }

            if (tipka.KeyData == Keys.F9)
            {
                Vrh_Click(sender, tipka);
            }

            if (tipka.KeyData == Keys.F2)
            {
                VidnostNastavitev();
                NastaviNaShranjeno();
            }

            if (tipka.KeyData == Keys.F1)
            {
                FAQ();
            }
            if (tipka.KeyData == Keys.F4)
            {
                ShraniNaDisk();
            }
            if (tipka.Control && tipka.KeyCode == Keys.C)
            {
                ShraniNaOdlozisce();
            }

            if (tipka.KeyData == Keys.F5)
            {
                Povezi_Click(sender, tipka);
                
            }

            if (tipka.KeyData == Keys.F12)
            {
                Okvir_Click(sender, tipka);
            }
        }

    

        private void VideoKanal_Click(object sender, EventArgs e)
        {

        }

        private void Resolucije_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VideoNaprava != null)
            {
                if (VideoNaprava.IsRunning)
                {
                    VideoNaprava.Stop();
                    bPoveziNaKamero = false;
                    NastaviNaShranjeno();
                }
            }

            PrivzetaResolucija = Resolucije.SelectedIndex;
            
        }

        private void KameraMenjaj_Click(object sender, EventArgs e)
        {
            VidnostNastavitev();
            NastaviNaShranjeno();
        }

        private void Okno_MouseDown(object sender, MouseEventArgs miska)
        {
            if (miska.Button == MouseButtons.Right)
            {

                Control c = sender as Control;
                if (miska.Button == MouseButtons.Right)
                {
                    this.DesniKlik.Show(c, miska.Location);
                }

            }
        }

      
    }
}
