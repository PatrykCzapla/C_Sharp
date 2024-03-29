I etap:

- napisać metodę rozszerzającą klasę string. Metoda ma nazwę DuplicateCharacters i zwraca string,
  który podwaja wystąpienie każdego znaku w wejściowym stringu. Metodę dodać do ExtensionMethods.cs

II etap:

- stworzyć uogólniony interfejs IMyList z jednym typem parametryzującym T z metodami: 
	Add(...) - dodaje do list element danego typu
	Get(int index) - zwraca element z list o zadanym indeksie
	RemoveLast() - usuwa ostatni element z listy i zwraca jego wartość
	Size typu int - właściwość, tylko do odczytu, zwraca rozmiar kolekcji

- stworzyć uogólnioną klasę abstrakcyjną GeneralList implementującą interfejs IMyList.
  Klasa posłuży do zaimplementowania listy jednokierunkowej (posortowanej i nieposorotwanej).
  Umożliwić korzystanie z pętli foreach (IEnumerable, yield do kolejnych elementów listy).

  Warto w tej klasie stworzyć podstawową funkcjonalność listy jednokierunkowej,
  a w klasach dziedziczących tylko nadpisywać odpowiednie metody. 

  Metoda ToString - tworzy odpowiedni string, przechodząc przez listę.

  Metody RemoveLast oraz Get zgłaszają wyjątek w przypadku gdy lista jest pusta.
  Wyjątek można zgłosić w następujący sposób:  throw new Exception("List is empty");


III etap:

- stworzyć klasę MyList dziedziczącą po GeneralList.
  Metoda Add wstawia element na początek listy jednokierunkowej. Metoda Add powinna mieć stałą złożoność.

IV etap:

- stworzyć klasę SortedMyList dziedziczącą po GeneralCollection.
  Metoda Add wstawia element w odpowiednie miejsce na liście jednokierunkowej, tak aby lista była posortowana rosnąco.
  Klasa SortedMyList musi zapewniać, że będzie można porównywać elementy na liście (interfejs IComparable<T>).
  Nałożyć odpowiednie ograniczenie na typ parametryzujący.

- stworzyć klasę Person z właściwościami int Age oraz string Name.
  Klasa ma metodę ToString zwracającą stringa postaci Name, Age.
  Można porównywać obiekty klasy Person (IComparable<T>).
  Porównanie odbywa się po imieniu, a w przypadku gdy są równe po wieku.

V etap:

Napisać metodę rozszerzającą:
- Metoda rozszerza klasę GeneralList, ale tylko dla typu Person.
  Metoda ma nazwę GetPeopleCountPowerOfTwoAge i zwraca ilość osób, których wiek jest potęgą liczby 2.

  Podpowiedź: liczba jest potęgą dwójki, gdy w reprezentacji bitowej ma tylko jedną jedynkę.
  Wymaganie: nie wolno używać metody Math.Pow - należy zastosować się do podpowiedzi.

Metodę dodać do pliku ExtensionMethods.cs

UWAGA: NIE MOŻNA KORZYSTAĆ Z GOTOWYCH KOLEKCJI C#

Punktacja:

etap I - 0.5p
etap II:
-interfejs - 0.5p
-klasa 1.5p
etap III - 0.5p
etap IV - 1.5p
etap V - 0.5p
