namespace Algorithms.Leetcode.Graphs;

public class CourseSchedule
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var courses = GenerateCourses(prerequisites);
        var visited = new HashSet<int>();
        var verified = new HashSet<int>();

        foreach (var course in courses.Keys)
        {
            if (verified.Contains(course))
            {
                continue;
            }
            if (!DFS(course, courses, visited, verified))
            {
                return false;
            }
        }

        return true;
    }

    private bool DFS(int course, Dictionary<int, List<int>> courses, HashSet<int> visited, HashSet<int> verified)
    {
        if (visited.Contains(course))
        {
            return false;
        }

        if (courses[course].Count == 0)
        {
            verified.Add(course);
            return true;
        }

        visited.Add(course);

        var pres = courses[course];
        foreach (var pre in pres)
        {
            if (!DFS(pre, courses, visited, verified))
            {
                return false;
            }
        }

        verified.Add(course);
        visited.Remove(course);

        return true;
    }

    private Dictionary<int, List<int>> GenerateCourses(int[][] prerequisites)
    {
        var courses = new Dictionary<int, List<int>>();

        for (int i = 0; i < prerequisites.Length; i++)
        {
            var course = prerequisites[i][0];
            var prerequisite = prerequisites[i][1];

            if (!courses.TryAdd(course, [prerequisite]))
            {
                courses[course].Add(prerequisite);
            }

            courses.TryAdd(prerequisite, []);
        }

        return courses;
    }
}