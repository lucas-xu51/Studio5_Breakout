### **Project Tools**

This project is implemented by Unity and Visual Studio Code, and is versioned by Github.


### **Project Description**

This project realizes some new features on the basis of a simple repeat of the classic game Breakout. In addition, this project also realizes version control and functional integration through github.

### **Updated Features**

- This project realizes a separate scoring system for each level. The player can more intuitively understand their game progress. The animation effect of the score display panel and the corresponding colour matching keep the style of the page unified and harmonious.

- 

### **Demo Video**

# Hearts Lives System and Game Over Logic Implementation ❤️

## Feature Overview 🎮 - Iverson (Shuchen) Yuan

In this Breakout game, I implemented a complete lives system and game over logic. Main features include:

1. 📊 Visual heart icons to represent lives
2. ✨ Animation effects when lives decrease
3. 🛑 Game over logic (pausing the game and displaying game over screen when lives reach zero)
4. 🔄 Scene transition logic (advancing to next level or showing victory screen)
5. 🎲 Game restart, return to main menu, and quit game functionality

## Implementation Approach 🛠️

### Visual Lives System ❤️

- 💗 Heart icons intuitively represent the player's remaining lives
- ⬅️ Hearts decrease from right to left, matching intuitive life consumption direction
- 📏 Fixed layout system ensures stable heart icon positioning

### Life Decrease Animation 🎭

- 📉 When the ball falls, the corresponding heart icon shrinks and disappears with animation
- 👁️ Animation effects enhance visual feedback
- 🔍 Players can visually perceive changes in their lives

### Game Over Logic 🏁

- ⚠️ When player lives reach zero, the game pauses and displays a game over screen
- 🔄 Game over panel provides restart and quit game options
- 🖱️ Mouse cursor is unlocked so players can interact with UI elements

### Scene Transition Logic 🚪

- 🗺️ Game flow is determined based on current scene name
- 🏆 Completing Level 1 automatically loads Level 2
- 🎉 Completing Level 2 shows the game victory screen
- 🧭 Provides clear game progression and objectives

## Visual Results 📸

1. **Heart Lives Display** ❤️❤️❤️: Three red heart icons in the upper left corner visually represent remaining player lives.
2. **Life Decrease Animation** 📉: When the ball falls, the rightmost heart icon shrinks and disappears with a smooth animation.
3. **Game Over** 🛑: When lives reach zero, the game pauses and displays a game over screen where players can choose to restart or quit.
4. **Level Transition** 🔄: Automatically advances to Level 2 after completing Level 1; displays victory screen after completing Level 2.

## Technical Challenges and Solutions 💡

### Heart Icon Layout Issues 📐

- ⚙️ Implemented a custom layout system to ensure heart icons align properly
- 🔧 Added configurable spacing and margin parameters for easy adjustment across different resolutions

### Game Pausing and Scene Transitions ⏯️

- ⏸️ Successfully implemented game pausing on game over or victory while keeping UI interactive
- 🧩 Designed intuitive scene transition logic enhancing game flow continuity



# Camera Shake Implementation on Ball-Brick Collision 📱(Lucas Xu)

## Feature Overview 🎮

In this Breakout game, I implemented a camera shake effect that triggers when the ball collides with bricks. This feature adds:

1. 📳 Responsive camera shake when destroying bricks
2. 🎯 Enhanced feedback for successful ball hits
3. 🔄 Configurable shake intensity and duration
4. 📊 Clean integration with the existing collision system

## Implementation Approach 🛠

### Camera Shake System 📳

- 💥 Camera shake triggers instantly when a ball hits and destroys a brick
- 🎚 Configurable intensity parameter allows for fine-tuning the effect
- ⏱ Duration control ensures the shake doesn't interfere with gameplay
- 🔍 Subtle enough to enhance feedback without disorienting the player

### Integration with Collision System 🎯

- 📡 Ball-brick collision detection seamlessly triggers the camera shake
- ⚙ Singleton pattern used for the CameraShake component allows for easy access
- 🧩 System works with any brick type without requiring individual configuration

## Visual Results 📸

1. **Impact Emphasis** 💥: The screen subtly shakes when the ball destroys a brick, emphasizing the impact.
2. **Graduated Feedback** 📊: Players receive immediate visual feedback when successfully hitting targets.
3. **Enhanced Game Feel** 🎮: The shake effect adds weight and significance to brick destruction.

## Technical Challenges and Solutions 💡

### Camera Movement Control 🎥

- ⚙ Implemented a mathematical approach using perlin noise for natural-feeling camera movement
- 🔧 Created a coroutine-based system to control shake duration and falloff
- 🛠 Ensured shake effect doesn't interfere with the main camera's tracking functions

### Performance Optimization ⚡

- 📉 Optimized shake calculations to maintain consistent frame rates
- 🔄 Used efficient shake algorithms that scale well with multiple simultaneous collisions
- 💻 Minimized garbage collection concerns by properly managing shake coroutines

## Summary 🎯

The camera shake feature significantly
