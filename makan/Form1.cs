using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;


namespace makan
{
	public partial class Form1 : MaterialForm
	{
		makan softech98 = new makan();
		private readonly MaterialSkinManager materialSkinManager;
		public Form1()
		{
			InitializeComponent();
			// Initialize MaterialSkinManager
			materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal600, Primary.Teal800, Primary.BlueGrey500, Accent.Teal700, TextShade.WHITE);

			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormClosingEventCancle_Closing);
		}
		private void FormClosingEventCancle_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DialogResult dr = MessageBox.Show("Apakah anda Yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question); if (dr == DialogResult.No)
				e.Cancel = true;
			else
				e.Cancel = false;
		}

		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		public void hitung()
		{
			lblTotal.Text = "Rp " + softech98.bayar().ToString("n0");
			lblSubt.Text = "Rp " + softech98.subtotal.ToString("n0");
			lblPpn.Text = "Rp " + softech98.ppn.ToString("n0");
		}
		private void btnHitung_Click(object sender, EventArgs e)
		{
			hitung();
		}

		public void Ceklis()
		{
			if (!cbNasi.Checked && !cbAyam.Checked && !cbMinum.Checked && !cbRendang.Checked && !cbIkan.Checked && !cbSayur.Checked)
			{
				MessageBox.Show("PILIH MENU YG TERSEDIA DAHULU", "PEMBERITAHUAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbNasi.Checked=true;
			}
			else
			{ 
				if (cbNasi.Checked)
				{
					softech98.setMenu(cbNasi.Text);
					listPesan.Items.Add(cbNasi.Text);
				}

				if (cbAyam.Checked)
				{
					softech98.setMenu(cbAyam.Text);
					listPesan.Items.Add(cbAyam.Text);
				}

				if (cbMinum.Checked)
				{
					softech98.setMenu(cbMinum.Text);
					listPesan.Items.Add(cbMinum.Text);
				}
				if (cbSayur.Checked)
				{
					softech98.setMenu(cbSayur.Text);
					listPesan.Items.Add(cbSayur.Text);
				}
				if (cbRendang.Checked)
				{
					softech98.setMenu(cbRendang.Text);
					listPesan.Items.Add(cbRendang.Text);
				}
				if (cbIkan.Checked)
				{
					softech98.setMenu(cbIkan.Text);
					listPesan.Items.Add(cbIkan.Text);
				}

				listPesan.SelectedIndex = (0);
			}
		}
		
		public void Form1_Load(object sender, EventArgs e)
		{
			listView1.GridLines = true;
			MessageBox.Show("Nama	: Ilham Saputra \n" +
							"NO.HP	: 081377815153 \n" +
							"Web	: www.softech98.com","INFORMASI PROGRAM",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void materialRaisedButton4_Click(object sender, EventArgs e)
		{
			Ceklis();
		}


		private void materialRaisedButton5_Click_1(object sender, EventArgs e)
		{

			//			 >> RESET MENU PILIHAN <<
			listPesan.Items.Clear();
			foreach (Control ctrl in groupBox1.Controls)
			{
				MaterialCheckBox hapus = (MaterialCheckBox)ctrl;
				hapus.Checked = false;
			}
			foreach (Control ctrl in groupBox2.Controls)
			{
				ListView reset = (ListView)ctrl;
				reset.Items.Clear();
			}
			lblSubt.Text = "-";
			lblPpn.Text = "-";
			lblTotal.Text = "-";
			lblKembalian.Text = "-";

			txtTambah.Clear();
			softech98.resetJmenu();
		}

		private void btnTambah_Click(object sender, EventArgs e)
		{
			Tambah();
			nextSelect();
		}
		public void Tambah()
		{
			ListViewItem lvi = new ListViewItem();

			if (txtTambah.Text == "")
			{
				MessageBox.Show("Masukkan Jumlah Pesanan", "PEMBERITAHUAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTambah.Focus();
			}
			else
			{
				if (listPesan.Items.Count < 0 || listPesan.SelectedItem == null)
				{
					MessageBox.Show("Harap Pilih Menu yang Tersedia");
				}

				else
				{
					//	>>>	DENGAN MENGGUNAKAN SWITCH CASE  <<< 
					switch (listPesan.SelectedItem)
					{
						case "NASI":

							softech98.setTambahNasi(Convert.ToInt16(txtTambah.Text));
							lvi.Text = cbNasi.Text;
							lvi.SubItems.Add(softech98.jNasi.ToString());
							lvi.SubItems.Add(softech98.priceNasi.ToString());
							lvi.SubItems.Add(Convert.ToString(softech98.jNasi * softech98.priceNasi));
							listView1.Items.Add(lvi);
							break;

						case "AYAM":
							softech98.setTambahAyam(Convert.ToInt16(txtTambah.Text));
							//	pesan = { cbAyam.Text, txtTambah.Text, Convert.ToString(softech98.priceAyam), Convert.ToString(softech98.priceAyam * softech98.jAyam) };
							lvi.Text = cbAyam.Text;
							lvi.SubItems.Add(softech98.jAyam.ToString());
							lvi.SubItems.Add(softech98.priceAyam.ToString());
							lvi.SubItems.Add(Convert.ToString(softech98.jAyam * softech98.priceAyam));
							listView1.Items.Add(lvi);
							break;
						case "MINUM":
							softech98.setTambahMinum(Convert.ToInt16(txtTambah.Text));
							//pesan = { cbMinum.Text, txtTambah.Text, Convert.ToString(softech98.priceMinum), Convert.ToString(softech98.priceMinum * softech98.jMinum) };
							lvi.Text = cbMinum.Text;
							lvi.SubItems.Add(softech98.jMinum.ToString());
							lvi.SubItems.Add(softech98.priceMinum.ToString());
							lvi.SubItems.Add(Convert.ToString(softech98.jMinum * softech98.priceMinum));
							listView1.Items.Add(lvi);
							break;
						case "RENDANG":
							softech98.setTambahRendang(Convert.ToInt16(txtTambah.Text));
							lvi.Text = cbRendang.Text;
							lvi.SubItems.Add(softech98.jRendang.ToString());
							lvi.SubItems.Add(softech98.priceRendang.ToString());
							lvi.SubItems.Add(Convert.ToString(softech98.jRendang * softech98.priceRendang));
							listView1.Items.Add(lvi);
							break;
						case "IKAN":
							softech98.setTambahIkan(Convert.ToInt16(txtTambah.Text));
							lvi.Text = cbIkan.Text;
							lvi.SubItems.Add(softech98.jIkan.ToString());
							lvi.SubItems.Add(softech98.priceIkan.ToString());
							lvi.SubItems.Add(Convert.ToString(softech98.jIkan * softech98.priceIkan));
							listView1.Items.Add(lvi);
							break;
						case "SAYUR":
							softech98.setTambahSayur(Convert.ToInt16(txtTambah.Text));
							lvi.Text = cbSayur.Text;
							lvi.SubItems.Add(softech98.jSayur.ToString());
							lvi.SubItems.Add(softech98.priceSayur.ToString());
							lvi.SubItems.Add(Convert.ToString(softech98.jSayur * softech98.priceSayur));
							listView1.Items.Add(lvi);
							break;
					}
				}
			}
		}
		private void txtTambah_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				Tambah();
				nextSelect();
			}
		}
		public void nextSelect()
		{
			int x = listPesan.SelectedIndex;
			try
			{

				listPesan.SelectedIndex = x + 1;
			}
			catch
			{
				listPesan.SelectedIndex = x;
				hitung();
				txtBayar.Focus();
				txtBayar.SelectAll();
			}
		}
		private void materialButton1_Click(object sender, EventArgs e)
		{
			materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
		}

		private void listPesan_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listPesan.SelectedItem.Equals("NASI") || listPesan.SelectedItem.Equals("AYAM") || listPesan.SelectedItem.Equals("MINUM") || listPesan.SelectedItem.Equals("RENDANG") || listPesan.SelectedItem.Equals("IKAN") || listPesan.SelectedItem.Equals("SAYUR"))
			{
				txtTambah.Focus();
				txtTambah.SelectAll();
			}
		}

		private void listPesan_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Space || e.KeyChar == (char)Keys.Back)
			{
				
				listPesan.Items.RemoveAt(listPesan.SelectedIndex);
				MessageBox.Show("Terhapus");
			}
		}

		private void materialSingleLineTextField1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Enter)))
			{
				MessageBox.Show("Hanya Input Angka");
				txtBayar.Clear();
				txtBayar.SelectAll();
			}
			else if (e.KeyChar == (char)Keys.Enter)
			{
				softech98.uangbayar = Convert.ToDouble(txtBayar.Text);
				lblKembalian.Text = "Rp " + softech98.kembalian().ToString("n0");
			}
		}
	}
}