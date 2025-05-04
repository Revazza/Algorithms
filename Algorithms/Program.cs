using Algorithms.Extensions;

CanCompleteCircuit([1,2,3,4,5],[3,4,5,1,2]).Dump();
// CanCompleteCircuit([2,3,4],[3,4,3]).Dump();


int CanCompleteCircuit(int[] gas, int[] cost) {
    for(int i = 0;i < gas.Length; i++){
        var currGas = gas[i];

        if(currGas < cost[i]){
            continue;
        }
        var station = i == gas.Length - 1 ? 0 : i + 1;

        while(true) {
            
            if(currGas < cost[station]){
                break;
            }
                
            currGas = currGas - cost[station] + gas[station];

            if(station == i){
                return i;
            }
            
            station++;

            if(station >= gas.Length){
                station = 0;
            }
        }
            
    }

    return -1;
}