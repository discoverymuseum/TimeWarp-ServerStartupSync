# TimeWarp-ServerStartupSync

Deze applicatie zorgt ervoor dat de twee WATCHOUT clusters gelijktijdig WATCHPOINT opstarten
om storingen met betrekking tot 'verkeerde opstart' te voorkomen.

<h2>Installatie</h2>

<h3>Installeer Mono Framework for Windows</h3>
Download en installeer Mono Framework (voor Windows):
https://www.mono-project.com/download/stable/

<h3>Maak een configuratiebestand</h3>
Maak op een toegankelijk pad een tekstbestant genaamd <b>config.ini</b> aan en voer
de minimaal vereiste attributen in:

<code>
  dadada
  </code>

<h3>Maak een opstartscript</h3>
Maak in BATCH een opstartscript waarmee je de <b>TimeWarp-ServerStartupSync</b> start.
