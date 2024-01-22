﻿using System.Collections.ObjectModel;
namespace JogoGourmet
{
    internal class Game
    {
        private static List<string> _availableDishes = new List<string> { "Lasanha", "Massa", "Bolo de Chocolate" };
        public ReadOnlyCollection<string> AvailableDishes => _availableDishes.AsReadOnly();
        private int _numberOfHits = 0;
        private int _numberOfMisses = 0;
        private string _dishUserThought = string.Empty;
        private void IncrementNumberOfHits() => _numberOfHits++;
        private void IncrementNumberOfMisses() => _numberOfMisses++;

        public void Start()
        {
            ClearConsole();
            ShowWelcomeMessage();
            TryToGuessDish();
            AskWhatDishUserThought();
            AskUserToCompleteSentence();
            var userWantsToPlayAgain = AskIfUserWantsToPlayAgain();
            if (userWantsToPlayAgain)
            {
                RestartGame();
            }
        }
        public void RestartGame()
        {
            _numberOfHits = 0;
            _numberOfMisses = 0;
            _dishUserThought = string.Empty;
            Start();
        }
        private void ShowWelcomeMessage()
        {
            Console.WriteLine("Pense em um prato que você gosta...");
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }
        private void TryToGuessDish()
        {
            foreach (var dish in _availableDishes)
            {
                var dishIsWhatUserThought = AskIfDishIs(dish);
                if (dishIsWhatUserThought)
                {
                    var userWantsToPlayAgain = AskIfUserWantsToPlayAgain();
                    if (userWantsToPlayAgain)
                    {
                        RestartGame();
                    }
                }
            }
        }
        private bool AskIfUserWantsToPlayAgain()
        {
            while (true)
            {
                Console.WriteLine("Deseja jogar novamente? (S/N)");
                var answer = Console.ReadLine();
                answer = answer?.Trim().ToUpper();
                switch (answer)
                {
                    case "S":
                        return true;
                    case "N":
                        return false;
                    default:
                        Console.WriteLine("Resposta inválida");
                        break;
                }
            }
        }
        private bool AskIfDishIs(string dish)
        {
            while (true)
            {
                Console.WriteLine($"O prato que você pensou é {dish}? (S/N)");
                var answer = Console.ReadLine();
                answer = answer?.Trim().ToUpper();
                switch (answer)
                {
                    case "S":
                        IncrementNumberOfHits();
                        Console.WriteLine("Acertei de novo! :D");
                        return true;
                    case "N":
                        IncrementNumberOfMisses();
                        return false;
                    default:
                        Console.WriteLine("Resposta inválida");
                        break;
                }
            }
        }
        private void AskWhatDishUserThought()
        {
            while (true)
            {
                Console.WriteLine("Qual prato você pensou?");
                var dish = Console.ReadLine();
                dish = dish?.Trim();
                switch (dish)
                {
                    case "":
                        Console.WriteLine("Resposta inválida");
                        Task.Delay(1000).Wait();
                        break;
                    default:
                        AddDishToAvailableList(dish);
                        _dishUserThought = dish;
                        return;
                }
            }
        }
        private void AskUserToCompleteSentence()
        {
            while (true)
            {
                Console.WriteLine("Complete a frase:");
                Console.WriteLine($"{_dishUserThought} é _______ mas {_availableDishes.GetRandom()} não.");
                var dish = Console.ReadLine();
                dish = dish?.Trim();
                switch (dish)
                {
                    case "":
                        Console.WriteLine("Resposta inválida");
                        break;
                    default:
                        return;
                }
            }
        }
        private void AddDishToAvailableList(string dish)
        {
            if (!_availableDishes.Contains(dish))
            {
                _availableDishes.Add(dish);
            }

        }
        private void ClearConsole()
        {
            Console.Clear();
        }

    }
}
