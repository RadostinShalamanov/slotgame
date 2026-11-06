using SlotGame.Domain;
using SlotGame.Domain.Models;
using SlotGame.Helpers;

namespace SlotGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Configuration slotConfiguration = new Configuration();

            Slot slot = new Slot(slotConfiguration);


            SimulationService simulationService = new SimulationService(slot);

            Console.WriteLine("~~~~~ Slot Game ~~~~~");
            Console.Write("Enter number of spins:");

            if (!long.TryParse(Console.ReadLine(), out long spins) || spins <= 0)
            {
                Console.WriteLine("Spins must be positive");
                return;
            }


            SimulationResult simulationResult = simulationService.Run(spins);


            Console.WriteLine("\n~~~~~ Simulation Results ~~~~~");

            Console.WriteLine($"TOtal Spins: {simulationResult.TotalSpins:N0}");
            Console.WriteLine($"TOtal Bets: {simulationResult.TotalBets:N0}");
            Console.WriteLine($"TOtal Wins: {simulationResult.TotalWins:N0}");
            Console.WriteLine($"Winning Spins: {simulationResult.WinningSpins:N0}");
            Console.WriteLine($"Profit/loss: {simulationResult.NetProfit:N0}");
            Console.WriteLine($"RTP: {simulationResult.RTP():F2}%");

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
