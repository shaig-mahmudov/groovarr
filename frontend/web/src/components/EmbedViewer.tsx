import React, { useEffect, useState } from 'react';
import api from '../api';

interface Track {
  title: string;
  artist: string;
  album?: string;
  year?: number;
}

interface Playlist {
  id: string;
  name: string;
  description?: string;
  tracks: Track[];
}

interface Props {
  playlistId: string;
}

export default function EmbedViewer({ playlistId }: Props) {
  const [playlist, setPlaylist] = useState<Playlist | null>(null);

  useEffect(() => {
    const fetchEmbed = async () => {
      try {
        const res = await api.get(`/embed/${playlistId}`);
        setPlaylist(res.data);
      } catch {
        setPlaylist(null);
      }
    };
    fetchEmbed();
  }, [playlistId]);

  if (!playlist) return <p>Loading embed...</p>;

  return (
    <div style={{ border: '1px solid #ccc', padding: '1rem', borderRadius: '8px' }}>
      <h3>{playlist.name}</h3>
      {playlist.description && <p>{playlist.description}</p>}
      <ul>
        {playlist.tracks.map((t, i) => (
          <li key={i}>
            {t.title} — {t.artist}
            {t.album && ` (${t.album})`}
            {t.year && ` [${t.year}]`}
          </li>
        ))}
      </ul>
    </div>
  );
}
