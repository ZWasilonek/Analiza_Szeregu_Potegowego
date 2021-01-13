# Analiza Szeregu Potęgowego
<br />

## I. OGÓLNE ZAŁOŻENIA PROGRAMU
Jest to responsywny program konsolowy napisanym w języku C#. Algorytm projektu wylicza sumę zadanego szeregu dla zmiennej niezależnej X, sumę szeregu w przedziale Xd(X dolne) – Xg(X górne) oraz pierwiastek kwadratowy z sumy k-tego wyrazu szeregu liczony metodą Herona oraz Newtona.
Program dokonuje obliczeń na zadanym szeregu o wzorze :

  ∞ &nbsp;&nbsp;&nbsp;    2^n + n^2 <br />
  ∑ &nbsp;&nbsp;&nbsp;  ----------- X^n <br />
 n=1 &nbsp;&nbsp;&nbsp;   3^n + n^3 <br />

gdzie ^ oznacza potęge


<br />

## II. ZAPOZNANIE Z DZIAŁANIEM PROGRAMU

### 1. Menu programu
Po uruchomieniu programu wyświetlony zostanie komunikat powitalny. Po naciśnięciu dowolnego przycisku zostanie wyświetlone menu zawierające dostępne rodzaje funkcjonalności.

### 2. Śledzenie programu
Po wybraniu istniejącej funkcjonalności z menu programu, użytkownik zostanie zapytany o zgodę na śledzenie programu. Jeżeli użytkownik wciśnie klawisz „T” lub „t”, podczas wykonywania wybranej funkcjonalności, wyświetlą się w tym wątku dodatkowe informacje dotyczące danych jakie użytkownik wprowadzał podczas wykonywania poleceń oraz obliczenia wybranej funkcjonalności. Jeżeli użytkownik nie wyrazi zgody na śledzenie programu, w wyniku końcowym wybranej funkcjonalności wyświetlony zostanie jedynie obliczony wynik wybranej funkcjonalności.

### 3. Wybrana Funkcjonalność
Użytkownikowi zostaje wyświetlona informacja o tym, co należy zrobić aby uruchomić szukaną funkcjonalność. Postępując zgodnie z instrukcją, należy wcisnąć odpowiedni klawisz odpowiadający wybranej funkcjonalności. <br />
**WĄTEK Z BŁĘDEM:** <br />
Jeżeli użytkownik wciśnie klawisz, do którego żadna funkcjonalność nie została przypisana, zostanie wyświetlony mu komunikat błędu oraz instrukcja sterująca - jak użytkownik ma postąpić dalej.

### 4. Instrukcja sterująca funkcjonalności
Po wybraniu istniejącej funkcjonalności, algorytm będzie komunikował się z użytkownikiem. Użytkownik zostanie poproszony o sprecyzowane dane, jakie będą konieczne do obliczenia wybranej funkcjonalności. <br />
**WĄTEK Z BŁĘDEM:** <br />
Za każdym razem, gdy użytkownik wprowadzi dane, które będą niezgodne z wymogami algorytmu, zostanie mu wyświetlony komunikat błędu oraz instrukcja sterująca – jak ma dalej postępować.


<br />

## III. ANALIZA SZEREGU:

### Do obliczenia sumy zadanego szeregu należy wprowadzić następujące zmienne:
  1. wartość zmiennej niezależnej **X**
  2. wartość dokładności obliczeń **Eps** (epsilon) dla iteracji przybliżeniowej
  3. wartość zmiennej **k**, która odpowiada numerowi kolejnego wyrazu szeregu oraz liczbie iteracji.
  4. wartość zmiennej **W** (wyraz szeregu), która będzie przechowywać wartość obliczonego k- tego wyrazu szeregu
  5. wartość zmiennej **S** (suma szeregu), która będzie przechowywać łączną sumę obliczonych wyrazów zadanego szeregu

