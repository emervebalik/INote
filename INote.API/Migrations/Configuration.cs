namespace INote.API.Migrations
{
    using INote.API.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<INote.API.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(INote.API.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser
                {
                    UserName = "emervebalik@gmail.com",
                    Email = "emervebalik@gmail.com",
                    EmailConfirmed = true
                };

                userManager.Create(user, "Ankara1.");
                user.Notes = new HashSet<Note>();

                context.Notes.Add(new Note
                {
                    AuthorId= user.Id,
                    Title = "Sample Note 1",
                    Content = "S�n�fland�rma s�rekli de�i�en ve geli�en bir bilim dal�d�r. �nceden do�ru kabul edilen bilgiler bilimin dinamik yap�s�yla yerini yeni bilgilere b�rakm��t�r. Ge�mi�te yap�lan s�n�fland�rmalarda bakteriler h�cre duvar�na sahip olmalar�, mantarlar ise bir yere ba�l� ya�amalar� nedeniyle bitkiler alemine dahil edilmi�lerdi. Paramesyum hareket etti�i i�in terliksi hayvan olarak adland�r�lm��t�. �glena ise kloroplast ta��d���ndan bitki, kam��s�yla hareket etti�i i�in hayvan olarak d���n�lm��t�. Canl�larla ilgili yeni bilgiler ve kan�tlar ortaya ��kt�k�a bakteri ve mantarlar�n bitki olmad���, her ikisinin de ayr� alemlerde yer ald���; paramesyumun da hayvan olmad��� anla��lm��t�r.",
                    CreatedTime = DateTime.Now.AddMinutes(10)
                });

                context.Notes.Add(new Note
                {
                    AuthorId = user.Id,
                    Title = "Sample Note 1",
                    Content = "Canl�lar�n yayg�n ve �nemli bir k�sm�n� olu�turmas�na ra�men mikroorganizmalar�n besin �retiminde kullan�lanlar� ve hastal�k yapanlar� d���nda b�y�k �o�unlu�u tan�mlanamam��t�r.Bakteriler, ilk defa Antony Van Leeuwenhoek taraf�ndan basit ���k mikroskobunda su damlac��� i�inde g�zlenmi�tir.",
                    CreatedTime = DateTime.Now.AddMinutes(10)
                });

               
            }
        }
    }
}
