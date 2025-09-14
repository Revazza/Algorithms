namespace Algorithms.Amazon;

public class MinimumSwapsToGroupAllOnesTogether
{
    public int MinSwaps(int[] data) {
        
        var windowSize = 0;

        for(int i = 0;i < data.Length; i++){
            if(data[i] == 1){
                windowSize++;
            }
        }

        if(windowSize == 1 || windowSize == 0){
            return 0;
        }

        var zerosCount = 0;
        var minSwaps = int.MaxValue;

        for(int i = 0; i < data.Length; i++){
            if(data[i] == 0){
                zerosCount++;
            }

            if(i < windowSize - 1){
                continue;
            }

            minSwaps = Math.Min(zerosCount, minSwaps);

            if(data[i - windowSize + 1] == 0){
                zerosCount--;
            }
        }

        return minSwaps;
    }
}