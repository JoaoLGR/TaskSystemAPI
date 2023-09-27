using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("A fazer")]
        todo = 1,
        [Description("Em andamento")]
        inProgress = 2,
        [Description("Concluído")]
        concluded = 3
    }
}
