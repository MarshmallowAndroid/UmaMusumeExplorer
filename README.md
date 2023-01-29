# Uma Musume Explorer
[![CI](https://github.com/MarshmallowAndroid/UmaMusumeExplorer/actions/workflows/build.yml/badge.svg?branch=master)](https://github.com/MarshmallowAndroid/UmaMusumeExplorer/actions/workflows/build.yml)

A GUI utility for viewing certain assets from the game ウマ娘　プリティーダービー (Uma Musume Pretty Derby) developed by Cygames, Inc.

DISCLAIMER: You must have your own installation of the game from DMM Games to use this utility.
Game data such as stats is not modified in any way, and can be viewed with any SQLite database viewer.

## Functions included

* File browser with search and export
* Audio player with export
* Live music player with export
    * Access more options by right clicking the window
* Race music simulator
* Character info
    * 5 main stats (speed, stamina, etc.) for each costume and its rarity
    * Skill view

## Remarks

This was really only just an audio player because I was mesmerized by the amazing in-game BGM.
However, since I spent a lot of time on that single tool, I thought it would be nice to
practice programming and expand the functionality a little.

In fact, I listen to the BGM while working on this tool. Personal favorites include:
* `gm026`
* `gm003`, `gm041`
* `gm036` ("Lose" jingle and BGM)
* `gm061` ("Draw" jingle and BGM)
* `gm097`, `gm098`, and `gm099`
* `gm133` and `gm133_long`
* `gm171`

## Credits

* [sqlite-net](https://github.com/praeclarum/sqlite-net) for SQLite functionality
* [vgmstream](https://github.com/vgmstream/vgmstream) for the CRIWARE code
* [AssetStudio](https://github.com/Perfare/AssetStudio) for reading Unity assets
