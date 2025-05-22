using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Klasa;

namespace klijentt
{
    public partial class Form1 : Form
    {
        private TcpClient tcpKlijent;
        private UdpClient udpSenzori, udpVideo;
        private Thread senzorThread, tcpThread, videoThread;
        private bool primaVideo = false;
        private string tempVideoPath = "temp_video.mp4";
        private bool spojeno = false;
        private volatile bool videoSpremanjeUTijeku = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnSpoji_Click(object sender, EventArgs e)
        {
            if (spojeno)
            {
                MessageBox.Show("Već ste spojeni na server!");
                return;
            }

            try
            {

                tcpKlijent = new TcpClient(txtIP.Text, int.Parse(txtPort.Text));
                tcpThread = new Thread(SlusajTCP);
                tcpThread.Start();


                udpSenzori = new UdpClient(9999);
                senzorThread = new Thread(SlusajSenzore);
                senzorThread.Start();


                udpVideo = new UdpClient();

                spojeno = true;
                btnOtvori.Enabled = true;
                btnZatvori.Enabled = true;
                btnStartVideo.Enabled = true;

                MessageBox.Show("Spojeni ste na server!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri spajanju: {ex.Message}");
            }
        }

        private void SlusajTCP()
        {
            byte[] buffer = new byte[1024];
            try
            {
                while (true)
                {
                    int procitano = tcpKlijent.GetStream().Read(buffer, 0, buffer.Length);
                    if (procitano == 0) break;
                    string poruka = Encoding.UTF8.GetString(buffer, 0, procitano);
                    AzurirajStatusVrata(poruka);
                }
            }
            catch { }
        }

        private void SlusajSenzore()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                try
                {
                    byte[] podaci = udpSenzori.Receive(ref ep);
                    if (podaci.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(podaci))
                        {
                            var senzor = (PodaciSenzora)formatter.Deserialize(ms);
                            AzurirajSenzore(senzor);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnOtvori_Click(object sender, EventArgs e)
        {
            PosaljiKomandu("OTVORI_VRATA");
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            PosaljiKomandu("ZATVORI_VRATA");
        }

        private void btnStartVideo_Click(object sender, EventArgs e)
        {

            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.URL = "";
            Application.DoEvents();


            primaVideo = false;
            videoThread?.Join(1000);


            if (File.Exists(tempVideoPath))
            {
                try
                {
                    File.Delete(tempVideoPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greška pri brisanju videa: {ex.Message}");
                    return;
                }
            }


            primaVideo = true;
            videoThread = new Thread(SpremiVideo);
            videoThread.Start();
        }






        private void SpremiVideo()
        {
            videoSpremanjeUTijeku = true;
            try
            {
                string serverIP = txtIP.Text.Trim();
                byte[] zahtjev = Encoding.UTF8.GetBytes("POKRENI_VIDEO");
                udpVideo.Send(zahtjev, zahtjev.Length, serverIP, 10000);


                udpVideo.Client.ReceiveTimeout = 2000;

                using (FileStream fs = new FileStream(tempVideoPath, FileMode.Create))
                {
                    IPEndPoint serverEP = new IPEndPoint(IPAddress.Any, 0);
                    while (true)
                    {
                        try
                        {
                            byte[] primljeno = udpVideo.Receive(ref serverEP);
                            fs.Write(primljeno, 0, primljeno.Length);
                        }
                        catch (SocketException ex)
                        {

                            if (ex.SocketErrorCode == SocketError.TimedOut)
                                break;


                            throw new Exception($"Mrežna greška: {ex.Message}");
                        }
                    }
                }


                if (File.Exists(tempVideoPath) && new FileInfo(tempVideoPath).Length > 0)
                {
                    MessageBox.Show("Video spremljen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Video nije primljen!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri spremanju videa: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                videoSpremanjeUTijeku = false;
            }
        }













        private void AzurirajSenzore(PodaciSenzora podaci)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<PodaciSenzora>(AzurirajSenzore), podaci);
                return;
            }
            lblTemperatura.Text = $"Temperatura: {podaci.Temperatura}°C";
            lblVlaznost.Text = $"Vlažnost: {podaci.Vlaznost}%";
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPustiVideo_Click(object sender, EventArgs e)
        {

            axWindowsMediaPlayer1.Visible = true;

            videoThread?.Join(1000);

            if (videoSpremanjeUTijeku)
            {
                MessageBox.Show("Video se još uvijek sprema. Pričekaj da spremanje završi!");
                return;
            }

            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, tempVideoPath);

            if (!File.Exists(fullPath))
            {
                MessageBox.Show($"Video file nije pronađen:\n{fullPath}");
                return;
            }

            try
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.URL = "";
                Application.DoEvents();

                using (FileStream fs = File.Open(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {

                }

                axWindowsMediaPlayer1.URL = fullPath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Video je još uvijek u upotrebi!\n{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri puštanju videa: {ex.Message}");
            }
        }

        private void btnStopVideo_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTemperatura_Click(object sender, EventArgs e)
        {

        }

        private void lblStatusVrata_Click(object sender, EventArgs e)
        {

        }

        private void AzurirajStatusVrata(string poruka)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AzurirajStatusVrata), poruka);
                return;
            }
            lblStatusVrata.Text = poruka.Replace("_", " ");
            lblStatusVrata.ForeColor = poruka.Contains("OTVORENA") ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }

        private void PosaljiKomandu(string komanda)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(komanda);
                tcpKlijent.GetStream().Write(buffer, 0, buffer.Length);
            }
            catch { }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            primaVideo = false;
            udpSenzori?.Close();
            udpVideo?.Close();
            tcpKlijent?.Close();
            base.OnFormClosing(e);
        }
    }
}
