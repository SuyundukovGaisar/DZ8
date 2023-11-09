using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab_9
{
    internal class Song
    {
        string name;
        string author;
        Song prev;
        public Song()
        {
            name = "";
            author = "";
            prev = null;
        }

        public Song(string Name, string Author)
        {
            Name = name;
            Author = author;
            prev = null;
        }
        public Song(string Name, string Author, Song previousSong)
        {
            Name = name;
            Author = author;
            prev = previousSong;
        }
        public void SetName(string songName)
        {
            name = songName;
        }

        public void SetAuthor(string songAuthor)
        {
            author = songAuthor;
        }

        public void SetPrev(Song previousSong)
        {
            prev = previousSong;
        }

        public string Title()
        {
            return name + " - " + author;
        }

        public override bool Equals(object d)
        {
            if (d is Song song)
            {
                return name == song.name && author == song.author;
            }

            return false;
        }
    }
}
