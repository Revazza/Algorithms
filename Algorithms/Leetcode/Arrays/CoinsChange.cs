namespace Algorithms.Leetcode.Arrays;

public class CoinsChange
{
    public int Solve(int[] coins, int amount)
    {
        Array.Sort(coins);
        if (amount <= 0)
        {
            return 0;
        }

        if (coins.Length == 1)
        {
            return amount % coins[0] == 0 ? amount / coins[0] : -1;
        }

        var minMoves = int.MaxValue;
        var dp = new Dictionary<int, int>();
        CoinChangeRecursive(coins, coins.Length - 1, amount, 0, ref minMoves, dp);

        return minMoves;
    }

    private int CoinChangeRecursive(
        int[] coins,
        int startIndex,
        int amount,
        int moves,
        ref int minMoves,
        Dictionary<int, int> dp)
    {
        if (amount < 0)
        {
            return -1;
        }

        if (amount == 0)
        {
            return moves;
        }

        for (int i = startIndex; i >= 0; i--)
        {
            if (dp.ContainsKey(amount - coins[i]))
            {
                dp[amount - coins[i]] = Math.Min(minMoves, dp.GetValueOrDefault(minMoves));
            }

            var totalMoves = CoinChangeRecursive(coins, i, amount - coins[i], moves + 1, ref minMoves, dp);
            if (totalMoves != -1)
            {
                minMoves = Math.Min(totalMoves, minMoves);
                if (dp.ContainsKey(minMoves))
                {
                    dp[amount - coins[i]] = Math.Min(minMoves, dp[amount - coins[i]]);
                }
                else
                {
                    dp[amount - coins[i]] = minMoves;
                }
                // return totalMoves;
            }
        }

        return -1;
    }
}