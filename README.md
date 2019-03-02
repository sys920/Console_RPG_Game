# Console_RPG_Game
Enjoy old console RPG game, make your hero more stronger through buying items each fight. 
-This Game has Hero and Monster, gives some functionality fight, buy items(Swords, Armors, Shields, Potions) and there are some reward for 
winning game. also this game is turn base game, when your hero win the game, get point and great achievement. 
Don't fail the fight. Have fun !!! 
- C# Console program practise using Linq, Interface, List base on OOP. 

# Code
Dist :  setup.exst  you can install and run to play this game
OOP_RPG : 
- Program.cs : Make new game  
- game.cs : main menu for game
- Hero.cs : Most function run here 
   
- Achievement.cs : Achievement class 
- IAchievement.cs : interface class for achievement 
- AchievementManager.cs : Managing Achievement
- Quest.cs : Just show what the Achievement is inside of the game  
 
- Hero.cs : Hero character class
- Monster.cs : Enemy character class and generate monstesrs 
- Fight.cs : main for fighting between Hero and Reandom Monster
- Shop.cs.cs : buying, selling items

- MonsterLevel.cs : using enum class for Monster Level
- MonsterSelector.cs : selector monster randomly each stage
- MonsterofTheDay.cs  : selector monste base on weekday 

- Armor.cs : Armor item class for strenth 
- IArmor.cs : interface class for armor
- Weapon.cs : weapon item class for defense  
- IWeapon.cs : interface class for weapon 
- Shield.cs : Shield item class for defense
- IShield.cs : interface class for Shield 
- Potion.cs : items for health for hero

# Requirement 
- The hero to fight only a range of 5 monsters per day based on the weekday. A monster should be selected randomly every time a new fight starts
- The amount of gold earned should be random based on the monster difficulty level
- The hero should be able to buy weapons and armors from the Shop. Weapons should have a Name, Strength and Price. Armors should have a Name, Defense and Price. Make sure the hero has enough gold coins to buy the item and that the item gets added to the hero’s bag.
- To allow the hero to equip/un-equip items that he has bought in the shop.
- Change the damage calculation for the fight. Currently there is no RNG factor and also we need to take into consideration when the hero has equipped armor/weapon
- Allowed to buy the potions and use them during or outside of the fight. Make sure that when using the potions, the hero’s health doesn’t go above the maximum health(HeroOriginal) and that you remove the potion after the usage. 
- Add the ability for the hero to sell items in the shop
- Add an achievement system for the game. Achievements are goals that can be accomplished while playing the game
