using Algorithms.Extensions;

namespace Algorithms;

public class PlayGround
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        
        var dict = new Dictionary<int,int>();

        for(int i = 0; i < nums2.Length;i++){
            dict[nums2[i]] = i;
        }

        var ans = new int[nums1.Length];
        for(int i = 0;i < nums1.Length; i++){
            var key = nums1[i];
            var val = -1;

            for(int k = dict[key];k < nums2.Length;k++){
                if(nums2[k] > key){
                    val = nums2[k];
                    break;
                }
            }
            
            ans[i] = val;

        }

        return ans;
    }
    
    
    
}