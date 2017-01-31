# SeedGenerator

Program do generowania mnemonica zgodnego z BIP39 

Wymagana entropia pobierana jest z dwóch talii 52 kart oraz dodatkowo z czasu w jakim użytkownik klika kolejne karty. 

Daje to brak powtażalności nawet przy użyciu tego samego układu kart.

Instrukcja:

- Przygotuj talię 52 kart.
- Potasuj ją metodą ['riffle shuffle'](https://en.wikipedia.org/wiki/Shuffling#Riffle) co najmniej 7 razy
- Wybierz długość mnemonica jaki chcesz uzyskać
- Klikaj kolejne wylosowane karty zgodnie z poleceniami
- Potasuj talię ponownie i wylosuj/klikaj drugi raz
- Wygenerowany mnemonic pojawi się w dolnym okienku
- Przed rozpoczęciem klikania możesz wpisać 'coś' w pole salt

Działa? Również nie ufasz generatorom losowości z komputera? 

Tipbox: 1Rav3nkMayCijuhzcYemMiPYsvcaiwHni
