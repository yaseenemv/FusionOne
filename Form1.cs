using Fusion_One_Cracker;
using System;
using System.Text;
using System.Windows.Forms;

namespace FileEncrypt
{
    public partial class Form1 : Form
    {

        public static object Properties { get; internal set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog
            {
                Multiselect = false
            };
            if (od.ShowDialog() == DialogResult.OK)
            {
                tbDuongDan.Text = od.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbMaHoa.Checked = true;

        }

        private void rbMaHoa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMaHoa.Checked)
            {
                rbGiaiMa.Checked = false;
            }
        }

        private void rbGiaiMa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGiaiMa.Checked)
            {
                rbMaHoa.Checked = false;
            }
        }

        private void btThucHien_Click(object sender, EventArgs e)
        {

            if (tbDuongDan.Text.Length == 0)
            {
                MessageBox.Show("You must enter a String.");
                return;
            }

            // Chuan bi du lieu de ma hoa hoac giai ma
            try
            {
                // Doc noi dung tep tin

                // Sinh khoa tu mat khau
                byte[] matKhauByte = Encoding.ASCII.GetBytes(tbDuongDan.Text);

                string str = Encoding.Default.GetString(matKhauByte);


                if (rbMaHoa.Checked)
                {
                    String msgtext = CryptorEngine.Encrypt(str);
                    if (MessageBox.Show(msgtext, "FusionOne (OK to copy)", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    { Clipboard.SetText(msgtext); }


                }
                else
                {

                    String msgtext = CryptorEngine.Decrypt(str);
                    if (MessageBox.Show(msgtext, "FusionOne (OK to copy)", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    { Clipboard.SetText(msgtext); }


                }
            }
            catch
            {
                MessageBox.Show("The file is in use by another program, close the program that is using the file and try again.");
                return;
            }
        }
    }
}
