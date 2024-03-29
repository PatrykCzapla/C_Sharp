﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

namespace p3z
{
    public class MovieDatabase
    {
        public List<Movie> movies;

        List<(DateTime date, string name)> holidays = new List<(DateTime, string)>() {(DateTime.Parse("2012-01-02"),"New Year Day"),
                                                                            (DateTime.Parse("2012-01-16"),"Martin Luther King Jr. Day"),
                                                                            (DateTime.Parse("2012-02-20"),"Presidents Day (Washingtons Birthday)"),
                                                                            (DateTime.Parse("2012-05-28"),"Memorial Day"),
                                                                            (DateTime.Parse("2012-07-04"),"Independence Day"),
                                                                            (DateTime.Parse("2012-09-03"),"Labor Day"),
                                                                            (DateTime.Parse("2012-10-08"),"Columbus Day"),
                                                                            (DateTime.Parse("2012-11-12"),"Veterans Day"),
                                                                            (DateTime.Parse("2012-11-22"),"Thanksgiving Day"),
                                                                            (DateTime.Parse("2012-12-25"),"Christmas Day"),
                                                                            (DateTime.Parse("2013-01-01"),"New Year Day"),
                                                                            (DateTime.Parse("2013-01-21"),"Martin Luther King Jr. Day"),
                                                                            (DateTime.Parse("2013-02-18"),"Presidents Day (Washingtons Birthday)"),
                                                                            (DateTime.Parse("2013-05-27"),"Memorial Day"),
                                                                            (DateTime.Parse("2013-07-04"),"Independence Day"),
                                                                            (DateTime.Parse("2013-09-02"),"Labor Day"),
                                                                            (DateTime.Parse("2013-10-14"),"Columbus Day"),
                                                                            (DateTime.Parse("2013-11-11"),"Veterans Day"),
                                                                            (DateTime.Parse("2013-11-28"),"Thanksgiving Day"),
                                                                            (DateTime.Parse("2013-12-25"),"Christmas Day"),
                                                                            (DateTime.Parse("2014-01-01"),"New Year Day"),
                                                                            (DateTime.Parse("2014-01-20"),"Martin Luther King Jr. Day"),
                                                                            (DateTime.Parse("2014-02-17"),"Presidents Day (Washingtons Birthday)"),
                                                                            (DateTime.Parse("2014-05-26"),"Memorial Day"),
                                                                            (DateTime.Parse("2014-07-04"),"Independence Day"),
                                                                            (DateTime.Parse("2014-09-01"),"Labor Day"),
                                                                            (DateTime.Parse("2014-10-13"),"Columbus Day"),
                                                                            (DateTime.Parse("2014-11-11"),"Veterans Day"),
                                                                            (DateTime.Parse("2014-11-27"),"Thanksgiving Day"),
                                                                            (DateTime.Parse("2014-12-25"),"Christmas Day"),
                                                                            (DateTime.Parse("2015-01-01"),"New Year Day"),
                                                                            (DateTime.Parse("2015-01-19"),"Martin Luther King Jr. Day"),
                                                                            (DateTime.Parse("2015-02-16"),"Presidents Day (Washingtons Birthday)"),
                                                                            (DateTime.Parse("2015-05-25"),"Memorial Day"),
                                                                            (DateTime.Parse("2015-07-03"),"Independence Day"),
                                                                            (DateTime.Parse("2015-09-07"),"Labor Day"),
                                                                            (DateTime.Parse("2015-10-12"),"Columbus Day"),
                                                                            (DateTime.Parse("2015-11-11"),"Veterans Day"),
                                                                            (DateTime.Parse("2015-11-26"),"Thanksgiving Day"),
                                                                            (DateTime.Parse("2015-12-25"),"Christmas Day"),
                                                                            (DateTime.Parse("2016-01-01"),"New Year Day"),
                                                                            (DateTime.Parse("2016-01-18"),"Martin Luther King Jr. Day"),
                                                                            (DateTime.Parse("2016-02-15"),"Presidents Day (Washingtons Birthday)"),
                                                                            (DateTime.Parse("2016-05-30"),"Memorial Day"),
                                                                            (DateTime.Parse("2016-07-04"),"Independence Day"),
                                                                            (DateTime.Parse("2016-09-05"),"Labor Day"),
                                                                            (DateTime.Parse("2016-10-10"),"Columbus Day"),
                                                                            (DateTime.Parse("2016-11-11"),"Veterans Day"),
                                                                            (DateTime.Parse("2016-11-24"),"Thanksgiving Day"),
                                                                            (DateTime.Parse("2016-12-25"),"Christmas Day"),
                                                                            (DateTime.Parse("2017-01-02"),"New Year Day"),
                                                                            (DateTime.Parse("2017-01-16"),"Martin Luther King Jr. Day"),
                                                                            (DateTime.Parse("2017-02-20"),"Presidents Day (Washingtons Birthday)"),
                                                                            (DateTime.Parse("2017-05-29"),"Memorial Day"),
                                                                            (DateTime.Parse("2017-07-04"),"Independence Day"),
                                                                            (DateTime.Parse("2017-09-04"),"Labor Day"),
                                                                            (DateTime.Parse("2017-10-09"),"Columbus Day"),
                                                                            (DateTime.Parse("2017-11-10"),"Veterans Day"),
                                                                            (DateTime.Parse("2017-11-23"),"Thanksgiving Day"),
                                                                            (DateTime.Parse("2017-12-25"),"Christmas Day"),
                                                                            (DateTime.Parse("2018-01-01"),"New Year Day"),
                                                                            (DateTime.Parse("2018-01-15"),"Martin Luther King Jr. Day"),
                                                                            (DateTime.Parse("2018-02-19"),"Presidents Day (Washingtons Birthday)"),
                                                                            (DateTime.Parse("2018-05-28"),"Memorial Day"),
                                                                            (DateTime.Parse("2018-07-04"),"Independence Day"),
                                                                            (DateTime.Parse("2018-09-03"),"Labor Day"),
                                                                            (DateTime.Parse("2018-10-08"),"Columbus Day"),
                                                                            (DateTime.Parse("2018-11-12"),"Veterans Day"),
                                                                            (DateTime.Parse("2018-11-22"),"Thanksgiving Day"),
                                                                            (DateTime.Parse("2018-12-25"),"Christmas Day"),
                                                                            (DateTime.Parse("2019-01-01"),"New Year Day"),
                                                                            (DateTime.Parse("2019-01-21"),"Martin Luther King Jr. Day") };

