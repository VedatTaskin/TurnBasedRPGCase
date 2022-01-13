# TurnBasedRPGCase


PLAYER<br>
• Players' properties (Shape, Size and Color) are created as scriptable objects and assigned through the HeroCreator object.<br>
• The created 10 Heroes are displayed in the menu. When the desired number of cards (default 3, but a different value can be entered-from the HeroCreator object-) is selected, the game start button becomes active.<br>
• When the game is started, the selected cards are instantiated as GameObjects via the BattlePreparation script.<br>

ENEMY<br>
• The shape features of the enemy in the game (color also random) are given by choosing one of the 10 randomly generated Heroes.<br>
• Enemy AP and HP values ​​are randomly assigned.<br>

SHAPE, SIZE AND COLOR SCRIPTABLE OBJECTS<br>
• Different sprites and materials can be assigned to the created SOs.<br>
• Options in SOs are taken from Enum (Enum Holder). Different options can be added and reduced here.<br>

STATES<br>
• State Pattern has been tried to be used, considering that the game can expand.<br>

EVENTS<br>
• Events in the game are kept in the EventManager for easy tracking.<br>

BATTLE<br>
• When the characters interact in the game, their colliders are temporarily closed and a small animation (with DOTween) is played during this time.<br>
• A text and return button are activated depending on whether the game is won or lost.<br>


You can play game 
https://taskinvedat.itch.io/turnbasedrpgcase
