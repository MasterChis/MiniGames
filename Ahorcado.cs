namespace MiniGames
{
    public class Ahorcado
    {
        string wordHidden = String.Empty, wordVisible = String.Empty;
        char[] letterHidden, letterVisible;
        string letter = String.Empty;
        int tryMax, tryCurrent;
        string[] listObject =
        {
            "jarra",
            "vaso",
            "plato",
            "cuchara",
            "tenedor",
            "regla",
            "lapiz",
            "mochila",
            "pelota",
            "soga",
            "caja",
            "zapatilla",
            "pantalon",
            "pincel",
            "olla",
            "papel",
            "carpeta",
            "cuaderno",
            "libro",
            "celular",
            "telefono",
            "libreta",
            "tijera",
            "aguja",
            "hilo",
            "broche",
            "jabon",
            "martillo",
            "escoba",
            "clavo"
        };

        //Generar palabra a descubrir
        private void WordRandom()
        {
            //Reinicia los valores
            tryMax = 0;
            tryCurrent = 0;
            wordHidden = String.Empty;
            wordVisible = String.Empty;

            Random random = new Random();
            int objectRandom = random.Next(0, listObject.Count());

            //Combierte a un array a la palabra elegida
            //Dimensionamos el array para la palabra visible
            letterHidden = listObject[objectRandom].ToArray();
            letterVisible = new char[letterHidden.Length];

            //Llenamos el array con '-'
            for(int i = 0; i < letterHidden.Length; i++)
            {
                letterVisible[i] = '-';
            }

            tryMax = letterHidden.Length + 5;
        }
        //Mostramos las letras
        private void ShowLetter()
        {
            wordHidden = String.Empty;
            wordVisible = String.Empty;

            for (int i = 0; i < letterHidden.Length; i++)
            {
                wordHidden += letterHidden[i];
                wordVisible += letterVisible[i];
            }
            //Console.WriteLine($"\t{wordHidden}");
            Console.WriteLine($"\t{wordVisible}");
        }

        //Comprobamos si el valor introducido es valido
        private bool LetterValid()
        {
            int isNumber;

            if (letter.Length > 1 || letter.Length == 0) return false;
            if (int.TryParse(letter, out isNumber)) return false;

            return true;
        }
        //Busca si la letra proporcionada es parte de la palabra
        private void TryToFindTheLetter()
        {
            int count = 0;

            for (int i = 0; i < letterHidden.Length; i++)
            {
                if (letterHidden[i] == char.Parse(letter))
                {
                    letterVisible[i] = char.Parse(letter);
                } else count++;
            }
            //Si las vueltas completas, quiere decir que al menos letra 
            //forma parte de la palabra [Si acierta no pierde una oportunidad]
            if (count == letterHidden.Length) tryCurrent++;

        }
        //Verifica si hay intentos disponibles
        private bool AttemptsAvailable()
        {
            if (tryCurrent >= tryMax) {

                Console.WriteLine("------ Ha Perdido -----");
                return false; 
            }
            
            return true;
        }
        //Averifua si se ha completado la palabra
        private bool CompletedWord()
        {
            if (wordHidden == wordVisible)
            {
                Console.WriteLine("------ Ha Ganado ------");
                Console.ReadKey();
                return true;
            }
            return false;
        }

        //Precarga el juego (lo prepara para comenzar a jugar)
        public void InitialGame()
        {
            string cont = String.Empty;
            do
            {
                this.WordRandom();
                this.StartGame();

                //Pregunta si desea continuar
                Console.Write("\n¿Continuar Jugando? (S/N): ");
                cont = Console.ReadLine();

            } while (cont == "S" || cont == "s" || cont == "Y" || cont == "y");
        }
        //Inicia el juego
        private void StartGame()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("=== A H O R C A D O ===");
                Console.WriteLine($"   [Intento: {tryCurrent}/{tryMax}]");

                //Muestra las letras
                ShowLetter();
                if (tryCurrent == (tryMax - 1)) Console.WriteLine("Ultimo intento");
                if (!CompletedWord())
                {
                    Console.Write("Introduzca una letra: ");
                    letter = Console.ReadLine();
                }
                else return;
                
                
                //Si el valor introducido es valido
                //Busca si forma parte de la palabra a descubrir
                if (LetterValid()) TryToFindTheLetter();
                else
                {
                    Console.WriteLine("Usted no ha introducido una letra, intente de nuevo");
                    Console.ReadKey();
                }

            } while (AttemptsAvailable());
        }

    }
}
