# Sonoma-Hackathon-2021
Tank Battle Game

For Sonoma Hacks competition 2021. You can read more about it on devpost.

There is a lot of code so I will mostly gloss over 90% of the details. We used the Unity Physics for most of the collision in this game such as bouncing the bullets and checking for collisions on powerups. For many aspects of this game we used IEnumerators as coroutines (see https://docs.unity3d.com/ScriptReference/Coroutine.html). We moved objects like the player and bullets by changing their transform position every frame.

Powerup system:
I created a new game object for each powerup and made it a prefabricated object that I can clone. Each powerup has a sprite, collider (to check if the player touches it), a script called Powerup.cs, and its behaviours. When the player touched the powerup then instead of firing the player uses a powerup on the next turn. The player calls a function in the Powerup.cs script which then later calls a function on its personal behaviour. I did this so that it is really easy to quickly make new powerups because I only need to make a new script and not have a long if/else statement asking which powerup you are using.

Other systems:
Some other systems include player movement (change position each frame). Some notable things include a function at the start that checks if you have moved so that the tutorial keys disappear. I also use a lot of IEnumerators for timers such as respawning, reloading, etc. These are very useful because you don't need to make 2 variables just for a timer if you use coroutines and you can also use infinite loops in coroutines for spawning things.

Another system I would like to mention is the audio manager. For this I created a function which spawns a new game object that has an AudioSource component. It plays the audiosource, and then it destroys the game object soon after for performance reasons. This is useful because you can adjust volume at runtime and create noises at runtime as well. 

To make bullets go through the middle wall and not the player without using long and confusing if-statements, we changed the physics of the middle wall by adjusting some settings in the Unity Engine so that the physics ignores collisions between the bullets and the middle wall. Luckily, this can be done in code as well which means that we were able to have a powerup that makes the middle wall solid for bullets. 

Scenes: Our game has 2 scenes. Menu and Play scene. You can transition from either scene back and forth. Scenes hold game objects and data. We are also able to reload scenes quickly so that instead of resetting every single value of a scene you can simply reset a scene in a single line of code. 
