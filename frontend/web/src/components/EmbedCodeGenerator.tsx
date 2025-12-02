import React from 'react';

interface Props {
  playlistId: string;
}

export default function EmbedCodeGenerator({ playlistId }: Props) {
  const embedCode = `<iframe src="http://localhost:5000/api/embed/${playlistId}" width="400" height="300"></iframe>`;

  const copyToClipboard = async () => {
    try {
      await navigator.clipboard.writeText(embedCode);
      alert('Embed code copied to clipboard!');
    } catch (err) {
      alert('Failed to copy embed code.');
    }
  };

  return (
    <div>
      <h3>Embed Code</h3>
      <textarea readOnly value={embedCode} rows={3} cols={60} />
      <br />
      <button onClick={copyToClipboard}>Copy to Clipboard</button>
    </div>
  );
}
