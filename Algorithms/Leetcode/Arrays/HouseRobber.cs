namespace Algorithms.Leetcode.Arrays;

public class HouseRobber
{
    public int Rob(int[] nums) {
        
        var dp = new Dictionary<int,int>();
        return RobHouses(0, nums, dp);
    }

    private int RobHouses(int k, int[] nums, Dictionary<int,int> dp){
        if(k >= nums.Length){
            return 0;
        }

        if(dp.ContainsKey(k)){
            return dp[k];
        }

        var max = 0;
        for(int i = k;i < nums.Length; i++){
            var total = RobHouses(i + 2, nums, dp) + nums[i];
            max = Math.Max(max, total);
        }

        if(!dp.ContainsKey(k)){
            dp[k] = max;
        }

        return max;
    }
}