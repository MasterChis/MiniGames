namespace MiniGames
{
    public class PPT
    {
        string selector = String.Empty;
        string[] shoter = new string[] {"Jugador", "Maquina"};
        int shoterPlayer;
        int shoterCPU;

        //Esto recontruye los valores por defecto
        private void BuiltPPT()
        {
            selector = String.Empty;
            shoterPlayer = 0;
            shoterCPU = 0;
        }
        //El jugador realiza su tiro
        private bool PlayerShot()
        {
            Console.Write("    ¿Que desea tirar?: ");
            selector = Console.ReadLine();

            //Si no es numerico
            //Si no esta en el rango
            //Es falso
            if (!int.TryParse(selector, out shoterPlayer)) return false;
            if (shoterPlayer < 0 || shoterPlayer >= 4) return false;

            MessageShot(shoter[0], shoterPlayer);
            return true;
        }
        //La maquina realiza su tiro
        private void MachineShot()
        {
            //Se genera el tiro segun el rango proporcionado (1-3)
            Random random = new Random();
            shoterCPU = random.Next(1, 4);

            MessageShot(shoter[1], shoterCPU);
        }
        //Mostramos un mensaje del tirador y el tiro
        private void MessageShot(string shoter, int shot)
        {
            switch (shot)
            {
                case 1:
                    Console.WriteLine($"    {shoter} tira 'Piedra'");
                    break;
                case 2:
                    Console.WriteLine($"    {shoter} tira 'Papel'");
                    break;
                case 3:
                    Console.WriteLine($"    {shoter} tira 'Tijera'");
                    break;
                default:
                    Console.WriteLine("    Tiro no valido");
                    return;
            }
        }
        //Se deternima quien gano
        private void Winner()
        {
            //Si ambos realizan el mismo tiro
            if(shoterPlayer == shoterCPU)
            {
                Console.WriteLine("    --- Hay un empate ---");
                return;
            }
            //Segun el tiro de jugador
            switch (shoterPlayer)
            {
                //Piedra
                case 1:
                    if (shoterCPU == 2) Console.WriteLine("    --- Maquina Gana ---");
                    else Console.WriteLine("    --- Jugador Gana ---");
                    break;
                //Papel
                case 2:
                    if (shoterCPU == 3) Console.WriteLine("    --- Maquina Gana ---");
                    else Console.WriteLine("    --- Jugador Gana ---");
                    break;
                //Tijera
                case 3:
                    if (shoterCPU == 1) Console.WriteLine("    --- Maquina Gana ---");
                    else Console.WriteLine("    --- Jugador Gana ---");
                    break;
            }
            Console.ReadKey();
        }
        //Precarga el juego (lo prepara para comenzar a jugar)
        public void InitialGame()
        {
            string cont = String.Empty;
            do
            {
                //this.BuildBoard();
                this.StartGame();

                //Pregunta si desea continuar
                Console.Write("¿Continuar Jugando? (S/N): ");
                cont = Console.ReadLine();

            } while (cont == "S" || cont == "s" || cont == "Y" || cont == "y");
        }
        //Inicia el juego
        private void StartGame()
        {
            do
            {
                BuiltPPT();
                Console.Clear();
                Console.WriteLine("== Piedra, Papel o Tijera ==");
                Console.WriteLine("\tPiedra  |  1");
                Console.WriteLine("\tPapel   |  2");
                Console.WriteLine("\tTijera  |  3");

                //Si el tiro no es valido, se pregunta de nuevo
            } while (!PlayerShot());
            //Se carga el tiro de la maquina
            MachineShot();

            Winner();
        }
    }
}
