using Newtonsoft.Json;
using System.Net;

namespace DeckOfCardsAPI.Models
{
    public class CardsDAL
    {
        public Deck GetNewCards()
        {
            string url = $"https://deckofcardsapi.com/api/deck/new/shuffle";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            Deck result = JsonConvert.DeserializeObject<Deck>(JSON);
            return result;
        }

        public Cards Get5Cards(string deckID)
        {
            //string deckId = "rhfw7fh63p9a";
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/draw/?count=5";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            Cards result = JsonConvert.DeserializeObject<Cards>(JSON);
            return result;
        }

    }
}
