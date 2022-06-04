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

        public DataController(CardMasterContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return Json(new {name="Ivan", age=12});
        }

        [Authorize]
        public string Cards()
        {
            var cards = context.Cards.Where(x => x.Id_Collection == 1);
            return JsonConvert.SerializeObject(cards);
        }

        [Authorize]
        public string Collections()
        {
            return "";
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
