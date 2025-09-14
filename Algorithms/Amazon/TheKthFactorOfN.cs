namespace Algorithms.Amazon;

public class TheKthFactorOfN
{
    public int KthFactor(int n, int k){
        var small = new List<int>();
        var large = new List<int>();
        
        for (int i = 1; i * i <= n; i++){
            if (n % i == 0){
                small.Add(i);
                if (i != n / i){
                    large.Add(n / i);
                }
            }
        }

        if(large.Count + small.Count < k){
            return - 1;
        }

        if(small.Count >= k){
            return small[k - 1];
        }

        k = k - small.Count;

        return large[^k];
    }
}