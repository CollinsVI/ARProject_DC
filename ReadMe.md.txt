Treasure Hunt!

Content:
A Main Menu guide scene
Game Scene with following features:
Collect coins that pop up in the environment to earn points.
You have 60 seconds to collect as many coins as possible.
You add 10 to your score for every coin that is collected and a coin will spawn in every 2 seconds.
When the 60 seconds expire time will stop and your score will be displayed.

Fixes and additions:
I could not get the coins to spin upright at all times regarding to which plane it was being instantiated on. I attempted to add AlingToWorldUp();
to my scripts and creating a function for an up transform to align with the worlds up vector but it made the coin stop spinning.

Alongside the coin spinning I need to add a Quit or Restart option to the GameOver state. In interest of time for the submission it was not added.
