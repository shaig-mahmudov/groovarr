import React, { useState } from 'react';
import api from '../api';

interface Props {
  playlistId: string;
}

export default function ShareLinkManager({ playlistId }: Props) {
  const [link, setLink] = useState<string | null>(null);

  const createShareLink = async () => {
    const res = await api.post(`/share/${playlistId}`);
    setLink(res.data.token);
  };

  return (
    <div>
      <h3>Share Links</h3>
      <button onClick={createShareLink}>Generate Share Link</button>
      {link && (
        <p>
          Share URL: <code>{`http://localhost:5000/api/share/${link}`}</code>
        </p>
      )}
    </div>
  );
}
