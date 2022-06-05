using CardMaster.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CardMaster.Server.Controllers
{
    public class DataController : Controller
    {
        private CardMasterContext context;

        private int UserId => int.Parse(HttpContext.User.Claims.First().Value);

        public DataController(CardMasterContext context)
        {
            this.context = context;
        }


        [Authorize]
        public string Cards()
        {
            var test = from collection in context.CardCollections
                       join card in context.Cards
                            on collection.Id equals card.Id_Collection
                       where collection.Id_User == UserId
                       select new { collection, card };

            var c = test.ToList();

            return JsonConvert.SerializeObject(test.ToList());
        }

        [Authorize]
        public string Collections()
        {
            var collections = context.CardCollections.Where(c => c.Id_User == UserId)
                .Select(x => new { x.Name, x.IsLearnt });

            return JsonConvert.SerializeObject(collections.ToList());
        }

        [Authorize]
        public void ExamplePost()
        {
            Console.WriteLine("Post request");
        }



        private void CreateSampleData()
        {
            context.Users.Add(new()
            {
                Created = DateTime.UtcNow,
                Email = "test@ema.il",
                Username = "test",
                PasswordHash = Encryption.CalculatePasswordHash("123", "test")
            });

            context.SaveChanges();

            var newCollection = new CardCollection();
            newCollection.Name = "TestCollection";
            newCollection.IsLearnt = false;
            newCollection.Id_User = 1;

            context.CardCollections.Add(newCollection);
            context.SaveChanges();

            var newWord_1 = new Word();
            newWord_1.Text = "Word 1";

            var newWord_2 = new Word();
            newWord_2.Text = "Word 2";

            context.Words.Add(newWord_1);
            context.Words.Add(newWord_2);
            context.SaveChanges();

            var newCard = new Card();
            newCard.IsLearnt = false;
            newCard.Id_Word_1 = 1;
            newCard.Id_Word_2 = 2;
            newCard.Id_Collection = 1;

            context.Cards.Add(newCard);
            context.SaveChanges();
        }
    }
}
