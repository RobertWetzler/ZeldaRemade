# CSE3902_Group 

# Legend of Zelda Level 1 Dungeon Clone
Developers: 
- Jacob Batt
- Maggie Feng
- Jena Fogarty 
- Edwin Pallithanam 
- Robert Wetzler
- Yuting Yang

## Keyboard Controls
### Link Movement
#### Link Move Up
- ```W```
- ```↑```
#### Link Move Down
- ```S```
- ```↓```
#### Link Move Left
- ```A```
- ```←```
#### Link Move Right
- ```D```
- ```→```
### Link Attack with Sword
- ```Z```
- ```N```
### Link Use Item
- Bomb: ```1```
- Arrow: ```2```
- Blue Arrow: ```3```
- Boomerang: ```4```
- Blue Boomerang: ```5```
- Flame: ```6```
### Cycle Rooms
- ```Left Mouse Button```
### Quit Game
- ```Q```
### Reset Level
- ```R```

## Mouse Controls
![alt text](https://github.com/RobertWetzler/CSE3902_Group/blob/defc779230380615480dc852efe908662521e6d8/MouseControllerExample.png?raw=true)
### Go To Next Room
- Click the right side of room walls
### Go To Previous Room
- Click the left side of room walls


## Known Bugs
- When Link takes damage, he ignores collision with blocks & wall collision. 
- Link's bounding box is too large so he his head intersects with blocks above causing clunky collision. 
- Enemies do not collide with moveable blocks.
- Link can rapidly fire items. 
- The animation of throwing sword sometimes shown abnormally (flash then disappear).
- Bombs do not damage anything nor collide with anything.
- When enemies are trapped in between two blocks on opposings sides they will become stuck momentarily.

## Missing Features
- Traps target link for movement, so currently our traps do not move.
