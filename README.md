# Warehouse
## Harmonogram
1. Dodawanie, edytowanie i usuwanie klientów
2. Dodawanie, edytowanie i usuwanie adresów
3. Dodawanie, edytowanie i usuwanie paczek
4. Dodawanie, edytowanie i usuwanie palet
5. Dodawanie, zarządzanie pracownikami
6. Uprawnienia pracowników (magazynier, spedytor)
7. Przyjmowanie dostaw
8. Wysyłka przesyłek
9. Kontrola stanu przesyłki


## Opis Projektu
Oprogramowanie służy do obsługi magazynu. Pozwala ewidencjonować paczki, 
łączyć je w palety, śledzić i zmieniać status. Zaimplementowano mechanizm
autentykacji oraz autoryzacji na podstawie ról użytkowników. Umożliwia tworzenie 
nowych użytkowników oraz logowanie.


## Architektura
Projekt zrealizowany został z wykorzystaniem technologii ASP .net w wersji 6. Główna aplikacja 
realizuje komunikację poprzez zapytania REST. Udostępnia następujące endpointy:
* /api/Account - odpowiada za rejestrację i logowanie użytkowników
* /api/Address - umożliwia listowanie, tworzenie, usuwanie oraz aktualizację adresów
* /api/Box - umożliwia listowanie, tworzenie, usuwanie oraz aktualizację paczek
* /api/Client - umożliwia listowanie, tworzenie, usuwanie oraz aktualizację klientów
* /api/Pallet - umożliwia listowanie, tworzenie, usuwanie oraz aktualizację palet

Baza danych obsługiwana jest przez serwer Microsoft SQL Server. Komunikacją z bazą danych
zajmuje się Entity Framework.

Rejestracja uźytkowników obsługuję niezależny mikroserwis. Komunikacja pomiędzy nim
a modułem RestAPI realizowana jest poprzez brokera RabbitMQ.

Dodatkowo solucja zawiera projekt prostej aplikacji okienkowej, stworzonej w oparciu 
o technologię WPF. Umożliwia ona sprawdzenie statusu paczki po podaniu jej id.
Po zalogowaniu umożliwia również listowanie wszystkich paczek znajdujących się w bazie danych.
Pozwala też na rejestrację nowych użytkowników.


## Uruchomienie
Do uruchomienia aplikacji wymagany jest zainstalowany Docker.
Główna część aplikacji (moduł RestApi oraz AccountService) wraz z serwerem bazodanowym
Microsoft SQL Server i brokerem RabbitMQ uruchamiamy jest z wykorzystaniem narzędzia docker-compose.

Aby to zrobić, uruchom terminal, przejdź do folderu solucji, a następnie użyj polecenia:

```
docker-compose up --build
```
Powyższa komenda zbuduje projekt oraz stworzy dockerowy stack aplikacji.

Aby uruchomić aplikację okienkową, zbuduj projekt przy pomocy środowiska programistycznego.

## Obsługa

Po uruchomieniu stacku dockerowego dostęp do aplikacji RestAPI mamy pod adresem
```
http://localhost
```

Dokumentacja dostępnych endpointów znajduje się w module Swagger dostępnym pod adresem
```
http://localhost/swagger
```

