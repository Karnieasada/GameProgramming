# Linear Algebra
This is a game made using the Unity Engine, which is intended to aid individuals with their understanding of a few core concepts in Linear Algebra.
The game focuses on the areas of Transpose operations and basic row operations in forming an identity matrix. The game uses simple controls with the mouse and keyboard and offers several puzzles
in each category for the player to aid their knowledge of Linear Algebra.

### Installing
The game can be played online using the WebGL platform [here](https://karnieasada.github.io/GameProgramming/).

If you wish to play locally using the Unity editor you can download the folders for the [Assets](Assets), [Packages](Packages), and [Project Settings](ProjectSettings). This should allow
you to play the game locally.

## Server Setup
The game allows for the use of either local save using Unity's built in PlayerPrefs or using a local server using PHP scripts.

If you wish to use a MAMP server please follow this tutorial [here](https://www.youtube.com/watch?v=N0CPgBrjpl8&ab_channel=QVisible).
From there you can then download the PHP scripts contained in the [Server Scripts](ServerScripts) folder. These will need to be added
to your htdocs or WWW folder to allow the game to communicate with the local server.

The server interactions will only work when playing locally in the Unity Editor unless CORS compatibility is added to your local server.

## Testing
The game makes use of 101 Unity tests to test the logic and playing of the game to ensure the functions of the game perform reliablly.
You can find these tests by downloading the game locally to play with the Unity Editor.

## Built With
The game is built using the Unity Engine for the WebGL platform.

## Author
Jeff Hale

Senior Computer Science student Northeastern State University.

## License
This project is licensed under the MIT License – see the [LICENSE.md](LICENSE) file for details 

## Acknowledgements
Thank to Dr. Bekkering for giving me a challenging game project for the Spring 24 semester.
