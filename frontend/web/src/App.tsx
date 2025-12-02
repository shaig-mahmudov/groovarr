import React, { useState } from 'react';
import PlaylistForm from './components/PlaylistForm';
import TrackSearch from './components/TrackSearch';
import ShareLinkManager from './components/ShareLinkManager';
import EmbedCodeGenerator from './components/EmbedCodeGenerator';
import AuditLogDashboard from './components/AuditLogDashboard';
import PlaylistSelector from './components/PlaylistSelector';
import PlaylistList from './components/PlaylistList';

function App() {
  const [activeTab, setActiveTab] = useState<'playlists' | 'tracks' | 'share' | 'embed' | 'audit'>('playlists');
  const [selectedPlaylist, setSelectedPlaylist] = useState<string>('demo-playlist-id');

  return (
    <div style={{ display: 'flex', height: '100vh' }}>
      {/* Sidebar Navigation */}
      <nav style={{ width: '200px', background: '#222', color: '#fff', padding: '1rem' }}>
        <h2>Groovarr</h2>
        <ul style={{ listStyle: 'none', padding: 0 }}>
          <li><button onClick={() => setActiveTab('playlists')}>Playlists</button></li>
          <li><button onClick={() => setActiveTab('tracks')}>Tracks</button></li>
          <li><button onClick={() => setActiveTab('share')}>Share</button></li>
          <li><button onClick={() => setActiveTab('embed')}>Embed</button></li>
          <li><button onClick={() => setActiveTab('audit')}>Audit Logs</button></li>
        </ul>
      </nav>

      {/* Main Content */}
      <main style={{ flex: 1, padding: '2rem' }}>
        <PlaylistSelector selectedPlaylist={selectedPlaylist} onSelect={setSelectedPlaylist} />

        {activeTab === 'playlists' && (
          <>
            <PlaylistForm />
            <PlaylistList onSelect={setSelectedPlaylist} />
          </>
        )}
        {activeTab === 'tracks' && <TrackSearch playlistId={selectedPlaylist} />}
        {activeTab === 'share' && <ShareLinkManager playlistId={selectedPlaylist} />}
        {activeTab === 'embed' && (
          <>
            <EmbedCodeGenerator playlistId={selectedPlaylist} />
            <EmbedViewer playlistId={selectedPlaylist} />
          </>
        )}
        {activeTab === 'audit' && <AuditLogDashboard />}
      </main>
    </div>
  );
}

export default App;
