By Ryden Bargren

Unity Version 6000.3.21f

Activity 3
The PlayerMovement script moves the player when the W/A/S/D or arrow keys are pressed.
The speed can also be changed in the editor.
The PlayerHealth script keeps track of the player's health and max health.
It decreases the player's health when the player takes damage, and sets to the GameOver state when currentHealth <= 0.
A challenge was resetting the health in the GameLoopManager script, as I had forgotten about GetComponent<>().

Activity 4
W/S/A/D or arrow keys are used to move. Win by collecting 5 coins while avoiding spikes to not reach 0 health.
Scripts included are Collectible, GameLoopManager, Hazard, PlayerHealth and PlayerMovement.
I learned how to use states to create a menu, playing and pause system, and a game over and victory state, using scripts.
I also learned how to display performance stats.