using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace p3z
{
	class SantaClause
	{
		Random rand = new Random(7);

		public List<(int, string)> decodedLetters = new List<(int, string)>(); //lista par: (identyfikator listu, zdekodowane imię dziecka)

        private List<Task> tasks = new List<Task>(); 

		private string DecodeChildName(long number)
		{
			Dictionary<long, string> childrenList = new Dictionary<long, string>() { { 3, "Marek" },
				{ 195421207, "Andrzej" }, { 32416189859, "Agnieszka" }, { 247531, "Kamil" },
				{ 4743953, "Dżesika" }, { 1536839, "Zuzia" }, { 21887587, "Brajanek" },
				{ 1503401, "Ola" }, { 12653723, "Janusz" }, { 522211, "Grażyna" }, {59464991, "Grześ" },
				{ 86281861, "Tomek" } };

			if (childrenList.ContainsKey(number))
				return childrenList[number];
			else
				return "UNKNOWN";
		}

		public void PrepareForChristmas(List<Letter> letters)
		{
			for (int day = 19; day < 24; day++)
			{
                tasks.Add( SendLettersToFactory(letters, day) );

                GoSleep();

                //WhatAbout(letters);
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Ho! Ho! Ho! Wesołych świąt!");
		}
        //public void WhatAbout(List<Letter> letters)
        //{
        //    lock(decodedLetters)
        //    {
        //        if()
        //    }
        //}
		public void GoSleep()
		{
			Console.WriteLine("Mikołaj śpi");
			System.Threading.Thread.Sleep(1000);
		}

        public async Task SendLettersToFactory(List<Letter> list, int day)
        {
            List<Letter> tmplist = new List<Letter>();
            

            foreach (var v in list)
            {
                if (v.ReceivedDay == day) tmplist.Add(v);
            }

            Console.WriteLine("Wysłanie listów do fabryki z {0} grudnia", day);
            List<(int, long)> results = await (ChristmasFactory.ManageLetters(tmplist));

            Console.WriteLine("Przetworzono wszystkie listy z {0} grudnia", day);

            foreach (var elem in results)
            {
                //Console.WriteLine(elem.Item2);
                lock(decodedLetters)
                {
                    decodedLetters.Add(((int)(elem.Item1), DecodeChildName(elem.Item2)));
                }
                
            }

        }

    }

}