using System;
using System.Collections.Generic;

namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan { get; }
        public string Nama { get; }
        public string Posisi { get; }

        public Karyawan(string nomorKaryawan, string nama, string posisi)
        {
            NomorKaryawan = nomorKaryawan;
            Nama = nama;
            Posisi = posisi;
        }
    }

    public class KaryawanNode
    {
        public Karyawan Karyawan { get; }  // Perbaikan: ganti "Data" menjadi "Karyawan"
        public KaryawanNode Next { get; set; }
        public KaryawanNode Prev { get; set; }

        public KaryawanNode(Karyawan karyawan)
        {
            Karyawan = karyawan;
        }
    }

    public class DaftarKaryawan
    {
        private KaryawanNode head;
        private KaryawanNode tail;

        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode newNode = new KaryawanNode(karyawan);
            if (tail == null)
                head = tail = newNode;
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        public bool HapusKaryawan(string nomorKaryawan)
        {
            KaryawanNode current = head;
            while (current != null && current.Karyawan.NomorKaryawan != nomorKaryawan)
                current = current.Next;

            if (current == null) return false;

            if (current.Prev != null)
                current.Prev.Next = current.Next;
            else
                head = current.Next;

            if (current.Next != null)
                current.Next.Prev = current.Prev;
            else
                tail = current.Prev;

            return true;
        }

        public Karyawan[] CariKaryawan(string kataKunci)
        {
            List<Karyawan> hasil = new List<Karyawan>();
            KaryawanNode current = head;
            while (current != null)
            {
                if (current.Karyawan.Nama.Contains(kataKunci) || current.Karyawan.Posisi.Contains(kataKunci))
                    hasil.Add(current.Karyawan);
                current = current.Next;
            }
            return hasil.ToArray();
        }

        public string TampilkanDaftar()  
        {
            List<string> daftarKaryawan = new List<string>();
            KaryawanNode current = tail;
            while (current != null)
            {
                daftarKaryawan.Add($"{current.Karyawan.NomorKaryawan}; {current.Karyawan.Nama}; {current.Karyawan.Posisi}");
                current = current.Prev;
            }
            return string.Join("\n", daftarKaryawan);
        }
    }
}
