using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; }
        public int Defense { get; }
        public int OriginalHP { get; }
        public int CurrentHP { get; set; }
    
        public IWeapon EquippedWeapon { get; set; }
        public IArmor EquippedArmor { get; set; }
        public IShield EquippedShield { get; set; }

        public List<IShop> HeroBag { get; private set; }
        public List<Potion> PotionsBag { get; set; }
        public int GoldCoin { get; set; }

        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero()
        {
            HeroBag = new List<IShop>();
            PotionsBag = new List<Potion>();
            
            //Balanced Hro
            Strength = 9;
            Defense = 11;
            OriginalHP = 30;
            CurrentHP = 30;
            GoldCoin = 10;
  
            //Test Hero 
            //Strength = 50;
            //Defense = 50;
            //OriginalHP = 100;
            //CurrentHP = 100;
            //GoldCoin = 100;

        }

        //These are the Methods of our Class.
        public void ShowStats()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"***** HERO { this.Name}'s STATS *****");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine($"# Strength: {this.Strength} {(this.EquippedWeapon == null ? "" : "(+" + this.EquippedWeapon.Strength + ")")}");            
            Console.WriteLine($"# Defense armor: {this.Defense} {(this.EquippedArmor == null ? "" : "(+" + this.EquippedArmor.Defense +")")}");
            Console.WriteLine($"# Defense shield:{(this.EquippedShield == null ? "0": "(+" + this.EquippedShield.Defense + ")")}");
            Console.WriteLine("# Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);

            Console.WriteLine("# Potion(s): ");
            DisplayPotion();

            Console.WriteLine("# Gold coins: " + this.GoldCoin);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"*****  HERO { this.Name}'s INVENTORY ******");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            //Display Weapon Items 
            Console.WriteLine("#####  Weapon(s) Bag  #####");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            var unEquippedWeapons = GetWeapons().Where(p => p != EquippedWeapon).ToList();
            if (unEquippedWeapons.Count() != 0)
            {
                for (var i = 0; i < unEquippedWeapons.Count(); i++)
                {
                    Console.WriteLine(String.Format("{0,3} | {1,-20} | {2,-15} |", i + 1, unEquippedWeapons[i].Name, unEquippedWeapons[i].Strength + " Strength"));
                }                               
            }
            else
            {
                Console.WriteLine(" Nothing ");
            }

            //Display Armor Items
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("#####  Armor(s) Bag  #####");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            var unEquippedArmors = GetArmors().Where(p => p != EquippedArmor).ToList();
            if (unEquippedArmors.Count() != 0 )
            {  
                for(var i = 0; i < unEquippedArmors.Count(); i ++ )
                {
                    Console.WriteLine(String.Format("{0,3} | {1,-20} | {2,-15} |", i+1, unEquippedArmors[i].Name, unEquippedArmors[i].Defense + " Defense"));
                }
            }
            else
            {
                Console.WriteLine(" Nothing ");
            }

            //Display Shield Items
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("#####  Shield(s) Bag  #####");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            var unEquippedShield = GetShield().Where(p => p != EquippedShield).ToList();
            if (unEquippedShield.Count() != 0)
            {
                
                for (var i = 0; i < unEquippedShield.Count(); i++)
                {
                    Console.WriteLine(String.Format("{0,3} | {1,-20} | {2,-15} |", i + 1, unEquippedShield[i].Name, unEquippedShield[i].Defense + " Defense"));
                }
            }
            else
            {
                Console.WriteLine(" Nothing ");
            }

            //Current Equipped Items
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("#####  Current Equipped Item(s)  #####");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            if (EquippedWeapon != null || EquippedArmor != null || EquippedShield != null)
            {
                if (EquippedWeapon != null)
                {
                    Console.WriteLine(String.Format(" {0,-8} | {1,-20} | {2,-15} |", "[Weapon]", EquippedWeapon.Name, "+"+EquippedWeapon.Strength + " Strenth"));
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                }
                if (EquippedArmor != null)
                {
                    Console.WriteLine(String.Format(" {0,-8} | {1,-20} | {2,-15} |", "[Armor]", EquippedArmor.Name, "+"+EquippedArmor.Defense + " Defense"));
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                }
                if (EquippedShield != null)
                {
                    Console.WriteLine(String.Format(" {0,-8} | {1,-20} | {2,-15} |", "[Shield]", EquippedShield.Name, "+"+ EquippedShield.Defense + " Defense"));
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                }
            }
            else 
            {
                Console.WriteLine(" Nothing ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }        
           
        }

        public void EquipWeapon(int index)
        {
            var unEquippedWeapon = GetWeapons().Where(p => p != EquippedWeapon).ToList();

            if (unEquippedWeapon.Count() != 0)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------"); 

                if (index > unEquippedWeapon.Count() || index < 0 )
                {
                    Console.WriteLine("Type corrent the weapon Id !");
                }
                else
                {
                    var weapon = unEquippedWeapon[index];
                    this.EquippedWeapon = weapon;
                    Console.WriteLine($"'{unEquippedWeapon[index].Name}' is equipped ");
                }
          
                Console.WriteLine("----------------------------------------------------------------------------------------------");
        
            }
            else
            {
                Console.WriteLine("You don't have any weapon, or Type corrent weapon Id");
                Console.ReadKey();
            }
        }

        public void UnEquipWeapon()
        {
            if (this.EquippedWeapon != null)
            {                             
                Console.WriteLine($"'{this.EquippedWeapon.Name}' is now unequipped ");
                this.EquippedWeapon = null;
            }
            else
            {
                Console.WriteLine("You don't have any weapon equipped");
                Console.ReadKey();
            }
        }

        public void EquipArmor(int index)
        {
            var unEquippedArmors = GetArmors().Where(p => p != EquippedArmor).ToList();
            if (unEquippedArmors.Count() != 0)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");   
                
                if (index > unEquippedArmors.Count() || index < 0 )
                {
                    Console.WriteLine("Type corrent the armor Id !");
                }
                else
                {
                    var armor = unEquippedArmors[index];
                    this.EquippedArmor = armor;
                    Console.WriteLine($"'{unEquippedArmors[index].Name}' is equipped ");
                   
                }
                
                Console.WriteLine("----------------------------------------------------------------------------------------------");
               
            }
            else
            {
                Console.WriteLine("You don't have any armor, or Type corrent armor Id");
                Console.ReadKey();
            }
        }

        public void UnEquipArmor()
        {
            if (this.EquippedArmor != null)
            {
                Console.WriteLine($"'{this.EquippedArmor.Name}' is now unequipped ");
                this.EquippedArmor = null;
            }
            else
            {
                Console.WriteLine("You don't have any armor equipped");
                Console.ReadKey();
            }
        }

        public void EquipShield(int index)
        {
            var unEquippedShield = GetShield().Where(p => p != EquippedShield).ToList();
            if (unEquippedShield.Count() != 0)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");

                if (index > unEquippedShield.Count() || index < 0)
                {
                    Console.WriteLine("Type corrent the shield Id !");
                }
                else
                {
                    var shield = unEquippedShield[index];
                    this.EquippedShield = shield;
                    Console.WriteLine($"'{unEquippedShield[index].Name}' is equipped ");

                }

                Console.WriteLine("----------------------------------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("You don't have any shield, or Type corrent shield Id ");
                Console.ReadKey();
            }
        }

        public void UnEquipShield()
        {
            if (this.EquippedShield != null)
            {
                Console.WriteLine($"'{this.EquippedShield.Name}' is now unequipped ");
                this.EquippedShield = null;
            }
            else
            {
                Console.WriteLine("You don't have any shield equipped");
                Console.ReadKey();
            }
        }

        public int GetUserInputNumber()
        {
            //Checking validation the date pickup
            bool inputnumberValid = false;
            int keyInputResult = 0;
            
            while (inputnumberValid != true)
            {
               
                if (int.TryParse(Console.ReadLine(), out keyInputResult))
                {
                    inputnumberValid = true;
                }
                else
                {
                    Console.Write("Type the number only or '0' to exit : ");                   
                }
            }
            return keyInputResult;
        }

        public void DisplayPotion()
        {
            var potionQuery = (from potion in PotionsBag
                               group potion by potion.Name into newGroup
                               select new
                               {
                                   Name = newGroup.Key,
                                   Quantyty = newGroup.Count()
                               }).ToList();
            if (potionQuery.Count() != 0)
            {
                for (var i = 0; i < potionQuery.Count(); i++)
                {
                    Console.WriteLine($" {i + 1}. {potionQuery[i].Name} ({potionQuery[i].Quantyty})");
                }
            }
            else
            {
                Console.WriteLine($" [No potion yet]");
            }
            
        }

        public void UsingPotion()
        {
            var potionQuery = (from potion in PotionsBag
                               group potion by potion.Name into newGroup
                               select new
                               {
                                   Name = newGroup.Key,
                                   Quantity = newGroup.Count()
                               }).ToList();

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            if (potionQuery.Count() != 0)
            {
                    for (var i = 0; i < potionQuery.Count(); i++)
                    {
                    Console.WriteLine($" {i + 1}. {potionQuery[i].Name} ({potionQuery[i].Quantity})");
                    }

                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.Write("Selet the potion to use: ");
                var KeyInput = GetUserInputNumber();

                //var pppotion = PotionsBag.ElementAtOrDefault(0);

                if (KeyInput > potionQuery.Count() || KeyInput <= 0)
                {
                    Console.WriteLine("Type corrent the potion ID !");

                }
                else
                {
                    var usingPotionQuery = (from potion in PotionsBag
                                            where potion.Name == potionQuery[KeyInput - 1].Name
                                            select potion).FirstOrDefault();


                    this.CurrentHP = this.CurrentHP + usingPotionQuery.HealthRestored;

                    if (this.CurrentHP > this.OriginalHP)
                    {
                        Console.WriteLine($"You don't need to drink potion at this point, You wasted ({this.CurrentHP - this.OriginalHP})! ");
                        this.CurrentHP = this.OriginalHP;                        
                    }

                    PotionsBag.Remove(usingPotionQuery);

                    Console.WriteLine($"Drink '{potionQuery[KeyInput - 1].Name}' successfully!");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine($" You don't have any potion");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
        }
                       
        public IReadOnlyList<IWeapon> GetWeapons()
        {
            return HeroBag.Where(p => p is IWeapon).Cast<IWeapon>().ToList();
        }

        public IReadOnlyList<IArmor> GetArmors()
        {
            return HeroBag.Where(p => p is IArmor).Cast<IArmor>().ToList();
        }

        public IReadOnlyList<IShield> GetShield()
        {
            return HeroBag.Where(p => p is IShield).Cast<IShield>().ToList();
        }

    }
}