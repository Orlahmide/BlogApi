namespace Assignment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            // Question 1 - Validate Number in Range (1-10)
            Console.Write("Enter a number between 1 and 10: ");
            string? userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int validatedNumber) && validatedNumber >= 1 && validatedNumber <= 10)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Invalid");

            // Question 1 - Find Maximum of Two Numbers
            Console.Write("Enter the first number: ");
            string? firstInput = Console.ReadLine();

            Console.Write("Enter the second number: ");
            string? secondInput = Console.ReadLine();

            if (int.TryParse(firstInput, out int firstNumber) && int.TryParse(secondInput, out int secondNumber))
                Console.WriteLine($"The maximum number is: {Math.Max(firstNumber, secondNumber)}");
            else
                Console.WriteLine("Invalid input. Please enter valid numbers.");

            // Question 1 - Determine Image Orientation
            Console.Write("Enter the width of the image: ");
            string? imageWidthInput = Console.ReadLine();

            Console.Write("Enter the height of the image: ");
            string? imageHeightInput = Console.ReadLine();

            if (int.TryParse(imageWidthInput, out int imageWidth) && int.TryParse(imageHeightInput, out int imageHeight))
                Console.WriteLine(imageWidth > imageHeight ? "The image is in Landscape mode." : "The image is in Portrait mode.");
            else
                Console.WriteLine("Invalid input. Please enter valid numbers.");

            // Question 1 - Speed Limit Check and Demerit Points
            Console.Write("Enter the speed limit: ");
            string? speedLimitInput = Console.ReadLine();

            Console.Write("Enter the speed of the car: ");
            string? carSpeedInput = Console.ReadLine();

            if (int.TryParse(speedLimitInput, out int speedLimit) && int.TryParse(carSpeedInput, out int carSpeed))
            {
                if (carSpeed <= speedLimit)
                {
                    Console.WriteLine("Ok");
                }
                else
                {
                    int overSpeed = carSpeed - speedLimit;
                    int demeritPoints = overSpeed / 5;
                    Console.WriteLine($"Demerit Points: {demeritPoints}");

                    if (demeritPoints > 12)
                        Console.WriteLine("License Suspended");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
            }





            // Question 2 - Count Numbers Divisible by 3 (1-100)
            int divisibleCount = Enumerable.Range(1, 100).Count(n => n % 3 == 0);
            Console.WriteLine($"The count of numbers divisible by 3 between 1 and 100 is: {divisibleCount}");

            // Question 2 - Sum of User Input Until 'ok'
            int sum = 0;
            while (true)
            {
                Console.Write("Enter a number or type 'ok' to exit: ");
                string? sumInput = Console.ReadLine();

                if (sumInput?.ToLower() == "ok")
                    break;

                if (int.TryParse(sumInput, out int numberToAdd))
                {
                    sum += numberToAdd;
                    Console.WriteLine($"Current sum: {sum}");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            Console.WriteLine($"Final sum: {sum}");

            // Question 2 - Calculate Factorial
            Console.Write("Enter a number to calculate its factorial: ");
            if (int.TryParse(Console.ReadLine(), out int factorialNumber) && factorialNumber >= 0)
            {
                BigInteger factorialResult = Enumerable.Range(1, factorialNumber).Aggregate(BigInteger.One, (a, b) => a * b);
                Console.WriteLine($"{factorialNumber}! = {factorialResult}");
            }
            else
            {
                Console.WriteLine("Factorial is not defined for negative numbers.");
            }

            // Question 2 - Guessing Game
            Random random = new Random();
            int secretNumber = random.Next(1, 11);
            bool isGuessedCorrectly = false;

            for (int attempt = 1; attempt <= 4; attempt++)
            {
                Console.Write($"Attempt {attempt} - Guess the number: ");
                if (int.TryParse(Console.ReadLine(), out int userGuess) && userGuess == secretNumber)
                {
                    isGuessedCorrectly = true;
                    break;
                }
            }

            Console.WriteLine(isGuessedCorrectly ? "You won!" : $"You lost. The secret number was: {secretNumber}");

            // Question 2 - Find Maximum in a List
            Console.Write("Enter a series of numbers separated by commas: ");
            string[] numberStrings = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();

            int[] numbers = numberStrings.Select(n => int.TryParse(n.Trim(), out int num) ? num : 0).ToArray();
            Console.WriteLine($"The maximum number is: {numbers.Max()}");





            // Question 3 - Facebook Likes
            List<string> likedUsers = new();
            Console.WriteLine("Enter names of people who liked your post (press 'Enter' to stop):");

            while (true)
            {
                string name = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(name)) break;
                likedUsers.Add(name);
            }

            switch (likedUsers.Count)
            {
                case 0:
                    Console.WriteLine("No one liked your post.");
                    break;
                case 1:
                    Console.WriteLine($"{likedUsers[0]} liked your post.");
                    break;
                case 2:
                    Console.WriteLine($"{likedUsers[0]} and {likedUsers[1]} liked your post.");
                    break;
                default:
                    Console.WriteLine($"{likedUsers[0]}, {likedUsers[1]}, and {likedUsers.Count - 2} others liked your post.");
                    break;
            }
            // Question 3 - Reverse Name
            Console.Write("Enter your name: ");
            string? userName = Console.ReadLine();
            Console.WriteLine(string.IsNullOrWhiteSpace(userName) ? "Invalid name" : $"Reversed name: {new string(userName.Reverse().ToArray())}");

            // Question 3 - Unique Sorted Numbers
            HashSet<int> uniqueNumbers = new();
            while (uniqueNumbers.Count < 5)
            {
                Console.Write("Enter a number: ");
                if (int.TryParse(Console.ReadLine(), out int userNumber) && uniqueNumbers.Add(userNumber))
                    continue;
                Console.WriteLine("Invalid input or duplicate number.");
            }

            Console.WriteLine("Sorted unique numbers:");
            foreach (var num in uniqueNumbers.OrderBy(n => n))
                Console.WriteLine(num);





            // Question 4 - Check for Consecutive Numbers
            Console.Write("Enter a series of numbers separated by hyphens: ");
            int[] sortedNumbers = (Console.ReadLine()?.Split('-').Select(n => int.Parse(n.Trim())).OrderBy(n => n).ToArray()) ?? Array.Empty<int>();

            Console.WriteLine(sortedNumbers.Zip(sortedNumbers.Skip(1), (a, b) => b - a == 1).All(x => x) ? "Consecutive" : "Not Consecutive");

            // Question 4 - Convert to Pascal Case
            Console.Write("Enter a few words separated by spaces: ");
            string pascalCase = string.Join("", (Console.ReadLine() ?? "").Split(' ').Select(word => char.ToUpper(word[0]) + word[1..].ToLower()));
            Console.WriteLine(string.IsNullOrWhiteSpace(pascalCase) ? "Invalid input" : pascalCase);

            // Question 4 - Count Vowels in a Word
            Console.Write("Enter an English word: ");
            string word = Console.ReadLine()?.ToLower() ?? "";
            int vowelCount = word.Count(c => "aeiou".Contains(c));
            Console.WriteLine($"Number of vowels: {vowelCount}");





            //Question 5 number 1
            Console.Write("Enter the path of the text file: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("The file does not exist.");
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(filePath);

                string[] words = fileContent.Split(new[] { ' ', '\n', '\r', '\t', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine("Number of words: " + words.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }


            ////Question 5 number 2
            Console.Write("Enter the path of the text file: ");
            string fileDir = Console.ReadLine();

            // Check if the file exists
            if (!File.Exists(fileDir))
            {
                Console.WriteLine("The file does not exist.");
                return;
            }

            try
            {
                // Read the content of the file
                string fileContent = File.ReadAllText(fileDir);

                // Split the content into words based on spaces and punctuation
                string[] words = fileContent.Split(new[] { ' ', '\n', '\r', '\t', '.', ',', ';', '!', '?', '-', '_', '(', ')', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

                // Initialize a variable to track the longest word
                string longestWord = string.Empty;

                // Iterate over each word
                foreach (string uniqueWord in words)
                {
                    // Check if the current word is longer than the longest word found so far
                    if (uniqueWord.Length > longestWord.Length)
                    {
                        longestWord = uniqueWord;
                    }
                }

                // Display the longest word found
                if (string.IsNullOrEmpty(longestWord))
                {
                    Console.WriteLine("No words found in the file.");
                }
                else
                {
                    Console.WriteLine("The longest word is: " + longestWord);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during file reading
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

    }

}

