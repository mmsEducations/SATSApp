using MassTransit;
using SATSApp.Business.Queues.EventModels;

namespace SATSApp.Business.Queues.Consumers
{
    public class CreateStudentCommandConsumer : IConsumer<CreateStudentCommandEventModel>
    {
        public Task Consume(ConsumeContext<CreateStudentCommandEventModel> context)
        {
            var message = context.Message;
            Console.WriteLine($"{DateTime.Now} tarihinde {message.FirstName + " " + message.LastName} verisi gelmiştir");

            return Task.CompletedTask;
        }
    }
}
