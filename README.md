
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
