using System;

namespace E02_ThuatToanSapXep
{
    public class SanPham
    {
        public int id;
        public string ten;
        public double price;
        public int soluongban;
        public double rating;
        public SanPham(int id, string ten, double price, int soluongban, double rating)
        {
            this.id = id;
            this.ten = ten;
            this.price = price;
            this.soluongban = soluongban;
            this.rating = rating;
        }
        public override string ToString()
        {
            return $"{id,-5} {ten,-15} {price,8} {soluongban,5} {rating,4}";
        }
    }
}