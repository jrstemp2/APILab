using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Poker.Models;                                                                                                                                        

namespace Poker.Controllers
{
    public class CardsController : Controller
    {
        public async Task<IActionResult> Index() //shuffle the deck and land on index
        {
            var client = new HttpClient();
            
            client.BaseAddress = new Uri("https://deckofcardsapi.com");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");

            var response = await client.GetAsync("api/deck/new/shuffle/?deck_count=1");

            
            var deck = await response.Content.ReadAsAsync<DeckData>();
            //var deck_id = deck.Data.Deck_Id;
                        
            return View(deck);
        }

        public async Task<IActionResult> Draw(DeckData deck)
        {
            string deckId = deck.Id;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");

            
            var response = await client.GetAsync($"api/deck/{deckId}/draw/?count=5");


            var hand = await response.Content.ReadAsAsync<Deck>();
            //var deck_id = deck.Data.Deck_Id;

            return View(hand);
        }
    }
}