using System;
using System.Collections.Generic;

namespace Iterative_computation
{
    class Iterative_Computation_Program
    {
        static bool realizationWithTracking;
        static ConsoleKeyInfo selectedFunctionKey;
        static Dictionary<ConsoleKey, string> availableFunctionality = getAvailableFunctionality();
        static List<float> iterativeSeriesSums = new List<float>();
        static List<float> iterativeWordsValues = new List<float>();
        static List<float> iterativeValuesX = new List<float>();
        static List<short> iterationCountersRoot = new List<short>();
        static List<short> summedWordsCounters = new List<short>();
        static float epsilon, maxX, minX, heightX;

        static void Main(string[] args)
        {
            setConsoleLook();
            Console.WriteLine("\n\n\t\t\tProgram 'Obliczenia Iteracyjne' umożliwia " +
                "wielokrotne obliczanie wartości \n\t\t\t z analizy wybranego szeregu potęgowego.");
            Console.WriteLine("\n\t\t\tDzisiejsza data: {0} \n\t\t\tGodzina: {1, 0:t}",
                DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now);
            Console.Write("\n\t\t\tNaciśnij dowolny klawisz aby rozpocząć... ");
            Console.ReadKey();

            do
            {
                Console.Clear();
                displayMenu();
                selectedFunctionKey = Console.ReadKey();

                if (selectedFunctionKey.Key != ConsoleKey.X)
                {
                    switch (selectedFunctionKey.Key)
                    {
                        case ConsoleKey.A:
                            getConsentForTracking();
                            calculateFunctionality_A();
                            break;
                        case ConsoleKey.B:
                            getConsentForTracking();
                            calculateFunctionality_B();
                            break;
                        case ConsoleKey.C:
                            getConsentForTracking();
                            calculateFunctionality_C();
                            break;
                        case ConsoleKey.D:
                            getConsentForTracking();
                            calculateFunctionality_D();
                            break;
                        default:
                            changeTextColor("\n\tERROR: nacisnąłeś niedozwolony klawisz (znak) " +
                                "- nie ma takiej funkcjonalności w MENU programu.", ConsoleColor.Red);
                            break;
                    }
                    Console.Write("\n\n\tDla kontynuacji działania programu naciśij dowolny klawisz... ");
                    Console.ReadKey();
                }
            } while (selectedFunctionKey.Key != ConsoleKey.X);

            displaySelectedFunctionality();
            Console.WriteLine("\n\tAutor programu: Zofia Wasilonek");
            Console.WriteLine("\n\tDzisiejsza data: {0}", DateTime.Now.ToString("dd-MM-yyyy"));
            Console.Write("\n\tWciśnięcie dowolnego klawisza spowoduje zamknięcie programu. " +
                "\n\tDo zobaczenia :) ");
            Console.ReadKey();
        }

        static Dictionary<ConsoleKey, string> getAvailableFunctionality()
        {
            return new Dictionary<ConsoleKey, string>()
            {
                { ConsoleKey.A, "A. Obliczanie wartości (sumy) zadanego szeregu potęgowego." },
                { ConsoleKey.B, "B. Tablicowanie wartości zadanego szeregu potęgowego." },
                { ConsoleKey.C, "C. Tablicowanie wartości pierwiastka kwadratowego, obliczonego " +
                    "\n\tmetodą Herona, z wartości zadanego szeregu potęgowego." },
                { ConsoleKey.D, "D. Tablicowanie wartości n-tego pierwiastka, obliczonego " +
                    "\n\tmetodą Newtona, z wartości zadanego szeregu potęgowego." },
                { ConsoleKey.X, "X. Zakończenie (wyjście z) programu." }
            };
        }

        static void displayMenu()
        {
            string seriesPattern =
                "\n\t ∞      2^n + n^2" +
                "\n\t ∑   = ----------- * X^n" +
                "\n\tn=1     3^n + n^3" +
                "\n";

            Console.WriteLine("\n\tMENU funkcjonalne programu:\n\n" + seriesPattern);
            foreach (string functionality in availableFunctionality.Values)
            {
                Console.WriteLine("\n\t" + functionality);
            }
            Console.Write("\n\tNaciśnięcie odpowiedniego klawisza wybiera jedną " +
                "z oferowanych funkcjonalości: ");
        }

        static void setConsoleLook()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WindowWidth = 140; 
            Console.WindowHeight = 30; 
            Console.Clear();
        }

