# Portfolio documentation review

Review date: **6 October 2026**, Asia/Kuala_Lumpur.
Source baseline: `fa92aff5ac6378e8c0affda3d6d54145fa85054d` (12 June 2022).

## Checked for this update

- Editor version against `ProjectSettings/ProjectVersion.txt`.
- Package versions against `Packages/manifest.json`.
- Five enabled scene paths against `ProjectSettings/EditorBuildSettings.asset` and the tracked file tree.
- Keyboard/mouse mappings against `ProjectSettings/InputManager.asset`, `WheelController`, `PlayerController`, `MouseLook`, `EventController`, `ParkingScript`, and `UIController`.
- Vehicle, objective, menu, audio, and speed-display descriptions against the corresponding C# sources.
- Local documentation links against tracked paths, and whitespace/scope checks on the documentation diff.
- No GitHub release was listed at review time. No project-owned automated test files were found in the tracked inventory; the declared Test Framework package is not evidence of a passing suite.

Only `README.md` and this Markdown document changed. Application scripts, scenes, prefabs, imported assets, package files, and Unity settings remain unchanged.

## Runtime checks not performed

This review used a sparse source/configuration checkout to avoid downloading the large imported art folders. No Unity editor session, asset import, Console/compilation check, Play-mode run, player build, or gameplay test was performed. It does not establish that the prototype runs without errors in a fresh full checkout.

## Items to verify before a demo

1. Open a full checkout in Unity 2021.3.0f1 and resolve import or Console errors. Confirm the five enabled scenes and their Inspector references.
2. Start at MainMenu; visit the movement and parking lessons and return to the menu. Check loading progress and the pause interface.
3. Check on-foot movement, vehicle entry/exit, engine start, steering, braking, horn, hints, and wheel/steering animation.
4. Complete parking/refuelling/checkpoint tasks. `F` uprights the vehicle in one script and handles mission interactions in another; verify those handlers together.
5. Check the speedometer and audio. Speed is read from Rigidbody velocity magnitude; no conversion to km/h is established by the source reviewed.

`SceneController` also contains `LoadHandBrakeScene`, targeting `CarHandBrakeLesson`. The tracked scene is `Assets/Scenes/CarHandbrake.unity`, and neither name is enabled in Build Settings. Its reachability was not verified, so the README does not present a working handbrake lesson. Existing object-name lookups and multiple car-controller variants also need scene-level inspection. These observations were documented without changing gameplay.
