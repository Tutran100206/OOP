using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization; 

namespace E02_ThuatToanSapXep
{
    public class SanPhamManager
    {
        public List<SanPham> ds = new List<SanPham>();

        public void DocFile(string filename, int n)
        {
            using (var reader = new StreamReader(filename))
            {
                for (int i = 0; i < n && !reader.EndOfStream; i++)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        i--;
                        continue;
                    }

                    var values = line.Split(',');
                    int id = int.Parse(values[0]);
                    string ten = values[1];
                    double price = Double.Parse(values[2]);
                    int soluongban = int.Parse(values[3]);
                    double rating = Double.Parse(values[4]);
                    SanPham sp = new SanPham(id, ten, price, soluongban, rating);
                    ds.Add(sp);
                }
            }
        }

        public void Sapxepgia()
        {
            Sorter.SelectionSort(ds);
        }
        public void Sapxeprating()
        {
            Sorter.BubbleSort(ds);
        }
        public void Sapxepsoluongban()
        {
            Sorter.InsertionSort(ds);
        }
        public void Sapxepten()
        {
            Sorter.QuickSort(ds, 0, ds.Count - 1);
        }
    }
}