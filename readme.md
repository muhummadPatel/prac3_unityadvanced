##Practical 3 - _Unity3D: Advanced_


**Author** : Muhummad Yunus Patel  
**Student#** : PTLMUH006  
**Date** : 27-July-2015  


###Submission:
Included in this submission is the Unity project folder (prac3). Note that the
local git repository can be found in the unity project folder. Should you have
any questions regarding this submission, please feel free to contact me on 
muhummad.patel@gmail.com. Hope you enjoy the game! :)


[![Gameplay trailer](http://img.youtube.com/vi/slgxF9uK-7E/0.jpg)](https://www.youtube.com/watch?v=slgxF9uK-7E)

Click the image to watch a gameplay video.


###Controls:
* Move: WASD
* Aim: mouse
* Fire/shoot: left mouse button
* Toggle views: v
* Increase orbit camera height: ,
* Decrease orbit camera height: .
* Increase orbit camera distance: k
* Decrease orbit camera distance: l
* Restart scene and reset score: r
* Show help screen: h
* Quit: esc


###Description: 
This assignment required a simple 3d scene in unity focused around a player model 
with a weapon. The scene I have implemented is a simple scene where the player walks 
around in a toy-like environment and shoots the objects that fall from the sky.
_All_ 3d models were modelled, animated, and textured by me in blender.
See below for a discuission of how/where I have implemented all of the required 
functionality within the simple scene.


###Animated, movable player model carrying a movable weapon:
The player controls a simple humanoid model whose right hand can shoot laser bullets.
I modelled, animated, and textured this model myself using Blender. This model is fully
animated and appropriate animations are diplayed when the player model is moved in the 
game world. The player can control the movements of the player model in the game world 
using the wasd keys. The Gun can be aimed using the mouse. The gun has a crosshair object
(a little white sphere) that helps the player visualize where the gun is aimed.


###Cameras:
There are three camreas available to the player in the scene. The third person camera is the
camera that is selected when the scene first starts. The third person camera follows the players
movements as they move around the scene. The first person camera shows the scene from the 
perspective of the player model. It also has the weapon in the view so that the player 
can see where they are aiming. The third camera is a orbiting camera that continuously 
orbits the player moodel. The orbit camera's height and radius can be adjusted using 
the following keys: "k", "l", ",", "." . The player can switch between the different 
camera views by pressing the "v" key.


###Collidable Objects:
I modelled some toyroom type collidable objects like lego pieces, crayons, pencils, etc.
These have been placed in the scene and set up such that the player can collide with the objects.
The destructable objects that fall from the sky are also collidable. The built-in unity physics
system was used to set up and handle the collisions between the objects.


###Randomised destructable objects:
Random primitive objects (sphere, cylinder, cube) fall from random locations in the sky. These
objects are textured with a randomly selected material. When the player shoots one of these 
objects they will explode.


###Shooting using raycasting:
The players' right hand shoots laser bullets. This is implemented using unity's physics 
raycasting. A ray is cast from the gun forward into the game world. If the ray hits a destructable 
gameObject within the range of the laser, that gameobject will then explode. Raycasting is also used
to position the crosshair object (a little white sphere) that shows the player where the laser gun hand
is aiming.


###3D Text:
The game uses unity's UI system to display a hud. This shows the score (how many destructable
objects the player had blown up so far), and some helpful info ("press H for help, press R to restart").
There is also some actual 3d text (a 3d model of some text) that has been added to the scene and
rendered using some custom material.


###Lighting:
I have used directional lights to light up the scene. The scene also contains a skybox which lights 
up the scene and adds visual interest.


###Particle effects and other visual fanciness:
Particle effects are used for the explosions shown when a destructable object is shot. Particle effects
are also used to show muzzle-flash at the tip of the laser hand gun. A linerenderer was used to show the
path of the laser through the game world. Custom materials were created for the objects in the scene.
Notice how every time you restart the legos and crayons are randomly coloured :). I also used some of the
other (non-default) unity shaders. e.g. the lego materials use the unity specular shader to achieve a more plasticky
look than just the default diffuse shader.


###Audio:
Audio has been added to the scene for when the laser gun fires and when the destructable objects explode.
Gunfire and explosion audio have been included in the game.