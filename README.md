# AltaGamesTest
![view](https://github.com/Vivoxti/AltaGamesTest/blob/main/Readme/Gameplay.png)
### Gameplay.
On the screen is the balloon player in the lower left corner, and the target in the upper right corner, where the ball must hit. The path is blocked by obstacles. The ball player creates shots due to its size, you need to clear a path for the ball player to jump along the cleared path to the final goal.

### Prototype.
When you tap, the player ball begins to separate from the player ball. The player-ball decreases in size in proportion to how the shot ball grows in size and depends on the holding time (the longer, the greater). When released, the shot flies in the direction of the target, and when it collides with the first obstacle it "infects" the obstacles in its radius, and they explode. 
The power of the shot - the "contamination" radius depends on the size of the shot ball, the bigger it is, the bigger the radius. The closer the obstacles are to each other, the easier it is to infect them. Small shots should be fired on lonely ones so as not to waste the entire size of the player's balloon. 

After clearing the area the player's balloon advances accordingly toward the target. At the end, his size is reduced, but he clearly should have enough room to pass freely between obstacles, bouncing down the center of the lane. The path decreases with the size of the ball.

At the end there should be a door. The door opens when the ball comes within 5 meters of it.
If the player held the tap too long and the ball is all pumped into the shot (to pick up the minimum critical size) - the player loses. If there were not enough shots to clear the path - lose. 

Initially, the ball size should be enough with a 20% margin for passing. 

Send the completed task as a build on android, gameplay video on youtube, and sors of the project in Unity.
