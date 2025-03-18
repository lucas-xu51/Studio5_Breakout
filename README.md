### **Project Tools**

This project is implemented by Unity and Visual Studio Code, and is versioned by Github.


### **Project Description**

This project realizes some new features on the basis of a simple repeat of the classic game Breakout. In addition, this project also realizes version control and functional integration through github.

### **Updated Features**

## Scoring System (Ming Xu)
- This project realizes a separate scoring system for each level. The player can more intuitively understand their game progress. The animation effect of the score display panel and the corresponding colour matching keep the style of the page unified and harmonious.



## Brick Collision Effects (Lucas Xu)

### When the ball touches the brick:
- **Camera Shake**: The camera vibrates upon impact.
- **Sound Effect**: A sound plays to enhance feedback.

## Particle System & Enhanced Audio System (Jinxi Hu)
- Use the particle system of unity to implement the effect of destory the brick and ball
- User unity audio system to implement the sound effect of ball hit wall, hit panddle, destory bricks and ball been break


# Hearts Lives System and Game Over Logic Implementation ❤️ - Iverson (Shuchen) Yuan

## Feature Overview 🎮

In this Breakout game, I implemented a complete lives system and game over logic. Main features include:

1. 📊 Visual heart icons to represent lives
2. ✨ Animation effects when lives decrease
3. 🛑 Game over logic (pausing the game and displaying game over screen when lives reach zero)
4. 🎲 Game restart, return to main menu, and quit game functionality

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
