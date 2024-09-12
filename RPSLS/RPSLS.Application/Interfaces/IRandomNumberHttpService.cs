namespace RPSLS.Application.Interfaces;

public interface IRandomNumberHttpService
{
	Task<int> GetRandomNumber();
}
