
Zadanie polega na implementacji operacji na zbiorach rozmytych.
Zbiór rozmyty to taki zbiór, gdzie każda z wartości ma przypisaną liczbę oznaczającą stopień/prawdopodobieństwo
przynależności do zbioru. Liczba ta jest z przedziału (0.0, 1.0].
Inaczej mówiąc elementami zbioru rozmytego są pary: wartość, stopień przynależności.

W zadaniu wartości będą liczbami całkowitymi, a stopnie przynależności liczbami typu float.

Przykład:
{(1,0.5), (2,1.0)} - zbiór rozmyty z dwoma elementami: jedynka należy do zbioru w stopniu 0.5, dwójka należy w stopniu 1.0.

Tak jak w tradycyjnych zbiorach w zbiorze rozmytym nie mogą istnieć dwa elementy o tej samej wartości.
Zbior tradycyjny można traktować jako zbiór rozmyty, w którym dla każdego elementu stopień jego przynależności równy jest 1.0.

== CZĘŚĆ 1 == (1 pkt)
Stwórz klasę FuzzySet, która będzie reprezentowała zbiór rozmyty.
Wewnętrzna reprezentacja zbiorów rozmytych (wybrana struktura danych) jest dowolna.
Wskazówka: Można użyć listy par elementów lub słownika (patrz "Przydatne informacje" poniżej).

Stwórz konstruktor przyjmujący dowolną liczbę dwuelementowych krotek typu (int, float) - będą to elementy zbioru rozmytego.
Uwaga: Aby używać krotek niezbędna jest zmiana wersji .Net na 4.7.
Aby to zrobić wybieramy Project -> Properties i zmieniamy Target Framework na .NET Framework 4.7

Zdefiniuj metodę ToString(), która będzie zwracała stringa z elementami zbioru rozmytego w formie takiej, jak w powyższym przykładzie.

== CZĘŚĆ 2 == (2 pkt)
Zaimplementuj operatory:
a) +, który pozwala na dodanie do zbioru jednego elementu - krotki typu (int, float)
	jeśli element o danej wartości istnieje już w zbiorze, to stopień jego przynależności jest wartością większą
	z aktualnego stopnia przynelażności oraz drugigo elementu parametru - krotki
b) +, który będzie zwracał sumę zbiorów: 
	jeśli w zbiorze A istnieje element o wartości, której nie ma w zbiorze B, to wynikowy zbiór zawiera tę wartość
	z stopniem przynależności takim jak w zbiorze A (analogicznie dla sytuacji odwrotnej)
	jeśli w obu zbiorach istnieje element o danej wartości, to w zbiorze wynikowym dodajemy również ten element o tej wartości
	i stopniem przynależności równym większemu ze stopni przynależności tej wartości z sumowanych zbiorów
c) /, który będzie zwracał różnicę zbiorów:
    do zbioru wynikowego różnicy A/B należą wszystkie elementy z wartościami, które istnieją w A i nie istnieją w B
    oraz dla tych wartości, które istnieją w obu zbiorach, do zbioru wynikowego dodawana jest ta wartość
    oraz stopień przynależności będący różnicą stopni przynależności dla tej wartości ze zbiorów A i B (o ile ta różnica jest większa od 0)
d) -, unarny minus, który będzie zwracał zbiór z elementami o tych samych wartościach i ich stopniach przynależności
    równych 1-p, gdzie p to stopień przynależności danej wartości

== CZĘŚĆ 3 == (1 pkt)
Zaimplementuj operatory porównywania:
a) ==, zwraca true tylko jeśli oba zbiory mają wszystkie te same wartości z tymi samymi stopniami przynależności
b) !=, zwraca true w przeciwnym przypadku niż operator ==
c) <, zwraca true tylko jeśli pierwszy ze zbiorów "zawiera się" w drugim, czyli dla każdej wartości ze zbioru pierwszego
      w zbiorze drugim istnieje element o tej samej wartości i większym stopniu przynależności
d) >, analogicznie jak powyższy - zwraca true tylko jeśli drugi ze zbiorów "zawiera się" w pierwszym

Uwaga: 
- kompilacja programu po zrealizowaniu tej części nie powinna powodować żadnych ostrzeżeń

== CZĘŚĆ 4 == (1 pkt)
Zaimplementuj indeksator [int], który pozwoli na:
a) pobranie stopnia przynależności elementu o wartości równej podanej w indeksatorze
   (jeśli w zbiorze nie istnieje taki element zwróć 0.0)
b) zmianę stopnia przynależności elementu o wartości równej podanej w indeksatorze

Stwórz niejawną konwersję typu List<int> na FuzzySet. Zwracany jest zbiór o elementach z wartościami równymi elementom
z podanej listy i wszystkimi stopniami przynależności równymi 1.
Stwórz jawną konwersję typu FuzzySet na List<int>. Zwracana lista posiadająca elementy równe wartościom elementów
ze zbioru rozmytego, których stopień przynależności wynosi co najmniej 0.5.


== Przydatne informacje ==
--- Listy ---
Lista (List<T>) w C# podobna jest do klasy vector z C++.
List<T> lista = new List<T>(); - tworzenie listy elementów typu T
lista.Add(x); - dodanie elementu do listy
lista.Count - liczba elementów listy

--- Słowniki ---
Słownik (Dictionary<K,V>) jest strukturą przechowującą parę klucz,wartość (odpowiednik map z C++)
Klucz jest wartością unikalną w ramach słownika.
Dictionary<K,V> slownik = new Dictionary<K,V>(); - tworzenie słownika
slownik.Add(klucz,wartosc); - dodanie elementu do słownika
slownik[klucz] - odczyt wartosci o podanym kluczu
slownik.ContainsKey(klucz); - informacja czy podany klucz istnieje w słowniku
lista.Count - liczba elementów (kluczy) w słowniku
