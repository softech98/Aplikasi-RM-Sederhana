using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makan
{
	class makan
	{
		public int priceNasi = 5000, priceAyam = 10000, priceMinum = 3000, priceSayur = 5000,
						priceRendang = 10000, priceIkan = 9000;

		public  int jNasi = 0, jAyam = 0, jMinum = 0, jSayur = 0, jRendang = 0,
					jIkan = 0, jKrupuk = 0, jSoto = 0;
		private bool nasi, ayam, minum, sayur, rendang, ikan;
		public double ppn = 0, subtotal=0,uangbayar=0;



		public void resetJmenu()
		{
			jNasi = 0;jAyam = 0; jMinum = 0; jSayur = 0; jRendang = 0;
			jIkan = 0; jKrupuk = 0; jSoto = 0;
		}
		public void setMenu (string a="")
		{
			if (a == "NASI")
			{
				this.nasi=true;
			}
			else if (a == "AYAM")
			{
				this.ayam = true;
			}
			else if (a == "MINUM")
			{
				this.minum = true;
			}
			else if (a == "SAYUR")
			{
				this.sayur = true;
			}
			else if (a == "RENDANG")
			{
				this.rendang = true;
			}
			else if (a == "IKAN")
			{
				this.ikan = true;

			}

		}
		public void setTambahNasi(int i)
		{
			if (this.nasi == true)
			{
				this.jNasi = i;
			}
		}
		public void setTambahAyam(int i)
		{
			if (this.ayam == true)
			{
				this.jAyam = i;
			}
		}
		public void setTambahMinum(int i)
		{
			if (this.minum == true)
			{
				this.jMinum = i;
			}
		}
		public void setTambahSayur(int i)
		{
			if (this.sayur == true)
			{
				this.jSayur = i;
			}
		}
		public void setTambahRendang(int i)
		{
			if (this.rendang == true)
			{
				this.jRendang = i;
			}
		}
		public void setTambahIkan(int i)
		{
			if (this.ikan == true)
			{
				this.jIkan = i;
			}
		}

		public double bayar()
		{
			double total = (this.jNasi * this.priceNasi) + (this.jAyam * this.priceAyam) + (this.jMinum * this.priceMinum) + (this.jSayur * this.priceSayur) + (this.jRendang * this.priceRendang) + (this.jIkan * this.priceIkan);
			//System.Windows.Forms.MessageBox.Show("Pembayaran Rp. " + total);
			this.subtotal = total;
			double ppn = (total * 10/100);
			this.ppn = ppn;
			
			double gTotal = total + ppn;
			return gTotal;
		}
		public double kembalian()
		{
			double kembali =this.uangbayar - this.bayar();
			return kembali;
		}
	}
}
