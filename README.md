# **Break out** - Group 27

## Project Description 🎮
This project extends the classic arcade game **Breakout** with enhanced features and modern gameplay elements. Building upon the timeless brick-breaking mechanics, we've implemented additional functionality including:

- ❤️ **Life system visualization** with animated hearts
- 🖥️ **Engaging UI elements** for game over
- 📱 **Responsive controls** for smooth gameplay
- 📊 **Score tracking** system
- 📷 **Camera effects** for impact feedback

## 📸 Game Demo

[![Unity Roll-a-Ball and Bowling Game Demo](https://img.youtube.com/vi/LmRjTkSof-w/0.jpg)](https://www.youtube.com/watch?v=LmRjTkSof-w)<br>
_Youtube Video of the game in action_

## Project Tools 🛠️
This project is built using **Unity engine** and developed with **Visual Studio Code**. Version control is managed through **GitHub**, enabling efficient collaboration and feature tracking throughout the development process.


## **Updated Features**

## Hearts Lives System and Game Over Logic Implementation ❤️ - **Iverson (Shuchen) Yuan**

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


## Scoring System (Ming Xu)
- This project realizes a separate scoring system for each level. The player can more intuitively understand their game progress. The animation effect of the score display panel and the corresponding colour matching keep the style of the page unified and harmonious.


## Brick Collision Effects (Lucas Xu)

### When the ball touches the brick:
- **Camera Shake**: The camera vibrates upon impact.
- **Sound Effect**: A sound plays to enhance feedback.

## Particle System & Enhanced Audio System (Jinxi Hu)
- Use the particle system of unity to implement the effect of destory the brick and ball
- User unity audio system to implement the sound effect of ball hit wall, hit panddle, destory bricks and ball been break
