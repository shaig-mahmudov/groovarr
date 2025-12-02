import React, { useState } from 'react';
import api from '../api';
import { useMutation, useQueryClient } from '@tanstack/react-query';

export default function PlaylistForm() {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const queryClient = useQueryClient();

  const createMutation = useMutation({
    mutationFn: async () => {
      const res = await api.post('/playlists', { name, description });
      return res.data;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['playlists'] });
      setName('');
      setDescription('');
    },
  });

  return (
    <div>
      <h3>Create Playlist</h3>
      <input
        placeholder="Name"
        value={name}
        onChange={e => setName(e.target.value)}
      />
      <input
        placeholder="Description"
        value={description}
        onChange={e => setDescription(e.target.value)}
      />
      <button onClick={() => createMutation.mutate()}>Create</button>
    </div>
  );
}
