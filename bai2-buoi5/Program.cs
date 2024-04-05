using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2_buoi5
{
    public struct Product
    {
        public string ProductName;
        public float ProductPrice;
        public DateTime ExpiredDate;
        public bool IsExpired()
        {
            TimeSpan timeSpan = ExpiredDate - DateTime.Now;
            return timeSpan.Days < 180;
        }
        public bool IsExpiring()
        {
            TimeSpan timeSpan = ExpiredDate - DateTime.Now;
            return timeSpan.Days <= 30;
        }
    }
    internal class Program
    {
        public static List<Product> NhapProduct(List<Product> products)
        {
            Console.Write("Nhap so luong product: ");
            string Productin = Console.ReadLine();
            int TongP;
            bool TongPlaso = int.TryParse(Productin, out TongP);
            while (TongPlaso == false)
            {
                Console.WriteLine("ban nhap khong phai so! xin moi nhap lai:");
                Productin = Console.ReadLine();
                TongPlaso = int.TryParse(Productin, out TongP);
                if ((TongP < 0) && (TongP > 2147483647) && (TongPlaso == true))
                {
                    Console.WriteLine("ban nhap so khong trong khoang int, xin moi nhap lai.");
                    TongPlaso = false;
                }
            }
            for (int i = 0; i < TongP; i++)
            {
                Product p = new Product();
                Console.Write("Nhap ten san pham: ");
                p.ProductName = Console.ReadLine();
                Console.Write("Nhap gia san pham: ");
                string Giavao = Console.ReadLine();
                float gia;
                bool Giavaolaso = float.TryParse(Giavao, out gia);
                while (Giavaolaso == false)
                {
                    Console.WriteLine("ban nhap khong phai so! xin moi nhap lai:");
                    Giavao = Console.ReadLine();
                    Giavaolaso = float.TryParse(Giavao, out gia);
                    if ((gia < 0) && (gia > 2147483647) && (Giavaolaso == true))
                    {
                        Console.WriteLine("ban nhap so khong trong khoang int, xin moi nhap lai.");
                        Giavaolaso = false;
                    }
                }
                p.ProductPrice = gia;
                Console.Write("Nhap ngay het han (dd/MM/yyyy): ");
                string NgayHetHan = Console.ReadLine();
                DateTime Ex;
                bool langay = DateTime.TryParseExact(NgayHetHan, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out Ex);
                while (langay == false)
                {
                    Console.WriteLine("ban nhap khong dung dinh dang, xin moi nhap lai!");
                    NgayHetHan = Console.ReadLine();
                    langay = DateTime.TryParseExact(NgayHetHan, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out Ex);
                }
                p.ExpiredDate = Ex;
                products.Add(p);
            }
            return products;
        }
        public static void InSanPhamSapHetHan(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.IsExpiring())
                {
                    Console.WriteLine($"ProductName: {product.ProductName}, ProductPrice: {product.ProductPrice}, ExpiredDate: {product.ExpiredDate}");
                }
            }
        }
        public static void InSanPhamTenDaiHon10KyTu(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.ProductName.Length > 10)
                {
                    Console.WriteLine($"ProductName: {product.ProductName}, ProductPrice: {product.ProductPrice}, ExpiredDate: {product.ExpiredDate}");
                }
            }
        }
        static void Main(string[] args)
        {
            List<Product> p = new List<Product>();
            Console.WriteLine("dau tien ban nhap so luong va chi tiet san pham!");
            NhapProduct(p);
            Console.WriteLine("vui long chon trong menu sau:");
            Console.WriteLine("1.in ra cac san pham co ngay het han <=30");
            Console.WriteLine("2.in san pham co ten dai hon 10 ky tu.");
            string chonvao = Console.ReadLine();
            int chon;
            bool chonlaso = int.TryParse(chonvao, out chon);
            while (chonlaso == false)
            {
                Console.WriteLine("ban nhap khong phai so! xin moi nhap lai:");
                chonvao = Console.ReadLine();
                chonlaso = int.TryParse(chonvao, out chon);
                if ((chon < 0) && (chon > 2) && (chonlaso == true))
                {
                    Console.WriteLine("ban nhap so khong trong khoang int, xin moi nhap lai.");
                    chonlaso = false;
                }
            }
            switch(chon)
            {
                case 1:InSanPhamSapHetHan(p); break;
                case 2:InSanPhamTenDaiHon10KyTu(p); break;
                default: Console.WriteLine("ban nhap khong trong menu"); break;
            }
            Console.ReadKey();
        }
    }
}
