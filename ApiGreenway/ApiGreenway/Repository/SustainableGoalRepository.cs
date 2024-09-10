using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class SustainableGoalRepository : ISustainableGoalRepository
{
    public Task<SustainableGoal> AddSustainableGoal(SustainableGoal sustainableGoal)
    {
        throw new NotImplementedException();
    }

    public void DeleteSustainableGoal(int SustainableGoalId)
    {
        throw new NotImplementedException();
    }

    public Task<SustainableGoal> GetSustainableGoalById(int SustainableGoalId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SustainableGoal>> GetSustainableGoals()
    {
        throw new NotImplementedException();
    }

    public Task<SustainableGoal> UpdateSustainableGoal(SustainableGoal sustainableGoal)
    {
        throw new NotImplementedException();
    }
}
