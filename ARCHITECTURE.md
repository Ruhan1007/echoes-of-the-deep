# Runtime Architecture

Meta XR Hand Tracking
        |
        +--> HandCupDetector ----> SpatialAudioManager ----> SpatialAudioSource
        |
        +--> PinchPull ----------> StoryFragment / HologramRenderer
        |
        +--> TwoHandRotate ------> HarmonicLock
        |
        +--> PalmPulse ----------> ChamberManager / door / music pulse
        |
        +--> Hand reach ---------> MemoryPool
        |
        +--> Gentle grab --------> EchoStone

ChamberManager
  1 Descent
  2 Gallery
  3 Harmonic Lock
  4 Memory Pool
  5 Echo Chamber
        |
        +--> SoundReactiveArchitecture
        +--> HologramRenderer
        +--> Ending sequence
