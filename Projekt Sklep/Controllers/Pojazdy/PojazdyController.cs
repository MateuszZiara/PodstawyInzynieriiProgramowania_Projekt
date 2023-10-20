﻿using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models.Pojazdy;
using Projekt_Sklep.Models;
using Projekt_Sklep.Persistence.Pojazdy;
using System.Text.RegularExpressions;
using Projekt_Sklep.Models.Placowki;
using Projekt_Sklep.Persistence.Placowki;

namespace Projekt_Sklep.Controllers.Pojazdy
{
    [Route("api/[controller]")]
    [ApiController]
    public class PojazdyController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Models.Pojazdy.Pojazdy>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntities = session.Query<Models.Pojazdy.Pojazdy>().ToList();
                return Ok(klientEntities);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Pojazdy.Pojazdy> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntity = session.Get<Models.Pojazdy.Pojazdy>(id);

                if (klientEntity == null)
                {
                    return NotFound();
                }

                return Ok(klientEntity);
            }

        }
        [HttpPost]
        public ActionResult<Models.Pojazdy.Pojazdy> CreateKlientEntity([FromBody] Models.Pojazdy.Pojazdy pojazdy)
        {
            if (pojazdy == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        IPojazdyService pojazdyServices = new PojazdyService();
                        pojazdyServices.VINCheck(pojazdy.VIN);
                        session.Save(pojazdy);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = pojazdy.Id }, pojazdy);
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
        public ActionResult DeletePojazdy(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var pojazdy = session.Get<Models.Pojazdy.Pojazdy>(id);

                        if (pojazdy == null)
                        {
                            return NotFound();
                        }


                        session.Delete(pojazdy);


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
