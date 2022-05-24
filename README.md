# desert-drifters-game
Desert Drifters Game preview material

3rd person game, custom C# scripts

1. Audio Low Pass Filter detection script: 
  Script dat afstand meet van speler tot binnenruimtes en low pass filter inzet op buitengeluiden wanneer de speler de binnenruimtes betreedt. Draagt bij aan sfeer/realisme omgevingsgeluiden.
2. Camera pan script:
  Script dat muis beweging detecteert. Als muis-x positie groter is dan schermbreedte / 2 dan start een coroutine die de camera langzaam laat pannen naar de andere schouder (POV rechts / links).
3. View Collectible script:
   Als je op een collectible item klikt beweegt het item zich richting de camera, begint rotatie en activeert de collectible camera.
4. Player Controller script (icm animator controller):
   Controller voor basis bewegingen, activeren lamp of activeren wapen, richten & schieten wapen.
