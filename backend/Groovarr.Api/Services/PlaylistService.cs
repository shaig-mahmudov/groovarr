using Groovarr.Api.Data;
using Groovarr.Api.Models;

namespace Groovarr.Api.Services
{
    public class PlaylistService
    {
        private readonly GroovarrDbContext _db;
        public PlaylistService(GroovarrDbContext db) => _db = db;

        public IEnumerable<Playlist> GetAll() => _db.Playlists.ToList();
        public Playlist? Get(string id) => _db.Playlists.Find(id);

        public void Create(Playlist playlist)
        {
            _db.Playlists.Add(playlist);
            _db.SaveChanges();
        }

        public bool Delete(string id)
        {
            var playlist = _db.Playlists.Find(id);
            if (playlist == null) return false;
            _db.Playlists.Remove(playlist);
            _db.SaveChanges();
            return true;
        }

        public bool AddTrack(int playlistId, Track track)
        {
            var playlist = _db.Playlists.Find(playlistId);
            if (playlist == null) return false;
            track.PlaylistId = playlistId;
            _db.Tracks.Add(track);
            _db.SaveChanges();
            return true;
        }
    }
}
