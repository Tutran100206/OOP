using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace E02_ThuatToanSapXep
{
    public static class Sorter
    {
        public static void SelectionSort(List<SanPham> ds) // sap xep theo gia bang selection
        {
            int n = ds.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (ds[i].price < ds[j].price)
                    {
                        var temp = ds[i];
                        ds[i] = ds[j];
                        ds[j] = temp;
                    }
                }
            }
        }

        public static void BubbleSort(List<SanPham> ds) // sap xep theo diem danh gia
        {
            int n = ds.Count;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (ds[j].rating > ds[j + 1].rating)
                    {
                        var temp = ds[j];
                        ds[j] = ds[j + 1];
                        ds[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }

        public static void InsertionSort(List<SanPham> ds) // sap xep theo so luong ban
        {
            int n = ds.Count;
            for (int i = 1; i < n; i++)
            {
                SanPham key = ds[i];
                int j = i - 1;
                while (j >= 0 && ds[j].soluongban < key.soluongban) // cao-->thap
                {
                    ds[j + 1] = ds[j];
                    j -= 1;
                }
                ds[j + 1] = key;
            }
        }
        public static void InsertionSort1(List<SanPham> ds) // sap xep theo so luong ban, neu bang nhau thi theo A-Z
        {
            int n = ds.Count;
            for (int i = 1; i < n; i++)
            {
                SanPham key = ds[i];
                int j = i - 1;
                while (j >= 0 &&
                      (ds[j].soluongban > key.soluongban ||
                      (ds[j].soluongban == key.soluongban &&
                       string.Compare(ds[j].ten, key.ten, StringComparison.OrdinalIgnoreCase) > 0)))
                {
                    ds[j + 1] = ds[j];
                    j--;
                }
                ds[j + 1] = key;
            }
        }

        public static void QuickSortByName(List<SanPham> ds)
        {
            QuickSort(ds, 0, ds.Count - 1);
        }

        public static void QuickSort(List<SanPham> ds, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(ds, low, high);

                QuickSort(ds, low, pi - 1);
                QuickSort(ds, pi + 1, high);
            }
        }

        public static int Partition(List<SanPham> ds, int low, int high)
        {
            string pivot = ds[high].ten;  // chọn tên cuối làm pivot
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (string.Compare(ds[j].ten, pivot) <= 0)  // so sánh A-Z
                {
                    i++;
                    var temp = ds[i];
                    ds[i] = ds[j];
                    ds[j] = temp;
                }
            }
            var tempPivot = ds[i + 1];
            ds[i + 1] = ds[high];
            ds[high] = tempPivot;

            return i + 1;
        }
    }
}