namespace MiniGames
{
    public class Gato
    {
        string[,] board = new string[3, 3];
        int countTurn = 0;
        //Inicializa al primer jugador
        string userMark = "X";
        bool playerGame = false;        
        //Coordenadas proporcionadas por el jugador
        string userCol = String.Empty;
        string userRow = String.Empty;

        //Contruye el tablero y reestablece los valores predeterminados
        private void BuildBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = "#";
                }
            }
            userMark = "X";
            playerGame = false;
            countTurn = 0;
            string userCol = String.Empty;
            string userRow = String.Empty;
        }
        //Dibuja el tablero de juego
        private void DrawnBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + board[i, j]);
                }
                Console.Write("\n");
            }
        }
        //Verifica si el espacio esta disponible
        private bool PositionAvailable()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ("#" == board[i, j]) return true;
                }
            }
            return false;
        }
        //Realiza el cambio de turno del jugador
        private void ChangeTurn()
        {
            switch (playerGame)
            {
                case false:
                    userMark = "O";
                    playerGame = true;
                    break;
                case true:
                    userMark = "X";
                    playerGame = false;
                    break;
            }

        }
        //Verifica el movimiento realizado por el jugador
        private bool MyMovement(string sCol, string sRow, string mark)
        {
            int nCol;
            int nRow;

            if (!int.TryParse(sCol, out nCol)) return false;
            if (!int.TryParse(sRow, out nRow)) return false;

            nCol--;
            nRow--;

            if (nCol >= 3 || nRow >= 3 || nCol < 0 || nRow < 0) return false;
            if (board[nCol, nRow] != "#") return false;

            board[nCol, nRow] = mark;
            countTurn++;
            return true;
        }
        //Busca en el tablero el patron ganador
        private bool Winner()
        {
            string markWinner = String.Empty;
            //Columnas
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == board[1, j] &&
                    board[0, j] == board[2, j])
                    markWinner = board[0, j];
            }
            //Filas
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] &&
                    board[i, 0] == board[i, 2])
                    markWinner = board[i, 0];
            }
            //Cruzados 1
            if (board[0, 0] == board[1, 1] &&
                board[0, 0] == board[2, 2])
                markWinner = board[0, 0];
            //Cruzados 2
            if (board[0, 2] == board[1, 1] &&
                board[0, 2] == board[2, 0])
                markWinner = board[0, 2];

            if (markWinner == "#" || markWinner == "") return false;

            Console.WriteLine($"======= Gano: {markWinner} =======\n  Pulsa para continuar");
            return true;
        }
        //Precarga el juego (lo prepara para comenzar a jugar)
        public void InitialGame()
        {
            string cont = String.Empty;
            do
            {
                this.BuildBoard();
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
                Console.Clear();
                Console.WriteLine("======= G A T O =======");
                Console.WriteLine($"     [Turno de: {userMark}]");
                this.DrawnBoard();

                //Apartir del 5to turno comienza a verificar debido a que si contara 
                //desde el principio seria un esfuezo inutil ya que no se forma el patron ganador
                if (countTurn >= 5) 
                    if (Winner()) return;

                Console.Write("Coord. de la columna: ");
                userRow = Console.ReadLine();
                Console.Write("Coord. de la fila: ");
                userCol = Console.ReadLine();

                if (MyMovement(userCol, userRow, userMark)) ChangeTurn();
                else
                {
                    Console.WriteLine("Jugada No Valida, Intenta de nuevo\nPulsa para continuar");
                    Console.ReadKey();
                }

                //Si hay puestos disponibles continua el juego
            } while (PositionAvailable());
        }

    }
}
