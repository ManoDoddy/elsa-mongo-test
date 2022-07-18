using Elsa.Activities.Console;
using Elsa.Activities.Temporal;
using Elsa.Builders;

namespace elsa_mongo_test.Workflows;

public class TimeBasedWorkflow : IWorkflow
{
    public void Build(IWorkflowBuilder builder)
    {
        builder
            .Timer(NodaTime.Duration.FromSeconds(25))
            .WriteLine("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam id.");
    }
}
