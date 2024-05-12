namespace zadanie4.zadanie4;

public interface IAssignmentService
{
    Task<bool> AddAssignment(Assignment dto);
}