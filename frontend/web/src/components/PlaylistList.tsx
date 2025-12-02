import React from 'react';
import api from '../api';
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';

interface Playlist {
  id: string;
  name: string;
  description?: string;
}

interface Props {
  onSelect: (id: string) => void;
}

export default function PlaylistList({ onSelect }: Props) {
  const queryClient = useQueryClient();

  const { data: playlists = [], isLoading } = useQuery({
    queryKey: ['playlists'],
    queryFn: async () => {
      const res = await api.get('/playlists');
      return res.data;
    },
  });

  const deleteMutation = useMutation({
    mutationFn: async (id: string) => {
      await api.delete(`/playlists/${id}`);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['playlists'] });
    },
  });

  if (isLoading) return <p>Loading playlists...</p>;

  return (
    <div>
      <h3>All Playlists</h3>
      <ul>
        {playlists.map((p: Playlist) => (
          <li key={p.id} style={{ marginBottom: '0.5rem' }}>
            <strong>{p.name}</strong> — {p.description}
            <div>
              <button onClick={() => onSelect(p.id)}>Select</button>
              <button onClick={() => deleteMutation.mutate(p.id)}>Delete</button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
}
