# Gilded Rose Requiements

This document summarizes the requirements related to the Guilded Rose Kata

| Id     | Description 
|--------|--------------
|        | Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a prominent city ran by a friendly innkeeper named Allison. We also buy and sell only the finest goods. 
| R1     | We have a system in place that updates our inventory for us. 
|        | It was developed by a no-nonsense type named Leeroy, who has moved on to new adventures.
|        | Your task is to add the new feature to our system so that we can begin selling a new category of items.
| R2     | Unfortunately, our goods are constantly degrading in quality as they approach their sell by date.
|        | First an introduction to our system:
| R2.1   |  - All items have a Quality value which denotes how valuable the item is
| R3     | 	- All items have a SellIn value which denotes the number of days we have to sell the item
| R4.1   | 	- At the end of each day our system lowers both values for every item
| R4.2   | 	- Once the sell by date has passed, Quality degrades twice as fast
| R4.3   | 	- The Quality of an item is never negative
| R4.4   | 	- The Quality of an item is never more than 50
| R4.5   | 	- "Aged Brie" actually increases in Quality the older it gets
| R4.6   | 	- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches; Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
| R5     | 	- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
| R6     | 	- "Conjured" items degrade in Quality twice as fast as normal items
| R7     | Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.
|        | Feel free to make any changes to the UpdateQuality method and add any new code as long as everything still works correctly.
| R10    | However, do not alter the Item class or Items property as those belong to the goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code ownership (you can make the UpdateQuality method and Items property static if you like, we'll cover for you).

