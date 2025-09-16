namespace Algorithms.Amazon;

public class SequentialDigits
{
    public IList<int> Solution(int low, int high) {
        var highest = "123456789";
        var firstNum = low.ToString()[0];
        var indexOfFirst = highest.IndexOf(firstNum);

        var result = new List<int>();

        for(int i = 0; i < highest.Length; i++){

            for(int k = i; k < highest.Length; k++){
                var sub = highest.Substring(i, k - i + 1);
                var num = int.Parse(sub);
                if(num >= low && num <= high){
                    result.Add(num);
                }
            }
        }

        result.Sort();
        return result;
    }
}