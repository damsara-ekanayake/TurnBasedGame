int playerHp = 100;
int enemyHp = 100;
int playerHeal = 20;
int enemyHeal = 10;

Random random = new Random();

bool isAlive = true;

Console.WriteLine("TURN BASED GAME\n");

do
{
    PlayerTurn();
    EnemyTurn();
}
while (isAlive);

Console.ReadKey();

void PlayerTurn()
{
    Console.Write("player turn\n[A]ttack\t[H]eal ....... ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "a":
        case "A":
            Console.WriteLine("\nPLAYER ATTACK");
            int playerAttack = random.Next(0, 30);
            PlayerAttackFunction(playerAttack);
            break;

        case "h":
        case "H":
            Console.WriteLine("\nPLAYER HEAL\n");
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
    Console.WriteLine("enemy turn\n\t..............");
    int enemyChioce = random.Next(0, 2);
    Thread.Sleep(2000);

    if (enemyChioce > 0)
    {
        Console.WriteLine("\nENEMY ATTACK");
        int enemyAttack = random.Next(0, 50);
        EnemyAttackFunction(enemyAttack);
    }
    else
    {
        Console.WriteLine("\nENEMY HEAL\n");
        EnemyHeal();
    }
}

void PlayerAttackFunction(int attack)
{
    Console.WriteLine($"attack:{attack}");

    if ( attack < 7)
    {
        Console.WriteLine("ATTACK MISSED!\n");
    }
    else if ( attack >= 7 && attack < 20)
    {
        Console.WriteLine("HIT\n");
        enemyHp -= attack;

        if ( enemyHp < 0)
        {
            enemyHp = 0;
            isAlive = false;
            Console.WriteLine("ENEMY DEAD. PALYER WIN");
        }
    }
    else if (attack >= 20 && attack <= 30)
    {
        Console.WriteLine("CRITICAL HIT\n");
        enemyHp -= attack;

        if (enemyHp < 0)
        {
            enemyHp = 0;
            isAlive = false;
            Console.WriteLine("ENEMY DEAD. PLAYER WIN");
        }
    }

    Console.WriteLine($"\tplayer_HP:{playerHp}\tenemy_HP: {enemyHp}\n");

}

void EnemyAttackFunction(int attack)
{
    Console.WriteLine($" attack:{attack}");

    if (attack < 10)
    {
        Console.WriteLine("ATTACK MISSED!\n");
    }
    else if (attack >= 10 && attack < 30)
    {
        Console.WriteLine("HIT\n");
        playerHp -= attack;

        if (playerHp < 0)
        {
            playerHp = 0;
            isAlive = false;
            Console.WriteLine("PLAYER DEAD. ENEMY WIN");
        }
    }
    else if (attack >= 30 && attack <= 50)
    {
        Console.WriteLine("CRITICAL HIT\n");
        playerHp -= attack;

        if (playerHp < 0)
        {
            playerHp = 0;
            isAlive = false;
            Console.WriteLine("PLAYER DEAD. ENEMY WIN");
        }
    }

    Console.WriteLine($"\tplayer_HP:{playerHp}\tenemy_HP:{enemyHp}\n");
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

    Console.WriteLine($"\tplayer_HP:{playerHp}\tenemy_HP: {enemyHp}\n");
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

    Console.WriteLine($"\tplayer_HP:{playerHp}\tenemy_HP: {enemyHp}\n");
}




