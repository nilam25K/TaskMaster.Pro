using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Pro.Shared.Enums
{

    public enum TaskStatus 
    {   
        Open =1, 
        InProgress=2, 
        Done=3 
    }
    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }
    public enum UserRole 
    { Admin=1, Manager=2, Developer=3 }
}
