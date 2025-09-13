namespace Algorithms.Amazon;

public class MaximumNumberOfRobotsWithinBudget
{
    public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget) {

        var low = 0;
        var high = 0;
        var maxChargeTime = 0;
        long  sumRunningCost = 0;

        var maxRobotsCount = 0;
        while(high < runningCosts.Length){
            var robotsCount = high - low + 1;
            maxChargeTime = Math.Max(maxChargeTime, chargeTimes[high]);
            sumRunningCost += runningCosts[high];
            var totalCost = maxChargeTime + robotsCount * sumRunningCost;
            
            while(totalCost > budget && low <= high){
                sumRunningCost -= runningCosts[low];
                low++;

                maxChargeTime = 0;

                for(int i = low; i <= high; i++){
                    maxChargeTime = Math.Max(maxChargeTime, chargeTimes[i]);
                }

                robotsCount = high - low + 1;
                totalCost = maxChargeTime + robotsCount * sumRunningCost;
            }

            maxRobotsCount = Math.Max(maxRobotsCount, robotsCount);
            high++;
        }

        return maxRobotsCount;
    }
}