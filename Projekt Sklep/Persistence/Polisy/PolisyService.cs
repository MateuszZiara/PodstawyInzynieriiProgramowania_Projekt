﻿using Projekt_Sklep.Models;

namespace Projekt_Sklep.Persistence.Polisy
{
    public class PolisyService : IPolisyService
    {
        readonly PolisyRepository polisyRepository = new PolisyRepository();

        public bool czyAktywna(Guid Id)
        {
            return polisyRepository.czyAktywna(Id);
        }

        
    }
}
