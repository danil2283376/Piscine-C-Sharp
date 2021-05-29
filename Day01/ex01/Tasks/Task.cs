using TaskType;
using TaskPriority;
using TaskState;

namespace Task
{
    class Task1
    {
        private string title;
        private string summary;
        private Type type;
        private Priority priority;
        private System.DateTime dueDate;
        private TaskState.TaskState taskState;

        public string typeString;
        public string priorityString;
        public string stateString;
        public string dateString;
        public bool error;
        public Task1()
        {
            
        }
        public Task1(string title, string summary, Type type, Priority priority, System.DateTime dueDate)
        {
            this.title = title;
            this.summary = summary;
            this.type = type;
            this.priority = priority;
            this.dueDate = dueDate;
            this.taskState = TaskState.TaskState.New;
            this.stateString = "New";
        }

        public string GetTitle()
        {
            return (this.title);
        }
        public string GetSummary()
        {
            return (this.summary);
        }
        public Type GetType()
        {
            return (this.type);
        }
        public Priority GetPriority() 
        {
            return (this.priority);
        }
        public System.DateTime GetDueDate()
        {
            return (this.dueDate);
        }

        public void SetValue(string title, string summary, Type type, Priority priority, System.DateTime dueDate)
        {
            this.title = title;
            this.summary = summary;
            this.type = type;
            this.priority = priority;
            this.dueDate = dueDate;
        }
        
        public void SetTypeString(string typeWork)
        {
            this.typeString = typeWork;
        }
        public void SetPriorityString(Priority priority)
        {
            this.priority = priority;
        }

        public void SetStateTask(string stateString, TaskState.TaskState taskState)
        {
            this.stateString = stateString;
            this.taskState = taskState;
        }
    }
}
