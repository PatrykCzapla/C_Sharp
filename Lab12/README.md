
Wydział Ewidencji Ludności pewnej ważnej instytucji potrzebuje systemu do 
zarządzania bazą zarejestrowanych obywateli. Pomóż im napisać prototyp programu, 
który będzie zarządzał plikami reprezentującymi obywateli.

Można założyć, że pesel zawsze będzie poprawny oraz że jego posiadacz będzie 
urodzony w latach od 1900 do 1999, tj. pierwsze 6 cyfr peselu XXYYZZ będzie oznaczało 
osobę urodzoną w dniu ZZ miesiąca YY roku 19XX.

Etap I (1 pkt.)
W klasie EwidencjaLudnosci dodaj konstruktor bezparametrowy, w którym 
w dowolnej (wybranej przez Ciebie) lokalizacji zostanie utworzony katalog 
o nazwie takiej jak nazwa wydziału (pole name). Jeśli katalog o takiej nazwie 
już istnieje należy go usunąć (łącznie z zawartością).

W klasie EwidencjaLudnosci dodaj metodę void SerializujObywatela 
o parametrach (Obywatel o, string path), która dokona serializacji binarnej 
obiektu o do pliku o lokalizacji i nazwie podanych w path.

W klasie EwidencjaLudnosci dodaj metodę DeserializujObywatela, która przyjmie 
jeden parametr typu string - ścieżkę pliku, z którego należy 
zdeserializować Obywatela i go zwrócić.

Etap II (1 pkt.)
W klasie Obywatel dodaj odpowiednie atrybuty i metodę, aby: pole miasto 
nie było zapisywane do pliku podczas serializacji, lecz było wyliczane 
automatycznie po deserializacji Obywatela na podstawie kodu pocztowego obywatela 
oraz dołączonego do zadania pliku kody.csv.

Etap III (1 pkt.)
W klasie EwidencjaLudnosci stwórz metodę void DodajObywatela z parametrem typu Obywatel, 
która zapisze plik z zserializowanym obywatelem według następującego schematu:
plik o nazwie "{pesel_obywatela}.bin" będzie w katalogu o nazwie odpowiadającej jego dniowi urodzenia,
który będzie znajdował się w katalogu odpowiadającemu miesiącowi urodzenia, który
będzie znajdował się w katalogu reprezentującym dwie ostatnie cyfry roku urodzenia
Przykład: obywatel o peseli 91011107811 powinien zostać zapisany do pliku 
"Ewidencja Ludnosci\91\01\11\91011107811.bin"
Jeśli obywatel o podanym peselu już istnieje należy wypisać komunikat:
"obywatel o podanym peselu istnieje już w bazie"

Etap IV (1 pkt.)
W klasie EwidencjaLudnosci stwórz metodę void UsunObywatela, która przyjmie 
pesel obywatela (string), który ma zostać usunięty. Metoda sprawdza 
czy obywatel o podanym peselu został wcześniej zapisany (w strukturze 
katalogów jak w etapie III). Jeśli obywatel nie istnieje wypisywany jest komunikat 
"obywatel o peselu {pesel} nie istnieje w bazie". 
W przeciwnym przypadku plik jest usuwany i wypisywany komunikat:
"Usunięto obywatel o peselu {pesel}"
Uwaga: jeśli usunięcie obywatela spowoduje, że katalog, w którym się on znajdował 
będzie pusty, to również ten katalog powinien zostać usunięty i jeśli usunięcie 
tego katalogu spowoduje, że katalog powyżej będzie pusty, to również powinien on 
zostać usunięty itp. Innymi słowy: żaden z katalogów po usunięciu obywatela nie może być pusty.

Etap V (1 pkt.)
W klasie EwidencjaLudnosci dodaj metodę IleUrodzonychWDniuTygodnia przyjmującą enum DayOfWeek, 
która zwróci liczbę obywateli w bazie urodzonych w podanym dniu tygodnia.
Wskazówka: Stworzyć zmienną typu DateTime z datą urodzenia. 
Typ DateTime zawiera pole DayOfWeek z dniem tygodnia.
