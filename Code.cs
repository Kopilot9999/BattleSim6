using System;
using System.Collections.Generic;

public class Character{
    public string Name{get; set;}
    public int Health{get; set;}
    public int Level{get; set;}
    public int BaseAttack{get; set;}
    public int Armor{get; set;}
    public Character(string name, int health, int level, int baseAttack, int armor){
        Name = name;
        Health = health;
        Level = level;
        BaseAttack = baseAttack;
        Armor = armor;
        }
        public virtual void Attack(Character target){
            target.Health -= BaseAttack;
            Console.WriteLine($"ви знесли 30 урона ");
        }
        
    }
    
    public class Warrior : Character{
        public Weapon EquippedWeapon;
        public Warrior(string name, int health, int level,int  baseAttack, int armor, Weapon weapon)
            : base(name, health, level, baseAttack, armor)
        {
            EquippedWeapon = weapon;
        }
        
        public override void Attack(Character target)
        {
            target.Health -= BaseAttack + EquippedWeapon.Damage - target.Armor;
            Console.WriteLine($"Воїн зніс {BaseAttack + EquippedWeapon.Damage} урона");
        }
    }

public class Mage : Character{
    public int Mana;
    public Mage(string name, int health, int level,int baseAttack,int armor, int mana)
    : base(name, health, level, baseAttack, armor)
    {
        Mana = mana;
    }
    public void CastHeal(){
        Mana -=20;
        Health +=20;
    }
    public override void Attack(Character target)
        {
            target.Health -= BaseAttack;
            Console.WriteLine($"Маг зніс {BaseAttack} урона");
        }
}
public class Archer : Character{
    public int ArrowCount;
    public Archer(string name, int health, int level,int baseAttack,int armor, int arrowcount)
    : base(name, health, level, baseAttack, armor)
    {
        ArrowCount = arrowcount;
    }
    public void ShootDoubleArrow(){
        ArrowCount -=2;
        Console.WriteLine("Ви вистрелили дві стріли");
    }
    public override void Attack(Character target)
        {
            target.Health -= BaseAttack - target.Armor;
            Console.WriteLine($"лучник зніс {BaseAttack} урона");
        }
}
public class Weapon
{
    public string Title;
    public int Damage;
    public int Durability;
    
}    

class Program
{
        static void Main()
    {
        
        Weapon sword = new Weapon { Title = "Меч", Damage = 25, Durability = 100 };

        Warrior warrior = new Warrior("Гром", 120, 5, 50, 10, sword);
        Mage mage = new Mage("Гендальф", 80, 7, 100, 0, 50);
        Archer archer = new Archer("Леголас", 90, 6, 20, 5, 10); 

        Console.WriteLine("\n=== ПОЧАТОК ТУРНІРУ ===");
        
        List<Character> tournamentFighters = new List<Character>
        {
            warrior,
            mage,
            archer
        };

        
        for (int i = 0; i < tournamentFighters.Count; i++)
        {
            Character attacker = tournamentFighters[i];
            Character target = tournamentFighters[(i + 1) % tournamentFighters.Count];

            Console.WriteLine($"\n{attacker.Name} атакує {target.Name}:");
            
            attacker.Attack(target);

            Console.WriteLine($"Залишок ХП у {target.Name}: {target.Health}");
        }
    }
}
    

