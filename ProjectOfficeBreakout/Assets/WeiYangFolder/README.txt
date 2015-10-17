README for Level 2: WeiYangDemoScene

Assets Used:

Model: TaiChi Pack

Objects: 
Water Flow Free (used for the running water and ice material animation)
Water FX Pack (used for the waterfall)

Materials:
Simple Physical Shaders (Used for the Yellow Paint, and the metal shades)

This level is meant to test how players can control the character above slippery floor.
You will be able to edit how slippery the floor is by editing SlipperySpeed in the player controller script. Instead of just adding a speed up, my implementation provides a secondary value of speed to the player that allows a slipping mechanism so that if a player walks fast in one direction and turn his body, he will still slide in the original direction until he slows down due to friction.

This level has a number of obstacles to go through. The controls are the standard directional Keys to move around, Space to Jump, left Mouse click to grab an object and shift to run. You will also be able to rotate through the checkpoints using right mouse click.

To restart the level, press '2'.

The checkpoints in this level are as follows:

CheckPoint 0: This is the starting point. To your left, there is a huge metal ball and a metal barrier in front of you. You will have to walk carefully behind the metal ball, such that the metal ball is between you and the metal barrier and push the metal ball such that it knocks down the metal barrier, opening up the route and paving the way to the next check point. Here, players must walk carefully on the slippery (blue) surface as accidentally knocking into the huge ball at a wrong angle may cause the ball to fall down to the ground before hitting the metal barrier. Also, players may accidentally slip off the platform. I have prevented the player from being able to knock down the metal barrier by just running into it and only allow it to fall when the metal ball knocks into it. This will also produce a crash sound upon collision.

As you walk around, each step on the yellow metal surface produce a thud sound while those on the ice surface produce a crunching sound. In this particular checkpoint, the blue surface is actually just water above the metal ground, and hence, both produces a metal thud sound.

CheckPoint 1: After walking over the metal barrier, you reach the next checkpoint where there are stacks of boxes in front of you. Players must ensure that they stop in time before walking/slipping off the surface and/or knocking down all the boxes. The boxes will be required for the next checkpoint. Use the Left Mouse Button to pick up a box when facing it. If there are no more boxes, players will not be able to complete the next section and will lose the game. While holding the left mouse button, the box will remain in front of you as you navigate the next part of this checkpoint.

Turning left, there is a metal platform 2 steps down. This platform rotates around a hinge (like a seesaw). Players will be able to navigate through this by jumping from the last ice platform onto the furthest part of the metal rotating platform. All these have to be done while holding onto the box.

CheckPoint 2: Here there is a small red squarish platform in front of you with seemingly nowhere else to go. Put the box you were holding onto the platform, and a ice path will extend out towards your left. Walk across this thin ice path while being careful not to slip off on either sides. Navigate through a few tight paths to reach the last Checkpoint.

CheckPoint 3: This is essentially the winning point. Simply walk down in the direction of the finish point. The steps down are not so in line to make it a little harder. Upon reaching the last step, Walk off it to reach a squarish platform where the flag will rise with your victory.