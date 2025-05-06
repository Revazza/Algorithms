namespace Algorithms.Leetcode.Arrays;

public class MinSubArrayLen
{
    public int Solve(int target, int[] nums) {
        if(nums.Length == 1){
            return nums[0] >= target ? 1 : 0;
        }

        var ans = int.MaxValue;
        var left = 0;
        var right = 0;
        var sum = nums[left];

        while(left < nums.Length || right < nums.Length){
            if(sum >= target){
                ans = Math.Min(ans, right - left + 1);
            }

            if(sum >= target || right >= nums.Length){
                sum -= nums[left];
                left++;
            }
            else{
                right++;
                if(right == nums.Length){
                    continue;
                }
                sum += nums[right];
            }

        }

        return ans == int.MaxValue ? 0 : ans;
    }
}