        static void getConsentForTracking()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\n\n\tCzy obliczenia mają być realizowane ze śledzeniem, czy bez ?" +
                    "\n\tNaciśnij klawisz T lub t jeśli ze śledzeniem lub dowolny inny klawisz jeśli bez śledzenia):  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            if (selectedFunctionKey.Key != ConsoleKey.X)
                if (Console.ReadKey().Key == ConsoleKey.T)
                    realizationWithTracking = true;
                else
                    realizationWithTracking = false;
        }

        static void displaySelectedFunctionality()
        {
            string selectedFunctionality = availableFunctionality[selectedFunctionKey.Key];
            Console.Clear();
            changeTextColor("\n\n\tWybrana funkcjonalość to " + selectedFunctionality,
                ConsoleColor.DarkMagenta);
        }



        /* ***************FUNCTIONALITY A******************* */
        static void calculateFunctionality_A()
        {
            displaySelectedFunctionality();

            iterativeValuesX = new List<float>();
            iterativeWordsValues = new List<float>();
            iterativeSeriesSums = new List<float>();
            summedWordsCounters = new List<short>();

            float x, epsilon, sumSeries;

            getValue_X("Podaj wartość zmiennej niezależnej X:", out x);
            getValue_Epsilon(out epsilon);
            sumSeries = calculateSeriesSum(x, epsilon);
            if (iterativeWordsValues.Count > 0)
            {
                displayResult("Obliczona suma szeregu potęgowego jest równa: " +
                String.Format("{0,8:F3}", sumSeries) +
                "\n\tZsumowano k = " + iterativeWordsValues.Count +
                " wyrazów szeregu potęgowego");
            }
            else displayResult("Brak wyrazów szeregu w podanych przedziałach.");
        }

        static float calculateSeriesSum(float x, float epsilon)
        {
            short k = 0; // word's number
            float w = 0.0F;
            double wordSeries;
            float sumSeries = 0.0F;
            do
            {
                sumSeries += w;
                if (k > 0)
                {
                    if (selectedFunctionKey.Key == ConsoleKey.A)
                    {
                        iterativeValuesX.Add((float)Math.Pow(x, k));
                        iterativeWordsValues.Add(w);
                        iterativeSeriesSums.Add(sumSeries);
                    }
                    if (realizationWithTracking)
                    {
                        string calculations =
                            "\tWartość X = " + x +
                            "\n\n\t\tWyraz szeregu: a" + k + " = " + w +
                            "\n\n\t\tSuma an = " + k + " wyrazów szeregu potęgowego " +
                            "dla X = " + x + ": " +
                            "\n\t\tSuma ∑ = " + sumSeries;
                        displayTrackingCalculation(calculations);
                    }
                }
                k++;
                wordSeries = (Math.Pow(2, k) + Math.Pow(k, 2)) / (Math.Pow(3, k) + Math.Pow(k, 3))
                    * Math.Pow(x, k);
                w = (float)wordSeries;
            } while (Math.Abs(w) > epsilon);
            k--;
            summedWordsCounters.Add(k);
            return sumSeries;
        }



        /* ***************FUNCTIONALITY B******************* */
        static void calculateFunctionality_B()
        {
            displaySelectedFunctionality();
            Console.WriteLine("\n\tAby obliczyć sumę szeregu w przedziale, należy podać przedział wartości " +
                "\n\tzmiennej niezależnej X: [Xd, Xg], wartość jej przyrostu H oraz " +
                "\n\tdokładność obliczeń kolejnych wyrazów szeregu Eps:");
            getCalculationData();

            if (iterativeWordsValues.Count > 0)
            {
                displayFunctionalTable_B(100);
                displayDataTableInDifferentFormats(iterativeSeriesSums, 100, "Suma(X)");
            }
            else
                displayResult("Brak wyrazów szeregu w podanych przedziałach.");
        }



        /* ***************FUNCTIONALITY C******************* */
        static void calculateFunctionality_C()
        {
            displaySelectedFunctionality();
            changeTextColor("\n\tAby obliczyć pierwiastek Herona, należy podać przedział wartości " +
                "\n\tzmiennej niezależnej X, wartość jej przyrostu H oraz " +
                "\n\tdokładność obliczeń kolejnych wyrazów szeregu Eps:", ConsoleColor.DarkGreen);
            getCalculationData();

            if (iterativeSeriesSums.Count > 0)
            {
                List<float> HeronsNumbers = getHeronsNumbs(iterativeSeriesSums);
                displayResult("Obliczono łacznie i = " + iterativeSeriesSums.Count +
                    " sumy szeregu potęgowego");
                if (HeronsNumbers.Count > 0)
                {
                    displayRootsTable(HeronsNumbers, "Herona", 100);
                    displayDataTableInDifferentFormats(HeronsNumbers, 100, "Heron S(x)");
                }
                else changeTextColor("\n\tERROR: Nie udało się obliczyć pierwiastka " +
                    "metodą Herona z podanych sum szeregu.", ConsoleColor.Red);
            }
            else displayResult("Brak wyrazów szeregu w podanym przedziale Eps = " + epsilon);
        }

        static List<float> getHeronsNumbs(List<float> numbsList)
        {
            iterationCountersRoot = new List<short>();
            List<float> HeronsNumbers = new List<float>();

            for (int i = 0; i < numbsList.Count; i++)
            {
                float number = numbsList[i];
                float HeronsNumber;
                short operationCounter;
                float x = iterativeValuesX[i];
                calculateHeronsRoot(numbsList, number, epsilon, x,
                    out HeronsNumber, out operationCounter);
                HeronsNumbers.Add(HeronsNumber);
                iterationCountersRoot.Add(operationCounter);

                if (realizationWithTracking)
                {
                    int computedSumIndex = numbsList.IndexOf(number) + 1;
                    string calculations =
                        "Pierwiastek kwadratowy Herona z ∑" + computedSumIndex + " = "
                        + number + " wynosi: " + HeronsNumber;
                    displayTrackingCalculation(calculations);
                }
            }
            return HeronsNumbers;
        }

        static void calculateHeronsRoot(List<float> numbsList, float number,
            float epsilon, float x, out float HeronsNumber, out short iterationCounter)
        {
            float testNumber;
            HeronsNumber = number / 2.0F;
            iterationCounter = 0;

            if (number < 0.0F)
                HeronsNumber = 0.0F;
            else
            {
                do
                {
                    testNumber = HeronsNumber;
                    iterationCounter++;
                    HeronsNumber = (testNumber + number / testNumber) / 2.0F;

                    if (realizationWithTracking)
                    {
                        int computedXIndex = iterativeValuesX.IndexOf(x) + 1;
                        int computedSumIndex = numbsList.IndexOf(number) + 1;
                        string calculations =
                            "\t" + iterationCounter + " ITERACJA:" +
                            " \n\t\tWartość pierwiastka obliczonego metodą Herona z" +
                            "\n\t\tsumy ∑" + computedSumIndex + " = " + number +
                            "\n\t\tX" + computedXIndex + " = " + x +
                            "\n\n\t\tPierwiastek kwadratowy Herona: " + HeronsNumber;
                        displayTrackingCalculation(calculations);
                    }

                } while (Math.Abs(HeronsNumber - testNumber) > epsilon);
            }
        }



        /* ***************FUNCTIONALITY D******************* */
        static void calculateFunctionality_D()
        {
            displaySelectedFunctionality();
            changeTextColor("\n\tAby obliczyć pierwiastek Newtona należy podać przedział wartości " +
                "\n\tzmiennej niezależnej X, wartość jej przyrostu H oraz " +
                "\n\tdokładność obliczeń kolejnych wyrazów szeregu Eps:", ConsoleColor.DarkGreen);
            getCalculationData();

            if (iterativeSeriesSums.Count > 0)
            {
                List<float> NewtonsNumbers = getNewtonsNumbers(iterativeSeriesSums);
                displayResult("Obliczono łacznie i = " + iterativeSeriesSums.Count +
                    " sum szeregu potęgowego");
                if (NewtonsNumbers.Count > 0)
                {
                    displayRootsTable(NewtonsNumbers, "Newtona", 100);
                    displayDataTableInDifferentFormats(NewtonsNumbers, 100, "Newton S(x)");
                }
                else changeTextColor("\n\tERROR: Nie udało się obliczyć pierwiastka " +
                    "metodą Newtona z podanych sum szeregu.", ConsoleColor.Red);
            }
            else displayResult("Brak wyrazów szeregu w podanym przedziale Eps = " + epsilon);
        }

        static List<float> getNewtonsNumbers(List<float> numbsList)
        {
            iterationCountersRoot = new List<short>();
            List<float> NewtonsNumbers = new List<float>();

            for (short i = 0; i < numbsList.Count; i++)
            {
                float numberNewtona;
                short operationCounter;
                short rootsDegree = (short)(i + 1.0F);
                float number = numbsList[i];
                float x = iterativeValuesX[i];
                calculateNewtonsRoot(numbsList, number, rootsDegree, x,
                    epsilon, out numberNewtona, out operationCounter);
                NewtonsNumbers.Add(numberNewtona);
                iterationCountersRoot.Add(operationCounter);

                if (realizationWithTracking)
                {
                    int computedSumIndex = numbsList.IndexOf(number) + 1;
                    string calculations =
                        "Pierwiastek Newtona z ∑" + computedSumIndex + " = "
                        + number + " wynosi: " + numberNewtona;
                    displayTrackingCalculation(calculations);
                }
            }
            return NewtonsNumbers;
        }

        static void calculateNewtonsRoot(List<float> numbsList, float number, short rootsDegree,
            float epsilon, float x, out float numberNewtona, out short iterationCounter)
        {
            iterationCounter = 0;
            float xi, xi_1; //i - th and(i - 1) approximations to the root
            if (number <= 0.0F || rootsDegree < 0)
                numberNewtona = 0.0F;
            else
            {
                xi = number;
                do
                {
                    iterationCounter++;
                    xi_1 = xi;
                    xi = ((rootsDegree - 1) * xi_1 + number / (float)Math.Pow(xi - 1, rootsDegree - 1)) / rootsDegree;

                    if (realizationWithTracking && Math.Abs(xi - xi_1) > epsilon)
                    {
                        int computedXIndex = (iterativeValuesX.IndexOf(x)) + 1;
                        int computedSumIndex = (numbsList.IndexOf(number)) + 1;
                        string calculations = "\t" + iterationCounter + " ITERACJA:" +
                            " \n\t\tWartość pierwiastka obliczonego metodą Newtona z" +
                            "\n\t\tsumy ∑" + computedSumIndex + " = " + number +
                            "\n\t\tX" + computedXIndex + " = " + x +
                            "\n\n\t\tPierwiastek Newtona: " + xi;
                        displayTrackingCalculation(calculations);
                    }
                } while (Math.Abs(xi - xi_1) > epsilon);
                numberNewtona = xi;
            }
        }



        /* ***************AUXILIARY METHODS**************** */
        static void getValue_Epsilon(out float epsilon)
        {
            do
            {
                getRealNumber("Podaj dokładność obliczeń kolejnych wyrazów Eps," +
                    " gdzie 0 < Eps < 1: ", out epsilon);
                if (epsilon <= 0.0F || epsilon >= 1.0F)
                {
                    string epsErrorMessage =
                        "\n\tERROR: podana dokładność obliczeń Eps wykracza poza " +
                        "przedział dozwolonych wartości: 0 < Eps < 1 ";
                    changeTextColor(epsErrorMessage, ConsoleColor.Red);
                }
            } while (epsilon <= 0.0F || epsilon >= 1.0F);
        }

        static void getIncrementValueHeight_X(out float heightX)
        {
            const float MIN_X_HEIGHT = 0.0F;
            float MAX_X_HEIGHT = (maxX - minX) / 2.0F;

            while (true)
            {
                getRealNumber("Podaj wartość przyrostu H zmiennej niezależnej X, " +
                    "gdzie " + MIN_X_HEIGHT + " < H <= " + MAX_X_HEIGHT + ": ", out heightX);
                if (heightX <= MIN_X_HEIGHT || heightX > MAX_X_HEIGHT)
                {
                    string hErrorMessage = "\n\tERROR: podana wartość przystu H wykracza poza " +
                        "przedział dozwolonych wartości: " + MIN_X_HEIGHT + " < H <= " + MAX_X_HEIGHT;
                    changeTextColor(hErrorMessage, ConsoleColor.Red);
                }
                else break;
            }
        }

        static void getCalculationData()
        {
            getValue_X("Podaj dolną (Xd) wartość zmiennej niezależnej X:", out minX);
            getValue_maxX("Podaj górną (Xg) wartość zmiennej niezależnej X:", out maxX);
            if (maxX - minX == 0)
            {
                heightX = 0.0F;
                changeTextColor("\n\tRóżnica między Xg a Xd wyniosi 0, co oznacza, " +
                    "że liczymy sumę szeregu tylko dla jednej wartości X", ConsoleColor.Green);
            }
            else getIncrementValueHeight_X(out heightX);
            getValue_Epsilon(out epsilon);

            if (realizationWithTracking)
            {
                displayTrackingCalculation("Wprowadzone dane: " +
                    "\n\tPrzedział wartości zmiennej niezależnej X: " +
                    "<" + minX + "; " + maxX + ">" +
                    "\n\tWartość przyrostu H zmiennej niezależnej X: H = " + heightX +
                    "\n\tDokładność obliczeń kolejnych wyrazów szeregu Eps: Eps = " + epsilon);
            }
            calculateSumSeriesInRange();
        }

        static void calculateSumSeriesInRange()
        {
            iterativeWordsValues = new List<float>();
            iterativeValuesX = new List<float>();
            iterativeSeriesSums = new List<float>();
            summedWordsCounters = new List<short>();

            ushort k = 0;
            float x = minX;
            float w;
            double wordSeries;
            do
            {
                k++;
                wordSeries = (Math.Pow(2.0F, k) + Math.Pow(k, 2.0F)) / (Math.Pow(3.0F, k)
                    + Math.Pow(k, 3.0F)) * Math.Pow(x, k);
                w = (float)wordSeries;

                iterativeValuesX.Add(x);
                iterativeWordsValues.Add(w);
                float sumSeries = calculateSeriesSum(x, epsilon);
                if (sumSeries > 0)
                    iterativeSeriesSums.Add(sumSeries);

                x += heightX;
            } while (Math.Abs(w) >= epsilon && x < maxX);
        }

        static void getValue_maxX(string message, out float maxX)
        {
            while (true)
            {
                getValue_X(message, out maxX);
                if (maxX < minX)
                    changeTextColor("\n\tERROR: podana wartość Xg " +
                        "nie może być mniejsza od Xd = " + minX + "!", ConsoleColor.Red);
                else break;
            };
        }

        static void getValue_X(string message, out float x)
        {
            const float MIN_X_LIMIT = (-4.0F / 3.0F);
            const float MAX_X_LIMIT = (4.0F / 3.0F); //excluding this value
            do
            {
                Console.Write("\n\tPodana wartość musi mieścić się w przedziale: X = [ -1,(3) ; 1,(3) ) " +
                     "\n\t" + message + " ");
                string stringX = Console.ReadLine();
                if (float.TryParse(stringX, out x))
                {
                    if (x < MIN_X_LIMIT || x >= MAX_X_LIMIT)
                    {
                        changeTextColor("\n\tERROR: podana wartość dla X wykracza poza " +
                            "przedział zbieżności szeregu !!!", ConsoleColor.Red);
                    }
                    else break;
                }
                else
                {
                    string numberErrorMessage =
                    "\n\tERROR: W zapisie liczby wystąpił niedozwolony znak." +
                    "\n\tNależy podać liczbę rzeczywistą.";
                    changeTextColor(numberErrorMessage, ConsoleColor.Red);
                }
            } while (true);
        }

        static void getRealNumber(string message, out float loadedNumber)
        {
            Console.Write("\n\t" + message + " ");
            while (!float.TryParse(Console.ReadLine(), out loadedNumber))
            {
                string numberErrorMessage =
                    "\n\tERROR: W zapisie liczby wystąpił niedozwolony znak." +
                    "\n\tNależy podać liczbę rzeczywistą.";
                changeTextColor(numberErrorMessage, ConsoleColor.Red);
                Console.Write("\n\t" + message + " ");
            }
        }

        static void changeTextColor(string message, ConsoleColor textColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        static void displayTrackingCalculation(string calculation)
        {
            string separator = "--------------------------------------------------------";
            string initialMessage = "\n\tTRACE: Operacje śledzenia: ";

            changeTextColor("\n\t" + separator + initialMessage, ConsoleColor.DarkBlue);
            changeTextColor("\n\t" + calculation, ConsoleColor.DarkBlue);
            changeTextColor("\n\t" + separator, ConsoleColor.DarkBlue);
        }

        static void displayResult(string resultMessage)
        {
            string separator = "********************************************************";
            string initialMessage = "\n\tWYNIK FUNKCJONALNOŚCI:";

            changeTextColor("\n\t" + separator + initialMessage, ConsoleColor.DarkGreen);
            changeTextColor("\n\t" + resultMessage, ConsoleColor.DarkMagenta);
            changeTextColor("\n\t" + separator, ConsoleColor.DarkGreen);
        }

        static void displayRootsTable(List<float> rootsList, string methodCreatorName, int tableWidth)
        {
            TableTools tableTools = new TableTools(tableWidth);

            //table header
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("\n\n\n");
            tableTools.drawSeparator();
            tableTools.drawRow(" ", "Suma ", "Licznik", "Pierwiastek", "Licznik");
            tableTools.drawRow("X", "szeregu", "zsumowanych", "metodą", "przebytych");
            tableTools.drawRow(" ", "potęgowego", "wyrazów", methodCreatorName, "iteracji");
            tableTools.drawSeparator();

            Console.ForegroundColor = ConsoleColor.Black;

            //table body
            for (int i = 0; i < iterativeValuesX.Count; i++)
            {
                string row1, row2, row3, row4, row5;
                row1 = String.Format("{0,6:F2}", iterativeValuesX[i]);
                row2 = String.Format("{0,8:F2}", iterativeSeriesSums[i]);
                row3 = String.Format("{0}", iterativeWordsValues.Count);
                row4 = String.Format("{0,6:F2}", rootsList[i]);
                row5 = String.Format("{0}", iterationCountersRoot[i]);

                tableTools.drawRow(row1, row2, row3, row4, row5);
                tableTools.drawSeparator();
            }
        }

        static void displayFunctionalTable_B(int tableWidth)
        {
            TableTools TableTools = new TableTools(tableWidth);

            //header
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("\n\n\n");
            TableTools.drawSeparator();
            TableTools.drawRow(" ", "Suma ", "Licznik");
            TableTools.drawRow("X", "szeregu", "zsumowanych");
            TableTools.drawRow(" ", "potęgowego", "wyrazów");
            TableTools.drawSeparator();

            Console.ForegroundColor = ConsoleColor.Black;

            //body
            for (int i = 0; i < iterativeValuesX.Count; i++)
            {
                string row1, row2, row3;
                row1 = String.Format("{0}", iterativeValuesX[i]);
                row2 = String.Format("{0}", iterativeSeriesSums[i]);
                row3 = String.Format("{0}", summedWordsCounters[i]);

                TableTools.drawRow(row1, row2, row3);
                TableTools.drawSeparator();
            }
        }
        static void displayDataTableInDifferentFormats(List<float> dataToDisplay,
            int tableWidth, string analyzedDataName = "F(X)")
        {
            TableTools tableTools = new TableTools(tableWidth);

            //header
            string wordValue, wordFormat;
            wordValue = "wartość w";
            wordFormat = "formacie";

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("\n\n\n");
            tableTools.drawSeparator();
            tableTools.drawRow(" ", analyzedDataName, analyzedDataName, analyzedDataName, analyzedDataName);
            tableTools.drawRow(" ", wordValue, wordValue, wordValue, wordValue);
            tableTools.drawRow("X", wordFormat, wordFormat, wordFormat, wordFormat);
            tableTools.drawRow(" ", "domyślnym:", "wykładniczym:", "stałopozycyjnym:", "zwięzłym:");
            tableTools.drawRow(" ", "{0}", "{0, 8:E2}", "{0, 8:F2}", "{0, 8:G2}");
            tableTools.drawSeparator();

            Console.ForegroundColor = ConsoleColor.Black;

            //body
            for (int i = 0; i < iterativeValuesX.Count; i++)
            {
                string row1, row2, row3, row4, row5;
                row1 = String.Format("{0}", iterativeValuesX[i]);
                row2 = String.Format("{0}", dataToDisplay[i]);
                row3 = String.Format("{0,8:E2}", dataToDisplay[i]);
                row4 = String.Format("{0,8:F2}", dataToDisplay[i]);
                row5 = String.Format("{0,8:G2}", dataToDisplay[i]);

                tableTools.drawRow(row1, row2, row3, row4, row5);
                tableTools.drawSeparator();
            }
        }
    }

    class TableTools
    {
        int tableWidth;

        public TableTools(int tableWidth)
        {
            this.tableWidth = tableWidth;
        }

        public void drawSeparator()
        {
            Console.WriteLine("\t" + new string('-', tableWidth));
        }

        public void drawRow(params string[] columns)
        {
            int rowWidth = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += setCenter(column, rowWidth) + "|";
            }
            Console.WriteLine("\t" + row);
        }

        public string setCenter(string message, int rowWidth)
        {
            message = message.Length > rowWidth ? message.Substring(0, rowWidth - 3) +
                "..." : message;
            if (string.IsNullOrEmpty(message)) return new string(' ', rowWidth);
            else return message.PadRight(rowWidth -
                (rowWidth - message.Length) / 2).PadLeft(rowWidth);
        }
    }
}