        public MovieDatabase()
        {
            LoadMovies();
        }

        public void LoadMovies()
        {
            string filePath = @"../../movies.csv"; 

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File movies.csv doesn't exist in project directory.");
                return;
            }

            movies = new List<Movie>();

            StreamReader reader = new StreamReader(filePath);
            string line;
            line = reader.ReadLine(); //skip header line
            while ((line = reader.ReadLine()) != null)
            {
                string[] splittedLine = line.Split(';');
                Movie newMovie = new Movie();
                newMovie.title = splittedLine[0];
                newMovie.budget = double.Parse(splittedLine[1]);
                newMovie.genres = splittedLine[2];
                newMovie.original_language = splittedLine[3];
                newMovie.release_date = DateTime.Parse(splittedLine[4]);
                newMovie.revenue = double.Parse(splittedLine[5], CultureInfo.InvariantCulture);
                newMovie.runtime = int.Parse(splittedLine[6]);
                newMovie.vote_average = double.Parse(splittedLine[7], CultureInfo.InvariantCulture);
                newMovie.vote_count = int.Parse(splittedLine[8]);

                movies.Add(newMovie);
            }

            reader.Close();

        }


        public void PartA() //co najmniej 2 rozwiązania tego etapu OBOWIĄZKOWO napisać z użyciem Query Expression
        {
            //wypisz liczbę filmów wydanych po 2000 roku, 
            //których tytuł zawiera podciąg "MINI" (wielkość liter nie ma znaczenia)

            var seq = from n in movies
                      where n.release_date.Year > 2000 && (n.title.Contains("mini")|| n.title.Contains("Mini"))
                      select n.title;
            Console.WriteLine("A1: " + seq.Count());

            //znajdź film (wypisz jego tytuł) z największą średnią oceną (vote_average), 
            //który ma co najmniej 10000 głosów (vote_count)

            var seq2 = from n in movies
                       where n.vote_count >= 10000
                       orderby n.vote_average descending
                       select n.title;
            Console.WriteLine("A2: " + seq2.First());

            //podaj sumę czasów trwania (runtime) ostatnich 10 filmów, których premiera (release_date) była w lutym

            var seq3 = from n in movies
                       where n.release_date.Month == 2
                       orderby n.release_date descending
                       select n.runtime;
            double ile = seq3.Take(10).Sum();
            Console.WriteLine("A3: " + ile);

        }


