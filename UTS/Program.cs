using System;
using System.Runtime.CompilerServices;
using uts;

namespace uts
{

    public class sekolah
    {
        public string idSekolah { get; set; }
        public string namaSekolah { get; set; }
        public int jumlahPaketDiterima { get; set; }

        public void TampilInfo()
        {
            Console.WriteLine($"{namaSekolah} dengan id {idSekolah} menerima juamlah paket MBG sebanyak {jumlahPaketDiterima}");
        }
    }


    class PaketMBG
    {
        private string idPaket;
        private string namaPaket;
        private int stokDapur;

        public PaketMBG(string idPaket, string namaPaket, int stokDapur)
        {
            this.idPaket = idPaket;
            this.namaPaket = namaPaket;

            if (stokDapur < 0)
            {
                Console.WriteLine("Stok dapur tidak boleh negatif");
            }

            this.stokDapur = stokDapur;
        }

        public string IdPaket
        {
            get { return idPaket; }
            set { idPaket = value; }
        }

        public string NamaPaket
        {
            get { return namaPaket; }
            set { namaPaket = value; }
        }

        public int StokDapur
        {
            get { return stokDapur; }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Stok dapur tidak boleh negatif");
                }

                stokDapur = value;
            }
        }

        public void KurangiStok(int jumlah)
        {
            if (jumlah <= 0)
            {
                Console.WriteLine("Jumlah pengurangan harus lebih dari 0");
            }
            else if (jumlah > stokDapur)
            {
                Console.WriteLine("Stok dapur tidak mencukupi");
            }
            else
            {
                StokDapur -= jumlah;
                Console.WriteLine("Stok berhasil dikurangi");
            }
        }

        public void TampilkanInfo()
        {
            Console.WriteLine("ID Paket: " + idPaket);
            Console.WriteLine("Nama Paket: " + namaPaket);
            Console.WriteLine("Stok Dapur: " + stokDapur);
        }
    }

    public class PaketReguler : PaketMBG
    {
    
        public override int HitungBiaya(int jumlah)
        {
            return jumlah * 15000;
        }

        public override void TampilkanInfo()
        {
            Console.WriteLine("Paket Reguler");
            Console.WriteLine("Berisi: Nasi, ayam, sayur, dan buah");
            Console.WriteLine("Harga: Rp15.000 per paket");
        }

        class PaketKhusus : PaketMBG
        {
            public string jenisDiet;

            public PaketKhusus(string diet)
            {
                jenisDiet = diet;
            }

            public override int HitungBiaya(int jumlah)
            {
                return jumlah * 20000;
            }

            public override void TampilkanInfo()
            {
                Console.WriteLine("Paket Khusus");
                Console.WriteLine("Jenis Diet: " + jenisDiet);
                Console.WriteLine("Harga: Rp20.000 per paket");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                sekolah sekolah1 = new sekolah();
                sekolah1.idSekolah = "1";
                sekolah1.namaSekolah = "SMA Purwoharjo";
                sekolah1.jumlahPaketDiterima = 300;

                sekolah sekolah2 = new sekolah();
                sekolah2.idSekolah = "2";
                sekolah2.namaSekolah = "SMA 2 Jember";
                sekolah2.jumlahPaketDiterima = 350;

                Console.WriteLine($"id    : {sekolah1.idSekolah}");
                Console.WriteLine($"nama  : {sekolah1.namaSekolah}");
                Console.WriteLine($"jumlah: {sekolah1.jumlahPaketDiterima}");
                sekolah1.TampilInfo();

                Console.WriteLine($"id    : {sekolah2.idSekolah}");
                Console.WriteLine($"nama  : {sekolah2.namaSekolah}");
                Console.WriteLine($"jumlah: {sekolah2.jumlahPaketDiterima}");
                sekolah2.TampilInfo();

                int jumlah;

                Console.WriteLine("PROGRAM PAKET MBG");

                PaketMBG paket;

                paket = new PaketReguler();

                Console.WriteLine(" PAKET REGULER");
                paket.TampilkanInfo();

                Console.WriteLine("Total Biaya: Rp" + paket.HitungBiaya(jumlah));

                paket = new PaketKhusus("Rendah Gula");

                Console.WriteLine("PAKET KHUSUS");
                paket.TampilkanInfo();

                Console.WriteLine("Total Biaya: Rp" + paket.HitungBiaya(jumlah));

                paket.TampilkanInfo();

                paket.KurangiStok(20);

                paket.TampilkanInfo();
            }
        }
    }
}