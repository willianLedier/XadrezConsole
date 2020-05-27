using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {

        static void Main(string[] args)
        {

            var pos = new PosicaoXadrez('a', 1);

            Console.WriteLine(pos);
            Console.WriteLine(pos.ToPosicao());

            Console.Read();


        }
    }
}
