
Klasa ObservableCollection implementuje interface IObservableCollection.

ObservableCollection to kolekcja powiadamiająca o zmianach.
Do implementacji logiki kolekcji można wykorzystać standardową listę.

Klasa ObservableCollection ma następującą właściwość:
Name - tylko do odczytu (typu string) ustawiana przez parametr przekazywany do konstruktora.

Klasa ObservableCollection ma następujące metody:
Add - dodaje element do kolekcji
Remove - usuwa element z kolekcji
Metody Add i Remove powodują zgłoszenie zdarzenia CollectionChanged
z odpowiednim parametrem informującym o rodzaju operacji i elemecie na którym ta operacja została wykonana.

Etap 1:
Napisać klasę ObservableCollection oraz klasę SimpleWatcher.

Klasa SimpleWatcher ma dwie publiczne metody:

Watch przyjmującą jako parametr obiekt typu IObservableCollection.
Po wywołaniu tej meteody za każdym razem gdy dla przekazanego obiektu zgłaszane jest zdarzenie CollectionChanged
watcher wypisuje na konsolę zdanie "Collection changed".

StopWatching przyjmującą jako parametr obiekt typu IObservableCollection.
Wywołanie tej metody zatrzymuje działanie metody Watch dla danego obiektu.

Etap 2:
Napisać klasę SmartWatcher, która działa tak jak SimpleWatcher
tylko wypisuje na konsolę także nazwę zmieniającj się kolekcji (właściwość Name), rodzaj operacji jaki został wykonany
i obiekt na którym została wykonana operacja (wynik metody ToString na obiekcie na którym wykonano operację)

Etap 3:
Napisać klasę NotifingObject implementującą interface IChangeNotifing.
Klasa NotifingObject ma jedną włąściwość Name.
Za każdym razem gdy właściwość Name jest zmieniana należy zgłosić zdarzenie Changed.
Należy przedefiniować metodę ToString tak by zwracała wartość właściwości Name.

Za każdym razem gdy do kolekcji dodawany jest obiekt typu IChangeNotifing
należy zacząć nasłuchiwać na jego właściwości Changed.
Po kazdej zmianie na wyżej wspomnianym obiekcie należy zgłosić zdarzenie CollectionCahnged
z operacją ValueChanged i wyżej wspomnianym obiektem jako parametrem zdarzenia.

UWAGA: Po usunięciu obiektu typu IChangeNotifing z kolekcji należy zaprzestać nasłuchiwania.

Punktacja:
Etap 1  - 2 pkt.
Etap 2  - 1 pkt.
Etap 3  - 2 pkt.
