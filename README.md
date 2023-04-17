<h1 align="center">Spaceship Game</h1>

Welcome to the SpaceShip Game! This is an action game where the player controls a spaceship and destroys enemies. The goal is to survive as long as possible and score as many points as you can by shooting down enemy spacecraft.
## How to Play And Rules
1. [Click here to play the game!](https://orihoward.itch.io/spaceship-game)
2. The player navigates the spaceship using the keys W, A, S, and D, and shoots using the spacebar.
3. Your objective is to destroy as many enemies as possible while avoiding being hit by them.
4. Power-ups are available in the game, and can give you an advantage. Make use of them when they appear.
## Power Ups
The game features two power-ups that can give the player an advantage.
### Canon power-up
This power-up provides the player with a bigger laser that can destroy multiple enemies at once for a few seconds.
### Freeze power-up
This power-up freezes all enemies on the screen, except those that are very low, to prevent the player from colliding into them.

#### Be sure to grab these power-ups when they appear to gain an edge in the game

## Scripts
The following scripts were added or modified to enhance the game

### ClickSpawner
The ClickSpawner script is responsible for spawning enemies in the game. An option for an alternatePrefabToSpawn was added to the script to support the Cannon power-up. When the player takes the Cannon power-up, the script changes the prefab the player spawns for a few seconds using a Coroutine function.

### TimedSpawnerRandom
The TimedSpawnerRandom script was modified to add an isValidPosition function to ensure that power-ups won't spawn on the player.

### CannonBoost
The CannonBoost script triggers a Coroutine function in response to a collision with the Cannon power-up. The script uses the ClickSpawner component to change the prefab the player spawns for a few seconds. This gives the player a big laser to shoot for a few seconds when they take the Cannon power-up.

### Freeze
The Freeze script triggers a Coroutine function in response to a collision with the Freeze power-up. The script iterates over all enemies and freezes them by setting their velocity to zero. The script checks that the enemies are still active and their position is not too low before freezing them.

### GameOverOnTrigger2D
The GameOverOnTrigger2D script is triggered when the game is over. It sets all enemies to inactive to ensure that they won't keep spawning and destroys the spaceship object.

### gameManager
The gameManager script reloads the scene whenever the player presses the "Restart Game" button.
