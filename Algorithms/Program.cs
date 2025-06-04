using Algorithms.DataStructures.Strings;
using Algorithms.Extensions;

NextClosestTime("19:34").Dump();

string NextClosestTime(string time) {
    var split = time.Split(":");
    var strHours = split.First();
    var strMinutes = split.Last();
    var digits = (strHours + strMinutes).Select(d => int.Parse(d.ToString())).ToHashSet();        
        
    var hours = int.Parse(strHours);
    var minutes = int.Parse(strMinutes);
        
    while(true){
            
        minutes++;
            
        if(minutes == 60){
            minutes = 0;
            hours++;
        }
            
        if(hours == 24){
            hours = 0;
            minutes = 0;
        }

        var newTimeDigits = (hours.ToString("D2") + minutes.ToString("D2")).Select(c => int.Parse(c.ToString()));
        if (newTimeDigits.All(d => digits.Contains(d))) {
            return $"{hours:D2}:{minutes:D2}";
        }
    }
        
    return "";
}



