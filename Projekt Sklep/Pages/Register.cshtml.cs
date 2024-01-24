using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Sklep.Controllers.Adres;
using Projekt_Sklep.Models.Adres;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Persistence.Klient;
using System.Collections.Generic;

namespace Projekt_Sklep.Pages
{
    public class RegisterModel : PageModel
    {
        // Dodaj w�a�ciwo��, kt�ra b�dzie przechowywa� dane adres�w
        public List<Adres> Addresses { get; set; }

        public void OnGet()
        {
            // Wywo�aj metod� do pobrania danych adres�w z bazy danych
            LoadAddresses();
        }

        public void OnPost()
        {
            // Tu mo�esz obs�u�y� logik� po naci�ni�ciu przycisku, je�li jest taka potrzeba
        }

        // Dodaj metod� do pobierania danych adres�w z bazy danych
        private void LoadAddresses()
        {
            AdresController addressEntityController = new AdresController();
            var result = addressEntityController.GetAll();

            // Sprawd�, czy pobranie danych by�o udane
            if (result.Result is OkObjectResult okResult)
            {
                Addresses = okResult.Value as List<Adres>;
            }
        }

        public void FormChange(bool state)
        {
            // Dodatkowa metoda, je�li jest potrzebna
        }
    }
}
