using MiniGames;
using System;

string select = String.Empty;

do
{
    switch (MenuSelect())
    {
        case "1":
            Gato gameCat = new Gato();
            gameCat.InitialGame();
            break;
        case "2":
            Ahorcado gameHanged = new Ahorcado();
            gameHanged.InitialGame();
            break;
        case "3":
            PPT gamePPT = new PPT();
            gamePPT.InitialGame();
            break;

        default:
            Console.WriteLine("\nUnknown(invalid) option");
            break;
    }
    Console.Write("¿Desea permanecer aqui? (S/N): ");
    select = Console.ReadLine();
} while (select == "S" || select == "s" || select == "Y" || select == "y");
GoodBye();

void GoodBye()
{
    Console.Clear();
    Console.WriteLine("------------Gracias por Jugar------------");
    Console.WriteLine("--------   Creador Master Chis   --------");
    Console.ReadKey();
}

string MenuSelect()
{
    Console.Clear();
    Console.WriteLine("====== Welcome to MiniGames Console======");
    Console.WriteLine("--------- Name ------------ Number ------");
    Console.WriteLine("   Gato(Tic-Tac-Toe)          1         ");
    Console.WriteLine("   Ahorcado                   2         ");
    Console.WriteLine("   Piedra, Papel o Tijera     3         ");
    Console.Write("\nSelect to minigame: ");
    select = Console.ReadLine();

    return select;
}