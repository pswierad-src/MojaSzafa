# PGSTask.MojaSzafa
Zadanie testowe .NET

G��wna ga��� projektu - master

Aplikacja realizuje funkcj� zarz�dzania garderob�. Posiada zaimplementowany CRUD, paginacj�, filtrowanie i sortowanie. Posiada tak�e kilka test�w jednostkowych weryfikuj�cych dzia�anie.

Baza danych powinna zosta� utworzona po wst�pnej kompilacji projektu, w przeciwnym razie nale�y j� utworzy� poleceniem <b>update-database</b> w konsoli Packet Managera.

Dependency Injection zrealizowano przy pomocy bilbioteki Autofac
Testy jednostkowe bazuj� na bilbiotece xUnit oraz Moq (sprawniejsze mockowanie danych).

Aplikacja posiada metod� SeedData kt�ra po wygenerowaniu bazy dodaje do niej przyk�adowe dane.



