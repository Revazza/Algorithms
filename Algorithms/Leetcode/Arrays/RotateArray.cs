namespace Algorithms.Leetcode.Arrays;

public class RotateArray
{
    public void Rotate(int[] nums, int rotates) {
        if(rotates >= nums.Length){
            rotates = rotates % nums.Length;
        }

        RotateArraySolution(nums, rotates);
    }

    private void RotateArraySolution(int[] nums, int k){
        var queue = new Queue<int>(k);
        for(int i = nums.Length - 1;i >= nums.Length - k;i--){
            queue.Enqueue(nums[i]);
        }

        for(int i = nums.Length - 1;i >= k;i--){
            nums[i] = nums[i - k];
        }

        for(int i = k - 1;i >= 0;i --){
            nums[i] = queue.Dequeue();
        }
    }
}