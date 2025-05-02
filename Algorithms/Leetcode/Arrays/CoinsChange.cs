namespace Algorithms.Leetcode.Arrays;

public class CoinsChange
{
    public int Solve(int[] coins, int amount)
    {
        coins = coins.OrderByDescending(c => c).ToArray();
        if (amount <= 0)
        {
            return 0;
        }

        if (coins.Length == 1)
        {
            return amount % coins[0] == 0 ? amount / coins[0] : -1;
        }

        var dp = new Dictionary<int, int>();
        return CalculateMoves(0, amount, coins, dp) - 1;
    }

    // Input: coins = [1,3,4,5], amount = 20
    // 
    private int CalculateMoves(int currentAmount, int amount, int[] coins, Dictionary<int, int> dp)
    {
        if (currentAmount > amount)
        {
            return -1;
        }
        
        if (currentAmount == amount)
        {
            return 1;
        }

        if (dp.ContainsKey(currentAmount))
        {
            return dp[currentAmount];
        }

        //           5
        //         5
        //       5 2 1      
        //       x  2  ^
        var minMoves = int.MaxValue;
        for (int i = 0; i < coins.Length; i++)
        {
            var moves = CalculateMoves(currentAmount + coins[i], amount, coins, dp);
            if (moves > 0)
            {
                minMoves = Math.Min(minMoves, moves + 1);
            }
        }

        dp.Add(currentAmount, minMoves == int.MaxValue ? 0 : minMoves);
        
        return minMoves == int.MaxValue ? 0 : minMoves;
    }
}