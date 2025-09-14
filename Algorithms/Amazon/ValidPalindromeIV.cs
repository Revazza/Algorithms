namespace Algorithms.Amazon;

public class ValidPalindromeIV
{
    public bool MakePalindrome(string str) {

        var missmatch = 0;
        var left = 0;
        var right = str.Length - 1;

        while(left < right){

            if(str[left] != str[right]){
                missmatch++;
                if(missmatch > 2){
                    return false;
                }
            }

            left++;
            right--;
        }

        return missmatch <= 2;
    }
}