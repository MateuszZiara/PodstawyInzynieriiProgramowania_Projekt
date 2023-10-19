﻿using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models;
using Projekt_Sklep.Persistence.Klient;

namespace Projekt_Sklep.Controllers.Placowki
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacowkiController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Models.Placowki.Placowki>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntities = session.Query<Models.Placowki.Placowki>().ToList();
                return Ok(klientEntities);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Placowki.Placowki> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntity = session.Get<Models.Placowki.Placowki>(id);

                if (klientEntity == null)
                {
                    return NotFound();
                }

                return Ok(klientEntity);
            }

        }
        [HttpPost]
        public ActionResult<Models.Placowki.Placowki> CreateKlientEntity([FromBody] Models.Placowki.Placowki placowki)
        {
            if (placowki == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(placowki);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = placowki.Id }, placowki);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                    }
                }
            }

        }
        [HttpDelete("{id}")]
        public ActionResult DeletePlacowki(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var placowki = session.Get<Models.Placowki.Placowki>(id);

                        if (placowki == null)
                        {
                            return NotFound();
                        }


                        session.Delete(placowki);


                        transaction.Commit();

                        return NoContent();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                    }
                }
            }
        }
    }

}