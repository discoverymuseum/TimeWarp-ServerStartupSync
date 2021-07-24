# TimeWarp-ServerStartupSync

Deze applicatie zorgt ervoor dat de twee WATCHOUT clusters gelijktijdig WATCHPOINT opstarten
om storingen met betrekking tot 'verkeerde opstart' te voorkomen.

<h2>Installatie</h2>

<h3>Installeer Mono Framework for Windows</h3>
Download en installeer Mono Framework (voor Windows):
https://www.mono-project.com/download/stable/

<h3>Maak een configuratiebestand</h3>
Maak op een toegankelijk pad een tekstbestant genaamd <b>config.ini</b> aan en voer
de minimaal vereiste attributen in:<p>

localip=172.16.0.20 (vul hier het eigen LAN IP-adres in)
targetip=172.16.0.21 (vul hier het IP adres van de andere server in)<br>
port=60000 (vul hier het TCP poortnummer in waarmee de servers onderling communiceren)<br>
command=C:\WATCHOUT 6\WATCHPOINT.exe (vul hier het pad in naar het uit te voeren programma)<br>


<h3>Maak een opstartscript</h3>
Maak in BATCH een opstartscript waarmee je de <b>TimeWarp-ServerStartupSync</b> start.
