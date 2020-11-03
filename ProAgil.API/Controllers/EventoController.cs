using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public readonly DataContext _context;

        public EventoController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = _context.Eventos.ToList();
                return Ok(results);

            }
            catch (System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");
            }
        }

            [HttpGet("{id}")]
            public ActionResult<Evento> Get(int id)
            {
                return new Evento[]{
              new Evento(){
                  EventoId = 1,
                  Local = "Serra",
                  QtdPessoas = 25,
                  Tema = "Angular e .net core",
                  Lote = "1º",
                  DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
              },
              new Evento(){
                  EventoId = 2,
                  Local = "Vila Velha",
                  QtdPessoas = 100,
                  Tema = "Angular e .net core",
                  Lote = "2º",
                  DataEvento = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy")
              }
            }.FirstOrDefault(x => x.EventoId == id);
            }
        }

        public interface IActionResult<T>
        {
        }
    }
