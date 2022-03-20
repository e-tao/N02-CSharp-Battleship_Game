# N02 C# Project Battleship Game

## Introduction
A WinForms application of Battleship game.

The application is required to be able to:
- play with an "AI";
- configure square board size greater or equal to 6x6;
- have at least 3 ships with different sizes all bigger than 1;
- allow both sides have the same number of ships;
- display grid colour according to guessing status; (white: miss, red: hit);

## Features 
The application is designed with the following functions: 
- Default configuration is 3 ships and 8x8 grid, minimu ship and grid constrains are 3 and 6;
- config.ini format: number of ships, number or grids in one line seperate by comma; 
- Only add one ship at a time, cancel button cancels the button not "add";
- validation of added ships, no "tetris" shape is allowed;
- "AI" will try to catch a whole ship once it finds a hit (red) tile;
- Click "START" x times will play with x 'AI' simultaneously;

## Tech
The project uses the following language, toolkit, IDE etc...

- [C#] - The sole language for the application
- [WinForm] -  Graphical class library 
- [Visual Studio] - IDE for C# development
- [git] - version control

## Screenshot
![Application Screenshot](https://github.com/ethantao-repo/N02-PRJ-Battleship_Game/blob/master/screenshot/N02-Project_ScreenShoot.png?raw=true)
