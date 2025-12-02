import React from 'react';
import api from '../api';
import { useQuery } from '@tanstack/react-query';

interface Playlist {
  id: string;
  name: string;
}

interface Props {
  selectedPlaylist: string;
  onSelect: (id: string) => void;
}

export default function PlaylistSelector({ selectedPlaylist, onSelect }: Props) {
  const { data: playlists = [], isLoading } = useQuery({
    queryKey: ['playlists'],
    queryFn: async () => {
      const res = await api.get('/playlists');
      return res.data;
    },
  });

  if (isLoading) return <p>Loading playlists...</p>;

  return (
    <div>
      <label htmlFor="playlist-select">Select Playlist: </label>
      <select
        id="playlist-select"
        value={selectedPlaylist}
        onChange={e => onSelect(e.target.value)}
      >
        {playlists.map((p: Playlist) => (
          <option key={p.id} value={p.id}>
            {p.name}
          </option>
        ))}
      </select>
    </div>
  );
}
