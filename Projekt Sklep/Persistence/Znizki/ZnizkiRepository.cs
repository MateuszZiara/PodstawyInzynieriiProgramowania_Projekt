﻿using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Znizki;

namespace Projekt_Sklep.Persistence.Znizki
{
    public class ZnizkiRepository : IZnizkiRepository
    {
        public bool edit(Guid Id, string Dorosly_dziecko, bool Wiek)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var query = session.Query<Models.Znizki.Znizki>().Where(x => x.Id == Id).ToList();
                    if (query.Count == 0)
                        return false;
                    foreach (var entity in query)
                    {

                        if (Dorosly_dziecko != null)
                            entity.Dorosly_dziecko = Dorosly_dziecko;

                        session.SaveOrUpdate(entity);
                        transaction.Commit();

                    }
                }
            }

            return true;
        }

    }
}
