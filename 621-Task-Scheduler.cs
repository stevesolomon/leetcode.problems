// https://leetcode.com/problems/task-scheduler/description/

public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        
        if (tasks == null || tasks.Length == 0) {
            return 0;
        } else if (tasks.Length == 1) {
            return 1;
        }
        
        // First, let's build up a Dictionary of all the Tasks
        // we have to perform. Key = Task name, Value = # of these tasks.
        // For simplicity, we'll keep track of the total tasks as well.
        Dictionary<char, int> availableTasks = new Dictionary<char, int>();
        int totalTasks = 0;
        
        // When we schedule a task, we'll record a new Dictionary entry
        // detailing the timestamp that we can schedule another instance of this task.
        Dictionary<char, int> coolingTasks = new Dictionary<char, int>();        
        
        foreach (char task in tasks) {
            if (!availableTasks.ContainsKey(task)) {
                availableTasks.Add(task, 0);
            }
            
            // Add an entry to cooling tasks to ensure that we always have 
            // every unique task name here so we don't have to check later.
            // We'll ensure that all these tasks can execute immediately.
            if (!coolingTasks.ContainsKey(task)) {
                coolingTasks.Add(task, -1);
            }
            
            availableTasks[task]++;
            totalTasks++;
        }
        
        // Then, let's start to schedule tasks until there are none left.        
        int timestamp = 0;
        List<char> tasksThatCanRun = new List<char>();
        
        while (totalTasks > 0) {
            // Try to schedule a task that is not in cooldown.
            char taskToSchedule = char.MinValue;
            
            // First get all the tasks that are not in cooldown
            tasksThatCanRun.Clear();
            
            foreach (char key in coolingTasks.Keys) {
                if (coolingTasks[key] < timestamp && availableTasks.ContainsKey(key)) {
                    tasksThatCanRun.Add(key);
                }    
            }
            
            // Then let's execute the available task that has the most 
            // remaining tasks to execute.
            int maxTaskCount = int.MinValue;
            foreach (char task in tasksThatCanRun) {
                if (availableTasks[task] > maxTaskCount) {
                    maxTaskCount = availableTasks[task];
                    taskToSchedule = task;
                }
            }
            
            // If we found a task to execute...
            if (taskToSchedule != char.MinValue) {
                // Set the coolingTasks entry.
                coolingTasks[taskToSchedule] = timestamp + n;
                
                // Decrement the number of this task in availableTasks
                availableTasks[taskToSchedule]--;
                totalTasks--;
                
                if (availableTasks[taskToSchedule] == 0) {
                    availableTasks.Remove(taskToSchedule);
                }
            }
            
            timestamp++;
        }
        
        return timestamp;        
    }
}