
Etap 1.
W pliku Ciagi.cs zdefiniować klasy implementujące interfejs IEnumerable
 - Naturlne - zwraca kolejne liczby naturalne (parametr konstruktora to pierwsza liczba, domyślnie 0)
 - Losowe - zwraca liczby losowe z zakresu <0,max) z zadanym ziarnem generatora
   (ziarno i max to parametry konstruktora). Wykorzystać klasę System.Random.
 - Tetranacci - zwraca kolejne liczby ciągu Tetranacciego - t0 = t1 = t2 = 0, t3 = 1, tn = tn-1 + tn-2 + tn-3 + tn-4
 - Catalan - zwraca ciąg liczb Catalana, c0 = 1, cn+1 = cn * 2 * (2 * n + 1) / (n + 2);
 - Wielomian - jako paramter konstruktora przyjmuje tablicę współczynników wielomianu.
   Zwraca wartości tego wielomianu liczone dla kolejnych liczb naturalnych

Etap 2.
W pliku Modyfikatory.cs zdefiniować klasy implementujące interfejs IModifier
 - PoczatkoweN - jako paramter przyjmuje n. Zwraca n pierwszych wyrazów ciągu
 - TransformacjaLiniowa - przekształca ciąg wejściowy (x) według wzoru y = a*x+b, gdzie a,b - parametry konstruktora
 - TylkoRozne - pomija sąsiadujące ze sobą elementy o jednakowej wartości
 - LiczbyPierwsze - zwraca wszystkie liczby pierwsze z ciągu

Etap 3.
W pliku Modyfikatory.cs zdefiniować klasę implementującą interfejs IModifier
 - MinimaLokalne - zwraca wszystkie minima lokalne w ciągu, przykłady:
      Dane                                 Wynik
      3                                    3
      4,1                                  1
      2,5                                  2
      2,5,4,4,4,1,1,2,3,5,3,4,2,2,2        2,1,3,2

Etap 4.
W pliku Polacz.cs zdefiniować klasę implementującą interfejs IMerger
 - Mnoz - mnoży parami kolejne wyrazy ciągów (przerywa gdy skończy się któraś z sekwencji wejściowych)
   
Etap 5.
W pliku Modyfikatory.cs zdefiniować klasę implementującą interfejs IModifier
 - ModyfikatorZlozony - jako parametr przyjmuje tablicę obiektów IModifier.
   Zwraca ciąg zmodyfikowany kolejno wszystkimi modyfikatorami (elementami tablicy)
W pliku Ciagi.cs zdefiniować klasę implementującą interfejs IEnumerable
 - TabliczkaDodawania - tworzy "tabliczkę dodawania" dla liczb od 0 do n ( n - parametr konstruktora)
   UWAGA! - generujemy seksencje sekwencji (nie poszczególne liczby, a całe wiersze tabliczki dodawania)
   Można skorzystać ze zdefiniowanych wcześniej generatorów sekwencji i modyfikatorów.

Uwagi:
 - właściwość Name podaje krótki opis tego co dana klasa robi
 - nie można używać LINQ
 - nie można zmieniać pliku Program.cs poza odkomentowaniem odpowiednich linii.
   Zaimplementowane klasy powinny dawać takie same wyniki jak w pliku Wyniki.txt
   
