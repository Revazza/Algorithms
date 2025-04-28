namespace Algorithms.Leetcode.Arrays;

public class HouseRobber
{
    public int Rob(int[] nums) {
        
        var dp = new Dictionary<int,int>();
        return RobHouses(0, 0, nums, dp);
    }

    private int RobHouses(int k, int amount, int[] nums, Dictionary<int,int> dp){
        if(k >= nums.Length){
            return amount;
        }

        if(dp.ContainsKey(k)){
            return dp[k];
        }

        var max = 0;
        for(int i = k;i < nums.Length; i++){
            var total = RobHouses(i + 2, amount + nums[i], nums, dp);
            max = Math.Max(max, total);
            if(!dp.ContainsKey(i)){
                dp[i] = max;
            }
        }

        return max;
    }
}