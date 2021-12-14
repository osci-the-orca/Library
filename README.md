Rapport för inlämningsuppgift – Biblioteket
När jag fick uppgiften började jag direkt med en snabb planering över hur jag ville skapa strukturen över programmet, vilka klasser, objekt och metoder som jag skulle använda mig utav för att lösa problemen. Sedan gjorde jag ett flödesschema över hur jag tänkte att programmet skulle köras. 

Det viktiga för mig var att hålla isär användargränssnittet från logiken. Jag tycker att jag lyckades bra med det genom att skapa Menu-klassen som tar hand om all inmatning från användaren och kallar på de olika metoderna från Library-klassen som utför jobbet som krävs. Så om man skulle använda sig utav något annat gränssnitt än konsolen så kommer man kunna använda koden ändå. Om man skulle vilja bygga på programmet med mer features än vad som efterfrågas just nu så är inte det något problem. 

Själva programmet baseras egentligen bara på en lista utav bokobjekt som ligger i Library-klassen, den listan kan vi sedan hantera på olika sätt. Man kan lägga till mer objekt, visa alla objekt i listan samt söka igenom den listan. Listan är privat och det går inte att manipulera listan från andra ställen i koden. Jag valde att göra en metod som returnerar en IList som representerar den privata listan som ReadOnly. 
Eftersom uppdragsgivaren vill att man som användare ska kunna skapa nya bokobjekt så skapade jag en constructor i Book-klassen för att kunna sätta dessa values. På så sätt kan vi genom menyn skapa bokobjekt. Jag har via min Utilityklass sett till så att det finns regler för hur ett bokobjekt ska kunna skapas.   Du måste välja vilken kategori objektet ska ha, du måste skriva in en Title, och Author samt att Year måste vara ett giltligt år tal. Just kategorin för varje bokobjekt valde jag att ha som en enum, jag valde det istället för att göra klasser som ärver av basklassen. Det gjorde jag för att det känns som ett smidigare alternativ ifall de väljer att lägga till en annan typ av Mediakategori i biblioteket. Då behövs det bara att lägga till en till member i enumen. Istället för att behöva skapa ny klass med fields, properties och konstrukor.

Jag valde att hantera inmatningen av användaren i Utilityklassen för att undvika att skriva samma kod på många ställen för att kolla att input är korrekt. Ett problem som kan uppstå här är att om man skulle använda något annat typ av användargränssnitt så fungerar inte all felhantering då de baseras på just input i consolen. Men jag vet inte tillräckligt mycket om andra typer av användargränssnitt för att göra på något bättre sätt. Man får helt enkelt skapa kontroller för att hantera inmatning som passar det användargränssnitt som används. 

För att visa alla bokobjektet för användaren på ett smidigt sätt skapade jag en metod som overridar ToString(). Det gör det väldigt smidigt att hantera bokobjektet som en sträng på olika sätt. Jag skriver ut alla objeckt i listan via en foreach-loop.  Min sökmetod använder sig också utav den override ToString() metoden för att kolla så att användarens input finns med i den strängen. På det sättet får jag ut ett resultat som kan matcha de olika egenskaperna som ett bokobjekt har. Sökfunktionen returnerar sen en lista med de objekt som innehåller användarens input. Jag har tidigare använt mig av lambda expression och tycker att det är ett väldigt bra sätt att få ner antal kodrader men att ändå kunna förstå vad som händer.  När listan av sökresultat sen visas så har jag valt att använda mig utav Linq biblioteket för att kunna sortera listan baserat på Author egenskapen (OrderBy()). Jag hade lite problem på vart i koden jag skulle sortera listorna, men valde att göra det precis innan de skrivs ut till användaren.
 
Jag försökte sedan tackla uppgiften med att kunna ladda in listan med böcker från en json fil, samt kunna spara listan efter att jag gjort ändringar i den. Det visade sig vara ganska krångligt. Men efter att ha tittat på kodexemplet som Gustav la upp och sedan skriva ett eget separat projekt som var väldigt likt exemplet men med andra andra klasser och objekt lyckades jag klura ut vad som hände och hur jag kanske skulle kunna använda det i Biblitotek projektet. Jag läste ganska mycket om Json Serializer och Deserializer och lyckades få de två olika metoderna SaveChanges och LoadData att fungera. Men märkte ganska snabbt att jsonfilen skrevs över varje gång jag startade om programmet. Så för att lösa detta så skapade jag en ny metod i Library-klassen som Loadar jsonfilen (en lista) och sedan addar jag den listan till books listan. Så varje gång programmet körs så skapas en lista med hjälp av LoadLibrary() sen lägger jag till den listan till List<Book> books. Under min research såg jag även att det var många kodexempel som använde sig utav Formatting =  FormatIndented. För att Jsonfilen skulle kunna vara lite mer lättläst. Men det visade sig bara vara tillgängligt om man använde sig utav Newtonsoft.json biblitoket och jag kör med text.Json. Efter lite mer research hittade jag dock att text.Json har en klass som heter SerializerOptions, där fanns det en, bool WriteIndented. Så då lyckades jag snygga till Jsonfilen också. 



# Inlämningsuppgift - Biblioteket
## Läs igen hela denna uppdragsbeskrivning noggrant.

Deadline för inlämning: Onsdag den 20:e Oktober kl 09:00
Inlämning sker via GitHub Classroom.

