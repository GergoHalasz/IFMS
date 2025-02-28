using MediatR;

namespace Domain.Events
{
	public class InterventionCreatedEvent : INotification
	{
		public int InterventionId { get; }

		public InterventionCreatedEvent(int interventionId)
		{
			InterventionId = interventionId;
		}
	}
}
