import axios from "axios";

// Axios instance configured for Groovarr backend
const api = axios.create({
  baseURL: "http://localhost:5000/api", // adjust for production
  headers: {
    "Content-Type": "application/json",
  },
});

// Example: Fetch all playlists
export async function getPlaylists() {
  const response = await api.get("/playlists");
  return response.data;
}

// Example: Create a new playlist
export async function createPlaylist(name: string, description?: string) {
  const response = await api.post("/playlists", { name, description });
  return response.data;
}

// Example: Add a track to a playlist
export async function addTrackToPlaylist(
  playlistId: number,
  title: string,
  artist?: string,
  album?: string,
  plexId?: string
) {
  const response = await api.post(`/playlists/${playlistId}/tracks`, {
    title,
    artist,
    album,
    plexId,
  });
  return response.data;
}

// Example: Create a share link
export async function createShareLink(playlistId: number, expiresAt?: string) {
  const response = await api.post("/share", { playlistId, expiresAt });
  return response.data;
}

// Example: Retrieve a shared playlist by code
export async function getSharedPlaylist(code: string) {
  const response = await api.get(`/share/${code}`);
  return response.data;
}

export default api;
