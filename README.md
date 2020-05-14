# App cycling

App cycling to aplikacja do planowania i monitorowania treningu kolarskiego. Bazuje ona na danych mierzonych kadencji (czyli obrotów na minutę) i mocy (w Watach). Na podstawie tych wielkości można przeprowadzić trening na zewnątrz lub też w domu (np. na trenażerze).

Dodatkowo program potrafi np. wyświetlić aktualną pogodę (temperaturę i siłę wiatru), które to wartosci są istotne w trakcie jazdy na rowerze.

## Zawartość instrukcji
* [Koncepcja projektu](#koncepcja-projektu)
* [Realizacja projektu](#realizacja-projektu)
* [Wykorzystane technologie](#wykorzystane-technologie)
* [Interfejs](#interfejs)
* [Obsluga dziennika zdarzen](#obsluga-dziennika-zdarzen)

## Koncepcja projektu

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/zalozenia.png)

## Realizacja projektu

### Zmiany w stosunku do koncepcji

*
*
*

## Wykorzystane technologie

* User Interface (logowanie do systemu)
* Log (obsługa dziennika zdarzeń)
* LINQ — (wykorzystanie SQL podczas pisania programu)
* Komunikacja z bazą danych (użytkownicy)
* Komunikacja z zewnętrznym API – pobieranie pogody - pliki json pobierane ze strony openweathermap
* Obsługa wielowątkowości (funkcje asynchroniczne w obsłudze bazy danych i komunikaji z api(async await))
* Testowanie zamierzonej funkcjonalności - testowanie wprowadzanie danych w logowaniu
* Wykorzystanie zewnętrznych bibliotek (NuGet) – entity framework, newtonson.json(lub zamiennik)
* Plik Readme w github-ie.

# Technologie do opracowania

* Transmisja BLE (Bluetooth Low Energy) zamiast symulowania wartości mierzonych
* Testowanie zamierzonej funkcjonalności.

# Interfejs

### Logowanie

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/poczatek_logowanie.png)

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/logowanie.png)

### Menu

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/menu.png)

### Trening w terenie 

* po włączeniu

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/teren_onStart.png)

* przykład działania

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/teren_onRun.png)

### Trening w domu (np. na trenażerze) 

* po włączeniu

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/dom_onStart.png)

* przykład działania

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/dom_onRun.png)

# Obsluga dziennika zdarzen

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/log1.png)
