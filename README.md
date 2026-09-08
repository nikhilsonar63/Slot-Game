# 🎰 Casino Games

A Unity-based slot machine game created as part of a Game Development Internship Assignment.

The game features randomized slot reels, smooth reel animations, coin betting, winning payouts, and a custom Loan & EMI system as a bonus feature.

## 🎮 Game Overview

Casino Games is a simple slot machine game where the player spins three reels and tries to match the same symbol on all reels.

### How to Play

1. Start the game from the Start Menu.
2. Choose your bet amount.
3. Press the **SPIN** button.
4. The three reels spin and stop on random symbols.
5. If all three symbols match, the player wins.
6. A winning spin gives the player **2× the bet amount**.
7. If the symbols do not match, the bet amount is lost.

## 🏆 Winning Logic

The player wins when all three reels show the same symbol.

Example:

`🍒 | 🍒 | 🍒` → WIN

`🍒 | ⭐ | 🍒` → LOSE

The winning payout is **2× the current bet amount**.

## 🎲 Randomization

The reel results are generated using Unity's random number generation system.

Each reel receives a random symbol ID, making the outcomes unpredictable.

## 🪙 Coin System

The game includes a coin-based betting system.

- Players start with coins.
- Coins are deducted when a spin is made.
- Winning spins reward the player with a 2× payout.
- Losing spins deduct the selected bet amount.

## 💳 Bonus Feature — Loan & EMI System

A custom Loan & EMI system was added as a bonus feature.

- When the player's coins are depleted, they can take a loan of **5,000 coins**.
- After every **3 spins**, an EMI payment of **500 coins** is deducted.
- The loan requires **10 EMI payments** to be fully repaid.
- After all 10 EMI payments are completed, the player can take another loan.

This feature was added to make the gameplay more interesting and demonstrate additional game logic.

## 🎰 Reel Animation

Each reel has its own spinning behaviour.

The reels use smooth scrolling animation and stop at their selected random symbol after a specific duration.

The reels also stop at different times to create a more realistic slot-machine effect.

## 🛠️ Technologies Used

- Unity
- C#
- Unity UI
- Coroutines
- Random Number Generation
- Animation
- WebGL
🎮 Play the Game

"Play Slot Game on Itch.io" (https://nikhilsonar.itch.io/slot-game)


