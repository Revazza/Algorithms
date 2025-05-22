namespace Algorithms.Leetcode.Graphs;

public class CourseScheduleTwo
{
    public int[] FindOrder(int numCourses, int[][] pres)
    {
        // 0 - []
        // 1 - [0, 2]
        // 2 - [0]
        // 3 - [1, 2]

        var dict = new Dictionary<int, List<int>>();

        for (int i = 0; i < numCourses; i++)
        {
            dict.Add(i, new List<int>());
        }

        for (int i = 0; i < pres.Length; i++)
        {
            dict[pres[i][0]].Add(pres[i][1]);
        }

        var taken = new HashSet<int>();
        var visited = new HashSet<int>();

        foreach (var kvp in dict)
        {
            if (taken.Contains(kvp.Key))
            {
                continue;
            }

            if (!CanCompleteCourse(kvp.Key, dict, taken, visited))
            {
                return [];
            }
        }

        return taken.ToArray();
    }

    private bool CanCompleteCourse(
        int course,
        Dictionary<int, List<int>> pres,
        HashSet<int> taken,
        HashSet<int> visited)
    {
        if (taken.Contains(course))
        {
            return true;
        }

        if (visited.Contains(course))
        {
            return false;
        }

        visited.Add(course);

        foreach (var preCourse in pres[course])
        {
            if (!CanCompleteCourse(preCourse, pres, taken, visited))
            {
                return false;
            }
        }

        visited.Remove(course);
        taken.Add(course);
        return true;
    }
}