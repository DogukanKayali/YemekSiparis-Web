using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YemekSiparis.Entities;

namespace YemekSiparis.Context
{
    public class Initilizer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category() { Name = "Hamburger", Description = "Hamburgerler" },
                new Category() { Name = "Pizza", Description = "Pizzalar" },
                new Category() { Name = "Tavuk", Description = "Tavuk Ürünleri" },
                new Category() { Name = "İçecek", Description = "İçecekler" }
            };
            context.Categories.AddRange(categories);

            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product(){ Name = "Whopper",Description = "Whopper eti, büyük boy susamlı sandviç ekmeği, salatalık turşusu, ketçap, mayonez, doğranmış marul, domates ve soğandan oluşan bir Burger King klasiği.", Price =160 , Stock =500 , CategoryId = 1,Image="whopper.png"},
                new Product(){ Name = "Steakhouse Burger",Description = "Kocaman Steakhouse eti, özel sosu, cheddar peyniri, domatesi, mayonezi, marulu ve çıtır kaplamalı soğanlarıyla sabrınızı zorlayacak bir lezzet.", Price =175 , Stock =200 , CategoryId = 1,Image="steakhouse.png"},
                new Product(){ Name = "Texas Smokehouse",Description = "Whopper eti, füme eti, cheddar peyniri, barbekü sosu ve çıtır kaplamalı soğanları ile nefis bir seçim.", Price =180 , Stock =0 , CategoryId = 1,Image="texas.png"},
                new Product(){ Name = "Big King XXL",Description = "2 adet Whopper eti, büyük boy susamlı sandviç ekmeği, cheddar peyniri, salatalık turşusu, doğranmış marul, soğan ve Big King sosunun birleştiği göz doyurucu bir seçim.", Price =170 , Stock =500 , CategoryId = 1,Image="big-king.png"},

                new Product(){ Name = "Margarita",Description = "Özel pizza sosu, pizza peyniri, domates.", Price =130 , Stock =300 , CategoryId = 2,Image="margarita.jpg"},
                new Product(){ Name = "Mantarlı Sosisli",Description = "Özel pizza sosu, pizza peyniri, sosis, mantar.", Price =140 , Stock =200 , CategoryId = 2,Image="mantarlı-sosisli.jpg"},
                new Product(){ Name = "Akdeniz",Description = "Özel pizza sosu, pizza peyniri, beyaz peynir, siyah zeytin, küp domates, maydanoz.", Price =145 , Stock =150 , CategoryId = 2,Image="akdeniz.jpg"},
                new Product(){ Name = "Special",Description = "Özel pizza sosu, pizza peyniri, sucuk, salam, sosis, mantar, mısır, siyah zeytin.", Price =150 , Stock =100 , CategoryId = 2,Image="special.jpg"},

                new Product(){ Name = "Acılı Kanat",Description = "", Price =55 , Stock =2000 , CategoryId = 3,Image="kanat.png"},
                new Product(){ Name = "Tenders",Description = "", Price =60 , Stock =5000 , CategoryId = 3,Image="tenders.png"},
                new Product(){ Name = "Nugget",Description = "", Price =45 , Stock =50 , CategoryId = 3,Image="nuggets.png"},
                new Product(){ Name = "Dip'n Chicken",Description = "", Price =48 , Stock =300 , CategoryId = 3,Image="dipn-chicken.png"},

                new Product(){ Name = "Coca Cola Kutu",Description = "", Price =30 , Stock =1000 , CategoryId = 4,Image="cola-kutu.jpg"},
                new Product(){ Name = "Sprite Kutu",Description = "", Price =30 , Stock =200 , CategoryId = 4,Image="sprite-kutu.jpg"},
                new Product(){ Name = "Coca Cola Şekersiz 1 LT",Description = "", Price =35 , Stock =300 , CategoryId = 4,Image="cola-zero.jpg"},
                new Product(){ Name = "Sprite 1 LT",Description = "", Price =35 , Stock =10 , CategoryId = 4,Image="sprite.jpg"},
            };

            

            foreach (Product item in products)
            {
                context.Products.Add(item);
            }
            context.SaveChanges();

            var extras = new List<ExtraMaterial>()
            {
                new ExtraMaterial(){ Name="Domates" },
                new ExtraMaterial(){ Name="Soğan" },
                new ExtraMaterial(){ Name="Sucuk" },
                new ExtraMaterial(){ Name="Mantar" },
                new ExtraMaterial(){ Name="Salam" },
                new ExtraMaterial(){ Name="Sosis" },
                new ExtraMaterial(){ Name="Zeytin" },


            };


            context.ExtraMaterials.AddRange(extras);
            context.SaveChanges();
        }
    }
}