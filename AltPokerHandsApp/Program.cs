
            using Poker.models;

            using var reader = File.OpenText("C:/temp/p054_poker.txt");
            var line = reader.ReadLine();
            var player1_wins = 0;

            while (line != null)
            {
                player1_wins += Game.Judge(line);
                line = reader.ReadLine();
            }

            Console.WriteLine("Player 1 wins");
            Console.WriteLine(player1_wins);