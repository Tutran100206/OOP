using System;

namespace HinhHoc
{
    public abstract class LopDaGiac
    {
        private int SoCanh;
        protected double[] chieudaicanh;
        public LopDaGiac(int SoCanh)
        {
            this.SoCanh = SoCanh;
            chieudaicanh = new double[SoCanh];
        }

        public virtual void InThongTin()
        {
            Console.WriteLine("Day la thong tin:\n");
        }
        public abstract double TinhChuVi();
        public abstract double TinhDienTich();
        // getter - setter
        public int getSoCanh()
        {
            return SoCanh;
        }
        public void setSoCanh(int SoCanh)
        {
            this.SoCanh = SoCanh;
        }
    }
}