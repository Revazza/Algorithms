namespace Algorithms.Amazon;

public class FindGoodDaysToRobTheBank
{
    public IList<int> GoodDaysToRobBank(int[] security, int time) {

        var goodDays = new List<int>();
        var n = security.Length;

        var decreasing = new int[n];
        decreasing[0] = 0;

        for(int i = 1; i < n; i++){
            if(security[i - 1] >= security[i]){
                decreasing[i] = decreasing[i - 1] + 1;
                continue;
            }

            decreasing[i] = 0;
        }

        var increasing = new int[n];
        increasing[n - 1] = 0;

        for(int i = n - 2; i >= 0; i--){
            if(security[i] <= security[i + 1]){
                increasing[i] = increasing[i + 1] + 1;
                continue;
            }
            increasing[i] = 0;
        }

        for(int i = time; i < n - time; i++){
            if(decreasing[i] >= time && increasing[i] >= time){
                goodDays.Add(i);
            }
        }

        return goodDays;
    }
}