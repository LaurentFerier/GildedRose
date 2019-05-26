# GildedRose

This is a refactoring of the GuildedRose Kata I have found here https://github.com/emilybache/GildedRose-Refactoring-Kata.

Requirements have been identifier and expressed in document Requirement.md

The following steps have been performed on the project

1. Projects have been split in two to differenciate business logic code from unit tests 
2. I've moved the Item in the namespace GildedRose.Items, too bad for the goblin... By the way, I also set up the right namespace in for all files
3. I've also created a Stock which felt a better name than GildedRose
4. I have also created updaters for both Quality & SellIn properties. I've checked such updater using both the initial non-regression test and by creating specific unit tests for each