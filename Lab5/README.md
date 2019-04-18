Zadanie polega na napisaniu prostej biblioteki do operacji na macierzach.

Etap 1 (2 punkty)

a) Stworzyć abstrakcyjną klasę Matrix z następującymi składowymi:
  - publiczne pola Rows (liczba wierszy) i Columns (liczba kolumn)
  - konstruktor z 3 parametrami
		-int rows - liczba wierszy
		-int columns - liczba kolumn
		-dwuwymiarowa tablica obiektów typu double zawierająca wartości elementów macierzy
		-konstruktor powinien ustawiać wartości pól Rows i Columns klasy oraz przeprowadzać sprawdzenie poprawności
		 parametrów - dla błędnych parametrów ustawia Rows = Columns = -1 i kończy działanie
	- abstrakcyjna metoda GetValue z parametrami int row i int column zwracająca obiekt typu double.
    Zaimplementowana metoda w klasach pochadnych będzie zwracała wartość elementu macierzy.
	- abstrakcyjna metoda SetValue z parametrami int row, int column i double value.
	  Zaimplementowana metoda w klasach pochodnych będzie ustawiała nową wartość elementu macierzy
	- metoda Print wypisująca elementy macierzy

b) Stworzyć klasę ArrayMatrix, która jest pochodną klasy Matrix i implementuje wszystkie jej składowe.
   Konstruktor klasy ArrayMatrix ma te same parametry jak konstruktor klasy Matrix.
   W tej klasie elementy powinny być przechowywane w dwuwymiarowej tablicy. Można definiować inne prywatne pola i metody,
   ale nie jest to konieczne.

Etap 2 (2 punkty)

c) Stworzyć klasę SparseMatrix pochodną klasy Matrix. Klasa będzie służyła do przechowywania macierzy rzadkich.
   W implementacji nie przechowujemy elementów o wartości 0. Wszystkie niezerowe elementy można przechowywać 
   na przykład za pomocą 3 tablic gdzie będzie trzymana wartość wiersza, kolumny oraz wartość elementu

   Uwaga: W tym etapie pozostawiamy pustą implementację metody SetValue

Etap 3 (1 punkt)

d) Zaimplementować metodę SetValue dla klasy SparseMatrix. Metoda ustawia wartości tylko tych elementów,
   które od początku ustnienia obiektu były niezerowe - przy próbie ustawienia zera na coś niezerowego nic się nie dzieje
   
