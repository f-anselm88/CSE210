// Eternal Quest Program -- CSE 210 Week 06 Project
//
// FEATURES THAT EXCEED THE CORE REQUIREMENTS:
//
// 1. Leveling system: GoalManager tracks the player's overall Level based
//    on total score (1,000 points per level). Leveling up is announced to
//    the user in RecordEvent(), turning long-term progress into a visible,
//    game-like milestone rather than just a raw point total.
//
// 2. NegativeGoal type: a fourth goal category (beyond Simple, Eternal,
//    and Checklist) for habits the user is trying to quit, e.g. skipping
//    a workout. Recording an event on a NegativeGoal SUBTRACTS points,
//    demonstrating polymorphism further by overriding RecordEvent() to
//    return a negative value while still fitting the same Goal interface
//    used for saving, loading, and display.
//
// Both features are fully integrated into the menu, and into the
// save/load file format, so they persist across sessions like any other
// goal type.

using EternalQuest;

GoalManager manager = new GoalManager();
manager.Start();
