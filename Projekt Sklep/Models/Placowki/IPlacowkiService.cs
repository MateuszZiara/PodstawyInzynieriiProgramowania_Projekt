﻿namespace Projekt_Sklep.Models.Placowki
{
    public interface IPlacowkiService
    {
        void NIPCheck(string NIP);
        public bool edit(Guid Id, int NrPlacowki, string NIP, Guid Adres);
    }
}
