int playerHp = 100;
int enemyHp = 100;
int playerHeal = 20;
int enemyHeal = 10;

Random random = new Random();

bool isAlive = true;

Console.WriteLine("     TURN BASED GAME\n");

do 
{
    PlayerTurn();
    if (isAlive)
    {
        EnemyTurn();
    }
    else
    {
        break;
    }
    
}
while (isAlive);

Console.WriteLine($"     THANKS FOR PLAYING\n\t\t*\n    BY MALFUNCTION SOFTWARE");
Console.ReadKey();

void PlayerTurn()
{
    Console.Write("     - PLAYER TURN -\n[A]ttack\t[H]eal ....... ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "a":
        case "A":
            Thread.Sleep(1000);
            Console.WriteLine("\n\tPLAYER ATTACK");
            int playerAttack = random.Next(0, 30);
            PlayerAttackFunction(playerAttack);
            break;

        case "h":
        case "H":
            Thread.Sleep(1000);
            Console.WriteLine("\n\tPLAYER HEAL\n");
            PlayerHeal();
            break;

        default:
            Console.WriteLine("INVALID INPUT\n");
            PlayerTurn();
            break;
    }
}

void EnemyTurn()
{
    Console.WriteLine("     - ENEMY TURN -\n     ..............");
    int enemyChioce = random.Next(0, 2);
    Thread.Sleep(2000);

    if (enemyChioce > 0)
    {
        Console.WriteLine("\n\tENEMY ATTACK");
        int enemyAttack = random.Next(0, 50);
        EnemyAttackFunction(enemyAttack);
    }
    else
    {
        Console.WriteLine("\n\tENEMY HEAL\n");
        EnemyHeal();
    }
}

void PlayerAttackFunction(int attack)
{
    Console.WriteLine($"\tDAMAGE:{attack}");

    if ( attack < 7)
    {
        Console.WriteLine("\tATTACK MISSED!\n");
    }
    else if ( attack >= 7 && attack < 20)
    {
        Console.WriteLine("\tHIT!\n");
        enemyHp -= attack;

        if ( enemyHp < 0)
        {
            enemyHp = 0;
            isAlive = false;
            Console.WriteLine($"  ***************************\n     ENEMY DEAD. PLAYER WIN\n  ***************************");
        }
    }
    else if (attack >= 20 && attack <= 30)
    {
        Console.WriteLine("\tCRITICAL HIT!\n");
        enemyHp -= attack;

        if (enemyHp < 0)
        {
            enemyHp = 0;
            isAlive = false;
            Console.WriteLine($"  ***************************\n     ENEMY DEAD. PLAYER WIN\n  ***************************");
        }
    }

    Console.WriteLine($"  player_HP:{playerHp}\t   enemy_HP: {enemyHp}\n\n**************************************");

}

void EnemyAttackFunction(int attack)
{
    Console.WriteLine($"\tDAMAGE:{attack}");

    if (attack < 10)
    {
        Console.WriteLine("\tATTACK MISSED!\n");
    }
    else if (attack >= 10 && attack < 30)
    {
        Console.WriteLine("\tHIT!\n");
        playerHp -= attack;

        if (playerHp < 0)
        {
            playerHp = 0;
            isAlive = false;
            Console.WriteLine($"  ***************************\n     PLAYER DEAD. ENEMY WIN\n  ***************************");
        }
    }
    else if (attack >= 30 && attack <= 50)
    {
        Console.WriteLine("\tCRITICAL HIT!\n");
        playerHp -= attack;

        if (playerHp < 0)
        {
            playerHp = 0;
            isAlive = false;
            Console.WriteLine($"  ***************************\n     PLAYER DEAD. ENEMY WIN\n  ***************************");
        }
    }

    Console.WriteLine($"  player_HP:{playerHp}\t   enemy_HP:{enemyHp}\n\n**************************************");
}

void PlayerHeal()
{
    if (playerHp < 100)
    {
        playerHp += playerHeal;

        if (playerHp > 100)
        {
            playerHp = 100;
        }
    }

    Console.WriteLine($"  player_HP:{playerHp}\t   enemy_HP: {enemyHp}\n\n**************************************");
}

void EnemyHeal()
{
    if (enemyHp < 100)
    {
        enemyHp += enemyHeal;

        if (enemyHp > 100)
        {
            enemyHp = 100;
        }
    }

    Console.WriteLine($"  player_HP:{playerHp}\t   enemy_HP: {enemyHp}\n\n**************************************");
}




