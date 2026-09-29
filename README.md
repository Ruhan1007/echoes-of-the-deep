# Echoes of the Deep — Unity Quest 3 Prototype

**Dive into a sunken city where sound is your only guide.**

This starter project implements the core gameplay architecture described in the pitch:

- Five-chamber 10-minute narrative
- Seated / no locomotion design
- Hand-first interaction hooks
- Spatial audio source management
- Cup-to-ear listening mechanic
- Pinch-pull reveal mechanic
- Two-hand harmonic lock
- Palm-push activation
- Echo Stone capture/playback
- Memory Pool interaction
- Sound-reactive architecture
- Final Echo Chamber conductor sequence

## Target

Unity 2022.3 LTS or newer compatible LTS version.

Meta Quest 3 / Meta XR SDK All-in-One v207 or the current compatible Meta XR SDK package.

> The scripts intentionally use an adapter-style approach around hand tracking. This keeps the core game logic independent of a particular Meta XR component API. Wire `HandCupDetector`, `PinchPull`, `TwoHandRotate`, and `PalmPulse` to the hand-joint data provided by the Meta XR SDK version installed in your project.

## Quick setup

1. Create/open a Unity project.
2. Copy the `Assets` folder from this package into the project.
3. Install Meta XR SDK All-in-One through Unity's Package Manager / Meta tooling.
4. Add an XR Origin / Meta camera rig.
5. Add `ChamberManager` to a persistent GameObject.
6. Create five chamber root objects and assign them to `ChamberManager`.
7. Add spatial audio sources to the voices/artifacts and register them with `SpatialAudioManager`.
8. Connect hand-joint positions to the gesture adapters.
9. Build for Android/Quest.

## Prototype flow

**Chamber 1 — The Descent**
- Darkness
- Left-side guiding voice
- Arrival trigger

**Chamber 2 — Gallery of Whispers**
- Three spatial voices
- Cup hand toward ear to isolate a source
- Story fragments unlock

**Chamber 3 — Harmonic Lock**
- Three rings
- Match the target chord
- Palm pulse opens the door

**Chamber 4 — Memory Pool**
- Reach toward the pool
- Ripple strength changes the memory perspective
- Memory fragments are revealed

**Chamber 5 — Echo Chamber**
- Collected echoes return
- Hands act as a conductor
- Final sequence resolves the story

## Important

This is a gameplay prototype, not a finished commercial APK. Audio clips, holographic videos, final 3D art, Meta SDK prefab references, and Quest-specific tuning still need to be supplied/connected.

## Recommended demo order

Lead the judges directly into Chamber 3:
1. Hear the chord around the player.
2. Rotate the three rings.
3. Hear the lock respond.
4. Open the door.
5. Jump to Chamber 5 for the conductor finale.

