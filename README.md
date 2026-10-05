# Car Driving Simulator

**A Unity 3D driving tutorial prototype with vehicle physics, parking objectives, and first-person interaction.**

The project combines a drivable car, on-foot exploration, lesson selection, and mission prompts in a city environment. It is an earlier portfolio project: the source baseline reviewed for this documentation update was committed in June 2022.

## Features represented in the source

- **Vehicle handling:** `WheelCollider` motor torque, front-wheel steering, four-wheel braking, wheel-mesh updates, and steering-wheel animation.
- **Player interaction:** first-person movement and mouse look, entering/exiting a car, and in-car hints.
- **Driving objectives:** prompts for parking, refuelling, and visiting checkpoints, with trigger-based mission state.
- **Presentation:** asynchronous lesson loading with a progress slider, a pause/menu interface, a speedometer based on Rigidbody velocity, engine audio, horn, and handbrake sound.

These features were identified from C# and configuration files. The game was not launched for this documentation update; scene wiring and end-to-end completion remain to be verified. See [review status and demo checks](docs/VALIDATION.md).

## Technology

| Area | Recorded implementation |
| --- | --- |
| Editor | Unity **2021.3.0f1** |
| Gameplay | C#, Rigidbody, WheelCollider, CharacterController, collider triggers |
| Input | Legacy Unity Input Manager; keyboard and mouse mappings |
| Interface | uGUI and TextMesh Pro **3.0.6** |
| Tools | ProBuilder **5.0.4**; Unity Test Framework **1.1.31** is declared, but no project test suite was found |

The repository contains multiple car-controller implementations. Check the components attached to each scene's vehicle before changing or extending its controls.

## Open the project

1. Clone the repository:

   ```sh
   git clone https://github.com/Azrinfreeman/Car-Driving-Simulator.git
   ```

2. Install Unity **2021.3.0f1** through Unity Hub and add the cloned repository root as a project. The project contains substantial art/audio assets, so allow time and disk space for the clone and first import.
3. Open `Assets/Scenes/MainMenu.unity` and enter Play mode. The menu controller includes routes to the movement and parking lessons. If import or Console errors prevent play, resolve those before making a build.
4. Retain the recorded editor and package versions for the first review. Test any future Unity upgrade in a separate branch.

No GitHub release build is currently available. Editor import, compilation, and player builds were not performed for this documentation PR.

## Keyboard and mouse controls

Mappings below come from the tracked scripts and Input Manager; availability depends on the scene and active controller.

| Input | Source behavior |
| --- | --- |
| W/S or Up/Down | Forward/reverse vehicle input; forward/backward movement on foot |
| A/D or Left/Right | Steering in the car; lateral movement on foot |
| Mouse movement | First-person view |
| E | Enter/exit when the vehicle interaction prompt is active |
| P | Set the riding/engine-start state in `WheelController` |
| Space | Vehicle braking/handbrake |
| H | Hold horn; release stops it |
| T | Toggle hints while in the car |
| F | Upright the car in `WheelController`; also interact with refuelling/checkpoint prompts |
| Escape | Toggle the pause/menu interface |

`F` has more than one handler, so verify its behavior during missions. The speedometer uses raw Rigidbody velocity magnitude; this review does not establish a km/h calibration.

## Build scenes and code guide

The tracked Build Settings enable these five scenes, in order:

1. `Assets/Scenes/MainMenu.unity`
2. `Assets/Scenes/CarMovementLesson.unity`
3. `Assets/Scenes/CarParkingLesson.unity`
4. `Assets/Scenes/CarStructure.unity`
5. `Assets/Scenes/learningScene.unity`

| Path | Responsibility |
| --- | --- |
| [`Assets/Scripts/WheelController.cs`](Assets/Scripts/WheelController.cs) | Vehicle physics, engine state, horn, steering animation, and mission triggers |
| [`Assets/Scripts/PlayerController.cs`](Assets/Scripts/PlayerController.cs) / [`MouseLook.cs`](Assets/Scripts/MouseLook.cs) | On-foot movement, view, and in-car state |
| [`Assets/UI/EventController.cs`](Assets/UI/EventController.cs) | Vehicle entry/exit interaction |
| [`Assets/Scripts/ObjectiveController.cs`](Assets/Scripts/ObjectiveController.cs) / [`Assets/ParkingScript.cs`](Assets/ParkingScript.cs) | Mission prompts and progression |
| [`Assets/Scripts/SceneController.cs`](Assets/Scripts/SceneController.cs) | Main-menu flow and asynchronous lesson loading |
| [`Assets/UIController.cs`](Assets/UIController.cs) | Pause/menu panels and return to the menu |
| [`Assets/Speedometer/Speedometer.cs`](Assets/Speedometer/Speedometer.cs) / [`Assets/Scripts/audio.cs`](Assets/Scripts/audio.cs) | Speed display and engine/vehicle audio |

Many components locate scene objects by name and use Inspector references. Preserve those object names and assignments when preparing a demo. A handbrake-loading target in `SceneController` differs from the tracked scene name and is not in the enabled build list; its runtime reachability has not been checked.

## Assets and attribution

The project includes imported vehicle, city, road, vegetation, cloud, outline, and text assets alongside gameplay scripts. Their presence does not imply that every asset was authored for this project or that it can be redistributed independently. Preserve included notices and confirm the applicable asset permissions before repackaging them. No top-level software license is currently present.
