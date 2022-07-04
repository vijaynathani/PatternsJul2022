using System;
using System.Collections.Generic;

namespace LearnCS.ooad
{
    internal class Q28Artists
    {
        private readonly List<Artist> _artists;

        public Q28Artists(List<Artist> artists)
        {
            _artists = artists;
        }

        public Artist GetArtist(int index)
        {
            if ((index < 0) || (index >= _artists.Count)) return null;
            return _artists[index];
        }

        public String GetArtistName(int index)
        {
            try
            {
                return GetArtist(index).GetName();
            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }

        //Improve the design of this class
    }


    internal class Artist
    {
        private readonly String _name;

        public Artist(String name)
        {
            _name = name;
        }

        public String GetName()
        {
            return _name;
        }
    }
}