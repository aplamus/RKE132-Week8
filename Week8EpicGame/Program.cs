string folderPath = @"C:\Users\\source\repos\Week8EpicGame\Data";
string heroFile = "heroes.txt";
string villainsFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainsFile));
string[] weapons = { "rock", "paper", "scissors" };

// heros
string hero = randomSelection(heroes);
string heroWeapon = randomSelection(weapons);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroWeapon} saves the day!");

// villains
string villain = randomSelection(villains);
string villainWeapon = randomSelection(weapons);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainWeapon} tries to take over the world!");

static string randomSelection(string[] myArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, myArray.Length);
    string randomStringFromArray = myArray[randomIndex];
    return randomStringFromArray;
}

while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");


if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine($"Draw!");
}


static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 7)
    {
        return 7;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
}