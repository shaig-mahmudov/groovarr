import React, { useState } from 'react';
import ShareLinkManager from '../components/ShareLinkManager';
import EmbedCodeGenerator from '../components/EmbedCodeGenerator';
import AuditLogDashboard from '../components/AuditLogDashboard';

export default function PlaylistsPage() {
  const [selectedPlaylist, setSelectedPlaylist] = useState<string | null>("demo-playlist-id");

  return (
    <div>
      <h2>Playlists</h2>
      {selectedPlaylist && (
        <>
          <ShareLinkManager playlistId={selectedPlaylist} />
          <EmbedCodeGenerator playlistId={selectedPlaylist} />
          <AuditLogDashboard />
        </>
      )}
    </div>
  );
}
