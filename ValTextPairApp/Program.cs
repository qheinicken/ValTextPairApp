using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FizzBuzzDLL;

namespace ValTextPairApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] _params = { "1", "1000000000", "4", "Fin", "6", "Fang", "9", "Foom", "12", "Fah" };

            ValTextPairEngine engine = null;

            ValTextPairEngine.TryCreate(_params, out engine);

            if (engine.IsValid)
            {
                //engine.Process();
                //Console.WriteLine(engine.Output);
                for (int i = engine.Begin; i <= engine.End; i++)
                {
                    Console.WriteLine(ValTextPairEngine.GetTextFromNumber(i, engine.Pairs));
                }
            }
            else
            {
                Console.WriteLine(engine.Error);
            }

            Console.Read();
        }
    }
}
