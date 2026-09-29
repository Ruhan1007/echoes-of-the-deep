# Meta XR wiring guide

The gameplay scripts intentionally accept plain Unity values so they can be connected to different Meta XR SDK versions.

## HandCupDetector
Feed:
- palm position
- palm forward direction
- ear/head position

Call:
`UpdateHandPose(palmPosition, palmForward, earPosition)`

On `onCupStart`, call:
`SpatialAudioManager.IsolateNear(listenerPosition, listenerForward)`

On `onCupEnd`, call:
`SpatialAudioManager.ClearIsolation()`

## PinchPull
On pinch begin call `BeginPinch(position)`.
While held call `UpdatePinch(position)`.
On release call `EndPinch()`.

## TwoHandRotate
When both hands are grabbing a ring:
`BeginTwoHand(left, right)`
then repeatedly:
`UpdateTwoHand(left, right)`
then:
`EndTwoHand()`

## PalmPulse
On palm tracking start:
`Begin(position)`
During tracking:
`UpdatePalm(position, Time.deltaTime)`
On release:
`End()`

These adapters avoid hard-coding Meta XR class names into the core narrative code.
