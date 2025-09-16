namespace Algorithms.Amazon;

public class MaximumUnitsOnTruck
{
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        Array.Sort(boxTypes, (a, b) => b[1].CompareTo(a[1]));
        
        var totalUnits = 0;
        var remaining = truckSize;
        foreach (var box in boxTypes) {
            if (remaining == 0){
                break;
            }

            var take = Math.Min(box[0], remaining);
            totalUnits += take * box[1];
            remaining -= take;
        }

        return totalUnits;
        
    }
}