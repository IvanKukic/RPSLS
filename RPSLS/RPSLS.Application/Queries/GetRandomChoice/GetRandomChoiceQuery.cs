using MediatR;
using RPSLS.Domain.Entities;

namespace RPSLS.Application.Queries.GetRandomChoice;
public record GetRandomChoiceQuery : IRequest<Handsign>;
