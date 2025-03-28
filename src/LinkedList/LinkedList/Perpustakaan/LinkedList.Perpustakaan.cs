using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Perpustakaan
{
    public class Buku
    {
        public string Judul { get; }
        public string Penulis { get; }
        public int Tahun { get; }

        public Buku(string judul, string penulis, int tahun)
        {
            Judul = judul;
            Penulis = penulis;
            Tahun = tahun;
        }
    }

    public class BukuNode
    {
        public Buku Data { get; }
        public BukuNode Next { get; set; }

        public BukuNode(Buku buku)
        {
            Data = buku;
            Next = null;
        }
    }

    public class KoleksiPerpustakaan
    {
        private BukuNode head;
        
        public void TambahBuku(Buku buku)
        {
            BukuNode newNode = new BukuNode(buku);
            newNode.Next = head;
            head = newNode;
        }

        public bool HapusBuku(string judul)
        {
            BukuNode current = head, prev = null;
            while (current != null && current.Data.Judul != judul)
            {
                prev = current;
                current = current.Next;
            }

            if (current == null) return false;

            if (prev == null)
                head = current.Next;
            else
                prev.Next = current.Next;

            return true;
        }

        public Buku[] CariBuku(string kataKunci)
        {
            List<Buku> hasil = new List<Buku>();
            BukuNode current = head;
            while (current != null)
            {
                if (current.Data.Judul.Contains(kataKunci))
                    hasil.Add(current.Data);
                current = current.Next;
            }
            return hasil.ToArray();
        }

        public string TampilkanKoleksi() 
        {
            StringBuilder sb = new StringBuilder();
            BukuNode current = head;
            while (current != null)
            {
                sb.AppendLine($"\"{current.Data.Judul}\"; {current.Data.Penulis}; {current.Data.Tahun}");
                current = current.Next;
            }
            return sb.ToString().TrimEnd(); 
        }
    }
}
