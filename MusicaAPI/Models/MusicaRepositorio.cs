using MusicaAPI.Classes;
using MusicaAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MusicaAPI.Models
{
    public class MusicaRepositorio : IMusicaRepositorio
    {
        private MeuContext db = new MeuContext();
        private List<Musica> Musicas;

        public void Salvar(int TrackId, bool Favorita)
        {
            GetMusicas(TrackId.ToString());

            var musica = Musicas.Find(m => m.TrackId == TrackId);
            musica.Favorita = Favorita;

            try
            {
                if (musica.Id == 0)
                {
                    db.Musicas.Add(musica);
                    db.SaveChanges();
                }
                else
                {
                    var musicaSalva = db.Musicas.SingleOrDefault(m => m.Id == musica.Id);

                    db.Entry(musicaSalva).CurrentValues.SetValues(musica);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        IEnumerable<Musica> IMusicaRepositorio.Listar(string Termo)
        {
            GetMusicas(Termo);
            return Musicas;
        }

        private void GetMusicas(string Termo)
        {
            var url = string.Format("https://itunes.apple.com/search?media=music&term={0}", TermoTratado(Termo));
            var musicas = ConversorJson.Baixar<MusicaCollection>(url);

            Musicas = musicas.Results;
            ComparaListaMusica();
        }

        private void ComparaListaMusica()
        {
            var MusicasSalvas = db.Musicas.AsEnumerable();

            foreach (var musicaSalva in MusicasSalvas)
            {
                var musica = Musicas.Find(m => m.TrackId == musicaSalva.TrackId);

                if (musica != null)
                {
                    musica.Favorita = musicaSalva.Favorita;
                    musica.Id = musicaSalva.Id;
                }
            }
        }

        private string TermoTratado(string Termo)
        {
            if (!string.IsNullOrEmpty(Termo))
            {
                string[] TermoSeparado = Termo.Split(' ');
                string TermoTratado = string.Empty;

                foreach (var item in TermoSeparado)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                        TermoTratado = string.Concat(TermoTratado, "+", item);
                }

                return TermoTratado.Substring(1);
            }
            return string.Empty;
        }
    }
}