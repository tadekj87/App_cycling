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

* Zamiast transmisji realnych wartości tymczasowo wprowadzono symulacje wielkości mierzonych opartą o suwaki (slider-y) u [dołu interfejsu](#trening-w-terenie)
* W [menu](#menu) użytkownik wybiera dwie opcje (Dom i Teren). Planowanie treningu w domu polega na wyborze przycisków "CHILL" i "SILA", które określają zakładaną przez użytkownika moc i kadencję.

## Wykorzystane technologie

* Platforma Xamarin (dodana do Visual Studio 2019)
* User Interface (logowanie do systemu)
* Log (obsługa dziennika zdarzeń)
* LINQ (wykorzystanie SQL podczas pisania programu)
* Komunikacja z bazą danych (użytkownicy)
* Komunikacja z zewnętrznym API – pobieranie pogody - pliki json pobierane ze strony openweathermap
* Obsługa wielowątkowości (funkcje asynchroniczne w obsłudze bazy danych i komunikaji z api(async await))
* Testowanie zamierzonej funkcjonalności (testowanie wprowadzanie danych w logowaniu)
* Wykorzystanie zewnętrznych bibliotek (NuGet) – entity framework
* Plik Readme w github-ie.

## Technologie do opracowania

* Transmisja BLE (Bluetooth Low Energy) zamiast symulowania wartości mierzonych
* Testowanie zamierzonej funkcjonalności.

# Interfejs

Po włączeniu programu użytkownik jest proszony o zarejestrowanie się (przycisk "REGISTER"- jeśli nie ma go w bazie danych). Jeśli jest wystarczy wprowadzić swoje dane (przycisk "SIGN UP"). 

### Rejestracja i logowanie

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/poczatek_logowanie.png)

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/logowanie.png)

Po udanym zalogowaniu pojawia się widok Menu.

### Menu

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/menu.png)

W Menu, aby rozpocząć trening wybiera się przyciski "Dom" lub "Teren".

Przycisku "EXCEPTION" i "CRASH" służą do [symulowania obługi zdarzeń](#obsluga-dziennika-zdarzen). 

### Trening w terenie 

* po włączeniu

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/teren_onStart.png)

* przykład działania

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/teren_onRun.png)

Aplikacja mierzy i podaje średnie wartości wielkości mierzonych oraz czas treningu.

Automatycznie pobierane dane pogodowe przewidziane są dla miasta: Wrocław. Jeśli użytkownik chce je zmienić powinien wyedytować pole po prawej stronie od etykiety: "Pogoda".

### Trening w domu (np. na trenażerze) 

* po włączeniu

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/dom_onStart.png)

* przykład działania

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/dom_onRun.png)

Ustawiony czas treningu wynosi 60 min i jest odliczany. Dzięki temu użytkownik wie, ile czasu zostało mu do końca treningu.

W przypadku wyboru przycisku "CHILL" wartości zadane określają moc równą 150 W i kadencję 90 rpm, a "SILA" odpowiednio 300 W i 80 rpm.
Jeśli użytkownik spełnia te kryteria (z niepewnością +/- 10 %) mierzone wartości mają zielony kolor czcionki, zaś jeśli nie- czerwony.

# Obsluga dziennika zdarzen

![alt text](https://github.com/tadekj87/App_cycling/blob/master/App2/App2/log1.png)

W celu obsługi dziennika zdarzeń wykorzystano usługę App Center od firmy Microsoft. Dzięki niej wydawca może na bieżąco śledzić jak używana jest jego aplikacja oraz dowiadywać się o występujących w niej błędach.

Po założeniu darmowego konta na stronie appcenter.ms założono nową aplikację do śledzenia na system Android a następnie skopiowano 
uzyskany tam "App Secret" do głównej aplikacji oraz ściagnięto tam pakiety "Microsoft.AppCenter". Od tej pory każde włączenie aplikacji 
na dowolnym urządzeniu na którym aplikacja jest zainstalowana przekazuje jej dane, takie jak model urządzenia, czas włączenia oraz 
wysyła raporty błędów na stronę App Center. Dodano również w celach statystycznych sprawdzanie, w jaki sposób aplikacja jest wykorzystywana poprzez wysyłanie informacji, który z treningów został wybrany.