        public void PartB()
        {
            //znajdź 11 westernów (wypisz ich tytuły) z najmniejszą liczbą słów w tytule
            //w przypadku remisu (takiej samej liczby słów) weź tytuły z mniejsza liczbą znaków

            var seq = from n in movies
                       where n.genres.Contains("Western")
                       orderby n.title.Split(' ').Length
                       select n;
            seq = seq.ThenBy(z => z.title.Count());
            var seq2 = seq.Take(11);

            var seq3 = from n in seq2
                       select n.title;

            Console.WriteLine("B1: " + string.Join(" ",seq3));

            //podaj średni budżet filmów, które miały premierę w 2015 roku
            //do obliczenia średniej odrzuć 10 z filmów z największym i 10 z najmniejszym budżetem

            var seq4 = from n in movies
                      where n.release_date.Year == 2015
                      orderby n.budget
                      select n.budget;
            seq4 = seq4.Skip(10);
            seq4 = seq4.Reverse();
            seq4 = seq4.Skip(10);
            double srednia = seq4.Average();
            Console.WriteLine("B2: " + srednia);

        }

        public void PartC()
        {
            //w którym roku wyprodukowano najwięcej filmów
            //podaj rok oraz liczbę filmów
            //do dokończenia
            var seq = from n in movies
                      select n.release_date;
            seq = seq.Distinct();

            var seq2 = from n in seq
                       join mv in movies on n equals mv.release_date
                       group new { mv.title } by n;

            var seq3 = from n in seq2
                        select (n.Count(),n.Key.Year);

            Console.WriteLine("C1: " + seq3.Max());

            //jakie jest pierwsze słowo tytułów filmów, dla którego
            //suma dochodów (revenue) jest najwyższy
            //wypisz to słowo oraz sumę dochódów

        }

        public void PartD() //rozwiązania tego etapu OBOWIĄZKOWO napisać z użyciem Query Expression
        {
            //wykorzystując listę amerykańskich świąt (holidays) znajdź wszystkie filmy, których
            //premiera przypadała w święto oraz tytuł filmu oraz nazwa święta mają co najmniej jedno to samo słowo (wielkość liter nie ma znaczenia)
            //wynik wypisz w postaci par: tytuł filmu, nazwa święta

            //znajdź i wypisz tytuły wyszstkich par różnych filmów, które miały swoją premierę w tym samym dniu
            //oraz pierwsze i ostatnie słowo ich tytułu jest takie samo
            //zwrócone pary muszą być unikalne - nie mogą wystąpić pary (a,b) oraz (b,a)

        }

        public void PartE()
        {
            //znajdź 3 najczęściej występujące gatunki filmów (genres), które ukazały się po 2010 roku
            //zwróć te gatunki i częstotliwość ich wstępowania

            //znajdź i wypisz dwudziestą liczbę Fibbonaciego

        }

    }
}
