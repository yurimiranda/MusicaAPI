using System.Web.Http;
using MusicaAPI.Models;
using MusicaAPI.Interfaces;
using System.Collections.Generic;

namespace MusicaAPI.Controllers
{
    public class MusicasController : ApiController
    {
        private readonly IMusicaRepositorio musicaRepositorio;

        public MusicasController()
        {
            musicaRepositorio = new MusicaRepositorio();
        }

        [HttpGet]
        public IEnumerable<Musica> Listar(string Termo)
        {
            return musicaRepositorio.Listar(Termo);
        }

        [HttpPut]
        public void Salvar(int TrackId, bool Favorita)
        {
            musicaRepositorio.Salvar(TrackId, Favorita);
        }
    }
}
