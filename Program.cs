namespace Trabajo_1
{
    //Hecho por Daniel Ruiz-Gopegui y César Navarro
    internal class Program
    {
        public class VariablesGlobales
        {
            public static int jugF = 3, jugC = 3,  //posicion jugador     
                abejaF = 8, abejaC = 3;            //posicion abeja
            public static bool colision = false;
        }
        static Random rnd = new Random();
        // generador de aleatorios (para mover abeja)

        const int ANCHO = 12, ALTO = 9;
        // dimensiones del área de juego

        public static void Main()
        {
            Console.SetWindowSize(ANCHO, ALTO); // tamaño de la consola            
              
            int delta = 300; // retardo entre frames (ms)
             
            bool salir = false, retardo=true;
            Console.Clear();

            Console.SetCursorPosition(VariablesGlobales.jugF, VariablesGlobales.jugC);
            Console.ForegroundColor = ConsoleColor.Blue;       //Inicializamos jugador
            Console.WriteLine("0");

            Console.SetCursorPosition(VariablesGlobales.abejaC, VariablesGlobales.abejaF);
            Console.ForegroundColor = ConsoleColor.Yellow;      //Inicializamos abeja
            Console.WriteLine("+");


            while (!VariablesGlobales.colision)
            {         
                string s = "";
                while (Console.KeyAvailable) s = (Console.ReadKey(true)).KeyChar.ToString();
                if (s == "q")
                {
                    salir = true;
                }
                // movimiento del jugador (en función del input)

                if ((s == "w" || s == "W") && VariablesGlobales.jugF > 0)
                {
                    VariablesGlobales.jugF--;
                }

                else if ((s == "S" || s == "s") && VariablesGlobales.jugF > 0)
                {
                    VariablesGlobales.jugF++;
                }

                else if ((s == "d" || s == "D") && VariablesGlobales.jugC > 0)
                {
                    VariablesGlobales.jugC++;
                }

                else if ((s == "a" || s == "A") && VariablesGlobales.jugC > 0)
                {
                    VariablesGlobales.jugC--;
                }


                // movimiento aleatorio de la abeja
                if (retardo)
                {
                    IA();
                }
                retardo = !retardo;

                // renderizado de las entidades en consola
                Console.Clear();
                Console.SetCursorPosition(VariablesGlobales.jugC, VariablesGlobales.jugF);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("0");
                Colision();
                Console.SetCursorPosition(VariablesGlobales.abejaC, VariablesGlobales.abejaF);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("+");
                Colision();

                System.Threading.Thread.Sleep(delta);              // retardo entre frames
                Console.Clear();
            }
        }
        // detección de colisión
        static void Colision() {
            
            if (VariablesGlobales.jugC == VariablesGlobales.abejaC && VariablesGlobales.jugF == VariablesGlobales.abejaF)
            {
                Console.Clear();
                Console.SetCursorPosition(VariablesGlobales.jugF, VariablesGlobales.jugC);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*");
                VariablesGlobales.colision = true;
            }

        }
        //IA abeja
        static void IA()
        {
            int posx = 0, posy = 0;
            posx=VariablesGlobales.jugC-VariablesGlobales.abejaC;
            posy = VariablesGlobales.jugF - VariablesGlobales.abejaF;
            if(posx<0 )
            {
                VariablesGlobales.abejaC--;
            }
            else if(posy<0 )
            {
                VariablesGlobales.abejaF--;
            }
            else if( posx>0 )
            {
                VariablesGlobales.abejaC++;
            }
            else if(posy>0 )
            {
                VariablesGlobales.abejaF++;
            }
        }

    }
}