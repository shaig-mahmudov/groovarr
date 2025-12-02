# Groovarr API Reference

Groovarr provides a RESTful API for managing playlists, tracks, and sharing links.  
All endpoints are prefixed with `/api`.

---

## 🔑 Authentication

- **AuthDbContext** manages Plex tokens and share links.
- Endpoints requiring authentication expect a valid Plex token in the `Authorization` header:
  ```
  Authorization: Bearer <plex-token>
  ```

---

## 🎶 Playlists

### GET `/api/playlists`
Retrieve all playlists.

**Response:**
```json
[
  {
    "id": 1,
    "name": "My Mix",
    "description": "Favorite tracks"
  }
]
```

---

### GET `/api/playlists/{id}`
Retrieve a single playlist by ID.

---

### POST `/api/playlists`
Create a new playlist.

**Request:**
```json
{
  "name": "Workout",
  "description": "High energy tracks"
}
```

---

### PUT `/api/playlists/{id}`
Update an existing playlist.

---

### DELETE `/api/playlists/{id}`
Delete a playlist and its associated tracks.

---

## 🎵 Tracks

### GET `/api/playlists/{id}/tracks`
Retrieve all tracks in a playlist.

---

### POST `/api/playlists/{id}/tracks`
Add a track to a playlist.

**Request:**
```json
{
  "title": "Song Title",
  "artist": "Artist Name",
  "album": "Album Name",
  "plexId": "12345"
}
```

---

### DELETE `/api/playlists/{id}/tracks/{trackId}`
Remove a track from a playlist.

---

## 🔗 Share Links

### POST `/api/share`
Create a share link for a playlist.

**Request:**
```json
{
  "playlistId": 1,
  "expiresAt": "2025-12-31T23:59:59Z"
}
```

**Response:**
```json
{
  "code": "abc123",
  "url": "https://groovarr.app/share/abc123"
}
```

---

### GET `/api/share/{code}`
Retrieve a shared playlist by code.

---

## 🔒 Plex Tokens

### POST `/api/auth/token`
Store a Plex token.

**Request:**
```json
{
  "userId": "user@example.com",
  "token": "plex-token-value"
}
```

---

### GET `/api/auth/token/{userId}`
Retrieve a Plex token for a user.

---

## 📂 Error Handling

Errors follow a consistent JSON format:

```json
{
  "error": "NotFound",
  "message": "Playlist not found"
}
```