### För G krävs följande i inlämningen:

1. Du har planerat din lösning på ett lämpligt sätt. Bifoga exempelvis pseudokod/klassdiagram.
2. Du har skapat en körbar konsolapplikation i C# ( lösningen kommer att testas i Visual Studio Code. )
3. Du har enskilt planerat och skapat en enkel men välstrukturerad applikation med hjälp av språket C#.
4. Du har skrivit en rapport för uppgiften som sammanfattar din lösning och tillvägagångssätt samt värderar hur bra du själv tycker att du lyckats med uppgiften. Rapporten skall vara skriven i denna Readme.md-fil (**All denna text är ok att ta bort**). _Ha med en lista på vilka funktionskrav du anser att ditt program uppfyller!_
5. Minst 10 av 15 funktionskrav måste vara uppfyllda.

---
### För VG krävs också följande i inlämningen:

6. 14 av 15 funktionskrav måste vara uppfyllda.
7. Din struktur skapar förutsättningar för effektivt underhåll och möjlighet till vidareutveckling. Detta innefattar prydlig och konsekvent kod.
8. Analysera och reflektera kring hur du uppfyllt kraven i uppgiften. Reflektera över din applikations funktion och kodstruktur - samt motivera dina ställningstaganden.
9. En god separering mellan gränssnittskod och applikationsbunden logik

## Uppgiftsbeskrivning:

Som programmerare har du blivit kontaktad av ett bibliotek som vill att du gör ett ideellt arbete åt dem. Självklart tackar du ja!

Biblioteket skall starta ett pilotprojekt och införa digital hantering av deras böcker! Som första steg skall du ska skapa ett grundläggande konsolprogram som innehåller funktioner för att registrera nya böcker samt söka i biblioteket bland dessa böcker.

## Funktionskrav

* Lösningen ska innehålla klassen _Book_ med minst tre egenskaper: titel, skribent och utgivningsår. 
* Det ska finnas minst tre olika kategorier av media i biblioteket, förslagsvis _Roman_, _Tidskrift_ och _Ljudbok_. Hur du väljer att implementera det är upp till dig, antingen med klasser som ärver från en bok-basklass, eller med exempelvis en enum för kategorier.  
* Lösningen ska innehålla en klass kallad Library, som ska innehålla en lista med alla böcker. Listan måste vara private och andra klasser kan bara integrera med listan med hjälp av metoder. 
* Bibliotek-klassen ska ha minst fyra publika metoder:
  * En för att lägga till en bok i listan 
  * En för att lägga till flera böcker samtidigt (en lista med böcker) 
  * En för av hämta ut alla böcker i biblioteket. 
  * En för att söka bland böckerna i bokhyllan med en given sträng (indata) 
* Om Book-klassen har underklasser skall varje underklass ha en egen override av ToString()-metoden som ska användas när alla böcker i biblioteket listas. Den metoden ska ge tillbaka olika strängar beroende på vilken klass det är. Om book-klassen är den enda klassen skall den ha en override av ToString().
* Användaren ska genom en konsolmeny kunna:
  * Lägga till nya böcker i biblioteket (där titel, skriben, och utgivningsår skall matas in)
  * Lista alla böcker i biblioteket 
  * Söka efter en bok med ett givet namn. Boken ska matcha om det man söker efter finns någonstans i bokens titel, författarens namn eller i utgivningsåret och ska inte vara känsligt för stora eller små bokstäver.
* Varje bok som användaren sparar i Biblioteket ska vara ett eget objekt av typen Book.
* När programmet startar ska en färdigkonfiguerad lista av minst 5 böcker av olika typer från början finnas i biblioteket.
* Programmet skall hantera felaktig inmatning
* [Svår] Programmet skall kunna ladda och spara bok-objekten som json-data

---

### Tips och riktlinjer:

* Inlämning av uppgiften sker via GitHub Classroom. Har du problem med att få det att fungera, se till att få hjälp med det i god tid! 
* Programmera i steg! Försök inte lösa allt på en gång. Börja gärna utan ett gränssnitt, tänkt på logiken först.
* Ni ska dokumentera er lösning (mål 4) i denna Readme.md fil som finns i repot. Ta gärna bort alla denna text och ersätt med din rapport.
* När ni skriver er rapport (mål 4), beskriv vad fördelarna är med er struktur. Vad är den ev. problematiken om programmet skulle växa och utökas.
* Mål 1 kommer bedömas utifrån er rapport jämte ert kodresultat. Dokumentera med fördel med hjälp av ev. flöde- & klassdiagram eller hur ni från er synvinkel förstått uppgiften.
* All form av koddelning är otillåten och innebär automatiskt U i betyg. Använder ni en färdig lösning från exempelvis Stack Overflow måste ni dokumentera- samt motivera detta i kodkommmentarer.
* Se till att ditt program kan hantera felaktig inmatning och inte kraschar.
* För en bra struktur, tänk på att separera "inmatningen av information" från "bibliotek- och bok-klasserna". Dom ska alltså inte använda sig av Console någonstans.
* Deadline kollas mot det senaste comitten, så se till att pusha ditt lokala repository innan deadline!
* **Kom ihåg, mer kod betyder inte bättre kod! Hellre eleganta lösningar än mycket extra funktionalitet utöver kravspecen!**

Lycka till!
