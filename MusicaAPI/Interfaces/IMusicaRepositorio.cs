using MusicaAPI.Models;
using System.Collections.Generic;

namespace MusicaAPI.Interfaces
{
    interface IMusicaRepositorio
    {
        IEnumerable<Musica> Listar(string Termo);
        void Salvar(int TrackId, bool Favorita);
    }
}
