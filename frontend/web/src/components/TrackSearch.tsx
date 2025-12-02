import React, { useState } from 'react';
import api from '../api';

interface Props {
  playlistId: string;
}

export default function TrackSearch({ playlistId }: Props) {
  const [title, setTitle] = useState('');
  const [artist, setArtist] = useState('');

  const addTrack = async () => {
    const res = await api.post(`/tracks/${playlistId}`, { title, artist });
    alert(`Added track: ${res.data.title}`);
    setTitle('');
    setArtist('');
  };

  return (
    <div>
      <h3>Add Track</h3>
      <input
        placeholder="Title"
        value={title}
        onChange={e => setTitle(e.target.value)}
      />
      <input
        placeholder="Artist"
        value={artist}
        onChange={e => setArtist(e.target.value)}
      />
      <button onClick={addTrack}>Add</button>
    </div>
  );
}
