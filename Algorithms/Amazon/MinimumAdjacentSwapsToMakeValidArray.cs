namespace Algorithms.Amazon;

public class MinimumAdjacentSwapsToMakeValidArray
{
    public int MinimumSwaps(int[] nums) {
        var minIndex = 0;
        var maxIndex = 0;

        for(int i = 0;i < nums.Length; i++){
            if(nums[i] >= nums[maxIndex]){
                maxIndex = i;
            }

            if(nums[i] < nums[minIndex]){
                minIndex = i;
            }
        }

        var maxSwaps = nums.Length - maxIndex - 1;
        var minSwaps = minIndex;

        if(maxIndex < minIndex){
            minSwaps = minIndex - 1;
        }

        return maxSwaps + minSwaps;
    }
}