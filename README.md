# Unity: Animation Effects Editor
An editor for playing particles and sounds by listening to Mecanim animations. Made in Unity 2019.4.1f1.
Please also have a look at the example project at https://github.com/neotalon/unity-animation-effects-example (Access Required)

** Hot Tip: ** You can directly add the package from the package manager using the git url: https://github.com/neotalon/unity-animation-effects.git

**Version 1.0.3**
 
 ![Result](https://i.imgur.com/F3dw7ML.gif)
 
## Workflow Definition
The animation effects editor allows the user to add sound effects and particles to character animations in Unity. This speeds up the integration process which would otherwise be limited to hard-coding and editor-reloading times.
 
Furthermore, this means that a VFX designer can take of implementing their particles themselves. This saves time used by the VFX designer communicate the feature to the programmer and fosters independet work.
 
This saves the most time during the production phase. As various character sounds (footsteps, explosions, and attacks) are created they can be quickly implemented without disturbing the already existing animation code. This is expected to save the programmer around 3 minutes per animation effect. In a game with 3 characters with 10 animation effects each this means a total of up to 90 minutes of production time.
 
In a large-scale game with 15 characters with 20 animation effects each the system could save up to a total of 15 hours of production time.
 
**Why not just use timeline?**

The system ties the built-in Unity particle system and animation system (Mecanim) together. Normally, this can also be done inside of Timeline for in-game cutscens. Timelines were not used because they have inherent limitations, e.g. Timeline has problems with Wwise event references (Audio) in Unity 2019.1. To avoid these problems, a simple and extensible system was built which gives the programmer enough control to extend the implementation when needed.

Furthermore, using the timeline means giving up advantages of Mecanim such as easy state debugging, out-of-the-box multi-layered animation, and complex transitions.
 
## Features
- Play sounds after animation has finished (echo sounds from a skill)
- Play particles after animation has finished (such as gun smoke)
- Play multiple particle effects at once
- Optional: parent particle effects to character upon spawning
- Play multiple sound effects at once
- Support for multiple animation layers (note: each layer needs each own animation listener)
- Example scene showcasing the system and how to use it

## How do I use it?
There is a simple Example scene you can take a look at it to learn how to use the system.
 
**Here is a step by step guide:**
 1. Create a new animation controller.
 ![AnimationController](https://imgur.com/QRmxnj3.jpg)
 2. Set up the animation controller as you would normally, see https://docs.unity3d.com/Manual/class-AnimatorController.html for help.
 3. Add the AnimationListener component  to the animation base layer.
  ![AnimationListener component](https://i.imgur.com/S5xOb2Q.jpg)
 4. Create a new CharacterEffectSet scriptable object. This object will hold all animation effects for the character.
 ![CharacterEffectSet](https://imgur.com/9rMZcjk.jpg)
 5. Create individual animation effects. First link the animation clip and then set up particles and sound events.
 ![AnimationEffect](https://imgur.com/KZAPfG6.jpg)
 6. Add the effects to the effects array inside the CharacterEffectSet.
 ![CharacterEffectSet Filled](https://imgur.com/wwimX5W.jpg)
 7. Press play and test the effect animations.
 
## How does it work?
The system takes advantage of Unity's build in mecanim system. The mecanim system informs the AnimationListener when a new state is entered.
The AnimationListener then looks if any animation effects match the entered state. If matching effects are found then particles are created with delays by using coroutines and instantiate calls. In the case of audio, a simple AudioManager then creates and automatically destroys audio sources based on the animation effects.
 
## Limitations
 1. Particles cannot be played before the animation state is entered
   To adress this, particles can be spawned at the end of the previous animation. For example, if a character has a wind-up animation and an attack animation the particles can be    spawned at the end of the wind-up animation rather than at the beginning of the attack animation.
 2. The AnimationListener system goes through all character effects when entering a new state. This means that characters with hundreds of animation effects will have significant performance drawbacks. This will need to be improved to work for larger projects with hundreds of animations.
 3. There is no preview button. Animations have to be triggered with character controllers or events implemented by the developer
 
 ## Future Work
 1. Support multiple animator layers ✅
 2. Add option to spawn particles in local space ✅
 3. Add option to randomize sound pitch ✅
 4. Stress-test and optimize performance by improving animation effects lookup speed
 

## Support
If you encounter any problems, please open an issue on this repository. You can also send a support e-mail to neotalon27@gmail.com and I will try to take a look if I have time.

## Resources
[Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/)

[Semantic Versioning](https://semver.org/)

## License
The package uses the [MIT License](https://opensource.org/licenses/MIT)

## Quick note on Odin Inspector
[Odin Inspector](https://odininspector.com/) is recommended to use alongside the package. It makes it easier to replace fields and easily allows you to add custom min-max sliders which are useful for random sound effect picthing. It is seen in some of the screenshots, if you have time, please check it out, it's a great tool.
