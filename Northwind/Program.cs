using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Northwind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Category ve Product tablosu için CRUD işlemlerini yaptığımız metotları yazın.

            //ProductEkle();

            //ProductListele();

            //ProductSil(80);

            //ProductGuncellemek();

            //CategoryEkle();

            //CategoryListele();            

            CategorySil(15);

            //CategoryGuncellemek();



        }

        private static void CategoryGuncellemek()
        {
            Categories categories = new Categories();

            categories.Id = 15;

            categories.CategoryName = "İçecek";

            categories.Description = "Soğuk ve sıcak";

            CategoryGuncelle(categories);
        }

        private static void ProductGuncellemek()
        {
            Products products = new Products();

            products.ProductID = 79;

            products.ProductName = "dondurma";

            products.SupplierID = 2;

            products.CategoryID = 5;

            products.QuantityPerUnit = "30 boxes";

            products.UnitPrice = 20;

            products.UnitsInStock = 10;

            products.UnitsOnOrder = 10;

            products.ReorderLevel = 10;

            products.Discontinued = true;

            ProductGuncelle(products);
        }


        public static void ProductEkle()
        {
            Console.WriteLine("Yeni Ürün Ekleniyor......");

            SqlConnection baglanti = new SqlConnection();

            baglanti.ConnectionString = "Server=DESKTOP-TUMHS1A\\NA;Database=Northwnd13;Integrated Security=true";

            SqlCommand komut =  new SqlCommand();

            komut.CommandText = "Insert Into Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                "Values (@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice, @unitInStock, @unitsOnOrder, @reorderLevel, @discontinued)";

            komut.Parameters.AddWithValue("@productName", "kahve");
            komut.Parameters.AddWithValue("@supplierId", "2");
            komut.Parameters.AddWithValue("@categoryId", "1");
            komut.Parameters.AddWithValue("@quantityPerUnit", "10 kutu");
            komut.Parameters.AddWithValue("@unitPrice", "8,0000");
            komut.Parameters.AddWithValue("@unitInStock", "30");
            komut.Parameters.AddWithValue("@unitsOnOrder", "20");
            komut.Parameters.AddWithValue("@reorderLevel", "4");
            komut.Parameters.AddWithValue("@discontinued", "False");

            komut.Connection = baglanti;

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            komut.ExecuteNonQuery();

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }


        }
        public static void ProductListele()
        {
            SqlConnection baglanti = new SqlConnection();

            baglanti.ConnectionString = "Server=DESKTOP-TUMHS1A\\NA;Database=Northwnd13;Integrated Security=true";

            SqlCommand komut = new SqlCommand();

            komut.CommandText = "select * from Products";

            komut.Connection = baglanti;

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlDataReader sqlData = komut.ExecuteReader();

            if (sqlData.HasRows)
            {
                while (sqlData.Read())
                {
                    string ProductID = sqlData["ProductID"].ToString();
                    string ProductName = sqlData["ProductName"].ToString();
                    string SupplierID = sqlData["SupplierID"].ToString();
                    string CategoryID = sqlData["CategoryID"].ToString();
                    string QuantityPerUnit = sqlData["QuantityPerUnit"].ToString();
                    string UnitPrice = sqlData["UnitPrice"].ToString();
                    string UnitsInStock = sqlData["UnitsInStock"].ToString();
                    string UnitsOnOrder = sqlData["UnitsOnOrder"].ToString();
                    string ReorderLevel = sqlData["ReorderLevel"].ToString();
                    string Discontinued = sqlData["Discontinued"].ToString();

                    Console.WriteLine($"Id..: {ProductID} - Ürün Adı..: {ProductName} - SupplierID..: {SupplierID} - CategoryID..: {CategoryID} - QuantityPerUnit..: {QuantityPerUnit} - UnitPrice...: {UnitPrice} - UnitsInStock...: {UnitsInStock} - UnitsOnOrder...: {UnitsOnOrder} - ReorderLevel...: {ReorderLevel} - Discontinued...: {Discontinued} ");

                }
            }
            else
            {
                Console.WriteLine("Products tablosunda listelenecek veri yok.");
            }

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }


        }
        public static void ProductGuncelle(Products products)
        {
            Console.WriteLine("Ürün Güncelleniyor......");

            SqlConnection baglanti = new SqlConnection();

            baglanti.ConnectionString = "Server=DESKTOP-TUMHS1A\\NA;Database=Northwnd13;Integrated Security=true";

            SqlCommand komut = new SqlCommand();

            komut.CommandText = "Update Products set ProductName = @productName, SupplierID = @supplierID, CategoryID = @categoryID, QuantityPerUnit = @quantityPerUnit, UnitPrice = @unitPrice, UnitsInStock = @unitsInStock, UnitsOnOrder = @unitsOnOrder, ReorderLevel = @reorderLevel, Discontinued = @discontinued where ProductID = @productID";

            komut.Parameters.AddWithValue("@productID", products.ProductID);
            komut.Parameters.AddWithValue("@productName", products.ProductName);
            komut.Parameters.AddWithValue("@supplierID", products.SupplierID);
            komut.Parameters.AddWithValue("@categoryID", products.CategoryID);
            komut.Parameters.AddWithValue("@quantityPerUnit", products.QuantityPerUnit);
            komut.Parameters.AddWithValue("@unitPrice", products.UnitPrice);
            komut.Parameters.AddWithValue("@unitsInStock", products.UnitsInStock );
            komut.Parameters.AddWithValue("@unitsOnOrder", products.UnitsOnOrder);
            komut.Parameters.AddWithValue("@reorderLevel", products.ReorderLevel);
            komut.Parameters.AddWithValue("@discontinued", products.Discontinued);
            komut.Connection = baglanti;

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            komut.ExecuteNonQuery();

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

            Console.WriteLine("Ürün Güncellendi......");

            ProductListele();


        }
        public static void ProductSil(int productID)
        {
            Console.WriteLine("Ürün Siliniyor......");

            SqlConnection baglanti = new SqlConnection();

            baglanti.ConnectionString = "Server=DESKTOP-TUMHS1A\\NA;Database=Northwnd13;Integrated Security=true";

            SqlCommand komut = new SqlCommand();

            komut.CommandText = "Delete from Products where ProductID = @productId";

            komut.Parameters.AddWithValue("@productId", productID);

            komut.Connection = baglanti;

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            komut.ExecuteNonQuery();

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

            Console.WriteLine("Ürün Silindi......");

            ProductListele();


        }


        public static void CategoryListele()
        {
            SqlConnection baglanti = new SqlConnection();

            baglanti.ConnectionString = "Server=DESKTOP-TUMHS1A\\NA;Database=Northwnd13;Integrated Security=true";

            SqlCommand komut = new SqlCommand();

            komut.CommandText = "select * from Categories";

            komut.Connection = baglanti;

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlDataReader sqlData = komut.ExecuteReader();

            if (sqlData.HasRows)
            {
                while (sqlData.Read())
                {
                    string CategoryID = sqlData["CategoryID"].ToString();
                    string CategoryName = sqlData["CategoryName"].ToString();
                    string Description = sqlData["Description"].ToString();
                    

                    Console.WriteLine($"Id..: {CategoryID} - CategoryName..: {CategoryName} - Description..: {Description}");

                }
            }
            else
            {
                Console.WriteLine("Products tablosunda listelenecek veri yok.");
            }

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }


        }
        public static void CategoryEkle()
        {
            Console.WriteLine("Yeni Kategori Ekleniyor......");

            SqlConnection baglanti = new SqlConnection();

            baglanti.ConnectionString = "Server=DESKTOP-TUMHS1A\\NA;Database=Northwnd13;Integrated Security=true";

            SqlCommand komut = new SqlCommand();

            komut.CommandText = "Insert Into Categories (CategoryName, Description) " +
                "Values (@categoryName, @description)";

            komut.Parameters.AddWithValue("@categoryName", "dondurma");
            komut.Parameters.AddWithValue("@description", "soğuk");           

            komut.Connection = baglanti;

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            komut.ExecuteNonQuery();

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }



        }
        public static void CategoryGuncelle(Categories categories)
        {
            Console.WriteLine("Kategori Güncelleniyor......");

            SqlConnection baglanti = new SqlConnection();

            baglanti.ConnectionString = "Server=DESKTOP-TUMHS1A\\NA;Database=Northwnd13;Integrated Security=true";

            SqlCommand komut = new SqlCommand();

            komut.CommandText = "Update Categories set CategoryName = @categoryName, Description = @description where CategoryID = @categoryID";

            komut.Parameters.AddWithValue("@categoryID", categories.Id);
            komut.Parameters.AddWithValue("@categoryName", categories.CategoryName);
            komut.Parameters.AddWithValue("@description", categories.Description);
           
            komut.Connection = baglanti;

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            komut.ExecuteNonQuery();

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

            Console.WriteLine("Kategori Güncellendi......");

            CategoryListele();


        }
        public static void CategorySil(int categoryID)
        {
            Console.WriteLine("Kategori Siliniyor......");

            SqlConnection baglanti = new SqlConnection();

            baglanti.ConnectionString = "Server=DESKTOP-TUMHS1A\\NA;Database=Northwnd13;Integrated Security=true";

            SqlCommand komut = new SqlCommand();

            komut.CommandText = "Delete from Categories where CategoryID = @categoryId";

            komut.Parameters.AddWithValue("@categoryId", categoryID);

            komut.Connection = baglanti;

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            komut.ExecuteNonQuery();

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

            Console.WriteLine("Kategori Silindi......");

            CategoryListele();

        }
    }
}
