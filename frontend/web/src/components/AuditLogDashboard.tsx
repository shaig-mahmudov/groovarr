import React, { useEffect, useState } from 'react';
import api from '../api';

interface AuditLog {
  id: string;
  action: string;
  userId?: string;
  playlistId?: string;
  shareLinkToken?: string;
  timestamp: string;
  ipAddress?: string;
}

export default function AuditLogDashboard() {
  const [logs, setLogs] = useState<AuditLog[]>([]);

  useEffect(() => {
    const fetchLogs = async () => {
      const res = await api.get('/audit');
      setLogs(res.data);
    };
    fetchLogs();
  }, []);

  return (
    <div>
      <h3>Audit Logs</h3>
      <table border={1} cellPadding={6}>
        <thead>
          <tr>
            <th>Action</th>
            <th>User</th>
            <th>Playlist</th>
            <th>Token</th>
            <th>Timestamp</th>
            <th>IP</th>
          </tr>
        </thead>
        <tbody>
          {logs.map(log => (
            <tr key={log.id}>
              <td>{log.action}</td>
              <td>{log.userId ?? 'Anonymous'}</td>
              <td>{log.playlistId}</td>
              <td>{log.shareLinkToken}</td>
              <td>{new Date(log.timestamp).toLocaleString()}</td>
              <td>{log.ipAddress ?? '-'}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
