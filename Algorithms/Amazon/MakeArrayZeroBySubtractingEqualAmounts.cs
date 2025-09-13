namespace Algorithms.Amazon;

public class MakeArrayZeroBySubtractingEqualAmounts
{
    public int MinimumOperations(int[] nums) {
        // var sub = 0;
        // sort array - 0, 1, 3, 5, 5
        // var sub = 1;
        // 0,1,3,5,5 - count 1
        // 0,1,3,5,5 - count 2
        
        Array.Sort(nums);
        var op = 0;
        var substracted = 0;
        for(int i = 0;i < nums.Length; i++){
            var current = nums[i] - substracted;

            if(current > 0){
                substracted += current;
                op++;
            }
        }

        return op;
    }
}