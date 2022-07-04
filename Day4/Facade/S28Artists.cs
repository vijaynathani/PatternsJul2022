using System;
using System.Collections.Generic;

namespace LearnCS.ooad
{
    internal class S28Artists
    {
        private readonly List<Artist> _artists;

        public S28Artists(List<Artist> artists)
        {
            _artists = artists;
        }

        public Artist GetArtist(int index)
        {
            if ((index < 0) || (index >= _artists.Count))
                throw new ArgumentException(index + " doesn't correspond to an Artist");
            return _artists[index];
        }

        public String GetArtistName(int index)
        {
             return GetArtist(index).GetName(); //Throw exception if invalid index.
        }
    }
}