# SlotGame

A simple slot machine game and simulation built with C# and .NET.

## How it works

The slot machine has 5 reels and 3 visible rows. Each spin randomly selects a position on every reel and displays the symbols.

The game checks the configured paylines for matching symbols from left to right. If a payline has a winning combination, the corresponding payout is added to the total win.

## How to install and run

1. Install the [.NET SDK](https://dotnet.microsoft.com/download).
2. Clone or download this repository.
3. Open a terminal in the folder containing the solution file.
4. Restore and build the project:

   ```bash
   dotnet restore
   dotnet build
   ```

5. Run the console project:

   ```bash
   dotnet run --project SlotGame
   ```

   If your console project has a different name or location, use its project path instead.

## Simulation

When the program starts, enter how many spins you want to simulate.

For example:

```text
Enter number of spins: 1000000
```

The simulation reports statistics such as:

```text
--- SIMULATION RESULTS ---
Total spins:       1000000
Total bets:        ...
Total wins:        ...
Winning spins:     ...
Net profit:        ...
RTP:               ...%
```

The results will vary between runs because each spin uses random reel positions.

### Simulation metrics

| Metric | Meaning |
|---|---|
| Total spins | Number of spins performed. |
| Total bets | Total amount wagered across all spins and active paylines. |
| Total wins | Gross payout returned by winning paylines. |
| Winning spins | Number of spins with at least one winning payline. |
| Net profit | Total wins minus total bets. |
| RTP | Return to Player, calculated as `TotalWins / TotalBets * 100`. |



## Project structure

- **SlotGame.Domain** – slot machine logic and game models.
- **SlotGame.Helpers** – runs multiple spins and calculates statistics.
- **SlotGame** – gets input from the user and displays the results.
