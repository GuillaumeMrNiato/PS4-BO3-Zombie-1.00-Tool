using System;
using System.Drawing;
using System.Windows.Forms;
using PS4Lib;

namespace BO3_PS4_1._00
{
    public partial class Form1 : Form
    {
        private readonly PS4API PS4 = new PS4API();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void firefoxButton7_Click(object sender, EventArgs e)
        {
           try
            {
                PS4.ConnectTarget(textBox1.Text);
                toolStripStatusLabel2.Text = "Connected !";
                toolStripStatusLabel2.ForeColor = Color.Lime;
                PS4.Notify(222, "PS4 successfully connected !\nPS4 BO3 RTM Tool By MrNiato\nTwitter : @ImMrNiato\nwww.mrniato.com");
            }
            catch
            {
                MessageBox.Show("Error while connecting the console !");
            }
        }

        private void firefoxButton6_Click(object sender, EventArgs e)
        {
            try
            {
                PS4.AttachProcess();
                toolStripStatusLabel5.Text = "Attached !";
                toolStripStatusLabel5.ForeColor = Color.Lime;
                PS4.Notify(222, "The process has been attached ! ");
            }
            catch
            {
                MessageBox.Show("Error while attaching the process !!");
            }
        }

        private void firefoxButton5_Click(object sender, EventArgs e)
        {
            PS4.DisconnectTarget();
            MessageBox.Show("PS4 Disconnected !");
            toolStripStatusLabel2.Text = "Disconnected !";
            toolStripStatusLabel2.ForeColor = Color.Red;
            toolStripStatusLabel5.Text = "Not Attached !";
            toolStripStatusLabel5.ForeColor = Color.Red;
        }
        public string get_player_name(uint client)
        {
            string getnames = PS4.Extension.ReadString(0x21BED64 + client * 0x17010);
            return getnames;
        }
        private void firefoxButton4_Click(object sender, EventArgs e)
        {
            Players.Items.Clear();
            for (uint i = 0; i < 0x04; i++)
            {
                Players.Items.Add(get_player_name(i));
                client0.Text = PS4.Extension.ReadString(0x21BED64);
                client1.Text = PS4.Extension.ReadString(0x21BED64 + 0x17010);
                textBox3.Text = PS4.Extension.ReadString(0x21BED64 + 0x17010 + 0x17010);
                textBox2.Text = PS4.Extension.ReadString(0x21BED64 + 0x17010 + 0x17010 + 0x17010);
            }
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8180 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x05 });
            }
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8180 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x04 });
            }
        }

        private void giveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A87E8 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0xff, 0xff, 0xff });
                PS4.SetMemory((0x21A87F0 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0xff, 0xff, 0xff });
                PS4.SetMemory((0x21A87AC + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0xff, 0xff, 0xff });
                PS4.SetMemory((0x21A87B4 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0xff, 0xff, 0xff });
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A87E8 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x10, 0x00, 0x00, 0x00 });
                PS4.SetMemory((0x21A87F0 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x10, 0x00, 0x00, 0x00 });
                PS4.SetMemory((0x21A87AC + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x10, 0x00, 0x00, 0x00 });
                PS4.SetMemory((0x21A87B4 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x10, 0x00, 0x00, 0x00 });
            }
        }

        private void giveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21BEE14 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0xff, 0xff, 0xff });
            }
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21BEE14 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x00, 0x00, 0x00});
            }
        }

        private void onToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21BEE5C + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x01 });
            }
        }

        private void oFFToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21BEE5C + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x03 });
            }
        }

        private void onToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8167 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x01 });
            }
        }

        private void offToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8167 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x00 });
            }
        }

        private void givToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A88F8 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x02 });
            }
        }

        private void removeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A88F8 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x04 });
            }
        }

        private void firefoxButton3_Click(object sender, EventArgs e)
        {
            PS4.Extension.WriteString(0x21BED64, client0.Text);
        }

        private void firefoxButton1_Click(object sender, EventArgs e)
        {
            PS4.Extension.WriteString(0x21BED64 + 0x17010, client1.Text);
        }

        private void defaultWeaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8508 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x01 });
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PS4.SetMemory((0x21A8568), BitConverter.GetBytes((int)numericUpDown1.Value));
        }

        private void missileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8508 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x64 });
            }
        }

        private void firefoxButton8_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            MessageBox.Show("In the numericUpDown change the number and your weapons will be changed ! Be carreful, it might freeze if you put a wrong number !\nDon't forget to follow me on Twitter !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start("https://twitter.com/ImMrNiato");
        }

        private void portersX2RayGunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8508 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x86 });
            }
        }

        private void beastArmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8508 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x90 });
            }
        }

        private void kN44ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8508 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x1C });
            }
        }

        private void iCR1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8508 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x1A });
            }
        }

        private void vesperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8508 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x02 });
            }
        }

        private void kudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8508 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x07 });
            }
        }

        private void deathTaxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x04; i++)
            {
                PS4.SetMemory((0x21A8508 + (uint)Players.SelectedIndex * 0x17010), new byte[] { 0x59 });
            }
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void firefoxButton10_Click(object sender, EventArgs e)
        {
            PS4.Extension.WriteString(0x21BED64 + 0x17010 + 0x17010, textBox3.Text);
        }

        private void firefoxButton9_Click(object sender, EventArgs e)
        {
            PS4.Extension.WriteString(0x21BED64 + 0x17010 + 0x17010 + 0x17010, textBox2.Text);
        }
    }
}
