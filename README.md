
# CS464 Assignment 04 · Aman Fatima · BSCS25087

**Project:** Collect, Dodge, Survive  
**Course:** CS464 – Game Development  
**Assignment:** 04  
**Engine:** Unity 6.3

## Video Demonstration (90–180 Seconds)

**Video Link:** [https://drive.google.com/file/d/14ZCU170quZUJo1IPfxxhTf7cyQ5she9t/view?usp=drive_link]

The video demonstrates the main gameplay features, including the main menu, level selection, coin collection, health system, sound effects, pause menu, restart, win and game-over screens, and level transitions.

## Screenshots

- **S1:** HUD at 16:9
-  <img width="1482" height="873" alt="Screenshot 2026-11-24 233205" src="https://github.com/user-attachments/assets/57fcec7c-b2d7-4ae3-9cba-f95d9d1eaeae" />
- **S2:** HUD at 4:3

<img width="1917" height="915" alt="image" src="https://github.com/user-attachments/assets/36e44284-a36c-49ca-bd4f-4501832ef5f8" />

- **S3:** HUD in Grayscale
- used google docs for the grayscale and then take screenshot
- <img width="950" height="560" alt="Screenshot 2026-11-24 235320" src="https://github.com/user-attachments/assets/b4667cb7-b4f2-4c1d-a7fe-f3f6292266f7" />

## Settings

## Settings

| Part | Setting | Value | Why |
|---|---|---|---|
| A | Harmony · Base Hue | Dark Red · `#5D0D01` | Consistent visual theme |
| A | Dark · Mid · Light | `#090808` · `#A96B1B` · `#A96B1B`  | Visual hierarchy |
| A | Accents | `#5D0D01` · `#A96B1B` | Highlights UI elements |
| A | HUD Text Contrast | `4.57:1` | Readability |
| A | Button Label Contrast | `6.17:1` | Button readability |
| B | Music · SFX Groups | Music · SFX | Separates audio |
| B | Slider at 1 · 0.5 · 0.0001 | Range `0–1`; `0.5` tested | Volume control |
| C | Sound 1, in Level 01 | 3D · Logarithmic · Min `1` · Max `500` | Spatial audio |
| C | Sound 2, in Level 02 | Same as Sound 1 | Spatial audio |
| C | AudioListener | Main Camera | Receives 3D audio |
| D | unlocked | int · default 1 | Saves unlocked levels |
| D | best1 ... best5 | float · HasKey first | Saves best times |
| D | MusicVolume | float · default 1 | Saves music preference |

## Answers

### 1. What `Time.timeScale = 0` stops in my game, and what it doesn't

When `Time.timeScale` is set to zero, gameplay time stops. Physics, movement, and scripts that depend on scaled time stop progressing. However, UI interactions and operations using unscaled time can continue. Setting the value back to one resumes normal gameplay.

### 2. What survives a LoadScene in my game, and how

Normally, scene objects are destroyed when another scene loads. Objects using `DontDestroyOnLoad()` survive scene transitions. This approach is useful for persistent systems such as audio managers and level-loading managers.

### 3. Why every PlayerPrefs read in my game has a default

Every PlayerPrefs read should have a default value because a new player may not have any saved data. Defaults ensure that the game starts with valid settings and progress instead of returning unexpected values.

### 4. An exception a forgotten unsubscribe would throw, and why mine can't

A forgotten event unsubscribe can cause a disabled or destroyed object to receive an event callback. This may result in a `MissingReferenceException` or `NullReferenceException`. Subscribing in `OnEnable()` and unsubscribing in `OnDisable()` prevents stale subscriptions.


## Credits & Licences

- **Sound Effects:** Pixabay – https://pixabay.com/sound-effects/
- **Background Music:** Pixabay – https://pixabay.com/music/
- **Fonts:** TextMeshPro / Unity default fonts.
- **Particle Effects:** Created using Unity's built-in Particle System.
- **Game Engine:** Unity Technologies.


## Development Tools

- Unity 6.3
- C#
- Visual Studio
- Git
- GitHub

## Project Information

**Project Name:** Collect, Dodge, Survive  
**Assignment:** CS464 – Assignment 04  
**Student:** Aman Fatima  
**Roll Number:** BSCS25087
=======
# CS464 Assignment 03 – Collect, Dodge, Survive

**Student Name:** Aman Fatima  
**Roll Number:** BSCS23001  
**Course:** CS464 – Game Development


Sir, I submitted my assignment late. I kindly request you to please consider compensating me for the late submission, as I had a remed exam immediately after the midterms, and I was also out of station.&#x20;


## Game Overview

Collect, Dodge, Survive is a 3D Unity game developed using GameObjects and C# scripts. The player collects coins, avoids hazards, deals with enemies, and uses power-ups to complete each level.

The game contains five progressively challenging levels. Each new level introduces additional gameplay mechanics while retaining challenges from previous levels.

## Gameplay Video
THE Video was long due to capture of all five levels
[https://drive.google.com/file/d/1O2ZO8PSjwxIMuNMbogAmJdXOE5eQ8GCU/view?usp=sharing]



## Controls

| Key | Action |
|---|---|
| W | Move Forward |
| S | Move Backward |
| A | Move Left |
| D | Move Right |

The player can also use the arrow keys for movement.

## How to Win

- Collect 8 coins to complete the level.
- Avoid hazards and enemies.
- Keep your health above zero.
- Complete the level before the timer runs out in levels where the timer is enabled.
- Use available power-ups to improve your chances of survival.

## Level Progression

| Level | New Gameplay Feature | Combined Mechanics |
|---|---|---|
| Level 1 | Basic coin collection | Collect 8 coins and reach the target score |
| Level 2 | Spikes | Level 1 mechanics + damaging spikes |
| Level 3 | Health pickups and chasing guards | Level 2 mechanics + 3 health pickups + 3 chasing guards |
| Level 4 | Moving crusher | Level 3 mechanics + moving crusher |
| Level 5 | Speed power-ups and patrolling enemies | Level 4 mechanics + 2 speed power-ups + 4 patrolling enemies |

### Level 1 – Basic Collection

The player collects 8 coins to complete the level. This level introduces the basic movement and coin collection mechanics.

**Screenshot:** <img width="1908" height="868" alt="level01" src="https://github.com/user-attachments/assets/a9b9a08b-1c37-4a29-a2b8-0e8beb653c88" />


### Level 2 – Spike Hazards

Spikes are introduced. Touching an active spike decreases the player's health and applies knockback.

**Screenshot:** <img width="1912" height="837" alt="level02" src="https://github.com/user-attachments/assets/640e7813-5024-4e4e-8d48-ac14c5d459d2" />


### Level 3 – Health and Chasing Guards

Three health pickups and three chasing guards are added. Health pickups restore one health point when the player's health is below the maximum. Guards chase the player when they enter their detection range.

**Screenshot:** <img width="1917" height="826" alt="level03" src="https://github.com/user-attachments/assets/09eeaf71-b6aa-4bcb-a24e-7f7411ffc30f" />


### Level 4 – Moving Crusher

A moving crusher is added. It continuously moves up and down, creating another obstacle for the player.

**Screenshot:** <img width="1917" height="836" alt="level04" src="https://github.com/user-attachments/assets/581c658d-489a-44d4-bee2-f542e57de233" />


### Level 5 – Speed Boost and Patrol Enemies

Two speed power-ups and four patrolling enemies are added. Collecting a speed power-up increases player movement speed for 10 seconds. Enemies patrol between two waypoints.

A 2-minute timer is enabled in this level.

**Screenshot:** <img width="1872" height="845" alt="level05" src="https://github.com/user-attachments/assets/fc72b5c7-41bb-463a-90fb-51ba02049bd3" />

## Gameplay Settings

| Feature | Setting |
|---|---:|
| Target score | 8 coins |
| Maximum health | 3 |
| Invulnerability time | 1 second |
| Spike damage | 1 health |
| Spike knockback | 6 |
| Knockback ForceMode | Impulse |
| Guard movement speed | 3 |
| Guard chase range | 7 units |
| Guard stop distance | 1.5 units |
| Guard damage | 1 health |
| Patrol speed | 2 units/second |
| Patrol turning speed | 360 degrees/second |
| Crusher movement height | 3 units |
| Crusher movement speed | 1.5 |
| Player movement force | 10 |
| Speed multiplier | 3× |
| Speed boost duration | 10 seconds |
| Level 5 timer | 120 seconds |

*Note: The actual values can also be changed through Unity Inspector settings.*

## Technical Questions

### 1. Why does a trigger need a Rigidbody on at least one of the two objects?

Unity requires at least one of the interacting objects to have a Rigidbody so that the physics system can detect trigger interactions and generate trigger events.

### 2. Which ForceMode is used for knockback and player movement? Why?

- **ForceMode.Impulse:** Used for knockback because it applies an instant push to the player.
- **ForceMode.Force:** Used for player movement because it continuously applies force while movement input is given.

### 3. What happens if the player collects a second power-up while one is already active?

The existing boost coroutine is stopped and restarted. The speed remains at 3×, and the 10-second duration starts again. The multiplier does not become 9×.

### 4. Why can `==` fail as an arrival check, and when does it work?

Using `==` with floating-point positions can fail because of small precision differences. A distance check such as `Vector3.Distance() < 0.05f` is more reliable. Exact equality works when both values match precisely.


**Aman Fatima**  
BS Computer Science  
Information Technology University