### Aby policzyć sumę szeregu, użytkownik musi najpierw wprowadzić następujące dane w podanej kolejności:
  1. wartość zmiennej niezależnej X, której zakres nie może przekraczać wartości zbieżności szeregu **X ∈ < -4/3, 4/3 )**
  2. wartość dokładności obliczeń Eps, która ma wyznaczony zakres wartości **Eps ∈ (0; 1)**

### Warunki logiczne:
  1. Wartość zmiennej niezależnej X musi był liczbą rzeczywistą należącą do przedziału: <br />
    X ∈ < -4/3, 4/3 ) <br />
    float X → X >= -4/3 && X < 4/3

  2. Wartość dokładności obliczeń Eps jest liczbą zmiennoprzecinkową, należącą do przedziału: <br />
    Eps ∈ (0; 1) <br />
    float Eps → Eps > 0 && Eps < 1 

  3. Aby k-ty wyraz szeregu mógł zostać zsumowany, należy sprawdzić czy wartość bezwzględna k-tego wyrazu szeregu jest mniejsza od przyjętej wartości Eps  <br />
    Math.Abs(W) < Eps 


<br />

## IV. RODZAJE FUNKCJONALNOŚCI

### 1. Obliczanie wartości (sumy) zadanego szeregu potęgowego.
#### Funkcjonalność ta przypisana jest do klawisza:
- **A**. Obliczanie wartości (sumy) zadanego szeregu potęgowego.

#### Zadanie: 
Wylicza sumę szeregu, dla podanej zmiennej niezależnej X oraz dokładności obliczeń Eps.

#### Warunki logiczne:
  1. Wartość zmiennej niezależnej X musi był liczbą rzeczywistą należącą do przedziału: <br />
    X ∈ < -4/3, 4/3 ) <br />
    float X → X >= -4/3 && X < 4/3

  2. Wartość dokładności obliczeń Eps jest liczbą zmiennoprzecinkową, należącą do przedziału: <br />
    Eps ∈ (0; 1) <br />
    float Eps → Eps > 0 && Eps < 1 

  3. Aby k-ty wyraz szeregu mógł zostać zsumowany, należy sprawdzić czy wartość bezwzględna k-tego wyrazu szeregu jest mniejsza od przyjętej wartości Eps  <br />
    Math.Abs(wyrazSzeregu) < Eps 

<br />

### 2. Tablicowanie wartości zadanego szeregu potęgowego.
#### Funkcjonalność ta przypisana jest do klawisza:
- **B**. Tablicowanie wartości zadanego szeregu potęgowego.

#### Zadanie: 
Wylicza sumę szeregu, dla podanego przedziału wartości zmiennej niezależnej X ∈ <Xd, Xg), podanej wartości przyrostu h zmiennej niezależnej X oraz podanej dokładności obliczeń Eps.

#### Warunki logiczne:
  1. Wartość zmiennej niezależnej Xd musi był liczbą rzeczywistą należącą do przedziału: <br />
    Xd ∈ < -4/3, 4/3 ) <br />
    float Xd → Xd >= -4/3 && Xd < 4/3

  2. Wartość zmiennej niezależnej Xg musi był liczbą rzeczywistą większą lub równą wartości Xd, której wartość jednocześnie należy do przedziału: <br />
    Xg ∈ < Xd, 4/3 )  <br />
    float Xg → Xg >= Xd  && Xg < 4/3

  3. Wartość przyrostu h zmiennej niezależnej X, może być dowolną liczbą rzeczywistą mieszczącą się w zakresie: <br />
    h ∈ < Xd, Xg >  <br />
    float h → h <= Xd && h >= Xg

  4. Wartość dokładności obliczeń Eps jest liczbą zmiennoprzecinkową, należącą do przedziału: <br />
    Eps ∈ (0; 1) <br />
    float Eps → Eps > 0 && Eps < 1 

  5. Aby k-ty wyraz szeregu mógł zostać zsumowany, należy sprawdzić czy wartość bezwzględna k-tego wyrazu szeregu jest mniejsza od przyjętej wartości Eps  <br />
    Math.Abs(wyrazSzeregu) < Eps 
    
<br />

