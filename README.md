# Computing-Project-Solar-System
### Contents
- [Computing-Project-Solar-System](#computing-project-solar-system)
    - [Contents](#contents)
    - [Problem Identification](#problem-identification)
    - [Stakeholders](#stakeholders)
    - [Research](#research)
    - [Essential Features](#essential-features)
    - [Limitations](#limitations)
    - [Solution Requirements](#solution-requirements)
      - [Software Requirements:](#software-requirements)
      - [Hardware Requirements:](#hardware-requirements)
      - [Evidence for Requirements:](#evidence-for-requirements)
    - [Success Criteria](#success-criteria)

### Problem Identification
In the current learning environment in physics there is a lack of interesting gamified learning experiences that helps to enthuse people about physics. A gamified learning experience relies on the simple concept of the motivation factor, which is often achieved by the use of competitive gameplay, and applying it to learning. The created experience helps to change perceptions and attitudes on the subject and develops skills through a practical and applied approach to learning. 

One reason in which this problem lends itself to computational solutions is that it will rely heavily on the computational methods to generate a convincing 3d world for the player to explore. 

One computation method that is suitable for this problem is Thinking abstractly and visualisation. This is an important method because the solar system will only include the relevant detail that is needed. One example of this could be the inclusion of only the most important planet to learn from. 

Another computational method that is suitable for this problem is performance modelling. This is an important method because the rendering of many different planets in my game and the complex gravitation calculations carried out between them will be very resource intensive. One example of this could be the use of abstraction to only calculate the necessity.

Another computational method that is suitable for this problem is Pipelining. This is an important method because the sounding in and out of planets and objects may become very resource intensive which means that this might have to be included to make sure that processes are happening over multiple frames and not causing the  game to stutter. 

Another computational method that is suitable for this problem is backtracking. This is an important method because I will not be able to achieve what I want to do on the first attempt but will have to continuously backtrack and incrementally build to a solution. For example, to achieve a playable game of 30fps I will have to backtrack continuously and keep on improving little things until I have reached my end goal.


### Stakeholders
The demographic for my game are 13+ which are of the age that people pick their gcses and then later go on to pick their A levels. Therefore this is the right age that I should target to get interested in physics because it will have the most impact in their lives. I will use my stakeholders throughout my project by surveying them to get their ideas on key features of my project. 

One stakeholder of my project is Erik Bolumburu; he is an avid gamer and has no prior knowledge of the core aspects of astrology. He is an appropriate stakeholder for my project because he wants to learn about astrology through a gaming setting.   

Another stakeholder of my project is Peter Harwin. He is an appropriate stakeholder for my project because he enjoys games, however is less interested in astrology and this will help me target the people that aren’t yet interested in astrology, however if successful could be interested after playing this game.

Lastly, another stakeholder of my project is Evan Harwin. He is an appropriate stakeholder because although interested in astrology he is 21 years of age will help to target a broader audience.


### Research
There is a limited amount of educational space games however the 2 that stand out are Kerbal Space Program and Space Engineers. Kerbal Space Program is a game that allows you to  make space ships and fly them around the solar system. 

One issue I came across for both games is the floating point precision errors. This is an error that occurs because as an object gets further from the origin the vector loses precision because the number requires a larger data type size to store at the same level of precision but to overcome this the computer calculates the end of the float and removes some precision to get roughly the same answer. To overcome this they implemented a origin shift threshold that moves all space around the player to an origin to prevent recenteralise it, meaning that all things close to the player are at a high accuracy.

Another issue is the performance that the game would see if I were to use the same resolution for all the planets. Instead of this I will use a level of detail system: What this will do is adjust the resolution of the object's surface depending on how close the player is to it. So that object that is really far away from the player won't be rendered with as high resolution because it doesn’t need it.  

Another issue with my game would be the performance issues that would come with realtime gravitational calculation between many different planets and objects. To overcome this kerbal space program doesn’t calculate the orbit for the celestial bodies only the spaceships and the bodies follow a predefined path. Whereas Space Engineers don’t even do that and instead have static bodies.


### Essential Features
Learn more about each Planet - The game should allow the ability to find out more about each celestial body so you can learn about the planet's origins.

Control a spaceship - Allow the ability to fly to allow the player to transverse the universe and fly to each and every planet.

Bases - The game should allow the player to when on a new planet create a base. This will be done by the use of points and allow the player to change space ships. 

Saves - Ability to save the progression of the game. This is an essential feature because it will allow the player to come back and learn more from the game without having to start again.


### Limitations
One limitation might be the hardware that the game is being run on when trying to calculate orbiting bodies. This can be represented as a limitation because the game may need to be scaled down to help with playability on my machine and orbits may have to be precalculated and possibly only calculated for the spaceship.

Another limitation is the time frame. This may limit the ability to add the advanced feature I want to add such as extra solar systems, but shouldn’t limit the core feature I want to put into place.


### Solution Requirements
#### Software Requirements:
Learn more about each Planet - The game should allow the ability to find out more about each celestial body so you can learn about the planet's origins.
Control a spaceship - Allow the ability to fly to allow the player to transverse the universe and fly to each and every planet.
Bases - The game should allow the player to when on a new planet create a base. This will be done by the use of points and allow the player to change space ships. 
Saves - Ability to save the progression of the game. This is an essential feature because it will allow the player to come back and learn more from the game without having to start again.

#### Hardware Requirements:
GPU: AMD rx570 (or equivalent)
CPU: Intel Core i5-9400F (or equivalent)
Memory: 16Gb 

#### Evidence for Requirements:
Information on each planet has been set as a requirement because my game is meant to be a gamified learning experience that allows you to grasp the core concepts of astrology.
Control of the spaceship has been set as a requirement because by the experience of gravity on your spaceship the player will understand the core concepts of astrology.
Bases have been set as a requirement because it will allow the player to change spaceships which will help the player to understand the different effects of thrust which comes from different spaceships allowing a broader understanding of the core concepts of astrology.
Saves will allow the player to start from where they left off allowing the player to continuously explore the planets which enables them to learn the core concepts of astrology.

### Success Criteria
Playable (play on my machine at above 30 fps) 
Enjoyable (When surveyed 80% respondents should say yes)
Understandable (When surveyed 80% respondents should say yes)