using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class AchievementManager
    {     
        private List<Achievement> Achievements { get; set; }
        private List<Quest> Quests { get; set; }
        private List<Monster> Kills { get; set; }

        public AchievementManager()
        {
            Achievements = new List<Achievement>();
            Quests = new List<Quest>();
            Kills = new List<Monster>();
            GenerateQuests();
        }

        public void GenerateQuests()
        {   //Add more Quest!  
            //AchivementName, DifferentMonster, Kill, point, Complete
            Quests.Add(new Quest("Killing 1 monster",false, 1, 1, false));
            Quests.Add(new Quest("Killing 2 monsters", false, 2, 3, false));
            Quests.Add(new Quest("Killing 3 monsters", false, 3, 5, false));
            Quests.Add(new Quest("Killing 5 different monsters", true, 5, 15, false));
            Quests.Add(new Quest("Killing 10 monsters",false, 10, 25, false));
            Quests.Add(new Quest("Killing 15 monsters ", true, 15, 25, false));           
        }

        //whenever Hero win the game, save enemy into kill<list> 
        public void SavingMonsterKills (Monster enemy)
        {           
            Kills.Add(enemy);

            //After winning game, check kills for message and achievement
            CheckingAchievement();
        }

        public void DisplayQuest()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("*****  Game Quests  ******");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-30} | {2, 5} | {3,11} |", "Num", "QuestName", "Point", "Status"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            if (Quests.Count() != 0)
            {
                for (var i = 0; i < Quests.Count(); i++)
                {
                   Console.WriteLine(String.Format("{0,3} | {1,-30} | {2, 5} | {3, 11} |", (i + 1), Quests[i].Name, Quests[i].Point, (Quests[i].Complete ? "[Completed]" : "")));
                }
            }
            else
            {
                Console.WriteLine($"Sorry, no quest now!");
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }

        public void DispalyAchievement()
        {
            var totalAchievementPoint = 0;
            for (var i = 0 ; i < Achievements.Count(); i++ )
            {
                totalAchievementPoint += Achievements[i].Point;
            }
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"****  Achievement (Total : {totalAchievementPoint} point(s))  ******");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-30} | {2,-7} | {3,-20} |", "Num", "AchievementName", "Point", "Completed Date"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            if (Achievements.Count() != 0)
            {                
                for (var i = 0; i < Achievements.Count(); i++)
                {        
                    Console.WriteLine(String.Format("{0,3} | {1,-30} | {2,-7} | {3,-20} |", (i + 1), Achievements[i].Name, Achievements[i].Point, Achievements[i].Date.ToString("MMMM dd HH:mm tt")));
                } 
            }
            else
            {
                Console.WriteLine($"Sorry, you don't have any achivement");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }

        public void CheckingAchievement()
        {
            for(var i = 0; i < Quests.Count(); i++)
            {
                if(Quests[i].Difference == true)
                {
                    //Diaplay achievement a message. In case of different Monster
    
                    var exceptDuplicateList = Kills.Select(x => x.Name).Distinct().ToList();

                    if (exceptDuplicateList.Count() == Quests[i].Kill && Quests[i].Complete == false)
                    {
                        DisplayAchieveMessage(i);
                    }
                }
                else
                {
                    //Diaplay achievement a message. In case of Any Monster
                    if (Kills.Count() == Quests[i].Kill && Quests[i].Complete == false)
                    {
                        DisplayAchieveMessage(i);
                    }
                }                               
            }   
        }

        //Diaplay achievement a message method
        public void DisplayAchieveMessage(int index)
        {
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine($"****    You have achieved '{Quests[index].Name}' and get {Quests[index].Point} point   ****");
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("********************************************************************************************");

            //Set this quest is completed 
            Quests[index].Complete = true;
            Achievements.Add(new Achievement(Quests[index].Name, Quests[index].Point, DateTime.Now));
        }
    }
}