### 3. Tablicowanie wartości pierwiastka kwadratowego, obliczonego metodą Herona, z wartości zadanego szeregu potęgowego.
#### Funkcjonalność ta przypisana jest do klawisza:
- **C**. Tablicowanie wartości pierwiastka kwadratowego, obliczonego metodą Herona, z wartości zadanego szeregu potęgowego.

#### Zadanie: 
Tablicowanie wartości pierwiastka kwadratowego, obliczonego metodą Herona, z wartości zadanego szeregu potęgowego w określonym przedziale X ∈ <Xd, Xg) zmian wartości zmiennej niezależnej X, przy podanej dokładności obliczeń Eps (0 < Eps < 1) i przyrostu h (0 < h < 1) zmian wartości zmiennej niezależnej X w podanym przedziale <Xd, Xg).

#### Warunki logiczne:
  1. Wartość zmiennej niezależnej Xd musi był liczbą rzeczywistą należącą do przedziału: <br />
    Xd ∈ < -4/3, 4/3 ) <br />
    float Xd → Xd > -4/3 && Xd <= 4/3

  2. Wartość zmiennej niezależnej Xg musi był liczbą rzeczywistą większą lub równą wartości Xd, której wartość jednocześnie należy do przedziału: <br />
    Xg ∈ < Xd, 4/3 )  <br />
    float Xg → Xg >= Xd  && Xg < 4/3

  3. Wartość przyrostu h zmiennej niezależnej X, może być dowolną liczbą rzeczywistą mieszczącą się w zakresie: <br />
    h ∈ < Xd, Xg >  <br />
    float h → h <= Xd && h >= Xg

  4. Wartość dokładności obliczeń Eps jest liczbą zmiennoprzecinkową, należącą do przedziału: <br />
    Eps ∈ (0; 1) <br />
    float Eps → Eps > 0 && Eps < 1 

  5. Aby uzyskać pierwiastek kwadratowy metodą Herona z sumy szeregu, należy spełnić warunek: <br />
    Math.Abs( liczbaHerona – liczbaTestowa ) > Eps

<br />

### 4. Tablicowanie wartości n-tego pierwiastka, obliczonego metodą Newtona, z wartości zadanego szeregu potęgowego.
**Funkcjonalność ta przypisana jest do klawisza:**
- **D**. Tablicowanie wartości n-tego pierwiastka, obliczonego metodą Newtona, z wartości zadanego szeregu potęgowego.

#### Zadanie: 
Tablicowanie wartości n-tego pierwiastka, obliczonego metodą Newtona, z wartości zadanego szeregu potęgowego w określonym przedziale X ∈ <Xd, Xg) zmian wartości zmiennej niezależnej X, przy podanej dokładności obliczeń Eps (0 < Eps < 1) i przyrostu h (0 < h < 1) zmian wartości zmiennej niezależnej X w podanym przedziale <Xd, Xg).

#### Warunki logiczne:
  1. Wartość zmiennej niezależnej Xd musi był liczbą rzeczywistą należącą do przedziału: <br />
    Xd ∈ < -4/3, 4/3 ) <br />
    float Xd → Xd > -4/3 && Xd <= 4/3

  2. Wartość zmiennej niezależnej Xg musi był liczbą rzeczywistą większą lub równą wartości Xd, której wartość jednocześnie należy do przedziału: <br />
    Xg ∈ < Xd, 4/3 ) <br />
    float Xg → Xg >= Xd  && Xg < 4/3

  3. Wartość przyrostu h zmiennej niezależnej X, może być dowolną liczbą rzeczywistą mieszczącą się w zakresie: <br />
    h ∈ < Xd, Xg > <br />
    float h → h <= Xd && h >= Xg

  4. Wartość dokładności obliczeń Eps jest liczbą zmiennoprzecinkową, należącą do przedziału: <br />
    Eps ∈ (0; 1) <br />
    float Eps → Eps > 0 && Eps < 1 
    
  5. Aby uzyskać pierwiastek kwadratowy metodą Herona z sumy szeregu, należy spełnić warunek: <br />
    Math.Abs( Xi – Xi - 1) > Eps
