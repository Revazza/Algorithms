namespace Algorithms.Amazon;

public class FindTriangularSumOfAnArray
{
    public int TriangularSum(int[] nums) {
        var current = 0;
        var counter = nums.Length - 1;

        while(counter != 0){

            for(int i = 0; i < nums.Length - current - 1; i ++){
                nums[i] = (nums[i] + nums[i + 1]) % 10;
            }

            current++;
            counter--;
        }

        return nums[0];
    } 
}