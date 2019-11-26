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
                    Content = "Sýnýflandýrma sürekli deðiþen ve geliþen bir bilim dalýdýr. Önceden doðru kabul edilen bilgiler bilimin dinamik yapýsýyla yerini yeni bilgilere býrakmýþtýr. Geçmiþte yapýlan sýnýflandýrmalarda bakteriler hücre duvarýna sahip olmalarý, mantarlar ise bir yere baðlý yaþamalarý nedeniyle bitkiler alemine dahil edilmiþlerdi. Paramesyum hareket ettiði için terliksi hayvan olarak adlandýrýlmýþtý. Öglena ise kloroplast taþýdýðýndan bitki, kamçýsýyla hareket ettiði için hayvan olarak düþünülmüþtü. Canlýlarla ilgili yeni bilgiler ve kanýtlar ortaya çýktýkça bakteri ve mantarlarýn bitki olmadýðý, her ikisinin de ayrý alemlerde yer aldýðý; paramesyumun da hayvan olmadýðý anlaþýlmýþtýr.",
                    CreatedTime = DateTime.Now.AddMinutes(10)
                });

                context.Notes.Add(new Note
                {
                    AuthorId = user.Id,
                    Title = "Sample Note 1",
                    Content = "Canlýlarýn yaygýn ve önemli bir kýsmýný oluþturmasýna raðmen mikroorganizmalarýn besin üretiminde kullanýlanlarý ve hastalýk yapanlarý dýþýnda büyük çoðunluðu tanýmlanamamýþtýr.Bakteriler, ilk defa Antony Van Leeuwenhoek tarafýndan basit ýþýk mikroskobunda su damlacýðý içinde gözlenmiþtir.",
                    CreatedTime = DateTime.Now.AddMinutes(10)
                });

               
            }
        }
    }
}
